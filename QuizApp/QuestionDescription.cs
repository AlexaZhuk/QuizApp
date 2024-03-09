using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
	internal class QuestionDescription
	{
		public string Question { get; set; }
		public List<string> Answers { get; set; }
		public int RightIndex { get; set; }
	}
}
