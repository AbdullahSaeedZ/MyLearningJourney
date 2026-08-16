using Serializer.Attributes;
using System.Reflection;
using System.Text;

namespace Serializer
{
    public static class Serializer
    {
        public static void SerializeList(object obj, string filePath)
        {
        }

        public static void SerializeObject(object obj, string filePath)
        {
            if (obj == null) return;

            using StreamWriter writer = new StreamWriter(filePath, false);
            string ConvertedObject = GetOneObjectJson(obj);

            writer.Write(ConvertedObject);
        }

        private static string GetOneObjectJson(object obj)
        {
            Type type = obj.GetType();

            // this will pick up both public and private fields and properties, but not static ones
            MemberInfo[] members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // to be fixed
            if (members.Length == 0)
                return "{}";

            StringBuilder oneObjectJson = new StringBuilder("{");
            foreach (MemberInfo member in members)
            {
                if (!HandleRestrictions(member))
                    continue;

                // preparing the name section. not handling nested objects yet
                string customName = member.GetCustomAttribute<JsonPropertyName>()?.Name ?? member.Name;

                oneObjectJson.Append($"\n\t\"{customName}\": ");
                AppendMemberValue(obj, member, oneObjectJson); 
            }

            oneObjectJson.Length -= 1; // to remove the last comma
            oneObjectJson.Append("\n}");

            return oneObjectJson.ToString();
        }

        private static void AppendMemberValue(object obj, MemberInfo member, StringBuilder oneObjectJson)
        {
            object? value = member switch
            {
                PropertyInfo p => p.GetValue(obj),
                FieldInfo f => f.GetValue(obj),
                _ => null
            };
            Type? itemType = member switch
            {
                PropertyInfo p => p.PropertyType,
                FieldInfo f => f.FieldType,
                _ => null
            };

            if (value == null)
            {
                oneObjectJson.Append("null,");
            }
            else if (itemType == typeof(string))
            {
                oneObjectJson.Append($"\"{value}\",");
            }
            else if (itemType!.IsPrimitive && itemType != typeof(bool) && itemType != typeof(char) || itemType == typeof(decimal))
            {
                oneObjectJson.Append($"{value},");
            }
            else if (itemType == typeof(bool))
            {
                oneObjectJson.Append($"{value.ToString().ToLower()},");
            }
            else
            {
                // nested objects, recursion??
            }
        }

        private static bool HandleRestrictions(MemberInfo member)
        {
            // to only include properties and fields
            if (member.MemberType != MemberTypes.Property && member.MemberType != MemberTypes.Field)
                return false;

            // to skip private fields and properties that are not marked with [JsonInclude] attribute
            if (member is FieldInfo field && !field.IsPublic && member.GetCustomAttribute<JsonIncludeAttribute>() == null)
                return false;
            if (member is PropertyInfo prop && prop.CanRead && prop.GetMethod?.IsPublic == false && member.GetCustomAttribute<JsonIncludeAttribute>() == null)
                return false;

            // to skip properties that are marked with [JsonIgnore] attribute
            if (member.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                return false;

            return true;
        }




        public static T DeserializeObject<T>(string filePath)
        {
            return default(T);
        }
        public static T[] DeserializeList<T>(string filePath)
        {
            return new T[0];
        }

    }
}
