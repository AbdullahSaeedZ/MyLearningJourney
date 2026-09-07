namespace Serializer.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class JsonIgnoreAttribute : Attribute
    {
    }
}
