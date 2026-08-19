using Serializer.Attributes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// c# comments on methods
// asynchronous methods

namespace Serializer
{
    public static class Serializer
    {
        // Total Space Offset = Depth X SpacesPerIndent
        // depth is the level, spaces number or tabs, which increasses with an open bracket and decreasses with a closing bracket

        // removed static depth and totalSpaces fields here to avoid resetting with multiple serializations at same app life time,
        // and to avoid race condition issues
        private static readonly int _spacesPerDepth = 4;



        // multiple elements serialization
        public static void Serialize(IEnumerable<object> elements, string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath, false);
            writer.Write(ConvertElementsToJson(elements));
        }
        private static string ConvertElementsToJson(IEnumerable<object> elements)
        {
            StringBuilder jsonList = new StringBuilder("[\n");

            for (int i = 0; i < elements.Count(); i++)
            {
                object? element = elements.ElementAt(i);
                if (element == null)
                {
                    // to remove the last comma and newline, if last object is null
                    if (i == elements.Count() - 1)
                        jsonList.Length -= 2;

                    continue;
                }

                if (i == elements.Count() - 1)
                    jsonList.Append(GetOneObjectJson(element, 1)); // depth is 1 cuz there is alreasy an array starting bracket
                else
                    jsonList.Append(GetOneObjectJson(element, 1) + ",\n");
            }
            jsonList.Append("\n]");
            return jsonList.ToString();
        }


        // single element serialization
        public static void Serialize(object obj, string filePath)
        {
            if (obj == null) return;

            using StreamWriter writer = new StreamWriter(filePath, false);
            string jsonObject = GetOneObjectJson(obj, 0);

            writer.Write(jsonObject);
        }

        private static string GetOneObjectJson(object obj, int depthLevel, bool isNested = false)
        {
            MemberInfo[] members = GetMembers(obj.GetType());
            if (members.Length == 0) return "{}";

            return ConvertMembersToJson(obj, members, depthLevel, isNested);
        }

        private static MemberInfo[] GetMembers(Type type)
        {
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

        private static string ConvertMembersToJson(object obj, MemberInfo[] members, int depthLevel, bool isNested)
        {
            int _depthLevel = depthLevel;
            string spaces = GetSpeaces(_depthLevel);

            StringBuilder oneObjectJson = new StringBuilder(isNested ? "{" : $"{spaces}{{");
            spaces = GetSpeaces(++_depthLevel);

            foreach (MemberInfo member in members)
            {
                // preparing the json property section
                string name = member.GetCustomAttribute<JsonPropertyName>()?.Name ?? member.Name;
                oneObjectJson.Append($"\n{spaces}\"{name}\": ");

                // to hanle value if a nesdted objcet
                if (HandleNestedObject(obj, member, oneObjectJson, _depthLevel))
                {
                    oneObjectJson.Append(",");
                    continue;
                }

                // preparing the json value section
                AppendMemberValue(obj, member, oneObjectJson);
            }
            oneObjectJson.Length--; // to remove the last comma
            spaces = GetSpeaces(--_depthLevel);

            oneObjectJson.Append($"\n{spaces}}}");
            return oneObjectJson.ToString();
        }

        private static string GetSpeaces(int newDepthLevel)
        {
            int TotalSpaces = newDepthLevel * _spacesPerDepth;
            return new string(' ', TotalSpaces);
        }

        private static bool HandleNestedObject(object parentObj, MemberInfo member, StringBuilder oneObjectJson, int depthLevel)
        {
            // to check if member is a nested class, other checks are done in HandleRestrictions
            if (!( member is PropertyInfo nestedClass && !nestedClass.PropertyType.IsPrimitive && nestedClass.PropertyType != typeof(string) ))
                return false;

            object? childObj = nestedClass.GetValue(parentObj);

            if (childObj == null)
                return false;

            oneObjectJson.Append(GetOneObjectJson(childObj, depthLevel, true));
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
            Type? elementType = member switch
            {
                PropertyInfo p => p.PropertyType,
                FieldInfo f => f.FieldType,
                _ => null
            };

            if (value == null)
            {
                oneObjectJson.Append("null,");
            }
            else if (elementType == typeof(string))
            {
                oneObjectJson.Append($"\"{value}\",");
            }
            else if (elementType!.IsPrimitive && elementType != typeof(bool) && elementType != typeof(char) || elementType == typeof(decimal))
            {
                oneObjectJson.Append($"{value},");
            }
            else if (elementType == typeof(bool))
            {
                oneObjectJson.Append($"{value.ToString()!.ToLower()},");
            }
        }



        //--------------



        public static List<T> DeserializeList<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            using StreamReader reader = new StreamReader(filePath);
            List<T> list = new List<T>();

            // read from file one object at a time
            // deserialize it and add it to the list

            return list;
        }



