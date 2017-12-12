using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Test
	{		
		// тестирование распределения
		public static void Frequency (double begin, double end, double[] arr, out int[] realData, out double scale)
		{
			double biggestDigit = 0;
			biggestDigit = 0;
			realData = new int[10];
			// задание диапазона распределения:
			double[] inV = new double[10];
			inV [0] = begin;
			for (int x = 1; x < 10; x++) inV [x] = end - (end - begin) / 10 * (10 - x);
			// определение в каком диапазоне находится число:
			int[] freq = new int[10];
			foreach (double elem in arr) for (int x = 0; x < 10; x++) if (elem < inV [x]) { freq [x]++; break; }
			// определение максимального числа для задания мастшаба:
			foreach (double number in freq) if (number > biggestDigit) biggestDigit = number;
			scale = biggestDigit / arr.Length;
			// подгонка чисел для нормального отображения на графике:
			for (int x = 0; x < 10; x++) realData [x] = Convert.ToInt32 ((freq [x] * 200) / biggestDigit);
		}

		// вычисление математического ожидания и дисперсии
		public static void MathAndDisp (double[] numbers, out double MathW, out double Disp)  
		{
			MathW = numbers.Sum() / Convert.ToDouble(numbers.Length-1);  // математическое ожидание
			Disp = Math.Round (numbers.Sum(s => s * s) / 
				Convert.ToDouble(numbers.Length - MathW * MathW), 4); // дисперсия
			MathW = Math.Round (MathW, 4);
		}
	}
}