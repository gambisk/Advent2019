using Advent2019.Inputs;
using Advent2019.Modules;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
	public static class Day7Solution
	{
		public static void SolvePart1()
		{
			var permutations = GetPermutations<int>(new List<int> { 0, 1, 2, 3, 4 }, 5);
			int biggest = 0;
			foreach(var permutation in permutations)
			{
				var permutationList = permutation.ToList();
				var ampA = new Amplifier();
				var ampB = new Amplifier();
				var ampC = new Amplifier();
				var ampD = new Amplifier();
				var ampE = new Amplifier();

				//var out1 = ampA.AmpPart1(permutationList[0], 0);
				//var out2 = ampB.AmpPart1(permutationList[1], out1);
				//var out3 = ampC.AmpPart1(permutationList[2], out2);
				//var out4 = ampD.AmpPart1(permutationList[3], out3);
				//var out5 = ampE.AmpPart1(permutationList[4], out4);

				//if (out5 > biggest)
				//	biggest = out5;
			}

			Console.WriteLine(biggest.ToString());
		}

		public async static void SolvePart2()
		{
			try
			{
				var permutations = GetPermutations<int>(new List<int> { 5, 6, 7, 8, 9 }, 5);
				int biggest = 0;
				foreach (var permutation in permutations)
				{
					var permutationList = permutation.ToList();

					var inputA = new ConcurrentQueue<int>();
					inputA.Enqueue(permutationList[0]);
					inputA.Enqueue(0);
					var inputB = new ConcurrentQueue<int>();
					inputB.Enqueue(permutationList[1]);

					var inputC = new ConcurrentQueue<int>();
					inputC.Enqueue(permutationList[2]);

					var inputD = new ConcurrentQueue<int>();
					inputD.Enqueue(permutationList[3]);

					var inputE = new ConcurrentQueue<int>();
					inputE.Enqueue(permutationList[4]);

					var ampA = new IntcodeComputerVirtual(inputA, inputB, "A");
					var ampB = new IntcodeComputerVirtual(inputB, inputC, "B");
					var ampC = new IntcodeComputerVirtual(inputC, inputD, "C");
					var ampD = new IntcodeComputerVirtual(inputD, inputE, "D");
					var ampE = new IntcodeComputerVirtual(inputE, inputA, "E");

					var programA = ampA.CompileProgram(Day7Input.Input);
					var programB = ampB.CompileProgram(Day7Input.Input);
					var programC = ampC.CompileProgram(Day7Input.Input);
					var programD = ampD.CompileProgram(Day7Input.Input);
					var programE = ampE.CompileProgram(Day7Input.Input);

					ampA.SetMemory(programA);
					ampB.SetMemory(programB);
					ampC.SetMemory(programC);
					ampD.SetMemory(programD);
					ampE.SetMemory(programE);





					//List<Task> tasks = new List<Task>();
					//tasks.Add(await ampA.Amplify(inputA, inputB, "A"));
					//tasks.Add(await ampB.Amplify(inputB, inputC, "B"));
					//ampC.Amplify(inputC, inputD, "C");
					//ampD.Amplify(inputD, inputE, "D");
					//ampE.Amplify(inputE, inputA, "E");


					var a = Task.Run(() => ampA.ExecuteProgram());
					var b = Task.Run(() => ampB.ExecuteProgram());
					var c = Task.Run(() => ampC.ExecuteProgram());
					var d = Task.Run(() => ampD.ExecuteProgram());
					var e = Task.Run(() => ampE.ExecuteProgram());

					Task.WaitAll(a, b,c,d,e);
					Console.WriteLine("done");

					int output;
					if (inputA.TryDequeue(out output))
					{
						if (output > biggest)
						{
							biggest = output;
						}
					}
				}

				Console.WriteLine(biggest);
			}
			catch(Exception ex)
			{

			}
		}

		public static void Test()
		{
			var ampA = new Amplifier();
			var ampB = new Amplifier();
			var ampC = new Amplifier();
			var ampD = new Amplifier();
			var ampE = new Amplifier();

			//var out1 = ampA.AmpPart1(4, 0);
			//var out2 = ampB.AmpPart1(3, out1);
			//var out3 = ampC.AmpPart1(2, out2);
			//var out4 = ampD.AmpPart1(1, out3);
			//var out5 = ampE.AmpPart1(0, out4);

			//Console.WriteLine($"Final Output: {out5}");
		}

		static IEnumerable<IEnumerable<T>>	GetPermutations<T>(IEnumerable<T> list, int length)
		{
			if (length == 1) return list.Select(t => new T[] { t });

			return GetPermutations(list, length - 1)
				.SelectMany(t => list.Where(e => !t.Contains(e)),
					(t1, t2) => t1.Concat(new T[] { t2 }));
		}
	}
}
