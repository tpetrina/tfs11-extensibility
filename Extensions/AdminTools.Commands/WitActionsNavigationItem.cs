using System.ComponentModel.Composition;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.Shell;

namespace AdminTools.Commands
{
    [TeamExplorerNavigationItem("{CD269465-EBD6-4DF4-87FA-448D4B3C4782}", 11000)]
    public class WitActionsNavigationItem : ViewModelBase, ITeamExplorerNavigationItem
    {
        private ITeamFoundationContextManager _contextManager;

        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }

        private bool _isVisible = true;
        private string _text = "Admin Tools";

        public System.Drawing.Image Image
        {
            get { return null; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
        }

        public string Text
        {
            get { return _text; }
            set { SetAndRaise(ref _text, value); }
        }

        public void Invalidate() { }

        public void Execute() { }

        public void Dispose() { }

    }
}
