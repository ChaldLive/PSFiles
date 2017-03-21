using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Management.Automation;
//
using PSFiles.Utils;
using PSFiles.Abstracts;
//

namespace FaciliaPS.CmdLets
{
    [Cmdlet(VerbsCommon.Split, "PSFile", SupportsShouldProcess = true)]
    public class PSFile : BaseCmdLet
    {
        #region  Private fields. 
        private string _filePath;
        private int _nFiles;
        #endregion
        //
        #region Constructors 
        public PSFile()
        {

        }
        #endregion
        //
        #region ♦ Public properties. ♦
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
                ValueFromPipeline = true,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "Sti og fil navn på den fil, der skal behandles og splittes i flere mindre filer."
            )
        ]
        [ValidateNotNullOrEmpty]
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        /// <summary>
        /// Gets or sets the server setup.
        /// </summary>
        /// <value>
        ///  The server setup.
        /// </value>
        [Alias("NFiles")]
        [
            Parameter
            (
                Mandatory = true,
                Position = 1,
                HelpMessage = "path and filenma of the file in qustion to be split into several smaler files."
            )
        ]
        public int NumberOfFiles
        {
            get { return _nFiles; }
            set { _nFiles = value; }
        }
        #endregion
        //
        #region ♦ Base overridden methods ♦
        //
        #region Begin Processesing.
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
        #region ♦ Tekst her ikke ♦
        #endregion
    }
}
