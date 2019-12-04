using System.Collections.Generic;
using System.Text;

namespace Advent2019
{
	public class IntcodeComputer
	{
		public List<int> InitializeMemory(string program)
		{
			var array = program.Split(",");
			List<int> numbers = new List<int>();
			foreach (var numberString in array)
			{
				int i = int.Parse(numberString);
				numbers.Add(i);
			}

			return numbers;
		}

		public List<int> ExecuteProgram(List<int> memory)
		{
			var instructionPointer = 0;
			while(instructionPointer < memory.Count)
			{
				var instruction = memory[instructionPointer];
				if (instruction == 99)
				{
					break;
				}

				var param1 = memory[instructionPointer + 1];
				var param2 = memory[instructionPointer + 2];
				var resultPointer = memory[instructionPointer + 3];
				if(instruction == 1)
				{
					memory[resultPointer] = memory[param1] + memory[param2];
					instructionPointer = instructionPointer + 4;
				}
				else if(instruction == 2)
				{
					memory[resultPointer] = memory[param1] * memory[param2];
					instructionPointer = instructionPointer + 4;
				}
			}

			return memory;
		}

		public string GetOutput(List<int> memory)
		{
			StringBuilder builder = new StringBuilder();
			foreach(var item in memory)
			{
				if (builder.Length > 0)
				{
					builder.Append(",");
				}

				builder.Append(item.ToString());
			}

			return builder.ToString();
		}
	}
}
