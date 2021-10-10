using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public class NumberLCD : INumberLCD
    {
        private LCD merge(LCD a, LCD b)
        {
            string[] f = new[] { "", "", "" };

            f[0] = a.Filas[0] + b.Filas[0];
            f[1] = a.Filas[1] + b.Filas[1];
            f[2] = a.Filas[2] + b.Filas[2];

            return new LCD(f);
        }

        public string NumberToLCD(int numero)
        {
            var result = new LCD(new[] { "", "", "" });
            foreach (var digito in numero.ToString())
            {
                result = merge(result, LCD.Digitos[digito]);
            }
            return result.ToString();
        }

        public string LCDtoNumber(string[] code)
        {
            string lcdCode = string.Empty;

            for (int j = 0; j < code[0].Length; j += 3)
            {
                var top = code[0].Substring(j, 3);
                var mid = code[1].Substring(j, 3);
                var bot = code[2].Substring(j, 3);

                var lcdKey = LCD.Digitos.FirstOrDefault(x => x.Value.Filas.SequenceEqual(new LCD(new string[] { top, mid, bot }).Filas)).Key;
                lcdCode += lcdKey;
            }

            return lcdCode;
        }
    }
}
