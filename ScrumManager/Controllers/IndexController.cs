using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumManager.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
                return RedirectToAction("Index", "Member");

            return View();
        }


        [HttpPost]
        public JsonResult Register(User user)
        {
            UserManager userManager = new UserManager();

            UserManager.Status status = userManager.Register(user);


            return Json(status);

        }

        [HttpPost]
        public JsonResult Login(User user)
        {
            UserManager userManager = new UserManager();

            switch (userManager.Login(user))
            {
                case UserManager.Status.Success:
                    Session["userID"] = userManager.currentUser.UserId;
                    Session["userName"] = userManager.currentUser.Username;
                    return Json(UserManager.Status.Success);

                default:
                    return Json(UserManager.Status.Fail);
            }
        }
    }
}