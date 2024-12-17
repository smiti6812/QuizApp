using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<string> Answers { get; set; }
        public int IndexOfCorrectAnswer { get; set; }
        public int SelectedAnswerIndex { get; set;}    
    }
}
