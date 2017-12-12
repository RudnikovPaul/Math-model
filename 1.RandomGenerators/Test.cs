using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Test
	{
		static double biggestDigit = 0;
		public static void Frequency (double[] arr, out int[] realData, out double scale)
		{
			biggestDigit = 0;
			realData = new int[10];
			double[] inV = {0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,1.0};
			int[] freq = new int[10];
			foreach (double elem in arr) for (int x = 0; x < 10; x++) if (elem < inV [x]) { freq [x]++; break; }

			foreach (double number in freq) if (number > biggestDigit) biggestDigit = number;
			scale = biggestDigit / arr.Length;

			for (int x = 0; x < 10; x++) realData [x] = Convert.ToInt32 ((freq [x] * 200) / biggestDigit);
		}

		public static string Independency(double[] numLis, int val)
		{
			double sum = 0;
			for (int i = 0; i < numLis.Length - val; i++) sum += numLis [i] * numLis [i + val];
			var R = (12 * sum / (numLis.Length - val)) - 3;
			if (R < -1)	R = -1;
			return "R = " + R.ToString ();
		}

		public static void MathAndDisp (double[] numbers, out double MathW, out double Disp)
		{
			MathW = numbers.Sum() / Convert.ToDouble(numbers.Length-1);
			Disp = Math.Round (numbers.Sum(s => s * s) / Convert.ToDouble(numbers.Length - MathW * MathW), 4);
			MathW = Math.Round (MathW, 4);
		}
	}
}