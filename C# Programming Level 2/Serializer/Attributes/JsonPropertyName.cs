using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class JsonPropertyName : Attribute
    {
        public string Name { get; set; }
        public JsonPropertyName(string name)
        {
            Name = name;
        }
    }
}
