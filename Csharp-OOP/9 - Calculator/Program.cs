using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9___Calculator
{


    class clsCalculator
    {
        private int _result = 0;
        private string _operation;
        private int _num;


        private bool _isZero(int num)
        {
            return num == 0;
        }

        public void Add(int num)
        {
            _num = num;
            _operation = "Adding";
            _result += num;
        }
        public void Subtract(int num)
        {
            _num = num;
            _operation = "subtracting";
            _result -= num;
        }
        public void Multiply(int num)
        {
            _num = num;
            _operation = "multiplying";
            _result *= num;
        }
        public void Divide(int num)
        {
            if (_isZero(num))
                num = 1;

            _num = num;
            _operation = "dividing";

            _result /= num;
        }

        public void PrintResult()
        {
            Console.WriteLine($"Result after {_operation} {_num} is : {_result}");
        }

        public void Clear()
        {
            _num = _result;
            _result = 0;
            _operation = "clearing";

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            clsCalculator calc = new clsCalculator();

            calc.Clear();

            calc.Add(10);
            calc.PrintResult();

            calc.Add(100);
            calc.PrintResult();

            calc.Subtract(20);
            calc.PrintResult();

            calc.Divide(0);
            calc.PrintResult();

            calc.Divide(2);
            calc.PrintResult();

            calc.Multiply(3);
            calc.PrintResult();

            calc.Clear();
            calc.PrintResult();


            // we encapsulated and restricted access of all methods and variable in the calculator class and made access through objects, and we chose to show certain members to user by abstraction

        }
    }
}
