namespace TeamExplorerExtensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Controls;
    using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer.Framework;
    using Microsoft.VisualStudio.Shell;

    [TeamExplorerNavigationItem("{89A024C5-B275-456D-8486-6F335C21E7E9}", 0x3e7)]
    public class MessageNavigationItem : ITeamExplorerNavigationItem
    {
        private ITeamFoundationContextManager ContextManager;

        [ImportMany]
        public List<Lazy<ITeamExplorerNavigationItem, ITeamExplorerNavigationItemMetadata>> NavigationItemCandidates
        {
            get;
            set;
        }

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
                    if (NavigationItemCandidates != null)
                    {
                        string text = string.Empty;

                        foreach (var navigationItemCandidates in NavigationItemCandidates)
                        {
                            if (!navigationItemCandidates.IsValueCreated)
                                continue;

                            text += navigationItemCandidates.Value.Text + Environment.NewLine;
                        }

                        service.ShowNotification(text, NotificationType.Information, NotificationFlags.None, null, Guid.NewGuid());
                    }
                    else
                        service.ShowNotification("This is a simple notification", NotificationType.Information, NotificationFlags.None, null, new Guid());

                    //ITeamExplorer explorer = ServiceProvider.GetService(typeof(ITeamExplorer)) as ITeamExplorer;
                    //if (explorer != null)
                    //{
                    //    var page = explorer.CurrentPage;
                    //    string info = page.GetId().ToString() + Environment.NewLine;
                    //    var sections = page.GetSections();
                    //    foreach (var section in sections)
                    //        info += section.Title + " " + section.GetId() + Environment.NewLine;
                    //    MessageBox.Show(info);
                    //}
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
