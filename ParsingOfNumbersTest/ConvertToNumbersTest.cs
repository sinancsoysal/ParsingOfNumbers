using ParsingOfNumbers.lib;

namespace ParsingOfNumbersTest
{
    public class ConvertToNumberTest
    {

        [Test]
        public void TestPositive()
        {
            Assert.AreEqual("He paid 20000000 for 3 such cars", ConvertToNumbers.ParseNumbers("He paid twenty million for three such cars."));
            Assert.AreEqual("Outside feels like 23 degrees", ConvertToNumbers.ParseNumbers("Outside feels like twenty three degrees."));
            Assert.AreEqual("I bought a car for 69000 dollars", ConvertToNumbers.ParseNumbers("I bought a car for sixty nine thousand dollars."));
            Assert.AreEqual("I have to find 104 th room", ConvertToNumbers.ParseNumbers("I have to find one hundred four th room."));
        }

        [Test]
        public void TestNegative()
        {
            Assert.AreEqual("I got -23669 dollars in my wallet", ConvertToNumbers.ParseNumbers("I got minus twenty three thousand six hundred sixty nine dollars in my wallet."));
            Assert.AreEqual("Alaska hit -43 degrees last night", ConvertToNumbers.ParseNumbers("Alaska hit minus forty three degrees last night."));
            Assert.AreEqual("Parking lot is at the -6 th floor", ConvertToNumbers.ParseNumbers("Parking lot is at the minus six th floor."));
        }

        [Test]
        public void TestNumberAtTheBeginning()
        {
            Assert.AreEqual("49 is not my password", ConvertToNumbers.ParseNumbers("Forty nine is not my password."));
            Assert.AreEqual("-49 is not my password", ConvertToNumbers.ParseNumbers("Minus forty nine is not my password."));
            Assert.AreEqual("2001 is my birthyear", ConvertToNumbers.ParseNumbers("Two thousand one is my birthyear."));
        }

        [Test, Ignore("to be fixed")]
        public void TestNumberAtTheEnd()
        {
            Assert.AreEqual("some number 69", ConvertToNumbers.ParseNumbers("some number sixty nine."));
            Assert.AreEqual("different number 19", ConvertToNumbers.ParseNumbers("different number nineteen."));
            Assert.AreEqual("other number -72", ConvertToNumbers.ParseNumbers("some number minus seventy two."));
        }
    }
}