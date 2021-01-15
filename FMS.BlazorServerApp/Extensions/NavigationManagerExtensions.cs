using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace FMS.BlazorServerApp.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static bool TryGetQueryString<T>(this NavigationManager navManager, string key, out T value)
        {
            var uri = navManager.ToAbsoluteUri(navManager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out var valueFromQueryString))
            {
                if (typeof(T) == typeof(int) && int.TryParse(valueFromQueryString, out var valueAsInt))
                {
                    value = (T)(object)valueAsInt;
                    return true;
                }

                if (typeof(T) == typeof(string))
                {
                    value = (T)(object)valueFromQueryString.ToString();
                    return true;
                }

                if (typeof(T) == typeof(decimal) && decimal.TryParse(valueFromQueryString, out var valueAsDecimal))
                {
                    value = (T)(object)valueAsDecimal;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public static void SetParametersFromQueryString<T>(this NavigationManager navManager, T options) where T : class
        {
            var uri = navManager.ToAbsoluteUri(navManager.Uri);

            Dictionary<string, StringValues> queryString = QueryHelpers.ParseQuery(uri.Query);

            foreach (var property in GetProperties<T>())
            {
                string parameterName = property.Name;

                if (queryString.TryGetValue(parameterName, out var value))
                {
                    var convertedValue = ConvertValue(value, property.PropertyType);
                    property.SetValue(options, convertedValue);
                }
            }
        }

        public static void SetQueryStringFromParameters<T>(this NavigationManager navManager, T options, out string newRelativeUri) where T : class
        {
            Dictionary<string, StringValues> parameters = new Dictionary<string, StringValues>();

            foreach (var property in GetProperties<T>())
            {
                string parameterName = property.Name;
                
                var value = property.GetValue(options);
                //if (value != null)
                if (!object.Equals(value, GetDefaultValue(property.PropertyType)))
                {
                    var convertedValue = ConvertToString(value);
                    parameters[parameterName] = convertedValue;
                }
            }

            newRelativeUri = navManager.ToAbsoluteUri(navManager.Uri).GetComponents(UriComponents.Path, UriFormat.Unescaped);
            foreach (var parameter in parameters)
            {
                foreach (var value in parameter.Value)
                {
                    newRelativeUri = QueryHelpers.AddQueryString(newRelativeUri, parameter.Key, value);
                }
            }
        }

        #region Helpers
        private static PropertyInfo[] GetProperties<T>()
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private static object ConvertValue(StringValues value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return Convert.ChangeType(value[0], type, CultureInfo.InvariantCulture);
        }

        private static string ConvertToString(object value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        private static object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        #endregion
    }
}
