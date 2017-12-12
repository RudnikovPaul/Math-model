using System;
using System.Collections.Generic;

namespace Job_3
{
	public class Mathem
	{
		private Random rnd = new Random();
		private double MX, MY, MXY;

		// генератор равномерно распределенных случайных чисел
		public double Rand(List<double> RowList, double[] Value)
		{
			var x = rnd.NextDouble();

			if (x <= RowList[0]) result = Value[0];
			else if (x > RowList[0] && x < RowList[0] + RowList[1]) return Value[1];
			else return Value[2];
		}

		// сумма матрицы по столбцам либо строкам
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

		// математическое ожидание для одного списка и дисперсия
		public void MathAndDis(double[] Value, List<double> RowList, bool dir, out double resultM, out double resultD)
		{
			double resultL = 0;

			for (var i = 0; i < 3; i++)	
			{
				resultL += Math.Pow(Value[i], 2) * RowList[i];
				resultM += Value[i] * RowList[i];
			}
			if (dir) MX = resultM;
			else MY = resultM;
			resultD = resultL - Math.Pow(resultL, 2);
		}

		// математическое ожидание для двух списков
		public double MathXY(double[] XValues, double[] YValues, double[,] ProbMatrix)
		{
			double result = 0;

			for (var i = 0; i < 3; i++)
				for (var j = 0; j < 3; j++)
					result += XValues[i] * YValues[j] * ProbMatrix[i, j];
			MXY = result;
			return result;
		}

		// определение плотности распределения для одного списка
		public List<double> Density(List<double> XY, bool dir)
		{
			var resultList = new List<double>();

			for (var i = 0; i < 3; i++) resultList.Add(0);
			foreach (var value in XY) {
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

		// определение плотности распределения для двух списков
		public List<double> XYDensity(List<double> XY, double[] XValue, double[] YValue)
		{
			var resultXYList = new List<double>();
			
			for (var i = 0; i < 9; i++) resultXYList.Add(0);
			for (var i = 0; i < XY.Count; i = i + 2)
			{
				var x = XY[i];
				var y = XY[i + 1];
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

		// определение корреляции
		public double Correlation()
		{ 
			return MXY - MX * MY;
		}
	}
}