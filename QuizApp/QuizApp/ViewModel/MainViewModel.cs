using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuizApp.Model;

namespace QuizApp.ViewModel
{
    public class MainViewModel
    {
        public Quiz Quiz { get; set; }
        public MyCommand PrevCommand { get; set; }
        public MyCommand NextCommand { get; set; }
        public MyCommand SubmitCommand { get; set; }
        public MyCommand ResetCommand { get; set; }

        private int selectedAnswerIndex;
        public int SelectedAnswerIndex
        {
            get => selectedAnswerIndex;
            set
            {
                selectedAnswerIndex = value;
                PrevCommand.RaiseCanExecuteChanged();
                NextCommand.RaiseCanExecuteChanged();                        
            }
        }
        public MainViewModel()
        {
            Quiz = new Quiz(5);
            PrevCommand = new MyCommand(Prev, CanPrev);
            NextCommand = new MyCommand(Next, CanNext);
            SubmitCommand = new MyCommand(Submit, CanSubmit);
            ResetCommand = new MyCommand(CallReset, CanReset);
            SelectedAnswerIndex = -1;
        }

        private bool CanReset() => enableReset;

        private bool enableReset = false;

        private bool enableSubmit = false;

        private void CallReset()
        {
            SelectedAnswerIndex = -1;
            Quiz.Reset();           
            enableReset = false;
            ResetCommand.RaiseCanExecuteChanged();
            enableSubmit = false;
            SubmitCommand.RaiseCanExecuteChanged();
        }
        private bool CanSubmit() => enableSubmit;
        private void Submit()
        {
            Quiz.GetResults();
            enableReset = true;
            ResetCommand.RaiseCanExecuteChanged();
        }
        private bool CanNext() => Quiz.CurrentQuestionIndex < Quiz.SelectedQuestions.Count && SelectedAnswerIndex > 0;
        private bool CanPrev() => Quiz.CurrentQuestionIndex > 0;

        private void Prev()
        {            
            Quiz.SetPrevCurrentIndex(SelectedAnswerIndex);            
            enableSubmit = Quiz.CurrentQuestionIndex == Quiz.SelectedQuestions.Count - 1;
            SelectedAnswerIndex = Quiz.CurrentQuestion.SelectedAnswerIndex;
            SubmitCommand.RaiseCanExecuteChanged();            
        }
        private void Next()
        {
            enableSubmit = Quiz.CurrentQuestionIndex == Quiz.SelectedQuestions.Count -1;           
            SubmitCommand.RaiseCanExecuteChanged();
            Quiz.SetNextCurrentIndex(SelectedAnswerIndex);
            SelectedAnswerIndex = -1;                    
        }
    }
}

