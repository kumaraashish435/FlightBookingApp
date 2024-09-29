using Microsoft.AspNetCore.Mvc;
using FlightBookingApp.Data.Context;
using FlightBookingApp.Data.Models;

namespace FlightBookingApp.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        public IActionResult Index()
        {
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }
    }
}