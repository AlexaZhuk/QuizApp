using Newtonsoft.Json;

namespace QuizApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string json = File.ReadAllText("C:\\Users\\Alexa\\Desktop\\test\\q.json");
			AllQuestions questionsData = JsonConvert.DeserializeObject<AllQuestions>(json);

			int rightAnswersCount = 0;
			foreach (QuestionDescription description in questionsData.Questions)
			{
				int answerNumber = 1;
				Console.WriteLine(description.Question);
				foreach (string answer in description.Answers)
				{
					Console.WriteLine($"{answerNumber++}. {answer}");
				}

				int userAnswer;
				while (!int.TryParse(Console.ReadLine(), out userAnswer))
				{
					Console.WriteLine("Try again");
				}

				if (userAnswer == description.RightIndex + 1)
				{
					rightAnswersCount += 1;
				}
			}

			Console.WriteLine($"You have {rightAnswersCount} right answers from {questionsData.Questions.Count} \n");
		}
	}
}
