using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorByndyusoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение: ");
            Calculator myCalculator = new Calculator();
            myCalculator.setUserEquation(Console.ReadLine());

            string userEquation = myCalculator.getUserEquation();
            Console.WriteLine($"Результат: {myCalculator.getResult(userEquation)}");
        }
    }
}
