using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019
{
	public class IntcodeComputerVirtual
	{
		private ConcurrentQueue<int> Inputs { get; set; }

		private ConcurrentQueue<int> Outputs { get; set; }

		private List<int> Memory { get; set; }

		public string Name { get; }

		public IntcodeComputerVirtual(ConcurrentQueue<int> input, ConcurrentQueue<int> output, string name)
		{
			Inputs = input;
			Outputs = output;
			Memory = new List<int>();
			Name = name;
		}

		public List<int> CompileProgram(string program)
		{
			var array = program.Split(",");
			List<int> compiled = new List<int>();
			foreach (var numberString in array)
			{
				int i = int.Parse(numberString);
				compiled.Add(i);
			}

			return compiled;
		}

		public void SetMemory(List<int> memory)
		{
			Memory = memory;
		}

		public async Task ExecuteProgram()
		{
			var instructionPointer = 0;
			while (instructionPointer < Memory.Count)
			{
				var instruction = Memory[instructionPointer];
				if (instruction == 99)
				{
					break;
				}

				var opcode = instruction % 100;
				Console.WriteLine($"Task{Name}: instruction:{opcode}");

				switch (opcode)
				{
					case 1:
						instructionPointer = await InstructionOne(instructionPointer);
						break;
					case 2:
						instructionPointer = await InstructionTwo(instructionPointer);
						break;
					case 3:
						instructionPointer = await InstructionThree(instructionPointer);
						break;
					case 4:
						instructionPointer = await InstructionFour(instructionPointer);
						break;
					case 5:
						instructionPointer = await InstructionFive(instructionPointer);
						break;
					case 6:
						instructionPointer = await InstructionSix(instructionPointer);
						break;
					case 7:
						instructionPointer = await InstructionSeven(instructionPointer);
						break;
					case 8:
						instructionPointer = await InstructionEight(instructionPointer);
						break;
				}
			}
		}

		private async Task<int> GetParameter(int instructionPointer, int paramNumber)
		{
			var instruction = Memory[instructionPointer].ToString().ToCharArray();
			Array.Reverse(instruction);
			int param;
			var index = paramNumber + 1;
			if (index <instruction.Length && instruction[index] == '1')
			{
				param = Memory[instructionPointer + paramNumber];
			}
			else
			{
				param = Memory[Memory[instructionPointer + paramNumber]];
			}

			return param;
		}

		//Add
		private async Task<int> InstructionOne(int instructionPointer)
		{

			var param1 = await GetParameter(instructionPointer, 1);
			var param2 = await GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];
			Memory[resultPointer] = param1 + param2;
			return instructionPointer + 4;
		}
		
		//Multiply
		private async Task<int> InstructionTwo(int instructionPointer)
		{
			var param1 = await GetParameter(instructionPointer, 1);
			var param2 = await GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];

			Memory[resultPointer] = param1 * param2;
			return instructionPointer + 4;
		}

		//Input
		private async Task<int> InstructionThree(int instructionPointer)
		{
			int input = 0;
			while (true)
			{
				lock (Inputs)
				{
					if (!Inputs.IsEmpty)
					{
						if (Inputs.TryDequeue(out input))
						{
							var resultPointer = Memory[instructionPointer + 1];
							Memory[resultPointer] = input;
							break;
						}
					}
				}

				Thread.Sleep(10);
			}

			return instructionPointer + 2;
		}

		//Output
		async Task<int> InstructionFour(int instructionPointer)
		{
			var param = await GetParameter(instructionPointer, 1);
			lock (Outputs)
			{
				Outputs.Enqueue(param);
			}
			return instructionPointer + 2;
		}

		//jump if true
		async Task<int> InstructionFive(int instructionPointer)
		{
			var param = await GetParameter(instructionPointer, 1);
			if(param != 0)
			{
				var param2 = await GetParameter(instructionPointer, 2);
				return param2;
			}

			return instructionPointer + 3;
		}

		//jump if false
		async Task<int> InstructionSix(int instructionPointer)
		{
			var param = await GetParameter(instructionPointer, 1);
			if (param == 0)
			{
				var param2 = await GetParameter(instructionPointer, 2);
				return param2;
			}

			return instructionPointer + 3;
		}

		//jump if less
		async Task<int> InstructionSeven(int instructionPointer)
		{
			var param1 = await GetParameter(instructionPointer, 1);
			var param2 = await GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];

			if (param1 < param2)
			{
				Memory[resultPointer] = 1;
			}
			else
			{
				Memory[resultPointer] = 0;
			}

			return instructionPointer + 4;
		}

		//jump if equal
		async Task<int> InstructionEight(int instructionPointer)
		{
			var param1 = await GetParameter(instructionPointer, 1);
			var param2 = await GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];

			if (param1 == param2)
			{
				Memory[resultPointer] = 1;
			}
			else
			{
				Memory[resultPointer] = 0;
			}

			return instructionPointer + 4;
		}
	}
}
