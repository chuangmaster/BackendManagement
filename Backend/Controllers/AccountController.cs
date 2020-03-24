using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Backend.Infrastructure.Consts;
using Backend.Infrastructure.Process;
using Backend.Models;
using Backend.Models.Parameters;

namespace Backend.Controllers
{
    public class AccountController : BaseController
    {
        private AccountProcess _AccountProcess;
        public AccountController()
        {
            _AccountProcess = new AccountProcess(_DatabaseHelper);
        }
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
            var loginResult = _AccountProcess.DoLogin(parameter);
            if (loginResult.Result)
            {
                return Redirect("home");
            }
            else
            {
                TempData[ApplicationConst.MessageKey] = loginResult.Message;
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [Route("~/Signup")]
        public ActionResult SignUp(SignUpParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return ResponseModelStateValidation();
            }
            
            var rptResult = _AccountProcess.DoSignUp(parameter);

            if (rptResult.Result)
            {
                TempData[ApplicationConst.MessageKey] = rptResult.Message;
                return RedirectToAction("Login");
            }
            else
            {
                TempData[ApplicationConst.MessageKey] = rptResult.Message;
                return Redirect("~/Login#signup");
            }
        }
    }
}