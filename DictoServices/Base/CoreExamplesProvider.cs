using System.Threading.Tasks;
using DictoServices.Data;
using Microsoft.Extensions.Logging;

namespace DictoServices.Base
{
    public abstract class CoreExamplesProvider
    {
        private ILogger _logger;

        protected CoreExamplesProvider(string original, ILogger logger)
        {
            _logger = logger;
            Original = original;
        }

        public string Original { get; private set; }

        public abstract Task<ExamplesRequestResult> GetExamples();

        protected void Log(LogLevel level, string message)
        {
            _logger?.Log(level,message);
        }

    }
}