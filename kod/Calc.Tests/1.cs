using Calc;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Main_Returns_IntMin_When_Null_Args()
        {
            // arrange
            int expected = int.MinValue;

            // act
            int actual = Program.Main(null);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_IntMin_When_Empty_Args()
        {
            int expected = int.MinValue;

            // act
            int actual = Program.Main(new string[] { });

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_IntMin_When_First_Arg_Not_sum_Or_product()
        {
            int expected = int.MinValue;

            // act
            int actual = Program.Main(new[] { "limes"});

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_Zero_When_There_Is_Only_One_Argument_string_sum()
        {
            int expected = 0;

            int actual = Program.Main(new[] { "sum" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Sum_Of_All_Remaining_Arguments_After_sum_String()
        {
            string[] sumArguments = {"sum", "2", "4", "6"};
            int expected = 12;

            int actual = Program.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_One_When_There_Is_Only_One_Argument_string_product()
        {
            int expected = 1;

            int actual = Program.Main(new[] { "product" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Product_Of_All_Remaining_Arguments_After_product_String()
        {
            string[] sumArguments = { "product", "2", "5", "3" };
            int expected = 30;

            int actual = Program.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_One_If_All_Remaining_Arguments_After_ndec_String_Generate_Non_Decreasing_Sequence()
        {
            string[] ndecArguments = { "ndec", "-9", "0", "2" };
            int expected = 1;

            int actual = Program.Main(ndecArguments);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Main_Returns_Minus_One_When_There_Is_Only_One_Argument_string_ndec()
        {
            int expected = -1;

            int actual = Program.Main(new[] { "ndec" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Minus_One_When_There_Is_Only_One_Argument_Remaining_After_String_ndec()
        {
            int expected = -1;

            int actual = Program.Main(new[] { "ndec", "1" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_One_If_All_Remaining_Arguments_After_aseq_String_Generate_Arithmetic_Sequence()
        {
            string[] aseqArguments = { "aseq", "-5", "0", "5" };
            int expected = 1;

            int actual = Program.Main(aseqArguments);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Main_Returns_Minus_One_If_There_Is_Only_One_Argument_Remaining_After_aseq_String()
        {
            string[] aseqArguments = { "aseq", "1" };
            int expected = -1;

            int actual = Program.Main(aseqArguments);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Main_Returns_Minus_One_When_There_Is_Only_One_Argument_String_aseq()
        {
            int expected = -1;

            int actual = Program.Main(new[] { "aseq" });

            Assert.AreEqual(expected, actual);
        }

    }
}