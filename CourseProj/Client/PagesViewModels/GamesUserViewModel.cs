using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.PagesViewModels
{
    class GamesUserViewModel : BaseViewModel
    {
        public GamesUserViewModel()
        {
            var dx = new CyberContext();
            var com = dx.Games.ToList();
            foreach (var c in com)
            {
                ShowedGames.Add(c);
            }
        }

        public ObservableCollection<Game> _showedGames;
        public ObservableCollection<Game> ShowedGames
        {
            get { return _showedGames ?? (_showedGames = new ObservableCollection<Game>()); }
            set
            {
                _showedGames = value;
                OnPropertyChanged();
            }
        }
    }
}
