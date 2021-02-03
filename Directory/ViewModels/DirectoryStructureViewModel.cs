using FileSystemWPFApp.Directory.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileSystemWPFApp
{
    /// <summary>
    /// ViewModel for application's main Directory View.
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Members
        /// <summary>
        /// List of all directories on the machine.
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        ///  Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));

        }
        #endregion
    }
}