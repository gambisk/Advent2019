using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019
{
	public class WirePoint
	{
		public int x { get; set; }
		public int y { get; set; }
		public int steps { get; set; }

		public WirePoint(int x, int y, int steps)
		{
			this.x = x;
			this.y = y;
			this.steps = steps;
		}

		public override bool Equals(object obj)
		{
			var objAsPoint = obj as WirePoint;
			if (objAsPoint != null)
				return (x == objAsPoint.x) && y == objAsPoint.y;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return (x + y).GetHashCode();
		}
	}

	public class TangledWires
	{
		public HashSet<WirePoint> GenerateWire(string input)
		{
			var wire = new HashSet<WirePoint>();
			var directions = input.Split(',');

			int x = 0;
			int y = 0;
			int steps = 0;

			foreach(var instruction in directions)
			{
				var direction = instruction[0];
				var length = int.Parse(instruction.Substring(1, instruction.Length - 1));

				for (int z = 0; z < length; z++)
				{
					switch(direction)
					{
						case 'U':
							y++;
							break;
						case 'D':
							y--;
							break;
						case 'L':
							x--;
							break;
						case 'R':
							x++;
							break;
					}

					steps++;
					wire.Add(new WirePoint(x,y,steps));
				}
			}

			return wire;
		}

		public string FindIntersections(HashSet<WirePoint> wire1, HashSet<WirePoint> wire2)
		{
			var leastSteps = int.MaxValue;
			foreach (var pointA in wire1)
			{
				if(wire2.Contains(pointA))
				{
					var pointB = wire2.First(x => x.x == pointA.x && x.y == pointA.y);
					var steps = pointA.steps + pointB.steps;
					if (steps < leastSteps)
						leastSteps = steps;
				}
			}
			

			return (leastSteps).ToString();
		}
	}
}
