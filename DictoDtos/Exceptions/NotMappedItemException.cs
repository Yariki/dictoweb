using System;

namespace DictoInfrasctructure.Exceptions
{
    public class NotMappedItemException  :Exception
    {
        public NotMappedItemException(string message) : base(message)
        {
        }
    }
}