using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Security.Claims;

namespace Library.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public AdminController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
		{
			this._roleManager = roleManager;
			this._userManager = userManager;
		}
		
		public IActionResult CreateRole()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> CreateRole(Role model)
		{
			if (ModelState.IsValid)
			{
				var IdentityRole = new IdentityRole()
				{
					Name = model.RoleName,

				};

				IdentityResult result = await _roleManager.CreateAsync(IdentityRole);

				if (result.Succeeded)
				{
					return RedirectToAction("ListRole", "Admin");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}
		public IActionResult ListRole()
		{
			var ListRoles = _roleManager.Roles;
			return View(ListRoles);
		}
		
		public async Task <IActionResult> EditRole(string Id)
		{
			if (Id == null)
			{
				return NotFound();
			}
			IdentityRole? role =await _roleManager.FindByIdAsync(Id);
			if (role == null)
			{
				ViewBag.Error = $"The Id {Id} is not found";
				return View("NotFound");
			}
			EditRole roleToEdit=new EditRole()
			{
				Id=role.Id,
				RoleName = role.Name,
			};
			var users=_userManager.Users;
			foreach (var user in users)
			{  
				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					roleToEdit.Users!.Add(user.UserName!);
				}
				
			}
			return View(roleToEdit);
		}

		[HttpPost]
	

		public async Task<ActionResult> EditRole(EditRole model)
		{
			if (ModelState.IsValid)
			{
				var Role = await _roleManager.FindByIdAsync(model.Id);
				if (Role == null)
				{
					ViewBag.Error = $"The Id {model.Id} is not found";
					return View("NotFound");
				}
				 Role.Name=model.RoleName;
				var result= await _roleManager.UpdateAsync(Role);
				if (result.Succeeded)
				{
					return RedirectToAction("ListRole");
				}
				foreach(var errors in result.Errors)
				{
					ModelState.AddModelError("", errors.Description);
				}
			}
			return View(model);
			
		}
		[Authorize(Policy = "DeletRolePolicy")]
		[HttpPost]
		public async Task<IActionResult> DeleteRole(string Id)
		{
			IdentityRole? role=await _roleManager.FindByIdAsync(Id);
			if(role == null)
			{
				ViewBag.Error = $"The role Id: {Id} is not found";
				return View ("NotFound");
			}
			IdentityResult result=await _roleManager.DeleteAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("ListRole");
			}
			else
			{
				foreach(var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return RedirectToAction("ListRole");
			}
		}
		public async Task<IActionResult> EditUsersInRole(string roleId)
		{
			ViewBag.RoleId = roleId;
			IdentityRole? role = await _roleManager.FindByIdAsync(roleId);
			if(role == null)
			{
				ViewBag.Error = $"The Id {role} is not found";
				return View("NotFound");
			}
			var users = _userManager.Users;
			var model = new List<UserRole>();
			foreach(var user in users)
			{
				UserRole userRole = new UserRole()
				{
					UserId = user.Id,
					UserName=user.UserName!,

				};
				if(await _userManager.IsInRoleAsync(user, role.Name!))
				{
					userRole.IsSelected = true;
				}
				else
				{
					userRole.IsSelected = false;
				}
				
				model.Add(userRole);
			}
			return View(model);

		}
		[HttpPost]
		public async Task<IActionResult> EditUsersInRole(List<UserRole> userRoles,string roleId)
		{
			IdentityRole? role = await _roleManager.FindByIdAsync(roleId);
			if(role == null)
			{
				ViewBag.Error = $"The Id: {roleId} is not found";
				return View("NotFound");
			}
			for (int i=0; i<userRoles.Count;i++)
			{
				ApplicationUser? user = await _userManager.FindByIdAsync(userRoles[i].UserId);
				
				if(user == null)
				{
					ViewBag.Error = $"The userId {userRoles[i].UserId} is not found";
					return View("NotFound");
				}
				IdentityResult? result = null;
				if (userRoles[i].IsSelected&&!(await _userManager.IsInRoleAsync(user,role.Name!)))
				{
					 result= await _userManager.AddToRoleAsync(user!, role.Name!);
				}
				else if(!userRoles[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name!))
				{
				    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					continue;
				}
				if (result.Succeeded)
				{
					if (i < (userRoles.Count - 1))
					{
						continue;
					}
					else return RedirectToAction("EditRole", new { Id = roleId });
				}
			}
			return RedirectToAction("EditRole", new { Id = roleId });
		}


		public IActionResult ListUsers()
		{
			var users=_userManager.Users;
			return View(users);	
		}

		public async Task<IActionResult> EditUser(string Id)
		{
			ApplicationUser? user= await _userManager.FindByIdAsync(Id);
			
			if (user == null)
			{
				ViewBag.Error=$"The user Id {Id} can not be found";
				return View("NotFound");
			}
			var roles = await _userManager.GetRolesAsync(user);
			var Claims= await _userManager.GetClaimsAsync(user);
			EditUser model = new EditUser()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				UserName = user.UserName,
				Address = user.Address,
				Roles = roles,
				Claims = Claims.Select(o => o.Type + " : " + o.Value  ).ToList(),
			};

			return View(model);
		}
		[HttpPost]
        public async Task<IActionResult> EditUser(EditUser model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByIdAsync(model.Id!);
				if (user == null)
				{
                    ViewBag.Error = $"The userId {model.Id} is not found";
                    return View("NotFound");
				}
				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.Email = model.Email;
				user.UserName = model.UserName;
				user.Address = model.Address;
				
				IdentityResult result= await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("ListUsers");
				}
				foreach(var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}
		[Authorize(Policy = "EditRolePolicy")]
		public async Task<IActionResult> ManageUserRoles(string Id)
		{
			ViewBag.UserId = Id;
			ApplicationUser? user = await _userManager.FindByIdAsync(Id);
			if (user == null)
			{
				ViewBag.Error = $"The user Id {Id} can not be found";
				return View("NotFound");
			}
			ViewBag.UserName = user.UserName;
			var model = new List<UserRoles>();
           foreach(var role in _roleManager.Roles)
			{
				var UserRoels = new UserRoles()
				{
					RoleId = role.Id,
					RoleName=role.Name!,
				};
				if(await _userManager.IsInRoleAsync(user, role.Name!))
				{
					UserRoels.IsSelected = true;
				}
				else
				{
					UserRoels.IsSelected = false;
				}
				model.Add(UserRoels);
			}
			return View(model);
        }
		[HttpPost]
		[Authorize(Policy = "EditRolePolicy")]
		public async Task<IActionResult> ManageUserRoles(List<UserRoles> model,string UserId)
		{
			ApplicationUser? User =await  _userManager.FindByIdAsync(UserId);
			if (User == null)
			{
				ViewBag.Error = $"The user Id {UserId} can not be found";
				return View("NotFound");
			}
			for(int i=0; i<model.Count;i++)
			{
				IdentityResult? result = null;
				if (model[i].IsSelected&&(!await _userManager.IsInRoleAsync(User, model[i].RoleName)))
				{
				 result = await _userManager.AddToRoleAsync(User, model[i].RoleName);
				}
				if(!model[i].IsSelected && (await _userManager.IsInRoleAsync(User, model[i].RoleName)))
				{
				 result = await _userManager.RemoveFromRoleAsync(User, model[i].RoleName);
				}
				else
				{
					continue;
				}
				if (result.Succeeded)
				{
					if (i < (model.Count - 1))
					{
						continue;
					}
					else return RedirectToAction("EditUser", new { Id = UserId });
				}
			}
			return RedirectToAction("EditUser", new { Id = UserId });
		}

		public async Task<IActionResult> ManageUserClaims(string UserId)
		{
			ApplicationUser? user = await _userManager.FindByIdAsync(UserId);
			if (user == null)
			{
				ViewBag.Error = $"The user Id {UserId} can not be found";
				return View("NotFound");
			}
			ViewBag.UserName=user.UserName;
			var existedUserClaims = await _userManager.GetClaimsAsync(user);
			var model = new UserClaims()
			{
				UserId = user.Id,
			};
			foreach (Claim claim in ClaimsStore.Claims)
			{
				ClaimProp claimProp = new ClaimProp()
				{
					ClaimType = claim.Type,

				};
				if (existedUserClaims.Any(o => o.Type == claim.Type&& o.Value=="true"))
				{
					claimProp.IsSelected = true;
				}
				else
				{
					claimProp.IsSelected = false;
				}
				model.Claims.Add(claimProp);
			}
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> ManageUserClaims(UserClaims model,string UserId)
		{
			ApplicationUser? user= await _userManager.FindByIdAsync(UserId);
			if (user == null)
			{
				ViewBag.Error = $"The user Id {UserId} can not be found";
				return View("NotFound");
			}
			var existedClaimsInuser = await _userManager.GetClaimsAsync(user);
			var result = await _userManager.RemoveClaimsAsync(user, existedClaimsInuser);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Cant remove the user existed claim");
				return View(model);
			}

			result = await _userManager.AddClaimsAsync(user, model.Claims
				.Select(c => new Claim(c.ClaimType, c.IsSelected?"true":"false")));
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "can not added selected claims to the user");
				return View(model);
			}
			else
			{
				return RedirectToAction("EditUser",new { Id = model.UserId});
			}

		}

			[HttpPost]
	    public async Task<IActionResult> DeleteUser(string Id)
		{
			ApplicationUser? user =await _userManager.FindByIdAsync(Id);
			if (user == null)
			{
                ViewBag.Error = $"The userId {Id} is not found";
                return View("NotFound");
            }
			IdentityResult result=await _userManager.DeleteAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("ListUsers");
			}
			foreach(var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
				
			}
			return View("ListUsers");			
		}

    }
}
