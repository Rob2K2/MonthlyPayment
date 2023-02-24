using Common.Helpers;
using Xunit;

namespace Tests.LCDTests
{
    public class LCDTests
    {
        private readonly INumberLCD _numberLCD;

        public LCDTests()
        {
            _numberLCD = new NumberLCD();
        }

        [Fact]
        public void TestNumberZeroToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[2] + '\n' + LCD.Leds[3];

            var actual = _numberLCD.NumberToLCD(0);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberOneToLCDstring()
        {
            var expected = LCD.Leds[0] + '\n' + LCD.Leds[7] + '\n' + LCD.Leds[7];

            var actual = _numberLCD.NumberToLCD(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberTwoToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[5] + '\n' + LCD.Leds[6];

            var actual = _numberLCD.NumberToLCD(2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberThreeToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[5] + '\n' + LCD.Leds[5];

            var actual = _numberLCD.NumberToLCD(3);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberFourToLCDstring()
        {
            var expected = LCD.Leds[0] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[7];

            var actual = _numberLCD.NumberToLCD(4);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberFiveToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[6] + '\n' + LCD.Leds[5];

            var actual = _numberLCD.NumberToLCD(5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberSixToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[6] + '\n' + LCD.Leds[3];

            var actual = _numberLCD.NumberToLCD(6);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberSevenToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[7] + '\n' + LCD.Leds[7];

            var actual = _numberLCD.NumberToLCD(7);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberEightToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[3];

            var actual = _numberLCD.NumberToLCD(8);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberNineToLCDstring()
        {
            var expected = LCD.Leds[1] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[5];

            var actual = _numberLCD.NumberToLCD(9);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberTenToLCDstring()
        {
            var expected = LCD.Leds[0] + LCD.Leds[1] + '\n' + LCD.Leds[7] + LCD.Leds[2] + '\n' + LCD.Leds[7] + LCD.Leds[3];

            var actual = _numberLCD.NumberToLCD(10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumberThousandToLCDstring()
        {
            // Arrange
            var expected = LCD.Leds[0] + LCD.Leds[1] + LCD.Leds[1] + LCD.Leds[1] + '\n' + LCD.Leds[7] + LCD.Leds[2] + LCD.Leds[2] + LCD.Leds[2] + '\n' + LCD.Leds[7] + LCD.Leds[3] + LCD.Leds[3] + LCD.Leds[3];
            // Act
            var actual = _numberLCD.NumberToLCD(1000);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, "    _  _  _ \n  || || || |\n  ||_||_||_|")]
        [InlineData(10, "    _ \n  || |\n  ||_|")]
        [InlineData(0, " _ \n| |\n|_|")]
        public void TestNumberToLCDstring(int number, string expected)
        {

            var actual = _numberLCD.NumberToLCD(number);

            Assert.Equal(expected, actual);
        }
    }
}
