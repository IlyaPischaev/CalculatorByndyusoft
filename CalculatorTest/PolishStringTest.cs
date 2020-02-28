using System;
using Xunit;
using CalculatorByndyusoft;

namespace CalculatorTest
{
    public class PolishStringTest
    {
        [Fact]
        public void CalculatorSetEquationResultTest1()
        {
            double expected = 55.0;

            Calculator myTest = new Calculator();
            myTest.setUserEquation("5+(7-2)*10");

            double result = myTest.getResult(myTest.getUserEquation());
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatorSetEquationResultTest2()
        {
            double expected = -33.8625;

            Calculator myTest = new Calculator();
            myTest.setUserEquation("(7,25-18)*3,15");

            double result = myTest.getResult(myTest.getUserEquation());
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatorSetEquationResultTest3()
        {
            double expected = 38.5;

            Calculator myTest = new Calculator();
            myTest.setUserEquation("84/(4+4)-5,5*4+1500/(2*15)");

            double result = myTest.getResult(myTest.getUserEquation());
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatorSetEquationResultTest4()
        {
            double expected = 38.5;

            Calculator myTest = new Calculator();
            myTest.setUserEquation("84/(4+4)-5.5*4+1500/(2*15)");

            double result = myTest.getResult(myTest.getUserEquation());
            Assert.Equal(expected, result);
        }
    }
}
