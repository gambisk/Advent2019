using Advent2019.Inputs;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Advent2019.Modules
{
	public class Amplifier
	{
		public async Task<Task> Amplify(ConcurrentQueue<int> input, ConcurrentQueue<int> output, string name)
		{
			var computer = new IntcodeComputerVirtual(input, output, name);
			var program = computer.CompileProgram(Day7Input.Input);
			computer.SetMemory(program);

			return computer.ExecuteProgram();
		}
	}
}
