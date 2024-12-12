using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Security;
using ProjectForVendista.Controllers;
using ProjectForVendista.Models;
using ProjectForVendista.Models.Auth;
using ProjectForVendista.Models.Auth.FormModel;
using ProjectForVendista.Models.ModelsContext;

namespace ProjectForVendista.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(LoginModel model) 
        {
            if (model == null)
                return View(model);
            else
            {
             
                    User user = null;
                    using (Context db = new Context())
                    {
                        user = db.users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);

                            return RedirectToAction("Index", "Command");
                        }
                        else
                        {
                            return View(model);
                        }
                    }
         
            }
        }
        public ActionResult Register(RegistrationModel model)
        {
            if(model == null) return View();
      
                using (Context db = new Context()) 
                {
                    var user = db.users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
                    if(user == null)
                    {
                        db.users.Add(new User
                        {
                            Name = model.Name,
                            Password = model.Password,
                        });
                        db.SaveChanges();
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Command");
                    }
                    else
                    {
                        return View();
                    }
                }

            
        }
    }
}