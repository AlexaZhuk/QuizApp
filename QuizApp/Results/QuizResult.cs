namespace QuizApp.Results
{
	internal class QuizResult
	{
		public int CorrectAnswers { get; set; }
		public int WrongAnswers { get; set; }
		public List<AnswerDetail> Details { get; set; }
	}
}
