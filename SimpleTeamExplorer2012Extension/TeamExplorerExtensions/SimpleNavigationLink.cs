namespace TeamExplorerExtensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.TeamFoundation.Controls;
    using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;

    [TeamExplorerSection("{696E87DE-6315-4E59-9F82-161D99BE182D}", "BCFB7AB4-3D5F-4D22-B297-FC933156882E", 8)]
    public class WorkItemPageSection : TeamExplorerSectionBase
    {
        protected override ITeamExplorerSection CreateViewModel(SectionInitializeEventArgs e)
        {
            return new WorkItemPageViewModel();
        }
    }

    [TeamExplorerNavigationLink("{C355CC29-896B-4CC0-A63A-370E629CA496}", "{6A2EB8BB-3557-4CF0-92FC-7CB56946BB6E}", 0)]
    public class SimpleNavigationLink : ITeamExplorerNavigationLink
    {
        public void Execute()
        {
            MessageBox.Show("Clicked on the link");
        }

        public void Invalidate()
        {
        }

        public bool IsEnabled
        {
            get { return true; }
        }

        public bool IsVisible
        {
            get { return true; }
        }

        public string Text
        {
            get { return "Link"; }
        }

        public void Dispose()
        {
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
