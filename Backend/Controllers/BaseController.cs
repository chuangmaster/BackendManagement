using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backend.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ResponseModelStateValidation()
        {
            if (ModelState.Values.Count > 0)
            {
                var errors = ModelState.Values.ToList().SelectMany(x => x.Errors);
                TempData["Messages"] = "參數有誤";
            }
            return Redirect(Request.Url.ToString());
        }
    }
}