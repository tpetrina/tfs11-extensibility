using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.Shell;

namespace Example2.ContextSensitiveNavigationItem
{
    [TeamExplorerNavigationItem("{8D79F188-21CC-4FC7-ADC9-62A230896164}", 11000)]
    public class ContextSensitiveNavigationItem : ITeamExplorerNavigationItem
    {
        private string _text;
        private bool _isVisible;

        private ITeamFoundationContextManager _contextManager;
        private ITeamExplorer _service;

        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }

        public void Execute()
        {
        }

        public System.Drawing.Image Image
        {
            get { return null; }
        }

        public void Invalidate()
        {
            if (_contextManager == null && ServiceProvider != null)
            {
                _contextManager = ServiceProvider.GetService(typeof(ITeamFoundationContextManager)) as ITeamFoundationContextManager;
                if (_contextManager != null)
                {
                    _contextManager.ContextChanged += _contextManager_ContextChanged;
                    UpdateText(_contextManager.CurrentContext);
                }
            }

            if (_service == null && ServiceProvider != null)
                _service = ServiceProvider.GetService(typeof(ITeamExplorer)) as ITeamExplorer;
        }

        void _contextManager_ContextChanged(object sender, ContextChangedEventArgs e)
        {
            UpdateText(e.NewContext);
        }

        private void UpdateText(ITeamFoundationContext teamFoundationContext)
        {
            if (teamFoundationContext == null || string.IsNullOrEmpty(teamFoundationContext.TeamProjectName))
                Text = string.Empty;
            else
                Text = "Plugin connected to " + teamFoundationContext.TeamProjectName;
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible == value)
                    return;
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;

                _text = value;
                IsVisible = !string.IsNullOrEmpty(_text);
                RaisePropertyChanged("Text");
            }
        }

        public void Dispose()
        {
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }
    }
}
