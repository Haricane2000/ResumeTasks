using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.PagesViewModels
{
    class AdminCommandsViewModel : BaseViewModel
    {
        public AdminCommandsViewModel()
        {
            var dx = new CyberContext();
            var com = dx.Commands.ToList();
            foreach (var c in com)
            {
                ShowedCommand.Add(c);
            }
        }

        public ObservableCollection<Command> _showedCommand;
        public ObservableCollection<Command> ShowedCommand
        {
            get { return _showedCommand ?? (_showedCommand = new ObservableCollection<Command>()); }
            set
            {
                _showedCommand = value;
                OnPropertyChanged();
            }
        }
    }
}
