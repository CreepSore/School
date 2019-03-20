using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BSWPFLib
{
  public class BS2Command : ICommand
  {
    #region Delegates

    public delegate void CommandDel(object parameter);

    #endregion

    #region Events

    public event EventHandler CanExecuteChanged;

    #endregion

    #region Members

    public CommandDel exectedFunc;

    #endregion

    public BS2Command(CommandDel exectedFunc)
    {
      if (exectedFunc == null)
        throw new ArgumentNullException();

      this.exectedFunc = exectedFunc;
    }

    public virtual bool CanExecute(object parameter)
    {
      return true;
    }

    public virtual void Execute(object parameter)
    {
      exectedFunc(parameter);
    }
  }
}
