using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

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

    public class Member
    {
        public string Name { get; set; }

        public string Function { get; set; }
    }
}