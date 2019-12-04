using Advent2019.Modules;
using System;

namespace Advent2019.Solutions
{
	public static class Day4Solution
	{
		public static void Solve()
		{
			var passwordSolver = new PasswordFinder();
			Console.WriteLine(passwordSolver.FindPasswords(372037, 905157));
		}
	}
}
