using System;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class LogInjectionExample
    {
        private readonly ILogger<LogInjectionExample> _logger;

        public LogInjectionExample(ILogger<LogInjectionExample> logger)
        {
            _logger = logger;
        }

        public void LogUserInput(string userInput)
        {
            // Insecure: Logging user input without sanitization (Log Injection vulnerability)
            _logger.LogInformation("User input received: {UserInput}", userInput);
        }

        public static void Main(string[] args)
        {
            // Setup logger
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<LogInjectionExample> logger = loggerFactory.CreateLogger<LogInjectionExample>();

            var logExample = new LogInjectionExample(logger);
            
            // Simulate user input with log injection
            string maliciousInput = "Normal input; DROP TABLE Users; --";  // Example of injected SQL statement or log manipulation
            logExample.LogUserInput(maliciousInput);
        }
    }
}

