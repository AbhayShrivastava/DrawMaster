 // DecompilerFi decompiler from Assembly-CSharp.dll class: DouglasPeucker
using System;
using System.Collections.Generic;
using UnityEngine;

public static class DouglasPeucker
{
	public static void Main()
	{
	}

	public static IList<Vector2> DouglasPeuckerReduction(IList<Vector2> Points, double Tolerance)
	{
		if (Points == null || Points.Count < 3)
		{
			return Points;
		}
		int num = 0;
		int num2 = Points.Count - 1;
		List<int> pointIndexsToKeep = new List<int>();
		pointIndexsToKeep.Add(num);
		pointIndexsToKeep.Add(num2);
		while (Points[num].Equals(Points[num2]) && num2 > 0)
		{
			num2--;
		}
		DouglasPeuckerReduction(Points, num, num2, Tolerance, ref pointIndexsToKeep);
		List<Vector2> list = new List<Vector2>();
		pointIndexsToKeep.Sort();
		foreach (int item in pointIndexsToKeep)
		{
			list.Add(Points[item]);
		}
		return list;
	}

	private static void DouglasPeuckerReduction(IList<Vector2> points, int firstPoint, int lastPoint, double tolerance, ref List<int> pointIndexsToKeep)
	{
		double num = 0.0;
		int num2 = 0;
		for (int i = firstPoint; i < lastPoint; i++)
		{
			double num3 = PerpendicularDistance(points[firstPoint], points[lastPoint], points[i]);
			if (num3 > num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num > tolerance && num2 != 0)
		{
			pointIndexsToKeep.Add(num2);
			DouglasPeuckerReduction(points, firstPoint, num2, tolerance, ref pointIndexsToKeep);
			DouglasPeuckerReduction(points, num2, lastPoint, tolerance, ref pointIndexsToKeep);
		}
	}

	public static double PerpendicularDistance(Vector2 Point1, Vector2 Point2, Vector2 Point)
	{
		double num = Math.Abs(0.5 * (double)(Point1.x * Point2.y + Point2.x * Point.y + Point.x * Point1.y - Point2.x * Point1.y - Point.x * Point2.y - Point1.x * Point.y));
		double num2 = Math.Sqrt(Math.Pow(Point1.x - Point2.x, 2.0) + Math.Pow(Point1.y - Point2.y, 2.0));
		return num / num2 * 2.0;
	}
}
