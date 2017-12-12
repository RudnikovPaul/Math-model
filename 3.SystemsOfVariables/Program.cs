using System;
using System.Collections.Generic;

namespace Job_3
{
	class MainClass
	{
		static Mathem maths = new Mathem();
		private static readonly double[,] probabilityMatrix = { { 0.12, 0.22, 0.06 }, { 0.04, 0.12, 0.14 }, { 0.13, 0.13, 0.04 } };
		private static double[] Xvars = { 7.3, 9, 13.8 };
		private static double[] Yvars = { 0.2, 2.6, 6.4 };
		private static string[] XYvars = {"7.3|0.2", "7.3|2.6", "7.3|6.4", "9|0.2", "9|2.6", "9|6.4", "13.8|0.2", "13.8|2.6", "13.8|6.4"};
		private static List<double> XRowList = new List<double>();
		private static List<double> YRowList = new List<double>();
		private static List<double> coordinates = new List<double>();

		public static void Main (string[] args)
		{
			CalculateRows();
			for (var i = 0; i < 100; i++) RandXY();
			analyze();
		}

		private static void CalculateRows()
		{
			XRowList = maths.Series(probabilityMatrix, true);
			YRowList = maths.Series(probabilityMatrix, false);
		}

		private static void RandXY()
		{
			double X, Y;
			maths.Rand(XRowList, Xvars, out X);
			maths.Rand(YRowList, Yvars, out Y);
			coordinates.Add(X);
			coordinates.Add(Y);
		}

		private static void analyze()
		{
			Console.WriteLine ("M(X)  = " + maths.Maths(Xvars, XRowList, true));
			Console.WriteLine ("M(Y)  = " + maths.Maths(Yvars, XRowList, false));
			Console.WriteLine ("D(X)  = " + maths.Dis(Xvars, XRowList, true));
			Console.WriteLine ("D(Y)  = " + maths.Dis(Yvars, YRowList, false));
			Console.WriteLine ("M(XY) = " + maths.MathXY(Xvars, Yvars, probabilityMatrix));
			Console.WriteLine ("corr  = " + maths.Correlation());

			Distribution(maths.Density(coordinates, true), Xvars, "Распределение X");
			Distribution(maths.Density(coordinates, false), Yvars, "Распределение Y");
			XYDistribution(maths.XYDensity(coordinates, Xvars, Yvars), XYvars, "Плотность XY");
		}

		private static void Distribution(List<double> DensinyList, double[] valueList, string chartName)
		{
			Console.WriteLine (chartName + ": ");
			for (var i = 0; i < DensinyList.Count; i++)
				Console.WriteLine (valueList[i].ToString() + "     " + DensinyList[i]);
		}

		private static void XYDistribution(List<double> DensinyList, string[] valueList, string chartName)
        {
            Console.WriteLine (chartName + ": ");
            for (var i = 0; i < DensinyList.Count; i++)
            	Console.WriteLine (valueList[i] + "     " + DensinyList[i]);
        }
	}
}