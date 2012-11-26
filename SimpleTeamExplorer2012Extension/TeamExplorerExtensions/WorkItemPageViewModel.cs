namespace TeamExplorerExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;

    public class WorkItemPageViewModel : TeamExplorerSectionViewModelBase
    {
        public override void Initialize(object sender, Microsoft.TeamFoundation.Controls.SectionInitializeEventArgs e)
        {
            base.Initialize(sender, e);
            this.Title = "Custom section";
            this.IsVisible = true;
            this.IsExpanded = true;
            this.IsBusy = false;
        }
    }
}
