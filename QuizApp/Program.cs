using Newtonsoft.Json;
using QuizApp.Questions;
using QuizApp.Results;

namespace QuizApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hallo, what is your name?");
			string userName = Console.ReadLine();
			string json = File.ReadAllText("C:\\Users\\Alexa\\Desktop\\test\\q.json");
			AllQuestions questionsData = JsonConvert.DeserializeObject<AllQuestions>(json);

			int rightAnswersCount = 0;
			List<AnswerDetail> userAnswers = new List<AnswerDetail>();

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

				AnswerDetail detail = new AnswerDetail();
				detail.Question = description.Question;
				if (userAnswer == description.RightIndex + 1)
				{
					rightAnswersCount += 1;
					detail.IsRight = true;
				}
				else
				{
					detail.IsRight = false;
				}
				userAnswers.Add(detail);
			}

			Console.WriteLine($"You have {rightAnswersCount} right answers from {questionsData.Questions.Count} \n");

			TestResult testResult = new TestResult();
			testResult.WrongAnswers = questionsData.Questions.Count - rightAnswersCount;
			testResult.RightAnswers = rightAnswersCount;
			testResult.Details = userAnswers;

			string path = $"C:\\Users\\Alexa\\Desktop\\test\\{userName}_{DateTime.Now:dd-MM-yyyy_hh-mm-ss}.json";
			string resultTry = JsonConvert.SerializeObject(testResult);
			File.WriteAllText(path, resultTry);



		}


	}
}
