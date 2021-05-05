using Client.Commands;
using Client.ViewModels;
using Client.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.PagesViewModels
{
    class AdminGamesViewModel : BaseViewModel
    {
        private RelayCommand _createGame;
        public RelayCommand CreateGame
        {
            get
            {
                return _createGame ??
                    (_createGame = new RelayCommand(obj =>
                    {
                        var cComG = new CreateGame();
                        cComG.Show();

                    }));
            }
        }

        public AdminGamesViewModel()
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

        private Game _selectedGame=null;
        public Game SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                if (value == _selectedGame)
                    return;
                _selectedGame = value;

                OnPropertyChanged();
            }
        }

        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString)
                    return;
                _searchString = value;

                OnPropertyChanged();
            }
        }

        private RelayCommand _deleteGame;
        public RelayCommand DeleteGame
        {
            get
            {
                return _deleteGame ??
                    (_deleteGame = new RelayCommand(obj =>
                    {
                        if (SelectedGame != null)
                        {
                            var dx = new CyberContext();

                            var GameDel = dx.Games
                                    .Where(c => c.GameName==SelectedGame.GameName)
                                    .FirstOrDefault();
                            var TGames = from c in dx.Tournaments
                                     where c.Game == SelectedGame.GameName
                                     select c;
                       
                            if (TGames.Count() == 0)
                            {
                                dx.Games.Remove(GameDel);
                                dx.SaveChanges();
                                ShowedGames.Remove(SelectedGame);
                            }
                            else
                            {
                                MessageBox.Show("По этой игре проводятся турниры");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите игру из списка");
                        }

                    }));
            }
        }

        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ??
                    (_refreshCommand = new RelayCommand(obj =>
                    {
                        ShowedGames.Clear();
                        var dx = new CyberContext();
                        var coms = dx.Games.ToList();
                        foreach (var c in coms)
                        {
                            ShowedGames.Add(c);
                        }
                        SearchString = "";

                    }));
            }
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand ??
                    (_searchCommand = new RelayCommand(obj =>
                    {

                        var dx = new CyberContext();

                        var size = dx.Games
                    .Where(c => c.GameName.Contains(SearchString) || c.GameType.Contains(SearchString) || c.CompanyName.Contains(SearchString))
                    .ToList();

                        if (size.Count > 0)
                        {
                            ShowedGames.Clear();
                            foreach (var com in size)
                            {
                                ShowedGames.Add(com);
                            }
                            //SearchString = "";
                        }
                        else { MessageBox.Show("Ничего не найдено"); }


                    }));
            }
        }
    }
}
