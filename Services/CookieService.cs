using Microsoft.AspNetCore.Http;
using System;

namespace Lr5.Net.Services
{
	public class CookieService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CookieService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public void SetCookie(string key, string value, DateTime expirationDate)
		{
			CookieOptions options = new CookieOptions
			{
				Expires = expirationDate
			};

			_httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
		}

		public string GetCookie(string key)
		{
			return _httpContextAccessor.HttpContext.Request.Cookies[key];
		}
	}
}
