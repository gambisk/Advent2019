using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Modules
{
	public class PasswordFinder
	{
		public int FindPasswords(int start, int end)
		{
			var passwords = GetPasswords(start, end);
			var valid = passwords.Where(x => IsSequential(x) && IsAdjacent(x)).ToList();
			return valid.Count;
		}

		private bool IsSequential(string x)
		{
			var charArray = x.ToCharArray();
			for (int i = 0; i < charArray.Length - 1; i++)
			{
				var char1 = charArray[i];
				var char2 = charArray[i + 1];
				if (char1 > char2)
					return false;
			}

			return true;
		}

		private bool IsAdjacent(string x)
		{
			var charArray = x.ToCharArray();
			for (int i = 0; i < charArray.Length - 1; i++)
			{
				if(charArray[i] == charArray[i+1])
				{
					if (!IsPartOfGroup(charArray, charArray[i]))
						return true;
				}				
			}

			return false;
		}

		private bool IsPartOfGroup(char[] x, char v)
		{
			int count = 0;
			foreach(var letter in x)
			{
				if (letter == v)
					count++;
			}

			return count != 2;
		}

		private List<string> GetPasswords(int start, int end)
		{
			List<string> passwords = new List<string>();
			for (int i = start; i != end; i++)
			{
				passwords.Add(i.ToString());
			}

			return passwords;
		}
	}
}
