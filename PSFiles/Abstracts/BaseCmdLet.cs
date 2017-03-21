using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;

namespace PSFiles.Abstracts
{
    public class BaseCmdLet : PSCmdlet
    {
        #region protected void ThrowValidatingErrorEx(string header, ErrorCategory errorCategory, string format, params object[] args)
        /// <summary>
        /// Basic helper method aiding throwing exceptions into to the PowerShell pipeline, stopping execution immediately. 
        /// </summary>
        /// <param name="header">The header information appearing first in the unwinded stack when exceptions are thrown.</param>
        /// <param name="errorCategory">This is cmdlets way of aiding the programmer and the user of cmdlets.</param>
        /// <param name="format">Extra information this .</param>
        /// <param name="args">The arguments.</param>
        protected void ThrowValidatingErrorEx(string header, ErrorCategory errorCategory, string format, params object[] args)
        {
            string localHeader = string.Format(format, args);
            //
            ThrowTerminatingError
            (
                new ErrorRecord
                (
                    new Exception(localHeader),
                    header,
                    errorCategory,
                    this
                )
            );
        }
        #endregion
    }
}
