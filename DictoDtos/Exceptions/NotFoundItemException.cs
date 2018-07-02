using System;

namespace DictoInfrasctructure.Exceptions
{
    public class NotFoundItemException : Exception
    {
        public NotFoundItemException(string message) : base(message)
        {
        }
    }
}