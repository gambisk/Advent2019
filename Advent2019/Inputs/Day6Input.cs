using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2019.Inputs
{
	public static class Day6Input
	{
		public static List<string> GetInput()
		{
			string[] lines = System.IO.File.ReadAllLines(@"C:\code\workspace\advent\Advent2019\Inputs\Raw\Day6.txt");
			return lines.ToList();
		}

		public static List<string> GetTestString()
		{
			return new List<string> {
			"COM)B",
			"B)C",
			"C)D",
			"D)E",
			"E)F",
			"B)G",
			"G)H",
			"D)I",
			"E)J",
			"J)K",
			"K)L",
			"K)YOU",
			"I)SAN"
				};
		}
	}
}

