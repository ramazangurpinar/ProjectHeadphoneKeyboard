using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Demo.Core.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductTypeEnum
    {
        [EnumMember(Value = "Headphone")]
        Headphone,

        [EnumMember(Value = "Keyboard")]
        Keyboard
    }
}
