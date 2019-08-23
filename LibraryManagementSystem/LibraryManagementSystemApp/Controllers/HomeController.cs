using LibraryManagementSystem.BLL.Manager;
using LibraryManagementSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystemApp.Controllers
{
    public class HomeController : Controller
    {
        UserManager _userManager = new UserManager();
        StudentManager _studentManager = new StudentManager(); 
       

        public ActionResult Student()
        {
            if (Session["Student"] != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            Session["Student"] = null;
            Session["admin"] = null;
            return View();
        }
        [HttpPost,ActionName("Login")]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {

                bool isAuth = _userManager.AuthUser(user);
                if(isAuth)
                {
                    if (user.UserName.ToLower() == "admin")
                    {
                        Session["admin"] = user.UserName;
                        return RedirectToAction("Show", "Book");
                    }
                    else
                    {
                        Session["Student"] = _studentManager.GetByUsername(user.UserName);
                        return RedirectToAction("Current","Student");
                    }
                }
                else
                {
                    ViewBag.FMsg = "Username Or Passwaord Does not match.";
                    return View(user);
                }


            }

            return View(user);
        }
         

    }
}