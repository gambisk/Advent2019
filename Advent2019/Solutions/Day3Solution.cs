using Advent2019.Inputs;
using System;

namespace Advent2019.Solutions
{
	public static class Day3Solution
	{
		public static void Solve()
		{
			TangledWires tangledWires = new TangledWires();
			var wire1 = tangledWires.GenerateWire(Day3Inputs.Line1);
			var wire2 = tangledWires.GenerateWire(Day3Inputs.Line2);

			Console.WriteLine(tangledWires.FindIntersections(wire1, wire2));
		}
	}
}
