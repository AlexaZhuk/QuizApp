namespace QuizApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string path = "C:\\Users\\Alexa\\Desktop\\test\\1.txt";
			string[] taxt = File.ReadAllLines(path);

			for (int j = 0; j < taxt.Length; j++)
			{
				taxt[j] = taxt[j].TrimEnd('*');
			}
			NumberQ(taxt);

		}

		static void NumberQ(string[] taxt)
		{
			int k = 1;
			int result;
			int point = 0;
			int count = 0;

			for (int i = 1; i < 11; i++)
			{
				for (k = (i - 1) * 6; k < i * 6 && k < taxt.Length; k++)
				{
					Console.WriteLine(taxt[k]);
				}
				Console.WriteLine("Choose the answer: ");

				try
				{
					result = int.Parse(Console.ReadLine());
				}
				catch (Exception)
				{
					Console.WriteLine("Недопустимый вариант\n");
					break;
				}
				string path = "C:\\Users\\Alexa\\Desktop\\test\\1.txt";
				string[] taxtFifst = File.ReadAllLines(path);

				if (i == 1)
				{
					count = result;
				}
				else
				{
					count = ((i - 1) * 6) + result;
				}
				string answer = taxtFifst[count];


				if (answer.EndsWith('*'))
				{
					point += 1;
				}

			}
			Console.WriteLine($"your points = {point}");

		}
	}
}
