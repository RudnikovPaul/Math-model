using System;
using System.Linq;

namespace Randoms_analyze
{
	public static class Generate
	{
		public static double[] equalGenerator (int size, double begin, double end)
		{
			Random r = new Random();
			double[] numbers = new double [size];
			for (int x = 0; x < size; x++) numbers [x] = r.NextDouble() * (end - begin) + begin;
			return numbers;
		}
	}
}