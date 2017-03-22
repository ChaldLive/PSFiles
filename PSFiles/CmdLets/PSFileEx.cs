using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Management.Automation;
using PSFiles.Abstracts;
//
namespace PSFiles.CmdLets
{

    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Format, "PSFileEx", SupportsShouldProcess = true)]
    public class PSFileEx : BaseCmdLet
    {
        #region ♦ Private fields. ♦
        #endregion
        //
        #region ♦ Constructors 
        public PSFileEx()
        {

        }
        #endregion
        //
        #region Public properties.
        /// <summary>
        /// Gets or sets the server setup.
        /// </summary>
        /// <value>
        ///  The server setup.
        /// </value>
        [Alias("Server")]
        [
            Parameter
            (
                Mandatory = true,
                Position = 0,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "Navnet på det server setup, der skal bruges i kaldet til facilia. Der opstår en fejl, hvis dette navn ikke eksistrer"
            )
        ]
        [ValidateNotNullOrEmpty]
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        #endregion
        //
        #region ♦ Base overridden methods ♦
        //
        #region Begin Processesing.
        /// <summary>
        /// 
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        #endregion
        //
        #region Process record.
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
            }
            catch (Exception ex)
            {
                WriteObject(ex);
            }
        }
        #endregion

        //
        #endregion
        //
    }
}
