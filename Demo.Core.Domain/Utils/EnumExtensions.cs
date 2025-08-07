using System.Reflection;
using System.Runtime.Serialization;

namespace Demo.Core.Domain.Utils
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(this T enumValue) where T : Enum
        {
            var type = typeof(T);
            var info = type.GetMember(enumValue.ToString()).FirstOrDefault();
            var attr = info?.GetCustomAttribute<EnumMemberAttribute>();
            return attr?.Value ?? enumValue.ToString();
        }
    }
}
