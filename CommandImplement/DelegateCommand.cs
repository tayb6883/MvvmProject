using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2.CommandImplement
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canexecuteMethod;
        private readonly Action<object> _execteMethod;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
                       : this(execute, null)
        {
        }
        public DelegateCommand(Action<object> execteMethod, Predicate<object> canexecuteMethod)
        {
            _execteMethod = execteMethod;
            _canexecuteMethod = canexecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod == null)
            {
                return true;
            }

            return _canexecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
