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
        public ViewResult OnlineRecording(int? id)
        {
            if (id.HasValue)
            {
                var recording = _context.Recordings.Include(r => r.Barber).Include(r => r.Service)
                                                  .FirstOrDefault(r => r.RecordingId == id.Value);
                if (recording != null)
                {
                    ViewBag.Barbers = new SelectList(_context.Barbers, "BarberId", "Name", recording.BarberId);
                    ViewBag.Services = _context.Services.Select(s => new SelectListItem
                    {
                        Value = s.ServiceId.ToString(),
                        Text = $"{s.Title} - {s.Price} руб"
                    }).ToList();
                    return View(recording);
                }
            }

            ViewBag.Barbers = new SelectList(_context.Barbers, "BarberId", "Name");
            ViewBag.Services = _context.Services.Select(s => new SelectListItem
            {
                Value = s.ServiceId.ToString(),
                Text = $"{s.Title} - {s.Price} руб"
            }).ToList();
            return View(new Recording());
        }

        [HttpPost]
        public IActionResult OnlineRecording(Recording recording)
        {
            if (ModelState.IsValid)
            {
                // Сначала преобразуем время из формы в UTC
                recording.Time = DateTime.SpecifyKind(recording.Time, DateTimeKind.Utc);

                if (recording.RecordingId == 0)
                {
                    // Добавление новой записи
                    _context.Recordings.Add(recording);
                }
                else
                {
                    // Обновление существующей записи
                    var existingRecording = _context.Recordings.Find(recording.RecordingId);
                    if (existingRecording != null)
                    {
                        // Копирование значений из recording в existingRecording, кроме ID
                        existingRecording.Name = recording.Name;
                        existingRecording.Email = recording.Email;
                        existingRecording.Phone = recording.Phone;
                        existingRecording.BarberId = recording.BarberId;
                        existingRecording.ServiceId = recording.ServiceId;
                        existingRecording.Time = recording.Time; // Время уже преобразовано в UTC выше
                                                                 // Остальные поля по необходимости
                    }
                }

                _context.SaveChanges();
                return RedirectToAction("Thanks", new { id = recording.RecordingId });
            }

            // Если форма не валидна, показать её снова
            ViewBag.Barbers = new SelectList(_context.Barbers, "BarberId", "Name", recording.BarberId);
            ViewBag.Services = new SelectList(_context.Services.Select(s => new SelectListItem
            {
                Value = s.ServiceId.ToString(),
                Text = $"{s.Title} - {s.Price} руб"
            }), "Value", "Text", recording.ServiceId);

            return View(recording);
        }

        public IActionResult Thanks(int id)
        {
            var recording = _context.Recordings.Include(r => r.Barber).Include(r => r.Service)
                                              .FirstOrDefault(r => r.RecordingId == id);
            if (recording == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ServicePrice = recording.Service?.Price;
            return View(recording);
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