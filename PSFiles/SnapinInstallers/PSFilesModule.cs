using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.ComponentModel;
using FaciliaPS.CmdLets;

namespace PSFiles.SnapinInstallers
{
    [RunInstaller(true)]
    public class PSFilesModule : PSFilesBaseSnapIn
    {
        #region public override string Name
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name
        {
            get { return "PSFilesModule"; }
        }
        #endregion
        //
        #region protected override void InitCmdLets()
        /// <summary>
        /// Initializes the command lets.
        /// </summary>
        protected override void InitCmdLets()
        {
            // Initial example of the shit running 
            AddCmdLet(new CmdletConfigurationEntry("Split-PSFile", typeof(PSFile), @"FaciliaPS.dll-help.xml"));
        }
        #endregion
    }
}
