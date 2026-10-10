namespace _1__Delegate_review;

class Program
{
    // delegate void delMethod();
    // instead, those are generic abstraction:
    // Action, Func, Pred
    
    static void Main(string[] args)
    {
        // passing a void method as parameter
        MethodVoid(Method1);
        
        // passing a return value method as parameter
        MethodReturnValue(Method2);

        // or this way:
        Func<string> funcDel = Method2;
        MethodReturnValue(funcDel);
        
        // or using lambda:
        Func<string> funcLambda = () => "lambda returned";
        MethodReturnValue(funcLambda);
    }

    static void Method1()
    {
        Console.WriteLine("method1");
    }
    
    static string Method2()
    {
        return "method2";
    }
    
    //----------------------------------------------
    // takes a method as a parameter
    static void MethodVoid(Action method)
    {
        method();
        Console.WriteLine("methodVoid");
    }
    
    static void MethodReturnValue(Func<string> method)
    {
        Console.WriteLine("methodReturnValue: " + method());
    }
    
}