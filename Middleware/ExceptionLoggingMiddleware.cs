using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Lr5.Net.Services;

namespace Lr5.Net.Middleware
{
	public class ExceptionLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly LoggingService _loggingService;

		public ExceptionLoggingMiddleware(RequestDelegate next, LoggingService loggingService)
		{
			_next = next;
			_loggingService = loggingService;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await _loggingService.LogExceptionAsync(ex);
				throw;
			}
		}
	}
}
