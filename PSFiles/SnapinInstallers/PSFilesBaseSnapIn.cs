using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;


namespace PSFiles.SnapinInstallers
{
    public abstract class PSFilesBaseSnapIn : CustomPSSnapIn
    {
        #region Private fields
        private Collection<CmdletConfigurationEntry> _cmdlets;
        private Collection<ProviderConfigurationEntry> _providers;
        private Collection<TypeConfigurationEntry> _types;
        private Collection<FormatConfigurationEntry> _formats;
        #endregion
        //
        #region Constructors
        public PSFilesBaseSnapIn()
        {

        }
        #endregion
        //
        #region Public properties
        /// <summary>
        /// 
        /// </summary>
        public override Collection<CmdletConfigurationEntry> Cmdlets
        {
            get
            {
                if (_cmdlets == null)
                {
                    _cmdlets = new Collection<CmdletConfigurationEntry>();
                    InitCmdLets();
                }
                return _cmdlets;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override Collection<ProviderConfigurationEntry> Providers
        {
            get
            {
                if (_providers == null)
                    _providers = new Collection<ProviderConfigurationEntry>();
                return _providers;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override Collection<TypeConfigurationEntry> Types
        {
            get
            {
                if (_types == null)
                    _types = new Collection<TypeConfigurationEntry>();
                return _types;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override Collection<FormatConfigurationEntry> Formats
        {
            get
            {
                if (_formats == null)
                    _formats = new Collection<FormatConfigurationEntry>();
                return _formats;
            }
        }
        #endregion
        //
        #region protected abstract void InitCmdLets()
        protected abstract void InitCmdLets();
        #endregion
        //
        #region protected void AddCmdLet(CmdletConfigurationEntry cmdLet)
        protected void AddCmdLet(CmdletConfigurationEntry cmdLet)
        {
            if (_cmdlets != null)
            {
                _cmdlets.Add(cmdLet);
            }
        }
        #endregion
        //
        #region public override string Description
        /// <summary>
        /// Gets description of powershell snap-in.
        /// </summary>
        public override string Description
        {
            get { return "File splitting and merging module aiding working with different office types of files."; }
        }
        #endregion
        //
        #region public override string Vendor
        /// <summary>
        /// Gets name of the vendor
        /// </summary>
        public override string Vendor
        {
            get { return "Chill libs inc."; }
        }
        #endregion


    }
}
