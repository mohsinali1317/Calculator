using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorApiApp.Models
{
    public class Calculator
    {
        public static int icp(char a)
        {
            if (a == '*' || a == '/')
                return 3;
            else if (a == '+' || a == '-')
                return 2;

            return -1;

        }
        public static bool HasHigherPrec(char top, char current)
        {
            return icp(top) >= icp(current);
        }

        public static bool IsOpeningParenthesis(char item)
        {
            return (item == '(' || item == '{' || item == '[');
        }

        public static bool IsClosingParenthesis(char item)
        {
            return (item == ')' || item == '}' || item == ']');
        }

        public static int Calculate(int number1, int number2, char myOperator)
        {
            switch (myOperator)
            {
                case '+':
                    return number1 + number2;
                case '-':
                    return number1 - number2;
                case '*':
                    return number1 * number2;
                case '/':
                    return number1 / number2;
            }

            return 0;
        }


        public int Calculate(string expression)
        {

            String postFixString = "";

            char[] myArray = expression.ToCharArray();

            Stack<string> operatorStack = new Stack<string>();

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] != ' ')
                {
                    int n;
                    if (int.TryParse(myArray[i].ToString(), out n))
                    {
                        postFixString += myArray[i].ToString();
                    }

                    else if (IsOpeningParenthesis(myArray[i]))
                    {
                        operatorStack.Push(myArray[i].ToString());
                    }

                    else if (IsClosingParenthesis(myArray[i]))
                    {
                        while (operatorStack.Count() > 0 && !IsOpeningParenthesis(Char.Parse(operatorStack.Peek())))
                        {
                            postFixString += operatorStack.Pop();
                        }
                        operatorStack.Pop();
                    }
                    else
                    {
                        while (operatorStack.Count() > 0 && HasHigherPrec(Char.Parse(operatorStack.Peek()), myArray[i]) && !IsOpeningParenthesis(Char.Parse(operatorStack.Peek())))
                        {
                            postFixString += operatorStack.Pop();
                        }
                        operatorStack.Push(myArray[i].ToString());
                    }
                }
            }

            while (operatorStack.Count() > 0)
            {
                postFixString += operatorStack.Pop();
            }

            Stack<int> result = new Stack<int>();

            char[] postFixArray = postFixString.ToCharArray();

            for (int i = 0; i < postFixArray.Length; i++)
            {
                int n;
                if (int.TryParse(postFixArray[i].ToString(), out n))
                {
                    result.Push(n);
                }
                else
                {
                    int number1 = result.Pop();
                    int number2 = result.Pop();

                    int res = Calculate(number1, number2, postFixArray[i]);

                    result.Push(res);
                }
            }
            try
            {
                return result.Pop();
            }
            catch(Exception e)
            {
                throw new Exception("something happened which was not suppose to happened. are you sure you have entered a valid expression?");
            }
           
        }

    }
}