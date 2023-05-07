using Mel_TPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace Mel_TPI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Fees()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public ActionResult contactForm(string name, string email, string message)
		{
			ViewBag.Name = name;
			ViewBag.Email = email;
			ViewBag.Message = message;

			return View("Contact");
		}
		[HttpPost]
		public ActionResult booking(string name, string email, string phone, string address, string suburb, string city, string zip, string level, string lesson)
		{
			ViewBag.Name = name;
			ViewBag.Email = email;
			ViewBag.Phone = phone;
			ViewBag.Address = address;
			ViewBag.Suburb = suburb;
			ViewBag.City = city;
			ViewBag.Zip = zip;
			ViewBag.Level = level;
			ViewBag.Lesson = lesson;

			return View("Index");
		}
	}
}