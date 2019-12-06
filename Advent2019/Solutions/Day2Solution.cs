using Advent2019.Inputs;
using System;

namespace Advent2019.Solutions
{
	public static class Day2Solution
	{
		public static void Solve()
		{
			var intcode = new IntcodeComputer();

			for (int noun = 0; noun < 100; noun++)
			{
				for (int verb = 0; verb < 100; verb++)
				{
					var program = intcode.CompileProgram(Day2Input.Input);
					program[1] = noun;
					program[2] = verb;

					intcode.SetMemory(program);
					var executedProgram = intcode.ExecuteProgram();
					if (executedProgram[0] == 19690720)
					{
						Console.WriteLine($"noun:{noun}   verb:{verb}");
						return;
					}
				}
			}
		}
	}
}
