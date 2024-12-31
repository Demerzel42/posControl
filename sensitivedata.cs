using System;
using Microsoft.Extensions.Logging;

namespace SensitiveDataLeakExample
{
    public class SensitiveDataLeak
    {
        private readonly ILogger<SensitiveDataLeak> _logger;

        public SensitiveDataLeak(ILogger<SensitiveDataLeak> logger)
        {
            _logger = logger;
        }

        public void LogUserLogin(string username, string password)
        {
            // Insecure: Logging sensitive data like password
            _logger.LogInformation("User {Username} attempted to log in with password {Password}.", username, password);

            // Insecure: Exposing sensitive data in error messages
            if (username == "admin" && password != "admin123")
            {
                throw new Exception("Invalid credentials! Please check your password: admin123");
            }
        }

        public static void Main(string[] args)
        {
            // Setup logger
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<SensitiveDataLeak> logger = loggerFactory.CreateLogger<SensitiveDataLeak>();

            var sensitiveDataLeak = new SensitiveDataLeak(logger);
            
            // Simulate sensitive data exposure
            string username = "admin";
            string password = "admin123"; // Sensitive data

            sensitiveDataLeak.LogUserLogin(username, password);
        }
    }
}

