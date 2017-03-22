using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSFiles.Exceptions;

namespace PSFiles.Utils
{
    public class TextFileSplitter : FileBasics
    {
        #region Private fields
        private List<string> _splitFileNames;
        private int _numberOfFiles;
        #endregion
        //
        #region public TextFileSplitter(string filePath)
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileSplitter"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="ArgumentNullException">string filePath;Parameteren er ikke korrekt initialiseret i kaldet til denne metode. TextFileSplitter.TextFileSplitter(string filePath)</exception>
        /// <exception cref="IOException"></exception>
        public TextFileSplitter(string filePath)
            :base(filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("string filePath", "Parameteren er ikke korrekt initialiseret i kaldet til denne metode. TextFileSplitter.TextFileSplitter(string filePath)");
            if (!DoFileExists(filePath))
                throw new IOException(string.Format("Der eksisterer ikke en file med dette navn: [{0}] i dette system.", filePath));
            FilePath = filePath;
        }
        #endregion
        //
        #region public TextFileSplitter(string filePath, int numberOfFiles)
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileSplitter" /> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="numberOfFiles">The number of files.</param>
        public TextFileSplitter(string filePath, int numberOfFiles)
                    : this(filePath)
        {
            if (numberOfFiles < 2)
                throw new ArgumentException("There should at least be 2 files as a number of split. Does it make sence numberOfFiles?", "int numberOfFiles");
            NumberOfFiles = numberOfFiles;
        }
        #endregion

        //
        #region Public properties
        /// <summary>
        /// Gets the split file names.
        /// </summary>
        /// <value>The split file names.</value>
        public List<string> SplitFileNames
        {
            get
            {
                if (_splitFileNames == null)
                    _splitFileNames = new List<string>();
                return _splitFileNames;
            }
        }

        public int NumberOfFiles
        {
            get{return _numberOfFiles;}
            set{_numberOfFiles = value;}
        }
        #endregion
        //
        #region Split()
        public void Split()
        {
            try
            {
                DanAktuelleInformationer();
                SplitFileNames.AddRange(GetSplitFileNames(FilePath, NumberOfFiles));

                string line = string.Empty;
                long readCounter = 0;
                int fileCounter = 0;

                CurrentTextFile currentTextFile = null;

                using (StreamReader sr = new StreamReader(FilePath, Encoding.Default))
                {
                    string currentFileName = SplitFileNames[fileCounter];

                    while ((line = sr.ReadLine()) != null)
                    {
                        //
                        if (fileCounter < SplitFileNames.Count - 1)
                        {
                            readCounter += GetStringByteSize(line);
                            if (readCounter >= SplitFileSize)
                            {
                                readCounter = 0;
                                fileCounter++;
                                currentFileName = SplitFileNames[fileCounter];
                                if (currentTextFile != null)
                                {
                                    currentTextFile.WriteLine(line);
                                    currentTextFile.Dispose();
                                    currentTextFile = null;
                                }
                            }
                            if (currentTextFile == null)
                            {
                                currentTextFile = new CurrentTextFile(currentFileName);
                                currentTextFile.Open();
                            }
                            currentTextFile.WriteLine(line);
                        }
                        else if (fileCounter < SplitFileNames.Count)
                        {
                            currentFileName = SplitFileNames[fileCounter];
                            currentTextFile.WriteLine(line);
                        }
                    }
                }
                if (currentTextFile != null)
                {
                    currentTextFile.WriteLine(line);
                    currentTextFile.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw PSFilesIOException.Create("Exception cought when splitting a file into more files", ex, "Filename is {0}", FilePath);
            }
        }
        #endregion
        //
        #region DanAktuelleInformationer()
        /// <summary>
        /// Dans the aktuelle informationer.
        /// </summary>
        protected void DanAktuelleInformationer()
        {
            FileInfo fi = new FileInfo(FilePath);
            ActualFileSize = fi.Length;
            //
            if (ActualFileSize > 0)
            {
                SplitFileSize = ActualFileSize / NumberOfFiles;
            }
        }
        #endregion
        //
        #region protected long GetStringByteSize(string testString)
        /// <summary>
        /// Gets the size of the string byte.
        /// </summary>
        /// <param name="testString">The test string.</param>
        /// <returns>System.Int64.</returns>
        protected long GetStringByteSize(string testString)
        {
            int byteCount = Encoding.ASCII.GetByteCount(testString);
            return byteCount;
        }
        #endregion
        //
        #region protected List<string> GetSplitFileNames(string filePath, int nSplits)
        /// <summary>
        /// Gets the split file names.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="nSplits">The n splits.</param>
        /// <returns>System.Collections.Generic.List&lt;System.String&gt;.</returns>
        protected List<string> GetSplitFileNames(string filePath, int nSplits)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("string filePath", "Parameteren er ikke korrekt initialiseret i kaldet til denne metode. TextFileSplitter.TextFileSplitter(string filePath)");

            List<string> result = new List<string>();
            //
            string fileExtension = Path.GetExtension(filePath);
            string fileWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string filePathName = Path.GetDirectoryName(filePath);
            //
            for (int i = 0; i < nSplits; i++)
            {
                result.Add
                (
                    string.Format
                    (
                        @"{0}\{1}_split_{2}{3}",
                        filePathName,
                        fileWithoutExtension,
                        i + 1,
                        fileExtension
                    )
                );
            }
            return result;
        }
        #endregion
        //
        #region protected void DeleteAllNewFilesIfExists(List<string> filePaths)

        protected void DeleteAllNewFilesIfExists(List<string> filePaths)
        {
            try
            {
                foreach (string filePath in filePaths)
                {
                    DeleteFile(filePath);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
