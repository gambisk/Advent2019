using Advent2019.Inputs;

namespace Advent2019.Solutions
{
	public static class Day5Solution
	{
		public static void Solve()
		{
			var intcode = new IntcodeComputer();
			var program = intcode.CompileProgram(Day5Inputs.Input);
			intcode.SetMemory(program);

			intcode.ExecuteProgram();
			intcode.GetOutput();
		}

		public static void Test()
		{
			var intcode = new IntcodeComputer();
			var program = intcode.CompileProgram(Day5Inputs.Test2);
			intcode.SetMemory(program);

			intcode.ExecuteProgram();
			intcode.GetOutput();
		}
	}
}
