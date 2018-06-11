using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DictoInfrasctructure.Extensions
{
    public static class CommonExtensions
    {
        public static T GetEnumValue<T>(this string valueName) where T : struct
        {
            return Enum.Parse<T>(valueName, true);
        }

        public static string GetUserName(this ClaimsPrincipal principals)
        {
            if (principals == null)
            {
                throw new NullReferenceException();
            }
            return principals.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }


    }
}