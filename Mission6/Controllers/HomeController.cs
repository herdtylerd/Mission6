using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext tContext { get; set; }

        public HomeController(TaskContext someName)
        {
            tContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuadrantsView()
        {
            var tasks = tContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        } 



        // Add tasks
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = tContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(AddTask at)
        {
            if (ModelState.IsValid)
            {
                // Viewbag
                tContext.Add(at);
                tContext.SaveChanges();
                return RedirectToAction("QuadrantsView");
            }
            else
            {
                // Viewbag
                return View();
            }            
        }

        [HttpGet]
        public IActionResult EditTask(int taskId)
        {
            // Viewbag

            var task = tContext.Responses
                .Single(x => x.TaskId == taskId);

            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult EditTask(AddTask t)
        {
            tContext.Update(t);
            tContext.SaveChanges();

            return RedirectToAction("QuadrantsView");
        }

        [HttpGet]
        public IActionResult Delete(int taskId)
        {
            var task = tContext.Responses
                .Single(x => x.TaskId == taskId);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(AddTask t)
        {
            tContext.Responses.Remove(t);
            tContext.SaveChanges();

            return RedirectToAction("QuadrantsView");
        }

    }
}
