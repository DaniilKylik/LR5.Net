using Microsoft.AspNetCore.Mvc;
using Lr5.Net.Models;
using Lr5.Net.Services;

namespace Lr5.Net.Controllers
{
    public class CookiesController : Controller
    {
		private readonly CookieService _cookieService;

		public CookiesController(CookieService cookieService)
		{
			_cookieService = cookieService;
		}

		public IActionResult CreateCookie()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateCookie(CookieData data)
		{
			_cookieService.SetCookie("UserValue", data.Value, data.ExpirationDate);

			return RedirectToAction("CheckCookie");
		}

		public IActionResult CheckCookie()
		{
			string cookieValue = _cookieService.GetCookie("UserValue");

			if (cookieValue != null)
			{
				ViewBag.Message = $"Cookie found: {cookieValue}";
			}
			else
			{
				ViewBag.Message = "Cookie not found";
			}

			return View();
		}
    }
}
