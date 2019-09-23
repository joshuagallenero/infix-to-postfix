using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfixToPostfix;
using NUnit.Framework;

namespace GroupingCheckTest
{
    [TestFixture]
    public class GroupingCheckTests
    {
        [TestCase(")6+2(")]
        [TestCase("[(6+2]+1)")]
        public void ValidGrouping_WrongExpressionGrouping_ReturnsFalse(string expression)
        {
            GroupingCheck cg = new GroupingCheck();

            var result = cg.IsValidGrouping(expression);

            Assert.That(result, Is.False);

        }

        [TestCase("(6+2)")]
        [TestCase("[(6+2)+1]")]
        public void ValidGrouping_CorrectExpressionGrouping_ReturnsTrue(string expression)
        {
            GroupingCheck cg = new GroupingCheck();

            var result = cg.IsValidGrouping(expression);

            Assert.That(result, Is.True);

        }
    }
}
