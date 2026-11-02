namespace Conversion.Shared;

public class ShippingList<T> : List<T> where T : Shipping
{
    // Custom instance method that intercepts the call
    public IEnumerable<T> Where(Func<T, bool> predicate)
    {
        Console.WriteLine("--> [CUSTOM ShippingList.Where WAS CALLED] <--");
        
        foreach (var item in this)
        {
            if (predicate(item))
                yield return item;
        }
    }
}