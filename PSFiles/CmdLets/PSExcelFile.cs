using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using PSFiles.Abstracts;

namespace PSFiles.CmdLets
{
    [Cmdlet(VerbsCommon.Join, "PSExcelFile", SupportsShouldProcess = true)]
    public class PSExcelFile : BaseCmdLet
    {
        #region Private fields
        private string _sourceFileName;
        private string _resultFileName;
        #endregion
        //
        #region MyRegion
        public PSExcelFile()
        {

        }
        #endregion
        //
        #region Public properties.
        [Alias("Source")]
        [
            Parameter
            (
                Mandatory = true,
                Position = 0,
                ValueFromPipeline = true,
                ValueFromPipelineByPropertyName = true,
                HelpMessage = "Sti og fil navn på den fil, der skal behandles."
            )
        ]
        [ValidateNotNullOrEmpty]
        public string SourceFile
        {
            get { return _sourceFileName; }
            set { _sourceFileName = value; }
        }
        [Alias("Dest")]
        [
            Parameter
            (
                Mandatory = true,
                Position = 1,
                HelpMessage = "Sti og fil navn på den fil, hele behanlingen resulterer i."
            )
        ]
        [ValidateNotNullOrEmpty]
        public string ResultFileName
        {
            get { return _resultFileName; }
            set { _resultFileName = value; }
        }

        #endregion
        //
        #region protected override void BeginProcessing()
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        #endregion
        //
        #region protected override void ProcessRecord()
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }
        #endregion
        //
        #region protected override void EndProcessing()
        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
        #endregion
    }
}
