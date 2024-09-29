using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApp.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
