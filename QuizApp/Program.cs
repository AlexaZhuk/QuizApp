using Newtonsoft.Json;

namespace QuizApp
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string json = File.ReadAllText("C:\\Users\\Alexa\\Desktop\\test\\q.json");
			AllQuestions info = JsonConvert.DeserializeObject<AllQuestions>(json);

			int count = 0;
			int countAmswer = 1;

			foreach (var quDescription in info.Questions)
			{
				Console.WriteLine(quDescription.Question);
				foreach (var item in quDescription.Answers)

				{
					Console.WriteLine($"{countAmswer++}. {item}");
				}

				int userAnswer;

				while (!int.TryParse(Console.ReadLine(), out userAnswer))
				{
					Console.WriteLine("Try again");
				}

				if (userAnswer == quDescription.RightIndex + 1)
				{
					count += 1;
				}
			}
			Console.WriteLine($"You have {count} right answers from {info.Questions.Count} \n");
		}
	}
}
