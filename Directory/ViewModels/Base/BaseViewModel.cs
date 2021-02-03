using PropertyChanged;
using System.ComponentModel;

namespace FileSystemWPFApp
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}