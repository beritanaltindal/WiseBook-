using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WiseBook.Admin.UI.Models;
using WiseBook.Admin.UI.Service;

namespace WiseBook.Admin.UI.Controllers
{
    public class AccountController : Controller
    {
     
        [HttpPost]

        public ActionResult SignIn(SignInVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (DataService.Service
                    .UserService
                    .CheckCredentials(credentials.Email, credentials.Password))
                {
                    var currentUser = DataService.Service
                        .UserService
                        .FindByEmail(credentials.Email);

                    string cookie = $"{currentUser.Id}-{currentUser.Role}-{currentUser.Name} {currentUser.Lastname}";

                    if (cookie.Split('-')[1]=="admin")
                    {
                        Session["AdminName"] = cookie.Split('-')[2];

                        return RedirectToRoute("AdminPanel");
                       
                    }
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    

                }

            }

            return Redirect("/");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/home/index");
        }
     
    }
}