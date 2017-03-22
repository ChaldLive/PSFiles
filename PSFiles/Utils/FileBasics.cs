using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSFiles.Utils
{
    public class FileBasics
    {
        #region Private fields
        private string _filePath;
        private long _actualFileSize;
        private long _splitFileSize;
        #endregion
        //
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileSplitter"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="ArgumentNullException">string filePath;Parameteren er ikke korrekt initialiseret i kaldet til denne metode. TextFileSplitter.TextFileSplitter(string filePath)</exception>
        /// <exception cref="IOException"></exception>
        public FileBasics(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("string filePath", "Parameteren er ikke korrekt initialiseret i kaldet til denne metode. TextFileSplitter.TextFileSplitter(string filePath)");
            if (!DoFileExists(filePath))
                throw new IOException(string.Format("Der eksisterer ikke en file med dette navn: [{0}] i dette system.", filePath));
            FilePath = filePath;
        }

        #endregion
        //
        #region Public properties
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        /// <summary>
        /// Gets or sets the actual size of the file.
        /// </summary>
        /// <value>The actual size of the file.</value>
        public long ActualFileSize
        {
            get { return _actualFileSize; }
            set { _actualFileSize = value; }
        }
        /// <summary>
        /// Gets or sets the size of the split file.
        /// </summary>
        /// <value>The size of the split file.</value>
        public long SplitFileSize
        {
            get { return _splitFileSize; }
            set { _splitFileSize = value; }
        }
        #endregion
        //
        #region protected bool DoFileExists(string filePath)
        protected bool DoFileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;
            //
            FileInfo fi = new FileInfo(filePath);
            return fi.Exists;
        }
        #endregion
        //
        #region protected void DeleteFile(string filePath)
        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="filePath">
        /// </param>
        protected void DeleteFile(string filePath)
        {
            if (DoFileExists(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion

        public static bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;
            return File.Exists(fileName);
        }

        /// <summary>
        /// This method reads through a file using a textReader,
        /// and if it cant read it I can assume that the file
        /// is not a text file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsTextFile(string fileName)
        {
            bool result = true;
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line = sr.ReadLine();
                    result = line.All(c => c == (char)10        // New line
                                        || c == (char)13        // Carriage Return
                                        || c == (char)11        // Tab
                                        || !char.IsControl(c)); // Non-control (regular) character
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
