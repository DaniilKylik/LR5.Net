using System;
using System.IO;
using System.Threading.Tasks;

namespace Lr5.Net.Services
{
	public class LoggingService
	{
		public async Task LogExceptionAsync(Exception ex)
		{
			var logPath = "logs/errors.txt";
			Directory.CreateDirectory(Path.GetDirectoryName(logPath));

			var logMessage = $"[{DateTime.Now}] Exception: {ex.Message} {Environment.NewLine}";
			await File.AppendAllTextAsync(logPath, logMessage);
		}
	}
}
