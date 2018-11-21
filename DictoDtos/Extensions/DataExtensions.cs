using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DictoInfrasctructure.Exceptions;

namespace DictoInfrasctructure.Extensions
{
    public static class DataExtensions
    {
        public static bool IsPropertyList(this object obj, string propertyName)
        {
            if (obj.IsNull())
            {
                throw new NullReferenceException("obj");
            }

            var propertyInfo = obj.GetType().GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo.IsNull())
            {
                throw new NotFoundItemException($"The property was not found: {propertyName} in the type {obj.GetType()}");
            }

            var result = typeof(IList).IsAssignableFrom(propertyInfo.PropertyType);
            return result;
        }
    }
}