using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSFiles.Exceptions
{
    public class PSFilesIOException : Exception
    {
        #region Private fields
        private string _extraInformation;
        #endregion
        //
        #region Construction

        public PSFilesIOException()
        {
        }

        public PSFilesIOException(string message)
        : base(message)
        {
        }

        public PSFilesIOException(string message, Exception inner)
        : base(message, inner)
        {
        }
        #endregion
        //
        #region Public properties
        public string ExtraInformation
        {
            get{return _extraInformation;}
            private set { _extraInformation = value; }
        }
        #endregion

        #region public static PSFilesIOException Create(string message, Exception exInner, string format, params object[] args)
        public static PSFilesIOException Create(string message, Exception exInner, string format, params object[] args)
        {
            PSFilesIOException result = new PSFilesIOException(message, exInner);
            result.ExtraInformation = string.Format(format, args);
            return result;

        }
        #endregion

        #region public static PSFilesIOException Create(string message, string extraInformation)
        public static PSFilesIOException Create(string message, string extraInformation)
        {
            PSFilesIOException result = new PSFilesIOException(message, new Exception(extraInformation));
            return result;
        }
        #endregion
    }
}
