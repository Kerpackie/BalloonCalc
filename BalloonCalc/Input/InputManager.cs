using System;
using BalloonCalc.Common;

namespace BalloonCalc.Input
{
	public class InputManager
	{
		/// <summary>
		/// Get Payload Mass
		/// </summary>
		/// <returns>int of payloadMass</returns>
		public static int GetPayloadMassFromUserInput()
		{
			Console.WriteLine("Please input your intended payload mass(g). It cannot be less then 10g, or more than 20,000g (20kg)");
			var payloadMass = GetInput.Int();
			return payloadMass;
		}

		/// <summary>
		/// Get Target Ascent Rate
		/// </summary>
		/// <returns>double of Target Ascent Rate</returns>
		public static double GetTargetAscentRateFromUserInput()
		{
			Console.WriteLine("Please insert the target ascent rate in m/s (cannot be less than 0, or greater than 10m/s)");
			var targetAscentRate = GetInput.Double();
			return targetAscentRate;
		}

		/// <summary>
		/// Get Target Burst Altitude
		/// </summary>
		/// <returns>double of Target Burst Altitude</returns>
		public static double GetTargetBurstAltitudeFromUserInput()
		{
			Console.WriteLine("Please insert the target burst altitude. Range: 10,000 - 40,000 (10k - 40k)");
			var targetBurstAltitude = GetInput.Double();
			return targetBurstAltitude;
		}

		/// <summary>
		/// Ask to calculate Target Burst Altitude or Target Ascent Rate.
		/// </summary>
		/// <returns>Which option the user chose.</returns>
		public static int AskCalcTbaOrTar()
		{
			Console.WriteLine("Would you like to specify [0]Target Burst Altitude or [1]Target Ascent Rate?");
			var option = GetInput.Int();
			return option;
		}

		public static double SelectGasUserInput()
		{
			Console.WriteLine("Please select a gas that you would like to use: [0]Helium [1]Hydrogen [2]Methane [3]Custom");
			var option = GetInput.Int();
			var gas = option switch
			{
				0 => Gas.Helium,
				1 => Gas.Hydrogen,
				2 => Gas.Methane,
				3 => SelectCustomGasUserInput(),
				_ => Gas.Helium
			};
			return gas;
		}

		public static double SelectCustomGasUserInput()
		{
			Console.WriteLine("Please input the gas density:");
			var gasDensity = GetInput.Double();
			return gasDensity;
		}
		
		// rho_a
		public static double SelectAirDensityUserInput()
		{
			Console.WriteLine("Please specify a valid air density. (0<Ad)");
			var airDensity = GetInput.Double();
			return airDensity;
		}

		// adm
		public static double SelectAirDensityModelUserInput()
		{
			Console.WriteLine("Please specify a valid air density model. (0<Adm)");
			var airDensityModel = GetInput.Double();
			return airDensityModel;
		}

		// ga
		public static double SelectGravitationalAccelerationUserInput()
		{
			Console.WriteLine("Please specify a valid Gravitational Acceleration. (0<Ga)");
			var gravitationalModel = GetInput.Double();
			return gravitationalModel;
		}

		// cd
		public static double SelectDragCoefficientUserInput()
		{
			Console.WriteLine("Please specify a valid Drag Coefficient. (0≤Cd≤1) In most cases this will be 0.25");
			var dragCoefficient = GetInput.Double();
			return dragCoefficient;
		}

		// bd
		public static double SelectBurstDiameter()
		{
			Console.WriteLine("Please specify a valid burst diameter. (0< Bd)");
			var burstDiameter = GetInput.Double();
			return burstDiameter;
		}
	}
}