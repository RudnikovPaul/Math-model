using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Test
	{
		static double biggestDigit = 0;
		// тестирование распределения
		public static void Frequency (double[] arr, out int[] realData, out double scale)  
		{
			biggestDigit = 0;
			realData = new int[10];
			// задание диапазона распределения:
			double[] inV = {0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,1.0};
			int[] freq = new int[10];
			// определение в каком диапазоне находится число:
			foreach (double elem in arr) 
				for (int x = 0; x < 10; x++) 
					if (elem < inV [x]) { freq [x]++; break; }  
			// определение максимального числа для задания мастшаба:
			foreach (double number in freq)
				if (number > biggestDigit) 
					biggestDigit = number;
			scale = biggestDigit / arr.Length;

			// подгонка чисел для нормального отображения на графике:
			for (int x = 0; x < 10; x++) 
				realData [x] = Convert.ToInt32 ((freq [x] * 200) / biggestDigit);  
		}

		// тестирование независимости
		public static string Independency(double[] numLis, int val) 
		{
			double sum = 0;
			// оцениваем взаимосвязь между числами с определенным шагом:
			for (int i = 0; i < numLis.Length - val; i++)
				sum += numLis [i] * numLis [i + val];
			// при увеличении числа опытом коэффициент корреляции должен стремиться к нулю:
			var R = (12 * sum / (numLis.Length - val)) - 3;  
			if (R < -1)	R = -1;
			return R.ToString ();
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