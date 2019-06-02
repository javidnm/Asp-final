
using AspFinal.AppCode.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspFinal
{
    public class CvAuthorizationAttribute : AuthorizeAttribute

    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
               || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (filterContext.HttpContext.Session[SessionKey.Admin] == null)
                filterContext.Result = new RedirectResult("Login");
        }


    }
}