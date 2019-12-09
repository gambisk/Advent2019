using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2019.Modules
{
	public class SIFDecoder
	{	
		private char[] Input { get; set; }
		public int Columns { get; }
		public int Rows { get; }
		public List<List<int>> Layers { get; set; }

		public SIFDecoder(string input, int columns, int rows)
		{
			Input = input.ToCharArray();
			Columns = columns;
			Rows = rows;
			Layers = new List<List<int>>();
		}

		public void Decode()
		{
			int position = 0;
			while(position<Input.Length)
			{
				List<int> layer = new List<int>();
				for (int y = 0; y < Rows; y++)
				{
					for (int x = 0; x < Columns; x++)
					{
						layer.Add(int.Parse(Input[position].ToString()));
						position++;
					}
				}

				Layers.Add(layer);
			}
		}

		public List<int> LeastZeros()
		{
			return Layers.OrderBy(x => x.Where(y=> y==0).Count()).First();
		}

		public void Render()
		{
			var position = 0;
			for(int y = 0; y< Rows; y++)
			{
				for(int x =0; x<Columns; x++)
				{
					foreach(var layer in Layers)
					{
						if(layer[position] == 0)
						{
							Console.Write(0);
							position++;
							break;
						}
						if(layer[position]==1)
						{
							Console.Write(1);
							position++;
							break;
						}
					}
				}

				Console.WriteLine();
			}
		}

	}
}
