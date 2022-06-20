using System;
namespace Calculator
{
    interface BasicCalculatorInterface
    {
        int sum(int x, int y);
        int sub(int x, int y);
        int multiplication(int x, int y);
        int division(int x, int y);
    }
    interface ScientificalCalculatorInterface
    {
        double squareRoot(int num);
        int powerValue(int powerOf, int num);
        int factorial(int num);
        int gcd(int num1, int num2);
        int lcm(int num1, int num2);
    }
    class MyCalculator : BasicCalculatorInterface, ScientificalCalculatorInterface
    {
        public int sum(int x, int y)
        {
            return (x + y);
        }

        public int sub(int x, int y)
        {
            return (x - y);
        }

        public int multiplication(int x, int y)
        {
            return (x * y);
        }

        public int division(int x, int y)
        {
            return (x / y);
        }

        public double squareRoot(int num)
        {
            return (Math.Sqrt(num));
        }

        public int powerValue(int powerOf, int num)
        {
            int val=0;
            for(int i=0; i<powerOf; i++)
            {
                val = val + num;
            }
            return val;
        }
        public int factorial(int num)
        {
            int result = 1;
            while (num != 1)
            {
                result = result * num;
                num = num - 1;
            }
            return result;
        }

        public int gcd(int num1, int num2)
        {
            int temp;
            int gcd=1;
            if (num1 > num2)
            {
                temp = num1;
                num1 = num2;
                num2 = temp;
            }

            for (int i = 1; i < (num1 + 1); i++)
            {
                if (num1 % i == 0 && num2 % i == 0)
                    gcd = i;
            }
            return gcd;
        }

        public int lcm(int num1, int num2)
        {
            int temp;
            int lcm = num2;
            if (num1 > num2)
            {
                temp = num1;
                num1 = num2;
                num2 = temp;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    lcm = i * num1;
                    break;
                }
            }

            return lcm;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCalculator mc = new MyCalculator();

            Console.WriteLine("Enter two numbers to add: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.sum(x,y));

            Console.WriteLine("Enter two numbers to Substract: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.sub(x, y));

            Console.WriteLine("Enter two numbers to Multiply: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.multiplication(x, y));

            Console.WriteLine("Enter two numbers to Divide: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.division(x, y));

            Console.Write("Enter a number to find square root: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.squareRoot(x));

            Console.WriteLine("Enter a number to power of(i.e 2 for square) and the number to find power value: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.powerValue(x, y));

            Console.Write("Enter a number to find factorial: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.factorial(x));

            Console.WriteLine("Enter two numbers to find GCD: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.gcd(x, y));

            Console.WriteLine("Enter two numbers to find LCM: ");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: " + mc.lcm(x, y));

            Console.ReadKey();
        }
    }
}