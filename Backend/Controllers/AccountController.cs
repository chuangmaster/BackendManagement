using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backend.Models;
using Backend.Models.Parameters;

namespace Backend.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [Route("~/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("~/Login")]
        public ActionResult DoLogin(LoginParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return ResponseModelStateValidation();
            }
            if (true)
            {
                return Redirect("home");

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [Route("~/Signup")]
        public ActionResult SignUp(SignUpParameter parameter)
        {

            if (true)
            {
                return Redirect("~/Login#signup");

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}