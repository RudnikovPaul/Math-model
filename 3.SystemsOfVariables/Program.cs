using System;
using System.Collections.Generic;

namespace Job_3
{
	class MainClass
	{
		static Mathem maths = new Mathem();

		// задаем начальные значения:
		private static readonly double[,] ProbMatrix = { { 0.12, 0.22, 0.06 }, 
			{ 0.04, 0.12, 0.14 }, { 0.13, 0.13, 0.04 } };
		private static double[] Xvars = { 7.3, 9, 13.8 };
		private static double[] Yvars = { 0.2, 2.6, 6.4 };
		
		private static List<double> XRowList = new List<double>();
		private static List<double> YRowList = new List<double>();
		private static List<double> coordinates = new List<double>();

		public static void Main (string[] args)
		{
			CalculateRows();
			double X, Y;
			for (var i = 0; i < 100; i++)  // генерируем случайные числа
			{				
				maths.Rand(XRowList, Xvars, out X);
				maths.Rand(YRowList, Yvars, out Y);
				coordinates.Add(X);
				coordinates.Add(Y);
			}
			analyze();
		}

		private static void CalculateRows()
		{
			XRowList = maths.Series(ProbMatrix, true);
			YRowList = maths.Series(ProbMatrix, false);
		}

		private static void analyze()  //  вывод значений оценок
		{
			Console.WriteLine ("M(X)  = " + maths.Maths(Xvars, XRowList, true));
			Console.WriteLine ("M(Y)  = " + maths.Maths(Yvars, XRowList, false));
			Console.WriteLine ("D(X)  = " + maths.Dis(Xvars, XRowList, true));
			Console.WriteLine ("D(Y)  = " + maths.Dis(Yvars, YRowList, false));
			Console.WriteLine ("M(XY) = " + maths.MathXY(Xvars, Yvars, ProbMatrix));
			Console.WriteLine ("corr  = " + maths.Correlation());

			Distribution(maths.Density(coordinates, true), Xvars, "Распределение X");
			Distribution(maths.Density(coordinates, false), Yvars, "Распределение Y");
			XYDistribution(maths.XYDensity(coordinates, Xvars, Yvars), "Плотность XY");
		}

		private static void Distribution(List<double> Density, 
			double[] valueList, string chartName)
		{
			Console.WriteLine (chartName + ": ");
			for (var i = 0; i < Density.Count; i++)
				Console.WriteLine (valueList[i].ToString() + "   " + Density[i]);
		}

		private static void XYDistribution(List<double> Density, string chartName)
        {
            string[] XYvars = {"7.3|0.2", "7.3|2.6", "7.3|6.4", 
			"9|0.2", "9|2.6", "9|6.4", "13.8|0.2", "13.8|2.6", "13.8|6.4"};
            Console.WriteLine (chartName + ": ");
            for (var i = 0; i < Density.Count; i++)
            	Console.WriteLine (XYvars[i] + "   " + Density[i]);
        }
	}
}