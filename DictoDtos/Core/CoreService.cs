using System;
using DictoInfrasctructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace DictoInfrasctructure.Core
{
    public abstract class CoreService : ICoreService
    {
        private ILogger _logger;

        protected CoreService(ILogger logger)
        {
            _logger = logger;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logger = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected ILogger GetLogger()
        {
            return _logger;
        }

        protected void Log(string message,LogLevel level = LogLevel.Error)
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

    }
}