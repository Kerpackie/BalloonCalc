using System;

namespace BalloonCalc.Input
{
	public class GetInput
	{
		public static double Double()
		{
			var input = Convert.ToDouble(Console.ReadLine());
			return input;
		}

		public static int Int()
		{
			var input = Convert.ToInt32(Console.ReadLine());
			return input;
		}

		public static string String()
		{
			var input = Console.ReadLine();
			return input;
		}
	}
}