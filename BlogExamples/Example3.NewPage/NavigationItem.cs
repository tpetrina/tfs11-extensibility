using System.ComponentModel.Composition;
using System.Drawing;
using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;
using Microsoft.VisualStudio.Shell;

namespace Example3.NewPage
{
    [TeamExplorerNavigationItem("{E9C94375-3287-4CBC-9BFE-5822CCA62D2C}", 500, TargetPageId = "{4A8ECFE5-6B30-43E0-AE85-6C8A2C960C4D}")]
    public class NavigationItem : ITeamExplorerNavigationItem
    {
        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }

        public void Execute()
        {
            TeamExplorerUtils.Instance.NavigateToPage("4A8ECFE5-6B30-43E0-AE85-6C8A2C960C4D", ServiceProvider, null);
        }

        public Image Image
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
            get { return "Go to My Page"; }
        }

        public void Dispose()
        {
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
