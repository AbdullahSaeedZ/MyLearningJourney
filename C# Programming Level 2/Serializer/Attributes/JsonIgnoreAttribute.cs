using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class JsonIgnoreAttribute : Attribute
    {
    }
}
