namespace Example1.SimpleNavigationItem
{
    using Microsoft.TeamFoundation.Controls;

    [TeamExplorerNavigationItem("{70871EF0-6965-431B-94C1-8EA914F9E519}", 10000)]
    public class SimpleNavigationItem : ITeamExplorerNavigationItem
    {
        public void Execute() { }

        public System.Drawing.Image Image
        {
            get { return null; }
        }

        public void Invalidate() { }

        public bool IsVisible
        {
            get { return true; }
        }

        public string Text
        {
            get { return "Simple navigation link"; }
        }

        public void Dispose() { }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
