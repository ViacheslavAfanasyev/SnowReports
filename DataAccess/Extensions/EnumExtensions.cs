using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DataAccess.Extensions
{
    public static class EnumExtensions
    {
        public static List<string> EnumToList(this Type source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (!source.IsEnum)
            {
                throw new InvalidCastException(nameof(source));
            }

            var results = new List<string>();
            var values = Enum.GetValues(source);
            foreach (var value in values)
            {
                if (value.ToString() != "DefaultValue")
                    results.Add(GetAttributeValueOrName(value, source));
            }

            return results;
        }
        public static Dictionary<int, string> EnumToDictionary(this Type source)
        {
            if (source==null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if  (!source.IsEnum)
            {
                throw new InvalidCastException(nameof(source));
            }

            var results = new Dictionary<int, string>();
            var values = Enum.GetValues(source);
            foreach (var value in values)
            {
                if (value.ToString()!= "DefaultValue")
                results.Add((int)value, GetAttributeValueOrName(value, source));
            }

            return results;
        }

        private static string GetAttributeValueOrName(object field, Type type)
        { 
            var fieldName = Enum.GetName(type, field);
            var attribute = type.GetField(fieldName).GetCustomAttribute<DisplayAttribute>();

            if (attribute != null && attribute.Name != null)
            {
                return attribute.Name;
            }

            return fieldName;
        }
    }
}
