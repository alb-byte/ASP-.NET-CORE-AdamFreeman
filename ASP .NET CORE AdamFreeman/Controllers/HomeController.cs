using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_.NET_CORE_AdamFreeman.Models;

namespace ASP_.NET_CORE_AdamFreeman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IRepository Repository = MyRepository.SharedRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public HomeController()
        {

        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Message = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                return View("Thanks", response);
            }
            else
            {
                return View();
            }

        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
