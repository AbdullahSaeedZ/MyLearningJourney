public class Point
{
    public int x { get; set; }
    public int y { get; set; }

    public Point(int x, int y)
    {
        this.y = y;
        this.x = x;
    }

    // to overload operators, we declare a puplic static function with the operator keyword followed by needed operator
    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.x + p2.x, p1.y + p2.y);
    }

    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.x - p2.x, p1.y - p2.y);
    }



    // this is a restricted operator overloading type, restricted operator overloading examples are ==, != and <, > and more in next lesson
    // meaning when overloading the == operator, we must overload the != operator along side.
    // the default behavior of coparison operators with reference types, will be to compare references and return a bool result.
    // here we change this behavior: (Requires overriding Equals and GetHashCode in real apps)
    public static bool operator ==(Point p1, Point p2)
    {
        return ((p1.x == p2.x) && (p1.y == p2.y));
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return ( ( p1.x != p2.x ) && ( p1.y != p2.y ) );
    }


    public override string ToString()
    {
        return $"x value: {this.x}, y value: {this.y}";
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Point p1 = new Point(4, 5), p2 = new Point(10, 20);

        // invoking the custom addition operator overloading:
        Point AddedPoints = p1 + p2;
        Console.WriteLine($"resulted object after using addition operator overloading: {AddedPoints}");

        // invoking the custom subtraction operator overloading:
        Point subtractedPoints = p1 - p2;
        Console.WriteLine($"resulted object after using subtraction operator overloading: {subtractedPoints}");

        // invoking the custom == and != operator overloading:
        if (p1 == p2)
            Console.WriteLine("object p1 is equal to object p2");
        else  if (p1 != p2)
            Console.WriteLine("object p1 does not equal object p2");



        // another example we can see is the built-in DateTime struct in .net
        // opertator overloading is used to compare, add and subtract dates
        DateTime d1 = new DateTime(2000, 1, 1), d2 = new DateTime(2001, 2, 2);
        Console.WriteLine($"\n\nusing operator overloadig in DateTime: date1 == date2: {d1 == d2}");

    }
}

