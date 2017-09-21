using System;
using System.Threading.Tasks;

namespace DictoInfrasctructure.Extensions
{
    public static class CommonExtensions
    {
        public static T GetEnumValue<T>(this string valueName) where T : struct
        {
            return Enum.Parse<T>(valueName, true);
        }
    }
}