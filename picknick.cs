using System;

namespace testprogram
{
	class Picnick
	{
		public static void Run()
		{
			string input;
			Console.WriteLine("Är det fint väder?");
			input = Console.ReadLine().ToLower();

			if (input == "j")
			{
				Console.WriteLine("Vi går på picknick!");
			}
			else if (input == "n")
			{
				Console.WriteLine("Vi stannar inne och läser en bok");
			}
			else {
				Console.WriteLine("Jag förstår inte :-(");
			}
		}
	}
}
