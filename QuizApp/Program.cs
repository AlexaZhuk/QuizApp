using Newtonsoft.Json;

namespace QuizApp
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string json = File.ReadAllText("C:\\Users\\Alexa\\Desktop\\test\\q.json");
			AllQuestions questionsData = JsonConvert.DeserializeObject<AllQuestions>(json);

			int count = 0;

			foreach (QuestionDescription description in questionsData.Questions)
			{
				int countAnswer = 1;
				Console.WriteLine(description.Question);
				foreach (string item in description.Answers)

				{
					Console.WriteLine($"{countAnswer++}. {item}");
				}

				int userAnswer;
				while (!int.TryParse(Console.ReadLine(), out userAnswer))
				{
					Console.WriteLine("Try again");
				}

				if (userAnswer == description.RightIndex + 1)
				{
					count += 1;
				}
			}
			Console.WriteLine($"You have {count} right answers from {questionsData.Questions.Count} \n");
		}
	}
}
