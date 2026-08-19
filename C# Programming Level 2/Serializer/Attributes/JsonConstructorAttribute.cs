using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class JsonConstructorAttribute : Attribute
    {
    }
}
