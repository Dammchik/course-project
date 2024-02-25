using System;
using BarbershopWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
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
        public ViewResult RsvpForm()
        {
            return View();
        }
    }
}