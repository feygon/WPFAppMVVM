using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FileSystemWPFApp.Directory.ViewModels
{
    /// <summary>
    /// A view model for each firectory item.
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// Full path to the item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name {
            get {
                return this.type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
        /// <summary>
        /// Type of the item.
        /// </summary>
        public DirectoryItemType type { get; set; }

        public string ImageName => type == DirectoryItemType.Drive ? "drive" : (type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed"));

        /// <summary>
        /// List of children
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Can this item expand?
        /// </summary>
        public bool CanExpand { get { return this.type != DirectoryItemType.File; } }
        
        /// <summary>
        /// Is this item expanded?
        /// </summary>
        public bool IsExpanded {
            get {
                return Children.Count(f => f != null) > 0;
            }
            // If UI tells us to expand, find all children.
            set {
                if (value == true) {
                    Expand();
                } else {
                    // remove children.
                    this.ClearChildren();
                }
            }
        }
        #endregion // Public Properties

        #region Public Commands

        /// <summary>
        /// Command to expand this item.
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fullPath">Full path of this item</param>
        /// <param name="type">Type of item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // set Expand method.
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.type = type;
            // Setup children as needed.
            this.ClearChildren();
        }
        #endregion

        #region Helper Method
        /// <summary>
        /// Clear all children, adding dummy item to show the expand icon if required.
        /// </summary>
        private void ClearChildren()
        {
            // Clear items.
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            // Folders and drives need to show the expand arrow.
            if (this.type != DirectoryItemType.File) {
                this.Children.Add(null);
            }
        }
        #endregion // Helper Method

        /// <summary>
        /// Expands this directory and finds all children.
        /// </summary>
        private void Expand()
        {
            // File can't expand.
            if (this.type == DirectoryItemType.File) return;

            // Find all children.
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(
                    content => new DirectoryItemViewModel(content.FullPath = FullPath, type = content.type)));
        }
    }     
}
