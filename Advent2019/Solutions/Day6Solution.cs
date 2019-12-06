using Advent2019.Inputs;
using Advent2019.Modules;
using System;
using System.Linq;

namespace Advent2019.Solutions
{
	public static class Day6Solution
	{
		public static void Part1()
		{
			var orbitalMap = new OrbitalMap();
			orbitalMap.GenerateMap(Day6Input.GetInput());

			var total = 0;
			foreach(var item in orbitalMap.Map)
			{
				total += orbitalMap.GetOrbitalCount(item.Key);
			}

			Console.WriteLine(total);
		}

		public static void Part2()
		{
			var orbitalMap = new OrbitalMap();
			orbitalMap.GenerateMap(Day6Input.GetInput());

			var santaPath = orbitalMap.GetOrbitalPath("SAN");
			var youPath = orbitalMap.GetOrbitalPath("YOU");

			var santaList = santaPath.Split('|').ToList();
			var youList = youPath.Split('|').ToList();

			string commonPoint = string.Empty;
			foreach(var item in santaList)
			{
				if (youList.Contains(item))
				{
					commonPoint = item;
					break;
				}
			}

			var result = youList.IndexOf(commonPoint) + santaList.IndexOf(commonPoint) -2;


			Console.WriteLine(result);
		}
	}
}
