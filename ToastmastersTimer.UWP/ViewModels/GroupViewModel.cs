using System.Collections.ObjectModel;
using Template10.Mvvm;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class GroupViewModel: ViewModelBase
    {
        private ObservableCollection<Member> _members;

        public GroupViewModel()
        {
                Members = new ObservableCollection<Member>
                {
                    new Member {Name = "Bogdan Bujdea", Function="Member"},
                    new Member {Name = "Emil Popescu", Function="President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                    new Member {Name = "Paula Lupes", Function="Vice President"},
                };
        }

        public ObservableCollection<Member> Members
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