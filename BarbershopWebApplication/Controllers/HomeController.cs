using System;
using BarbershopWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BarbershopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(BarbershopRecordings barbershopRecordings) { 
            Repository.AddRecordings(barbershopRecordings);
            return View("Thanks", barbershopRecordings);
        }
        
        public ViewResult ListRecordings()
        {
            return View(Repository.Recordings.Where(r => r.WillAttend == true));
        }
    }
}