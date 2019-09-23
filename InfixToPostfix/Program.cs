using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixToPostfix
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupingcheck = new GroupingCheck();
            
            Console.WriteLine("Please enter an expression.");
            string infix = Console.ReadLine();
            if (!groupingcheck.IsValidGrouping(infix))
            {
                Console.WriteLine("Brackets for grouping are incorrect. Please enter a valid expression.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Please enter an expression.");
                infix = Console.ReadLine();
            }

            var InfixToPostfixConverter = new InfixToPostfixConverter(infix);
            Console.WriteLine(InfixToPostfixConverter.Output);
            Console.ReadLine();
        }
    }
}
