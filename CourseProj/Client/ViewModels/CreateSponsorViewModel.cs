using Client.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
   
    class CreateSponsorViewModel : BaseViewModel
    {
        public CreateSponsorViewModel()
        {
            var dx = new CyberContext();
            var com = from c in dx.Members
                      where c.NTournament == SingleUser.SelectTournament.TName & c.Confirm==true
                      select c;
            foreach (var c in com)
            {
                ShowedMember.Add(c);
            }
        }

        public ObservableCollection<Member> _showedMember;
        public ObservableCollection<Member> ShowedMember
        {
            get { return _showedMember ?? (_showedMember = new ObservableCollection<Member>()); }
            set
            {
                _showedMember = value;
                OnPropertyChanged();
            }
        }

        
    }
}
