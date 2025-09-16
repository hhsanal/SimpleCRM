using System.ComponentModel;
using System.Reflection;

namespace Application.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
    public static TEnum? GetEnumValueFromDescription<TEnum>(this string description) where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields())
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute?.Description == description)
            {
                return (TEnum)field.GetValue(null);
            }

            // Eğer description yoksa, enum adıyla da eşleşme yapılabilir:
            if (field.Name == description)
            {
                return (TEnum)field.GetValue(null);
            }
        }

        return null; // eşleşme yoksa
    }

}
