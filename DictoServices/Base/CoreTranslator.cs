using System.Threading.Tasks;
using DictoData.Model;
using DictoServices.Data;
using Microsoft.Extensions.Logging;

namespace DictoServices.Base
{
    public abstract class CoreTranslator
    {
        private ILogger _logger;
        

        protected CoreTranslator(ILogger logger, Language source, Language target, string query)
        {
            _logger = logger;
            Query = query;
            Source = source;
            Target = target;
        }

        public abstract Task<TranslateRequestResult> Request();
        
        
        protected Language Source { get; private set; }
         
        protected Language Target { get; private set; }
         
        protected string Query { get; private set; }

        protected void Log(string message)
        {
            
        }
        
    }
}