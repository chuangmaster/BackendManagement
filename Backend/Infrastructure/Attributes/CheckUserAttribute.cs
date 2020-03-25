using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Backend.Infrastructure.Consts;
using Backend.Infrastructure.Process;
using Repository.Dapper;
using Repository.Dapper.Helpers;
using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using Repository.Dapper.Models;

namespace Backend.Infrastructure.Attributes
{
    public class CheckUserAttribute : ActionFilterAttribute
    {
        private IDatabaseHelper _DatabaseHelper;
        private IMemberRepository _MemberRepository;
        public CheckUserAttribute()
        {
            var conStr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            _DatabaseHelper = new DatabaseHelper(conStr);
            _MemberRepository = new MemberRepository(_DatabaseHelper);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // member model
            var member = filterContext.HttpContext.Session[ApplicationConst.LoginSessionKey];
            if (member == null)
            {
                //表示Session消失
                var identity = filterContext.HttpContext.User.Identity as FormsIdentity;
                if (identity != null && identity.IsAuthenticated)
                {
                    if (!identity.Ticket.Expired)
                    {
                        var memberData = identity.Ticket.UserData;
                        member = _MemberRepository.Get().FirstOrDefault(x => x.Account == memberData);
                        filterContext.HttpContext.Session[ApplicationConst.LoginSessionKey] = member;
                    }
                }
            }

            if (member != null)
            {
                filterContext.Controller.ViewBag.Member = member;
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login");
            }

        }
    }
}