        public static T? DeserializeObject<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);

            using StreamReader reader = new StreamReader(filePath);
            string jsonContent = reader.ReadToEnd();

            return ConvertJsonToObject<T>(jsonContent);
        }

        private static T? ConvertJsonToObject<T>(string jsonContent)
        {
            Dictionary<string, string> jsonKeyAndValues = ParseJsonContent(jsonContent);

            Type type = typeof(T);

            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo validConstructor = GetValidConstructor(constructors);
            ParameterInfo[] parameters = validConstructor.GetParameters();

            T obj = InvokeInitialObject<T>(validConstructor, parameters);
            MapParsedValuesToObject(obj, type, jsonKeyAndValues);

            return obj;
        }

        private static void MapParsedValuesToObject<T>(T? obj, Type type, Dictionary<string, string> jsonKeyAndValues)
        {
            // neseted objects are not handled yet
            MemberInfo[] members = GetMembers(type);

            foreach (MemberInfo member in members)
            {
                string name = member.GetCustomAttribute<JsonPropertyName>()?.Name ?? member.Name;
                
                if (jsonKeyAndValues.TryGetValue(name, out string value))
                {
                    if (value == "null")
                        value = null;
                    if (member is PropertyInfo property)
                    {
                        property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                    }
                    else if (member is FieldInfo field)
                    {
                        field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
                    }
                }

                    
            }

        }

        private static T? InvokeInitialObject<T>(ConstructorInfo validConstructor, ParameterInfo[] parameters)
        {
            if (parameters.Length == 0)
                return (T?)validConstructor.Invoke(null);
            else
            {
                object[] readyParameters = new object[parameters.Length];
                //Dictionary<Type, object> typesWithValues = new Dictionary<Type, object>();

                for (int i = 0; i < parameters.Length; i++)
                {
                    readyParameters[i] = parameters[i].ParameterType.IsValueType ?
                        Activator.CreateInstance(parameters[i].ParameterType) : null;
                }

                return (T?)validConstructor.Invoke(readyParameters);
            }
        }

        private static ConstructorInfo GetValidConstructor(ConstructorInfo[] constructors)
        {
            if (constructors.Length == 0)
                throw new InvalidOperationException("No public constructors found for the type.");

            ConstructorInfo markedConstructor = null;
            ConstructorInfo parameterizedConstructor = null;
            ConstructorInfo parameterlessConstructor = null;
            int JsonConstructorAttribute = 0;
            int parameterizedConstructors = 0;

            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.IsDefined(typeof(JsonConstructorAttribute)))
                {
                    JsonConstructorAttribute++;
                    markedConstructor = constructor;
                }

                if (constructor.GetParameters().Length == 0)
                    parameterlessConstructor = constructor;
                else
                {
                    parameterizedConstructors++;
                    parameterizedConstructor = constructor;
                }
            }

            if (JsonConstructorAttribute > 1)
                throw new InvalidOperationException("Multiple constructors with [JsonConstructor] attribute found.");

            if (parameterizedConstructors > 1)
                throw new InvalidOperationException("Multiple parameterized constructors found.");

            if (markedConstructor != null)
                return markedConstructor;

            if (parameterlessConstructor != null)
                return parameterlessConstructor;

            if (parameterizedConstructor != null)
                return parameterizedConstructor;

            return null;
        }


        private static Dictionary<string, string> ParseJsonContent(string jsonContent)
        {
            Dictionary<string, string> propertyPairs = new Dictionary<string, string>();

            jsonContent = jsonContent.TrimStart('{').TrimEnd('}');
            string[] pairs = jsonContent.Split(',');

            foreach (string pair in pairs)
            {
                string[] key_Value = pair.Split(':');
                string key = key_Value[0].Trim().Trim('"');
                string value = key_Value[1].Trim().Trim('"');

                propertyPairs[key] = value;
            }
            return propertyPairs;
        }
    }
}

/*
 foreach (ConstructorInfo constructor in constructors)
            {

                Console.WriteLine(constructor);

                ParameterInfo[] parameters = constructor.GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine($"Parameter: {parameter.Name}, Type: {parameter.ParameterType}");
                }

                foreach (MemberInfo member in members)
                {
                    Console.WriteLine($"Member: {member.Name}, Type: {member.MemberType}");
                }
            }
 */