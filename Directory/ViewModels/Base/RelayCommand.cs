using System;
using System.Windows.Input;
using UniversalCoreLib;

namespace FileSystemWPFApp
{
    /// <summary>
    /// A basic command that runs an Action.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// Action to run.
        /// </summary>
        private Action mAction;
        private DelRet<bool> CanExecuteDelegate { get; } = null;
        #endregion

        #region Public Events
        /// <summary>
        /// Event that's fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => {};
        #endregion

        #region Constructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand(Action action, DelRet<bool> CanExecuteDelegate)
        {
            mAction = action;
            this.CanExecuteDelegate = CanExecuteDelegate;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A RelayCommand can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => CanExecuteDelegate?.Invoke() ?? true;

        /// <summary>
        /// Execute action that was passed in ctor.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion // Command Methods
    }
}
