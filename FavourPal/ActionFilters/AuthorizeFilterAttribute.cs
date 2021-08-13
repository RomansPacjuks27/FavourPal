using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
//using Jumis.Domain.HR.UserToken;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using FavourPal.Domain.Interfaces;
using FavourPal.Domain.Models;

namespace FavourPal.ActionFilter
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public AuthorizeFilterAttribute()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var companyMasterService = context.HttpContext.RequestServices.GetService<HR.Domain.Interfaces.Services.ICompanyMasterService>();
            var actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var actionAttributes = actionDescriptor.MethodInfo.GetCustomAttributes(true);
            var controllerAttributes = context.Controller.GetType().GetCustomAttributes(true);

            if (actionAttributes.Any(x => x is AllowAnonymousAttribute))
            {
                base.OnActionExecuting(context);
                return;
            }
            if (context.Controller is IUserContextable)
            {
                SetAuthorizedUserFromJwtToken(context);
            }
            base.OnActionExecuting(context);
        }

        private static void SetAuthorizedUserFromJwtToken(ActionExecutingContext context)
        {
            var identity = context.HttpContext.User.Identities.FirstOrDefault();
            if (identity != null && identity.Claims != null && identity.Claims.Count() > 0)
            {
                //var companyUuid = identity.Claims.FirstOrDefault(c => c.Type == "company_uuid").Value;
                //var companyId = 0;
                //if (companyMasterService.ExistsCompanyWithMasterUuid(companyUuid))
                    //companyId = companyMasterService.GetCompanyIdByMasterCompanyUuid(companyUuid);
                //var companyId = identity.Claims.FirstOrDefault(c => c.Type == "company_id").Value ?? "0";
                var Id = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier) != null ?
                    identity.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value : null;
                //var employeeUuid = identity.Claims.FirstOrDefault(c => c.Type == "employee_uuid") != null ?
                      //identity.Claims.First(c => c.Type == "employee_uuid").Value : null;
                var email = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                var firstName = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? "Nav norādīts";
                var lastName = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value ?? "Nav norādīts";
                var companyName = identity.Claims.FirstOrDefault(c => c.Type == "company_name")?.Value ?? "Nav norādīts";
                ((IUserContextable)context.Controller).AuthorizedUser = new User()
                {
                    //SelectedCompany = companyId,
                    //SelectedCompanyUuid = companyUuid,
                    //EmployeeId = !string.IsNullOrEmpty(employeeId) ? int.Parse(employeeId) : (int?)null,
                    //EmployeeUuid = employeeUuid,
                    Id = Id,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    //Roles = identity.Claims
                        //.Where(x => x.Type == ClaimTypes.Role && !string.IsNullOrEmpty(x.Value))
                            //.Select(x => x.Value).ToList(),
                    //CompanyName = companyName
                };
            }
        }
    }

    public class AuthorizeFilterProjectManagerWhitelistAttribute : Attribute
    {

    }

    public class AuthorizeFilterValidityExceptionAttribute : Attribute
    {

    }

    public class AuthorizeFilterLicenceExceptionAttribute : Attribute
    {

    }
}
