using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Generate
	{
		public static double[] squareMethod (int amount)
		{
			double[] values = new double[amount];
            var rnd = new Random();
            var num4Digit = rnd.Next(1000, 10000);
            var i = 0;
            do
            {
                num4Digit = num4Digit*num4Digit;
                var num4DigitStr = num4Digit.ToString();
                while (num4DigitStr.Length < 8) num4DigitStr = "0" + num4DigitStr;                    
				num4Digit = int.Parse(num4DigitStr.Substring(2, 4));
				var value = ((double)(num4Digit) / 10000);
                values[i] = value;
            } while (++i < amount);
			return values;
		}

		public static double[] multiplyMethod (int m, int k)
		{
			double[] values = new double[m-1];
			values[0] = 1.0;

			double[] results = new double[m];
			results[0] = (double)1/m;

            double Ai;
            for (int i = 1; i < m-1; i++)
            {
                Ai = (k * values[i - 1]) % m;
                values[i] = Ai;
                results[i] = Ai / m;
            }
			return results;
		}
	}
}

