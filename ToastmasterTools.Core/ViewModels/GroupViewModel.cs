using System.Collections.ObjectModel;
using Template10.Mvvm;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.ViewModels
{
    public class GroupViewModel: ViewModelBase
    {
        private ObservableCollection<Speaker> _members;

        public GroupViewModel()
        {
                Members = new ObservableCollection<Speaker>
                {
                    new Speaker {Name = "Bogdan Bujdea", Function="Member"},
                    new Speaker {Name = "Emil Popescu", Function="President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                    new Speaker {Name = "Paula Lupes", Function="Vice President"},
                };
        }

        public ObservableCollection<Speaker> Members
        {
            get { return _members; }
            set
            {
                _members = value; 
                RaisePropertyChanged();
            }
        }
    }
}