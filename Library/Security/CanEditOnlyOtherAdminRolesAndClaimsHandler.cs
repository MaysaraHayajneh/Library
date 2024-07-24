using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Library.Security
{
	public class CanEditOnlyOtherAdminRolesAndClaimsHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirment>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirment requirement)
		{
			var authFilterContext = context.Resource as AuthorizationFilterContext;
			if (authFilterContext == null)
			{
				return Task.CompletedTask;
			}

			string? LoggedInAdmin = context.User.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
			string? adminIsBeigEdited = authFilterContext.HttpContext.Request.Query["userId"];
			if(context.User.IsInRole("Admin")&&
			context.User.HasClaim(c=>c.Type== "Edit Role"&&c.Value=="true")&& adminIsBeigEdited.ToLower() != LoggedInAdmin.ToLower())
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
		}
	}
}
