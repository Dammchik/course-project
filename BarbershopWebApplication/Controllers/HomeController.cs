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
            ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Добрый день";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult OnlineRecording()
        {
            return View();
        }
        [HttpPost]
        public ViewResult OnlineRecording(BarbershopRecordings barbershopRecordings) { 
            if (ModelState.IsValid) {
                Repository.AddRecordings(barbershopRecordings);
                return View("Thanks", barbershopRecordings);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ViewResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Services()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Barbers()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contacts()
        {
            return View();
        }

        public ViewResult ListRecordings()
        {
            return View(Repository.Recordings.Where(r => r.WillAttend == true));
        }
    }
}