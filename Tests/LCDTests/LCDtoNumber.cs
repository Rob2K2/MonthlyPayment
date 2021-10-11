using Common.Helpers;
using System;
using Xunit;

namespace Tests.LCDTests
{
    public class LCDtoNumber
    {
        private readonly INumberLCD _numberLCD;

        public LCDtoNumber()
        {
            _numberLCD = new NumberLCD();
        }

        [Fact]
        public void TestLCDZeroTostring()
        {
            var expected = "0";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[2] + '\n' + LCD.Leds[3]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDOneTostring()
        {
            var expected = "1";

            string[] LED = (LCD.Leds[0] + '\n' + LCD.Leds[7] + '\n' + LCD.Leds[7]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDTwoTostring()
        {
            var expected = "2";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[5] + '\n' + LCD.Leds[6]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDThreeTostring()
        {
            var expected = "3";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[5] + '\n' + LCD.Leds[5]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDFourTostring()
        {
            var expected = "4";

            string[] LED = (LCD.Leds[0] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[7]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDFiveTostring()
        {
            var expected = "5";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[6] + '\n' + LCD.Leds[5]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDSixTostring()
        {
            var expected = "6";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[6] + '\n' + LCD.Leds[3]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDSevenTostring()
        {
            var expected = "7";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[7] + '\n' + LCD.Leds[7]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDEightTostring()
        {
            var expected = "8";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[3]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDNineTostring()
        {
            var expected = "9";

            string[] LED = (LCD.Leds[1] + '\n' + LCD.Leds[3] + '\n' + LCD.Leds[5]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDTenTostring()
        {
            var expected = "10";

            string[] LED = (LCD.Leds[0] + LCD.Leds[1] + '\n' + LCD.Leds[7] + LCD.Leds[2] + '\n' + LCD.Leds[7] + LCD.Leds[3]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDThousandTostring()
        {
            var expected = "1000";

            string[] LED = (LCD.Leds[0] + LCD.Leds[1] + LCD.Leds[1] + LCD.Leds[1] + '\n' + LCD.Leds[7] + LCD.Leds[2] + LCD.Leds[2] + LCD.Leds[2] + '\n' + LCD.Leds[7] + LCD.Leds[3] + LCD.Leds[3] + LCD.Leds[3]).Split('\n');
            var actual = _numberLCD.LCDtoNumber(LED);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLCDInvalidTostring()
        {
            string[] LED = ("bad string").Split('\n');

            Assert.Throws<FormatException>(() => _numberLCD.LCDtoNumber(LED));
        }
    }
}
