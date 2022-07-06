using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectForVendista.Controllers;
using ProjectForVendista.Models;
using ProjectForVendista.Models.Auth;
using ProjectForVendista.Models.Auth.Context;
using ProjectForVendista.Models.Auth.FormModel;
namespace ProjectForVendista.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) 
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using(UserContext db = new UserContext()) 
                {
                    user = db.users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                    if (user!=null) 
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                     
                        return RedirectToAction("Index", "Command");
                    }
                    else
                    {
                        ModelState.AddModelError("444", "Not login");
                    }
                }
            }
            return View();
        }
    }
}