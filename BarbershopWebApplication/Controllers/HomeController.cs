using System;
using BarbershopWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarbershopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private BarbershopContext _context;

        public HomeController(BarbershopContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Добрый день";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult OnlineRecording()
        {
            ViewBag.Barbers = new SelectList(_context.Barbers, "BarberId", "Name");
            ViewBag.Services = _context.Services.Select(s => new SelectListItem
            {
                Value = s.ServiceId.ToString(),
                Text = $"{s.Title} - {s.Price} руб"
            }).ToList();

            return View(new Recording()); // Возвращаем новую модель для формы
        }
        [HttpPost]
        public ViewResult OnlineRecording(Recording barbershopRecording) { 
            if (ModelState.IsValid) {
                barbershopRecording.Barber = _context.Barbers.FirstOrDefault(b => b.BarberId == barbershopRecording.BarberId);
                barbershopRecording.Service = _context.Services.FirstOrDefault(s => s.ServiceId == barbershopRecording.ServiceId);
                barbershopRecording.Time = DateTime.SpecifyKind(barbershopRecording.Time, DateTimeKind.Utc);

                _context.Recordings.Add(barbershopRecording);
                _context.SaveChanges();

                ViewBag.ServicePrice = barbershopRecording.Service?.Price;

                return View("Thanks", barbershopRecording);
            }
            else
            {
                ViewBag.Barbers = new SelectList(_context.Barbers, "BarberId", "Name");
                ViewBag.Services = _context.Services.Select(s => new SelectListItem
                {
                    Value = s.ServiceId.ToString(),
                    Text = $"{s.Title} - {s.Price} руб"
                }).ToList();

                return View(barbershopRecording);
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

        /*[HttpGet]
        public ViewResult Barbers()
        {
            return View();
        }*/

        [HttpGet]
        public ViewResult Contacts()
        {
            return View();
        }
    }
}