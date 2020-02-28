using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorByndyusoft
{
    public class Calculator
    {
        private string userEquation;
        private List<string> quitConsole = new List<string>();
        private Stack<double> equationEnding = new Stack<double>();

        public Calculator()
        {
        }

        public string getUserEquation()
        {
            return this.userEquation;
        }

        public void setUserEquation(string userEquation)
        {
            this.userEquation = userEquation.Replace(" ", String.Empty);
            this.userEquation = userEquation.Replace(".", ",");
        }

        public double getResult(string userEquation)
        {
            quitConsole = ToReversePolishString.transformToReversePolishString(userEquation);
            return equationResult(quitConsole, equationEnding);
        }

        private double equationResult(List<string> quitConsole, Stack<double> equationEnding)
        {
            string equationList = "+-/*";

            foreach (string element in quitConsole)
            {
                if (!equationList.Contains(element))
                {
                    equationEnding.Push(Convert.ToDouble(element));
                }
                else
                {
                    equationEnding.Push(equation(equationEnding.Pop(), equationEnding.Pop(), element));
                }
            }
            return equationEnding.Pop();
        }

        private double equation(double number1, double number2, string equationType)
        {
            double result = 0.0;
            switch (equationType)
            {
                case "+":
                    result = number2 + number1;
                    break;
                case "-":
                    result = number2 - number1;
                    break;
                case "*":
                    result = number2 * number1;
                    break;
                case "/":
                    result = number2 / number1;
                    break;
            }
            return result;
        }
    }
}
