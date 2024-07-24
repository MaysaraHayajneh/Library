using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	/// <summary>
	/// commidhskjhfks
	/// </summary>
	/// 

	//this new comment//
	public class  AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _user;

		public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> user)
		{
			_signInManager = signInManager;
			_user = user;
		}
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(Login loginVM,string ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginVM.UserName!, loginVM.Password!, loginVM.RememberMe!, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(ReturnUrl)&& Url.IsLocalUrl(ReturnUrl))
					{
						return Redirect(ReturnUrl);
					}else
					return RedirectToAction("Index", "Home");
				}
				ViewBag.HasAccount = false;
				ModelState.AddModelError("", "Invlalid login attempt");
				return View(loginVM);
			}
			return View(loginVM);
		}
		[AcceptVerbs("Get","Post")]
		//allow how are not authintecated not login
		[AllowAnonymous]
		public async Task<IActionResult> IsEmailUsed(string Email)
		{
			var result =await _user.FindByEmailAsync(Email);
			if (result == null)
			{
				return Json(true);
			}
			else
			{
				return Json($"this {Email} is already in used");
			}
		
		}
		[AllowAnonymous]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register(Register registerVM)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser()
				{
					FirstName = registerVM.FirstName,
					LastName = registerVM.LastName,
					Email = registerVM.Email,
					UserName = registerVM.Email,
					Address = registerVM.Address,

				};
				var result = await _user.CreateAsync(user, registerVM.Password!);
				if (result.Succeeded)
				{
					if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
					{
						return RedirectToAction("ListUsers", "Admin");
					}
					await _signInManager.SignInAsync(user, false); //false is session cookies ,Ture is persistent cookies
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(registerVM);
		}

		[HttpPost]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}

	

	}
}

