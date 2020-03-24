using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Backend.Infrastructure.Consts;
using Backend.Infrastructure.Profiles;
using Repository.Dapper.Helpers;
using Repository.Dapper.Helpers.Interfaces;

namespace Backend.Controllers
{
    public class BaseController : Controller
    {
        protected IMapper _Mapper;
        protected IDatabaseHelper _DatabaseHelper;
        public BaseController()
        {
            var conStr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            _DatabaseHelper = new DatabaseHelper(conStr);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountProfile>();
            });
            _Mapper = config.CreateMapper();
        }
        public ActionResult ResponseModelStateValidation()
        {
            if (ModelState.Values.Count > 0)
            {
                var errors = ModelState.Values.ToList().SelectMany(x => x.Errors);
                TempData[ApplicationConst.MessageKey] = "參數有誤";
            }
            return Redirect(Request.Url.ToString());
        }
    }
}