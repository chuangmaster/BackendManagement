using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult DoLogin()
        {
            return View();
        }

        [HttpPost]
        [Route("~/Sign")]
        public ActionResult SignUp()
        {
            return View();
        }
    }
}