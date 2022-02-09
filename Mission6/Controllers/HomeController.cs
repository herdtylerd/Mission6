using Microsoft.AspNetCore.Mvc;
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
            var applications = tContext.responses.ToList();
            return View(applications);
        }

        // Add tasks
        [HttpGet]
        public IActionResult AddTask()
        {
            var categories = tContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(AddTask at)
        {
            tContext.Add(at);
            tContext.SaveChanges();
            return View();
        }

    }
}
