using System;

namespace testprogram
{
	class Kallast
	{
		public static void Run()
		{
			double temp_amal, temp_ostersund;
			Console.WriteLine("Vad är temperaturen i Östersund??");
			temp_ostersund = Convert.ToDouble(Console.ReadLine());

			Console.WriteLine("Vad är temperaturen i Åmål?");
			temp_amal = Convert.ToDouble(Console.ReadLine());

			if (temp_amal < temp_ostersund)
				Console.WriteLine("Det är kallast i Åmål!");
			else if (temp_ostersund < temp_amal)
				Console.WriteLine("Det är kallast i Östersund!");
			else
				Console.WriteLine("Det är lika kallt i båda");
		}
	}
}
