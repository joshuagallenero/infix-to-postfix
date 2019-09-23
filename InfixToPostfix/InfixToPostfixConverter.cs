using System;
using System.Collections.Generic;

namespace InfixToPostfix
{
    public class InfixToPostfixConverter
    {
        public string Input { get; set; }
        public string Output { get; set; }

        public InfixToPostfixConverter(string input)
        {
            Input = input;
            Output = ConvertToPostFix(Input);
        }

        public string ConvertToPostFix(string infix)
        {
            infix = infix.Replace(" ", "");
            var stack = new Stack<char>();
            var postfix = new Queue<string>();
            foreach (char character in infix)
            {

                if (character == '(' || character == '[' || character == '(')
                {
                    stack.Push(character);
                }

                else if (IsOperator(character))
                {
                    if (stack.Count > 0)
                    {
                        while (IsOperator(stack.Peek()) && Precedence(character, stack.Peek()))
                        {
                            postfix.Enqueue(stack.Pop().ToString());
                        }

                        stack.Push(character);
                    }
                    else
                    {
                        stack.Push(character);
                    }
                    
                }

                else if (character == ')' || character == ']' || character == '}')
                {
                    while (!IsOperator(stack.Peek()))
                    {
                        postfix.Enqueue(stack.Pop().ToString());
                    }

                    stack.Pop();
                }
                else
                {
                    postfix.Enqueue(character.ToString());
                }
                
            }
            var output = "";
       
            foreach (string character in postfix)
            {
                output = output + character;
            }

            return output;
        }

        public bool IsOperator(char character)
        {
            return character == '+' || character == '-' || character == '*' || character == '/' || character == '^';
        }

        private bool Precedence(char firstOperator, char secondOperator)
        {
            var holder = 0;
            var holder2 = 0;

            if (firstOperator == '+' || firstOperator == '-')
            {
                holder = 1;
            }
            else if (firstOperator == '*' || firstOperator == '/')
            {
                holder = 2;
            }
            else if (firstOperator == '^')
            {
                holder = 3;
            }

            if (secondOperator == '+' || secondOperator == '-')
            {
                holder2 = 1;
            }
            else if (secondOperator == '*' || secondOperator == '/')
            {
                holder2 = 2;
            }
            else if (secondOperator == '^')
            {
                holder2 = 3;
            }

            if (holder == 1 && holder2 == 1) return true;
            if (holder == 2 && holder2 == 2) return true;
            return holder < holder2;
        }
    }
}