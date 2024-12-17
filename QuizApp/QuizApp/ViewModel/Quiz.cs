using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuizApp.Model;

namespace QuizApp.ViewModel
{
    public class Quiz : INotifyPropertyChanged
    {
        public IList<Question> AllQuestions { get; set; }
        public IList<Question> SelectedQuestions { get; set; }
        public int NumberOfQuestion { get; set; }
        public int CurrentQuestionIndex { get; set; }

        private bool[] quizResultsArr;
        public bool[] QuizResultsArr
        {
            get => quizResultsArr;
            set
            {
                quizResultsArr = value;
                OnPropertyChanged(nameof(QuizResultsArr));
            }
        }

        private string answer;
        public string GivenAnswer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged(GivenAnswer);
            }
        }

        private int results;
        public int Results
        {
            get => results;
            set
            {
                results = value;
                OnPropertyChanged(nameof(Results));
            }
        }

        private Question currentQuestion;
        public Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }
        public Quiz(int numberofQuestions)
        {
            AllQuestions = GetAllQuestions();
            SelectedQuestions = GetSelectedQuestions(numberofQuestions);
            QuizResultsArr = new bool[SelectedQuestions.Count];
            NumberOfQuestion = numberofQuestions;
            CurrentQuestionIndex = 0;
            CurrentQuestion = SelectedQuestions[CurrentQuestionIndex];           
        }
        public void Reset()
        {
            CurrentQuestionIndex = 0;
            GivenAnswer = "";
            SelectedQuestions = GetSelectedQuestions(NumberOfQuestion);
            QuizResultsArr = new bool[NumberOfQuestion];
            GetResults();
            CurrentQuestion = SelectedQuestions[CurrentQuestionIndex];
        }
        public void SetNextCurrentIndex(int selectedAnswerIndex)
        {
            QuizResultsArr[CurrentQuestionIndex] = CurrentQuestion.IndexOfCorrectAnswer == selectedAnswerIndex;
            CurrentQuestion.SelectedAnswerIndex = selectedAnswerIndex;
            if (CurrentQuestionIndex < SelectedQuestions.Count - 1)
            {
                CurrentQuestionIndex++;
                CurrentQuestion = SelectedQuestions[CurrentQuestionIndex];
            }
            GivenAnswer = "";
        }
        public void SetPrevCurrentIndex(int selectedAnswerIndex)
        {
            QuizResultsArr[CurrentQuestionIndex] = CurrentQuestion.IndexOfCorrectAnswer == selectedAnswerIndex;
            if (CurrentQuestionIndex > 0)
            {
                CurrentQuestionIndex--;
                CurrentQuestion = SelectedQuestions[CurrentQuestionIndex];                
            }
            GivenAnswer = CurrentQuestion.Answers[CurrentQuestion.SelectedAnswerIndex];
        }

        public void GetResults() => Results = QuizResultsArr.Count(c => c);
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public IList<Question> GetAllQuestions()
        {
            AllQuestions = new List<Question>()
            {
                new Question
                {
                    Id = 1,
                    Text = "Question1",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 1,
                    SelectedAnswerIndex = -1
                },
                 new Question
                {
                    Id = 2,
                    Text = "Question2",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 2,
                    SelectedAnswerIndex = -1
                },
                 new Question
                {
                    Id = 3,
                    Text = "Question3",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 3,
                    SelectedAnswerIndex = -1
                },
                 new Question
                {
                    Id = 4,
                    Text = "Question4",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 1,
                    SelectedAnswerIndex = -1
                },
                  new Question
                {
                    Id = 5,
                    Text = "Question5",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 4,
                    SelectedAnswerIndex = -1
                },
                  new Question
                {
                    Id = 6,
                    Text = "Question6",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 1,
                    SelectedAnswerIndex = -1
                },
                   new Question
                {
                    Id = 7,
                    Text = "Question7",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 3,
                    SelectedAnswerIndex = -1
                },
                    new Question
                {
                    Id = 8,
                    Text = "Question8",
                    Answers = new List<string>()
                    {
                        "",
                        "Answer1",
                        "Answer2",
                        "Answer3",
                        "Answer4",
                        "Answer5"
                    },
                    IndexOfCorrectAnswer = 2,
                    SelectedAnswerIndex = -1
                }
            };
            return AllQuestions;
        }

        public IList<Question> GetSelectedQuestions(int number)
        {
            Random rnd = new Random();
            var selectedQuestions = new List<Question>();
            int i = 0;
            do
            {
                int index = rnd.Next(1, AllQuestions.Count - 1);
                if (!selectedQuestions.Any(c => c.Text == AllQuestions[index].Text))
                {
                    selectedQuestions.Add(AllQuestions[index]);
                    i++;
                }
            }
            while (i < number);
            return selectedQuestions;
        }


    }
}
