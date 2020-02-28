using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorByndyusoft
{
    public static class ToReversePolishString
    {
        public static List<string> transformToReversePolishString(string userEquation)
        {
            List<string> quitConsole = new List<string>();
            string element = String.Empty;
            string equationSymbols = "+-/*()";
            Stack<char> stackSigns = new Stack<char>();

            foreach (char symbol in userEquation)
            {
                if (!equationSymbols.Contains(symbol))
                {
                    element += symbol;
                }
                else
                {
                    if (!string.IsNullOrEmpty(element))
                    {
                        quitConsole.Add(element);
                        element = String.Empty;
                    }

                    symbolCheck(ref quitConsole, ref stackSigns, symbol);
                }
            }

            if (!string.IsNullOrEmpty(element))
            {
                quitConsole.Add(element);
                element = String.Empty;
            }

            while (stackSigns.Count != 0)
            {
                quitConsole.Add(stackSigns.Pop().ToString());
            }

            return quitConsole;
        }

        private static bool priorityCheck(char toStack, char inStack)
        {
            string priority3 = "*/";
            string priority2 = "+-";
            int toStackPriority;
            int inStackPriority;

            toStackPriority = priority3.Contains(toStack) ? 3 : priority2.Contains(toStack) ? 2 : 1;
            inStackPriority = priority3.Contains(inStack) ? 3 : priority2.Contains(inStack) ? 2 : 1;
            bool putInStack = (toStackPriority > inStackPriority) ? true : false;

            return putInStack;
        }

        private static void symbolCheck(ref List<string> quitConsole, ref Stack<char> stackSigns, char symbol)
        {
            if (symbol == '(')
            {
                stackSigns.Push(symbol);
                return;
            }
            else if (symbol == ')')
            {
                while (stackSigns.Peek() != '(')
                {
                    quitConsole.Add(stackSigns.Pop().ToString());
                }
                stackSigns.Pop();
            }
            else
            {
                while (true)
                {
                    if (stackSigns.Count == 0)
                    {
                        stackSigns.Push(symbol);
                        break;
                    }
                    else if (priorityCheck(symbol, stackSigns.Peek()))
                    {
                        stackSigns.Push(symbol);
                        break;
                    }
                    quitConsole.Add(stackSigns.Pop().ToString());
                }
            }
        }
    }
}
