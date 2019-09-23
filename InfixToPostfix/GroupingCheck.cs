using System.Collections.Generic;

namespace InfixToPostfix
{
    public class GroupingCheck
    {
        public bool IsValidGrouping(string input)
        {
            var stackchecker = new Stack<char>();
            foreach (char c in input)
            {
                if(IsOpening(c)) stackchecker.Push(c);

                if (IsClosing(c))
                {
                    if (stackchecker.Count == 0) return false;
                    if (!IsPair(stackchecker.Pop(), c)) return false;
                }
            }

            if (stackchecker.Count == 0) return true;
            return false;
        }

        private bool IsOpening(char literal)
        {
            if (literal == '(' || literal == '{' || literal == '[') return true;
            return false;
        }
        private bool IsClosing(char literal)
        {
            if (literal == ')' || literal == '}' || literal == ']') return true;
            return false;
        }
        private bool IsPair(char opening, char closing)
        {
            if (opening == '{' && closing == '}')
                return true;
            if (opening == '(' && closing == ')')
                return true;
            if (opening == '[' && closing == ']')
                return true;

            return false;
        }
    }
}