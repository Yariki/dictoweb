using DictoInfrasctructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DictoInfrasctructure.Core
{
    public abstract class CoreController<T> : Controller where T : Controller
    {
        private ILogger<T> _logger;

        protected CoreController(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected void Log(string message, LogLevel level = LogLevel.Error)
        {
            if (_logger == null)
            {
                return;
            }
            switch (level)
            {
                case LogLevel.Critical:
                    _logger.LogCritical(message);
                    break;
                case LogLevel.Debug:
                    _logger.LogDebug(message);
                    break;
                case LogLevel.Error:
                    _logger.LogError(message);
                    break;
                case LogLevel.Information:
                    _logger.LogInformation(message);
                    break;
                case LogLevel.Warning:
                    _logger.LogWarning(message);
                    break;
            }
        }

        protected string GetUserName()
        {
            return this.User.GetUserName();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}