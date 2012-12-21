using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Controls;

namespace Example3.NewPage
{
    [TeamExplorerPage("{4A8ECFE5-6B30-43E0-AE85-6C8A2C960C4D}")]
    public class Page : ITeamExplorerPage
    {
        private string _title = "Info page";
        PageView _pageContent = null;

        public bool IsBusy
        {
            get { return false; }
        }

        public object PageContent
        {
            get
            {
                if (_pageContent == null)
                    _pageContent = new PageView();

                return _pageContent;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public void Cancel()
        {
        }

        public object GetExtensibilityService(Type serviceType)
        {
            return null;
        }

        public void Initialize(object sender, PageInitializeEventArgs e)
        {
        }

        public void Loaded(object sender, PageLoadedEventArgs e)
        {
        }

        public void Refresh()
        {
        }

        public void SaveContext(object sender, PageSaveContextEventArgs e)
        {
        }

        public void Dispose()
        {
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
