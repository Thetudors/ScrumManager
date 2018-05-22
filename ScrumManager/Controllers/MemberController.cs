using BusinessLayer;
using DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumManager.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Index", "Index");
            
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;

            return RedirectToAction("Index", "Index");
        }

        public JsonResult AddTask(Task task)
        {
            TaskManager taskManager = new TaskManager();

            switch (taskManager.AddTask(task))
            {
                case Manager.Status.Success:

                    return Json(new { status = Manager.Status.Success, Task = taskManager.currentTask });
                default:
                    return Json(new { status = Manager.Status.Fail });
            }
        }

        public JsonResult UpdateTask(int Task_Id, int TaskStatus)
        {
            TaskManager taskManager = new TaskManager();

            switch (taskManager.UpdateStatus(Task_Id, TaskStatus))
            {
                case Manager.Status.Success:
                    return Json(new { status = Manager.Status.Success, Task = taskManager.currentTask });

                default:
                    return Json(new { status = Manager.Status.Fail });
            }
        }

        public JsonResult RemoveTask(int TaskId)
        {
            TaskManager taskManager = new TaskManager();

            switch (taskManager.RemoveTask(TaskId))
            {
                case Manager.Status.Success:
                    return Json(new { status = Manager.Status.Success });

                default:
                    return Json(new { status = Manager.Status.Fail });
            }
        }


        public JsonResult AddStory(Story story)
        {
            StoryManager storyManager = new StoryManager();

            switch (storyManager.AddStory(story))
            {
                case Manager.Status.Success:
                    return Json(new { status = Manager.Status.Success,Story = storyManager.currentStory});

                default:
                    return Json(new { status = Manager.Status.Fail } );
            }

        }

        [HttpPost]
        public JsonResult GetUsers()
        {
            UserManager userManager = new UserManager();

            IEnumerable s = userManager.GetUsers();

            return Json(s);
        }
        [HttpPost]
        public JsonResult GetTask()
        {
            TaskManager taskManager = new TaskManager();

            IEnumerable s = taskManager.GetTasks();

            return Json(s);
        }



        [HttpPost]
        public JsonResult GetStories()
        {
            StoryManager storyManager = new StoryManager();

            IEnumerable list = storyManager.GetStories();

            return Json(list);
        }




    }


}