using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    class WPFCommand : ICommand
    {
        public delegate void cmd(object arg);

        public event EventHandler CanExecuteChanged;
        private readonly cmd act;

        public WPFCommand(cmd function)
        {
            this.act = function;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.act(parameter);
        }
    }
}
