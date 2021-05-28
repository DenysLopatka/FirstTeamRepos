using NUnit.Framework;
using TechTalk.SpecFlow;

namespace FirstTeamProject
{
    [Binding]
    public class Tests
    {
        [Given(@"the first number is 50")]
        public int FirstNumber()
        {
            var firstNumber = 50;
            return firstNumber;
        }

        [Given(@"the second number is 70")]
        public int SecondNumber()
        {
            var secondNumber = 70;
            return secondNumber;
        }

        [When(@"the two numbers are added")]
        public int Sum()
        {
            var firstNumber = FirstNumber();
            var secondNumber = SecondNumber();
            return firstNumber + secondNumber;
        }
        [Then(@"the result should be 120")]
        public void Is120()
        {
            var expectedResult = 120;
            Assert.AreEqual(expectedResult, Sum());
        }

    }
}