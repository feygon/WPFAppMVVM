namespace FileSystemWPFApp
{
    /// <summary>
    /// Info about a directory item, such as a drive, file, or folder.
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// Type of this item.
        /// </summary>
        public DirectoryItemType type { get; set; }
        /// <summary>
        /// Name of this directory item.
        /// </summary>
        public string Name { get { return 
                    this.type == DirectoryItemType.Drive ?
                        this.FullPath :
                        DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
        /// <summary>
        /// Absolute path to this item.
        /// </summary>
        public string FullPath { get; set; }

    }
}
