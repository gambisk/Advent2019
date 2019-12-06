using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2019.Modules
{

	public class OrbitalMap
	{
		public Dictionary<string, string> Map { get; private set; }

		public void GenerateMap(List<string> list)
		{
			Map = new Dictionary<string, string>();

			foreach(var item in list)
			{
				var input = item.Split(')');
				Map.Add(input[1], input[0]);
			}
		}

		public int GetOrbitalCount(string input)
		{
			if (input == "COM")
				return 0;

			return 1 + GetOrbitalCount(Map[input]);
		}

		public string GetOrbitalPath(string input)
		{
			if (input == "COM")
			{
				return input;
			}

			return $"{input}|{GetOrbitalPath(Map[input])}";
		}
	}
}
