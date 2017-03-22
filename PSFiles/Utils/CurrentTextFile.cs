using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace PSFiles.Utils
{
    /// <summary>
    /// Class CurrentTextFile.
    /// </summary>
    /// <remarks>Class file documentation please get here soon</remarks>
    public class CurrentTextFile : IDisposable
    {
        #region Private fields
        /// <summary>
        /// The _file path
        /// </summary>
        private string _filePath;
        /// <summary>
        /// The _stream writer
        /// </summary>
        private StreamWriter _streamWriter;
        /// <summary>
        /// The _file stream
        /// </summary>
        private FileStream _fileStream;
        #endregion
        //
        #region public CurrentTextFile(string filePath)
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentTextFile"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <remarks>Class file documentation please get here soon</remarks>
        public CurrentTextFile(string filePath)
        {
            FilePath = filePath;
        }
        #endregion
        //
        #region Public properties.
        /// <summary>
        /// Gets the file s.
        /// </summary>
        /// <value>The file s.</value>
        public FileStream FileS
        {
            get { return _fileStream; }
        }

        /// <summary>
        /// Gets the stream w.
        /// </summary>
        /// <value>The stream w.</value>
        public StreamWriter StreamW
        {
            get { return _streamWriter; }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath
        {
            get { return _filePath; }
            private set { _filePath = value; }
        }
        #endregion
        //
        #region public void Open()
        /// <summary>
        /// Opens this instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Filen er allerede open så det kan ikke gøres igen.</exception>
        public void Open()
        {
            if (FileS != null || StreamW != null)
                throw new InvalidOperationException("Filen er allerede open så det kan ikke gøres igen.");
            try
            {
                _fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
                if (_fileStream != null)
                    _streamWriter = new StreamWriter(_fileStream, Encoding.Default);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //
        #region public void WriteLine(string line)
        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="line">
        /// </param>
        /// <exception cref="InvalidOperationException">Filen er ikke åbnet eller oprettet endnu husk at kalde Open på før denne metode kaldes.</exception>
        public void WriteLine(string line)
        {
            if (FileS == null || StreamW == null)
                throw new InvalidOperationException("Filen er ikke åbnet eller oprettet endnu husk at kalde Open på før denne metode kaldes.");
            StreamW.WriteLine(line);
            StreamW.Flush();
            FileS.Flush();
        }
        #endregion
        //
        #region public static void ReplaceText(string fileName, string textToRplace, string replacementBuffer)

        public static void ReplaceText(string fileName, string textToRplace, string replacementBuffer)
        {
            //
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("string fileName", "Parameteren er ikke korrekt initaliseret i kaldet til CurrentTextFile.ReplaceText");
            if (string.IsNullOrEmpty(textToRplace))
                throw new ArgumentNullException("string textToRplace", "Parameteren er ikke korrekt initaliseret i kaldet til CurrentTextFile.ReplaceText");
            if (string.IsNullOrEmpty(replacementBuffer))
                throw new ArgumentNullException("string replacementBuffer", "Parameteren er ikke korrekt initaliseret i kaldet til CurrentTextFile.ReplaceText");
            if (!File.Exists(fileName))
                throw new ArgumentException("Der eksisterer ikke nogen fil med dette navn i systemet.", "string fileName");
            //
            FileStream fsw = null; // Is disposed by the streamWriter.
            FileStream fsr = null; // Is Disposed by the streamReader.
            try
            {
                fsw = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                fsr = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                //
                using (StreamReader sr = new StreamReader(fsr))
                {
                    using (StreamWriter sw = new StreamWriter(fsw))
                    {
                        string nextLineRead = sr.ReadLine();
                        string nextLineToWrite = string.Empty;
                        //
                        while ((nextLineRead = sr.ReadLine()) != null)
                        {
                            if (nextLineRead.Contains(textToRplace))
                            {
                                nextLineToWrite = nextLineRead.Replace(textToRplace, replacementBuffer);
                            }
                            else
                            {
                                nextLineToWrite = nextLineRead;
                            }
                            sw.WriteLine(nextLineToWrite);
                            sw.Flush();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        //
        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="CurrentTextFile" /> class.
        /// </summary>
        ~CurrentTextFile()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_streamWriter != null)
                {
                    _streamWriter.Flush();
                    _streamWriter.Close();
                }
                if (_fileStream != null)
                {
                    _fileStream.Flush();
                    _fileStream.Close();
                }
                if (FileS != null)
                {
                    FileS.Close();
                }
            }
        }
        #endregion
    }
}
