using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = delegate { };
        private readonly Action ExecuteMethode;
        private readonly Func<bool> CanExecuteMethode;
        public MyCommand(Action executeMethode) => this.ExecuteMethode = executeMethode;

        public MyCommand(Action executeMethode, Func<bool> canExecuteMethode)
        {
            this.ExecuteMethode = executeMethode;
            CanExecuteMethode = canExecuteMethode;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged(this, EventArgs.Empty);

        public bool CanExecute(object parameter)
        {
            if (CanExecuteMethode != null)
            {
                return CanExecuteMethode();
            }          
            return false;
        }

        public void Execute(object parameter)
        {
            if (ExecuteMethode != null)
            {
                ExecuteMethode();
            }
        }
    }
}
