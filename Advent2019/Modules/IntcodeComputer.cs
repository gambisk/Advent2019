using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2019
{
	public class IntcodeComputer
	{
		private List<int> Memory { get; set; }

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

		public List<int> ExecuteProgram()
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

				switch (opcode)
				{
					case 1:
						instructionPointer = InstructionOne(instructionPointer);
						break;
					case 2:
						instructionPointer = InstructionTwo(instructionPointer);
						break;
					case 3:
						instructionPointer = InstructionThree(instructionPointer);
						break;
					case 4:
						instructionPointer = InstructionFour(instructionPointer);
						break;
					case 5:
						instructionPointer = InstructionFive(instructionPointer);
						break;
					case 6:
						instructionPointer = InstructionSix(instructionPointer);
						break;
					case 7:
						instructionPointer = InstructionSeven(instructionPointer);
						break;
					case 8:
						instructionPointer = InstructionEight(instructionPointer);
						break;
				}
			}

			return Memory;
		}
		
		public string GetOutput()
		{
			StringBuilder builder = new StringBuilder();
			foreach (var item in Memory)
			{
				if (builder.Length > 0)
				{
					builder.Append(",");
				}

				builder.Append(item.ToString());
			}

			return builder.ToString();
		}

		private int GetParameter(int instructionPointer, int paramNumber)
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
		private int InstructionOne(int instructionPointer)
		{

			var param1 = GetParameter(instructionPointer, 1);
			var param2 = GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];
			Memory[resultPointer] = param1 + param2;
			return instructionPointer + 4;
		}
		
		//Multiply
		private int InstructionTwo(int instructionPointer)
		{
			var param1 = GetParameter(instructionPointer, 1);
			var param2 = GetParameter(instructionPointer, 2);
			var resultPointer = Memory[instructionPointer + 3];

			Memory[resultPointer] = param1 * param2;
			return instructionPointer + 4;
		}

		//Input
		private int InstructionThree(int instructionPointer)
		{
			var resultPointer = Memory[instructionPointer + 1];
			Console.WriteLine("Input Required: ");
			int input = int.Parse(Console.ReadLine());
			Memory[resultPointer] = input;
			return instructionPointer + 2;
		}

		//Output
		private int InstructionFour(int instructionPointer)
		{
			var param = GetParameter(instructionPointer, 1);
			Console.WriteLine(param);
			return instructionPointer + 2;
		}

		//jump if true
		private int InstructionFive(int instructionPointer)
		{
			var param = GetParameter(instructionPointer, 1);
			if(param != 0)
			{
				var param2 = GetParameter(instructionPointer, 2);
				return param2;
			}

			return instructionPointer + 3;
		}

		//jump if false
		private int InstructionSix(int instructionPointer)
		{
			var param = GetParameter(instructionPointer, 1);
			if (param == 0)
			{
				var param2 = GetParameter(instructionPointer, 2);
				return param2;
			}

			return instructionPointer + 3;
		}

		//jump if less
		private int InstructionSeven(int instructionPointer)
		{
			var param1 = GetParameter(instructionPointer, 1);
			var param2 = GetParameter(instructionPointer, 2);
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
		private int InstructionEight(int instructionPointer)
		{
			var param1 = GetParameter(instructionPointer, 1);
			var param2 = GetParameter(instructionPointer, 2);
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
