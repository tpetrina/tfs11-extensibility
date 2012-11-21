namespace TeamExplorerExtensions
{
    using System;
    using System.ComponentModel.Composition;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Controls;
    using Microsoft.VisualStudio.Shell;

    [TeamExplorerNavigationItem("{89A024C5-B275-456D-8486-6F335C21E7E9}", 0x3e7)]
    public class MessageNavigationItem : ITeamExplorerNavigationItem
    {
        private ITeamFoundationContextManager ContextManager;

        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }

        public void Execute()
        {
            if (this.ServiceProvider != null)
            {
                ITeamExplorer service = this.ServiceProvider.GetService(typeof(ITeamExplorer)) as ITeamExplorer;
                if (this.ContextManager == null)
                {
                    this.ContextManager = (ITeamFoundationContextManager)this.ServiceProvider.GetService(typeof(ITeamFoundationContextManager));
                }
                if (this.ContextManager != null)
                {
                    this.ContextManager.ContextChanged += new EventHandler<ContextChangedEventArgs>(this.ContextManager_ContextChanged);
                }
                if (service != null)
                {
                    service.ShowNotification("This is a simple notification", NotificationType.Information, NotificationFlags.None, null, new Guid());
                }
            }
        }

        public System.Drawing.Image Image
        {
            get { return null; }
        }

        public void Invalidate()
        {
        }

        public bool IsVisible
        {
            get { return true; }
        }

        public string Text
        {
            get { return "Show simple notification"; }
        }

        public void Dispose()
        {
            if (this.ContextManager != null)
            {
                this.ContextManager.ContextChanged -= new EventHandler<ContextChangedEventArgs>(this.ContextManager_ContextChanged);
            }
            this.ContextManager = null;
        }

        private void ContextManager_ContextChanged(object sender, ContextChangedEventArgs e)
        {
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
