using System;

namespace BalloonCalc.Calculations
{
	public class Calculator
	{
		public double CalculateBurstVolume(double burstDiameter)
		{
			var burstVolume = (4.0 / 3.0) * Math.PI * Math.Pow(burstDiameter / 2.0, 3);
			return burstVolume;
		}

		public double CalculateLaunchVolumeTbaSet(double burstVolume, double targetBurstAltitude, double airDensityModel)
		{
			var launchVolume = burstVolume * Math.Exp(-targetBurstAltitude / airDensityModel);
			return launchVolume;
		}

		public double CalculateLaunchRadiusTbaSet(double launchVolume)
		{
			var launchRadius = Math.Pow(3 * launchVolume / (4 * Math.PI), (1.0 / 3.0));
			return launchRadius;
		}

		public double CalculateLaunchRadiusTarSet(double gravitationalAcceleration, double airDensity,
			double gasDensity, double targetAscentRate, double dragCoefficient, ulong payloadMass,
			ulong balloonMass)
		{
			var a = gravitationalAcceleration * (airDensity - gasDensity) * (4.0 / 3.0) * Math.PI;
			var b = -0.5 * Math.Pow(targetAscentRate, 2) * dragCoefficient * airDensity * Math.PI;
			var c = 0.0;
			var totalMass = payloadMass + balloonMass;
			var d = (totalMass * - 1.0) * gravitationalAcceleration;

			var f = 3 * c / a - Math.Pow(b, 2) / Math.Pow(a, 2) / 3.0;
			var g = (2 * Math.Pow(b, 3) / Math.Pow(a, 3) -
				9 * b * c / Math.Pow(a, 2) + 27 * d / a) / 27.0;
			var h = Math.Pow(g, 2) / 4.0 + Math.Pow(f, 3) / 27.0;

			if (h <= 0)
				throw new Exception("Expecting exactly one real root");

			var R = 0.5 * g * Math.Sqrt(h);
			var S = Math.Pow(R, 1.0 / 3.0);
			var T = 0.5 * g - Math.Sqrt(h);
			var U = Math.Pow(T, 1.0 / 3.0);

			var launchRadius = S + U - b / (3 * a);
			return launchRadius;
		}
	}
}