using Shammill.LobbyManager.Models;
using System;
using System.ComponentModel;

namespace Shammill.LobbyManager.Utilities
{
    public static class RegionStringToEnum
    {
        public static RegionEnum Convert(string region)
        {
            //To Do
            return RegionEnum.Australia;
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }
    }
}
