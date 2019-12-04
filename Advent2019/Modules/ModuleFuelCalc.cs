using System;
using System.Collections.Generic;

namespace Advent2019
{
	public class ModuleFuelCalc
	{
		public long FuelRequired(List<int> modules)
		{
			long fuelRequired = 0;
			foreach(var module in modules)
			{
				fuelRequired += CalculateFuelRequiement(module);
			}

			return fuelRequired;
		}

		private long CalculateFuelRequiement(long mass)
		{
			double fuel = mass / 3;
			fuel = Math.Round(fuel, 0, MidpointRounding.ToZero);

			long fuelInt = (long)fuel - 2;
			if (fuelInt <= 0)
				return 0;

			fuelInt += CalculateFuelRequiement(fuelInt);
			return fuelInt;
		}
	}
}
