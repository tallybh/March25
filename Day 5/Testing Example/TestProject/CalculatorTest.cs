using Testing_Example;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testAdd()
        {
            int result = Calculator.Add(1, 2);
            Assert.IsTrue(result == 3);
        }

        [Test]
        public void testSubtract()
        {
            int result = Calculator.Subtract(1, 2);
            Assert.IsTrue(result == -1);
        }


        [Test]
        public void testMultiply()
        {
            int result = Calculator.Multiply(1, 2);
            Assert.IsTrue(result == 2);
        }

        [Test]
        public void testDivide()
        {
            double result = Calculator.Divide(1, 2);
            Assert.IsTrue(result == 0.5);
        }

        [Test]
        public void testDivideByZero()
        {
            double result = Calculator.Divide(1, 0);
            Assert.IsTrue(double.IsInfinity(result));
        }
    }
}
