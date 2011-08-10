using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace eFact_N
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        protected override void OnAfterInstall(System.Collections.IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            try
            {
                System.ServiceProcess.ServiceController myController = new System.ServiceProcess.ServiceController("Servicio-eFact-N");
                myController.Start();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
    }
}