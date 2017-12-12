using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Generate
	{
		// генератор случайных чисел по методу середины квадрата
		public static double[] squareMethod (int amount)
		{
			double[] values = new double[amount];
            var rnd = new Random();
            var num4Digit = rnd.Next(1000, 10000); // выбираем случайное число
            var i = 0;
            do
            {
            	
                num4Digit = num4Digit*num4Digit; // возводим случайное число в квадрат
                var num4DigitStr = num4Digit.ToString();
                // добавление нулей перед числом для достижения длины в 8 символов:
                while (num4DigitStr.Length < 8) num4DigitStr = "0" + num4DigitStr;
				num4Digit = int.Parse(num4DigitStr.Substring(2, 4)); // вычленение четырех цифр из середины числа
                values[i] = ((double)(num4Digit) / 10000); // для соблюдения масштаба уменьшаем число
            } while (++i < amount);
			return values;
		}

		// генератор случайных чисел по мультипликационно-конгруэнтному методу 
		public static double[] multiplyMethod (int m, int k)
		{
			double[] values = new double[m-1];
			values[0] = 1.0;

			double[] results = new double[m];
			results[0] = (double)1/m;  // определяется первое случайное число A1

			// суть алгоритма:
			//  - умножаем предыдущее случайное число на множительный коэффициент,
			//  - делим результат на модуль с получением остатка,
			//  - имеем очередное 'случайное' число.
            double Ai;
            for (int i = 1; i < m-1; i++)  
            {
            	// Ai = (kAi -1) mod m, i = 1, 2,..., m - модуль, k - множительный коэффициент
                Ai = (k * values[i - 1]) % m;  
                values[i] = Ai;
                results[i] = Ai / m;
            }
			return results;
		}
	}
}

