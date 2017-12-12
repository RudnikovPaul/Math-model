using System;
using System.Collections.Generic;

namespace Job_3
{
	public class Mathem
	{
		private Random rnd = new Random();
		private double MX, MY, MXY;

		public void Rand(List<double> RowList, double[] Value, out double result)
		{
			var x = rnd.NextDouble();
			if (x <= RowList[0]) result = Value[0];
			else if (x > RowList[0] && x < RowList[0] + RowList[1]) result = Value[1];
			else result = Value[2];
		}

		public List<double> Series(double[,] matrix, bool dir)
		{
			var result = new List<double>();
			for (var i = 0; i < 3; i++)
			{
				double sir = 0;
				for (var j = 0; j < 3; j++)
				{
					if (dir) sir = sir + matrix[i, j]; 
					else sir = sir + matrix[j, i];
				}
				result.Add(sir);
			}
			return result;
		}

		public double Maths(double[] Value, List<double> RowList, bool dir)
		{
			double result = 0;
			for (var i = 0; i < 3; i++)	result += Value[i] * RowList[i];
			if (dir) MX = result;
			else MY = result;
			return result;
		}

		public double MathXY(double[] XValues, double[] YValues, double[,] probabilityMatrix)
		{
			double result = 0;
			for (var i = 0; i < 3; i++)
				for (var j = 0; j < 3; j++)
					result += XValues[i] * YValues[j] * probabilityMatrix[i, j];
			MXY = result;
			return result;
		}

		private double SquareMath(double[] Value, List<double> RowList)
		{
			double result = 0;
			for (var i = 0; i < 3; i++) result += Math.Pow(Value[i], 2) * RowList[i];
			return result;
		}

		public double Dis(double[] XValue, List<double> XRowList, bool dir)
		{
			if (dir) return SquareMath(XValue, XRowList) - Math.Pow(Maths(XValue, XRowList, true), 2);
			else return SquareMath(XValue, XRowList) - Math.Pow(Maths(XValue, XRowList, false), 2);
		}

		public List<double> Density(List<double> ResultXYofValueList, bool dir)
		{
			var resultList = new List<double>();
			for (var i = 0; i < 3; i++) resultList.Add(0);
			foreach (var value in ResultXYofValueList) {
				if (dir)
				{
					if (value == 7.3)  { resultList [0]++; break; }
					if (value == 9)   { resultList [1]++; break; }
					if (value == 13.8) { resultList [2]++; break; }
				}
				else
				{
					if (value == 0.2) { resultList [0]++; break; }
					if (value == 2.6) { resultList [1]++; break; }
					if (value == 6.4) { resultList [2]++; break; }
				}
			}
			return resultList;
		}

		public List<double> XYDensity(List<double> ResultXYofValueList, double[]XValue, double[]YValue)
		{
			var resultXYList = new List<double>();
			for (var i = 0; i < 9; i++) resultXYList.Add(0);
			for (var i = 0; i < ResultXYofValueList.Count; i = i + 2)
			{
				var x = ResultXYofValueList[i];
				var y = ResultXYofValueList[i + 1];
				for (var q = 0; q < 3; q++)
				{
					if (Equals(x, XValue[q]))
					{
						if (Equals(y, YValue[0])) resultXYList[q*3]++;
						else if (Equals(y, YValue[1])) resultXYList[q*3+1]++;
						else resultXYList[q*3+2]++;
					}
				}
			}
			return resultXYList;
		}

		public double Correlation()
		{ 
			return MXY - MX * MY;
		}
	}
}