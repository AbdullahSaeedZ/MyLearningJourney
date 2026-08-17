using Serializer.Attributes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Serializer
{
    public static class Serializer
    {
        // multiple items serialization
        public static void Serialize(IEnumerable<object> items, string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath, false);
            writer.Write(ConvertItemsToJson(items));
        }
        private static string ConvertItemsToJson(IEnumerable<object> items)
        {
            StringBuilder jsonList = new StringBuilder("[\n");

            for (int i = 0; i < items.Count(); i++)
            {
                if (i == items.Count() - 1)
                {
                    jsonList.Append(GetOneObjectJson(items.ElementAt(i), true));
                    break;
                }
                jsonList.Append(GetOneObjectJson(items.ElementAt(i), true) + ",\n");
            }
            jsonList.Append("\n]");
            return jsonList.ToString();
        }


        // single item serialization
        public static void Serialize(object obj, string filePath)
        {
            if (obj == null) return;

            using StreamWriter writer = new StreamWriter(filePath, false);
            string jsonObject = GetOneObjectJson(obj);

            writer.Write(jsonObject);
        }

        private static string GetOneObjectJson(object obj, bool isPartOfItems = false)
        {
            MemberInfo[] members = GetMembers(obj);
            if (members.Length == 0)
                return "{}";

            return ConvertMembersToJson(obj, members, isPartOfItems);
        }

        private static MemberInfo[] GetMembers(object obj)
        {
            Type type = obj.GetType();

            // this will pick up both public and private fields and properties 
            return type.FindMembers(MemberTypes.Property | MemberTypes.Field,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                HandleRestrictions, null);
        }
        // this is a filtering method for FindMembers, it will be called for each member of the type so that only members that pass the filter will be returned
        private static bool HandleRestrictions(MemberInfo member, object? criteria)
        {
            // to exclude backing fields of properties (which are marked CompilerGeneratedAttribute by compiler)
            if (member.IsDefined(typeof(CompilerGeneratedAttribute)) || member.IsDefined(typeof(JsonIgnoreAttribute)))
                return false;
           
            if (member.IsDefined(typeof(JsonIncludeAttribute)))
                return true;

            // to skip private fields and properties that are not marked with either
            if (member is FieldInfo field && !field.IsPublic)
                return false;
            if (member is PropertyInfo prop && prop.CanRead && prop.GetMethod?.IsPublic == false)
                return false;

            return true;
        }


        private static string ConvertMembersToJson(object obj, MemberInfo[] members, bool isPartOfItems)
        {
            StringBuilder oneObjectJson = new StringBuilder(isPartOfItems ? "\t{" : "{");
            foreach (MemberInfo member in members)
            {
                // preparing the name section
                string customName = member.GetCustomAttribute<JsonPropertyName>()?.Name ?? member.Name;
                oneObjectJson.Append(isPartOfItems ? $"\n\t\t\"{customName}\": " : $"\n\t\"{customName}\": ");

                if (HandleNestedObjects(obj, member, oneObjectJson))
                {
                    oneObjectJson.Append(",");
                    continue;
                }

                // value section
                AppendMemberValue(obj, member, oneObjectJson);
            }

            oneObjectJson.Length--; // to remove the last comma
            oneObjectJson.Append(isPartOfItems ? "\n\t}" : "\n}");
            return oneObjectJson.ToString();
        }
        private static bool HandleNestedObjects(object parentObj, MemberInfo member, StringBuilder oneObjectJson)
        {
            // to check if member is a nested class, other checks are done in HandleRestrictions
            if (!( member is PropertyInfo nestedClass && !nestedClass.PropertyType.IsPrimitive && nestedClass.PropertyType != typeof(string) ))
                return false;

            object? childObj = nestedClass.GetValue(parentObj);

            if (childObj == null)
                return false;

            oneObjectJson.Append(GetOneObjectJson(childObj, true));
            return true;
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
                oneObjectJson.Append($"{value.ToString()!.ToLower()},");
            }
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
