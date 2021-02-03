using System.Collections.Generic;
using System.Linq;

namespace FileSystemWPFApp
{
    /// <summary>
    ///  Helper class to query info about directories
    /// </summary>
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select((drive) =>
                new DirectoryItem { 
                    FullPath = drive,
                    type = DirectoryItemType.Drive 
                }).ToList();
        }

        /// <summary>
        /// Get Directory top-level content.
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list.
            var items = new List<DirectoryItem>();
            #region Get Directories
            // create blank list for directories, and try to fill it from the folder, ignoring any issues doing so.

            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(
                        dir => new DirectoryItem {
                            FullPath = dir,
                            type = DirectoryItemType.Folder }));
                }
                // Get every folder inside this folder.
            }
            catch { }// ignore all problems?!

            // Create directory item
            #endregion

            #region Get Files

            // Create blank list for files

            // try & get files from folder, ignoring any issues.
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(
                        (file) => new DirectoryItem { 
                            FullPath = file,
                            type = DirectoryItemType.File }));
                }
            }
            catch { } // do nothing on error.

            #endregion
            return items;
        }

        #region Helpers
        /// <summary>
        /// Find file or folder name from the full path.
        /// </summary>
        /// <param name="path">The full path.</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path) 
        {
            // If path empty, return empty.
            if (string.IsNullOrEmpty(path)) { return string.Empty; }

            // Make all slashes backslashes.
            var normalizedPath = path.Replace('/', '\\');

            // find last backslash in path
            var lastIndex = path.LastIndexOf('\\');

            // if no backslash, return path itself.
            if (lastIndex <= 0)
            {
                return path;
            }

            // return name after last backslash.
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
