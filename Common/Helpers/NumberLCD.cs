using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public class NumberLCD : INumberLCD
    {
        private LCD merge(LCD a, LCD b)
        {
            string[] f = new[] { "", "", "" };

            f[0] = a.Rows[0] + b.Rows[0];
            f[1] = a.Rows[1] + b.Rows[1];
            f[2] = a.Rows[2] + b.Rows[2];

            return new LCD(f);
        }

        public string NumberToLCD(int number)
        {
            var result = new LCD(new[] { "", "", "" });
            foreach (var digito in number.ToString())
            {
                result = merge(result, LCD.Digits[digito]);
            }
            return result.ToString();
        }

        //public string[] NumberToArray(int number)
        //{
        //    var result = new LCD(new[] { "", "", "" });
        //    foreach (var digito in number.ToString())
        //    {
        //        result = merge(result, LCD.Digits[digito]);
        //    }
        //    return result;
        //}

        public string LCDtoNumber(string[] code)
        {
            string lcdCode = string.Empty;

            for (int j = 0; j < code[0].Length; j += 3)
            {
                var top = code[0].Substring(j, 3);
                var mid = code[1].Substring(j, 3);
                var bot = code[2].Substring(j, 3);

                var lcdKey = LCD.Digits.FirstOrDefault(x => x.Value.Rows.SequenceEqual(new LCD(new string[] { top, mid, bot }).Rows)).Key;
                lcdCode += lcdKey;
            }

            return lcdCode;
        }
    }
}
