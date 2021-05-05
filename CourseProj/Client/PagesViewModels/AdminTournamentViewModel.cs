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
    class AdminTournamentViewModel : BaseViewModel
    {
        public AdminTournamentViewModel()
        {
            var dx = new CyberContext();
            var com = dx.Tournaments.ToList();
            foreach (var c in com)
            {
                ShowedTournaments.Add(c);
            }
        }

        private ObservableCollection<Tournament> _showedTournaments;
        public ObservableCollection<Tournament> ShowedTournaments
        {
            get { return _showedTournaments ?? (_showedTournaments = new ObservableCollection<Tournament>()); }
            set
            {
                _showedTournaments = value;
                OnPropertyChanged();
            }
        }

        private Tournament _selectedTournament;
        public Tournament SelectedTournament
        {
            get { return _selectedTournament; }
            set
            {
                if (value == _selectedTournament)
                    return;
                _selectedTournament = value;
                SingleUser.SelectTournament = value;
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

        private RelayCommand _memberList;
        public RelayCommand MemberList
        {
            get
            {
                return _memberList ??
                    (_memberList = new RelayCommand(obj =>
                    {
                    if (SelectedTournament != null)
                    {
                        var cComM = new CreateSponsorAdmin();
                        cComM.Show();
                        }
                        else
                        {
                            MessageBox.Show("Выберите турнир из списка");
                        }
                    }));
            }
        }

        private RelayCommand _createTournament;
        public RelayCommand CreateTournament
        {
            get
            {
                return _createTournament ??
                    (_createTournament = new RelayCommand(obj =>
                    {
                        var cComT = new CreateTournament();
                        cComT.Show();

                    }));
            }
        }

        private RelayCommand _refreshTournament;
        public RelayCommand RefreshTournament
        {
            get
            {
                return _refreshTournament ??
                    (_refreshTournament = new RelayCommand(obj =>
                    {
                        ShowedTournaments.Clear();
                        var dx = new CyberContext();
                        var coms = dx.Tournaments.ToList();
                        foreach (var c in coms)
                        {
                            ShowedTournaments.Add(c);
                        }
                        SearchString = "";

                    }));
            }
        }

        private RelayCommand _deleteTournament;
        public RelayCommand DeleteTournament
        {
            get
            {
                return _deleteTournament ??
                    (_deleteTournament = new RelayCommand(obj =>
                    {
                        if (SelectedTournament != null)
                        {
                            var dx = new CyberContext();

                            var TournamentDel = dx.Tournaments
                                    .Where(c => c.TName == SelectedTournament.TName)
                                    .FirstOrDefault();

                            dx.Tournaments.Remove(TournamentDel);

                            var delMem = dx.Members
                                        .Where(m => m.NTournament == SelectedTournament.TName)
                                        .ToList();
                            foreach(var mem in delMem)
                            {
                                dx.Members.Remove(mem);
                            }
                            dx.SaveChanges();

                            ShowedTournaments.Remove(SelectedTournament);
                           
                        }
                        else
                        {
                            MessageBox.Show("Выберите турнир из списка");
                        }

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

                        var size = dx.Tournaments
                    .Where(c => c.TName.Contains(SearchString) || c.Game.Contains(SearchString))
                    .ToList();

                        if (size.Count > 0)
                        {
                            ShowedTournaments.Clear();
                            foreach (var com in size)
                            {
                                ShowedTournaments.Add(com);
                            }
                            //SearchString = "";
                        }
                        else { MessageBox.Show("Ничего не найдено"); }


                    }));
            }
        }

    }
}
