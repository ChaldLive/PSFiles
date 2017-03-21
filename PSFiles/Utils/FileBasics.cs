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
        private int _antalFiler;
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
        /// Gets or sets the antal filer.
        /// </summary>
        /// <value>The antal filer.</value>
        public int AntalFiler
        {
            get { return _antalFiler; }
            set { _antalFiler = value; }
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

    }
}
