using Advent2019.Inputs.Raw;
using Advent2019.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2019.Solutions
{
	public static class Day8Solution
	{
		public static void Solve()
		{
			var decoder = new SIFDecoder(Day8Input.Input, 25, 6);
			decoder.Decode();
			var x = decoder.LeastZeros();
			var ones = x.Where(i => i == 1).Count();
			var twos = x.Where(i => i == 2).Count();

			Console.WriteLine(ones * twos);


			}

		public static void Part2()
		{
			var decoder = new SIFDecoder(Day8Input.Input, 25, 6);
			decoder.Decode();
			decoder.Render();
		}
	}
}
