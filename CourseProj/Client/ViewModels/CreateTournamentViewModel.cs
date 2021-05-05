using Client.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    class CreateTournamentViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;
                switch (name)
                {
                    case "TournamentName":
                        if (string.IsNullOrWhiteSpace(TournamentName))
                            result = "Поле не может быть пустым";
                        break;

                    case "TPrize":
                        if (string.IsNullOrWhiteSpace(TPrize))
                            result = "Поле не может быть пустым";
                        else if (IsDigitalsOnly(TPrize) != true)
                            result = "Поле должно содержать тольцо цифры";
                        break;

                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");

                return result;
            }
        }

        bool IsDigitalsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public ObservableCollection<string> _showedGame;
        public ObservableCollection<string> ShowedGame
        {
            get { return _showedGame ?? (_showedGame = new ObservableCollection<string>()); }
            set
            {
                _showedGame = value;
                OnPropertyChanged();
            }
        }
        public CreateTournamentViewModel()
        {
            var dx = new CyberContext();
            var com = dx.Games.ToList();
            foreach (var c in com)
            {
                ShowedGame.Add(c.GameName);
            }
        }

        private string _tournamentName="";
        public string TournamentName
        {
            get { return _tournamentName; }
            set
            {
                if (value == _tournamentName)
                    return;
                _tournamentName = value;
                OnPropertyChanged();
            }
        }

        private string _selectedGame;
        public string SelectedGame
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



        private DateTime _TDate = DateTime.Now;
        public DateTime TDate
        {
            get { return _TDate; }
            set
            {
                if (value == _TDate)
                    return;
                _TDate = value;
                OnPropertyChanged();
            }
        }

        private string _tPrize="0";
        public string TPrize
        {
            get { return _tPrize; }
            set
            {
                if (value == _tPrize)
                    return;
                _tPrize = value;
                OnPropertyChanged();
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
                    if (TournamentName.Length > 0 & TPrize.Length > 0 )
                    {
                        var cTournament = new Tournament();
                        cTournament.TName = TournamentName;
                        cTournament.Game = SelectedGame;
                        cTournament.Date = TDate;
                        if (IsDigitalsOnly(TPrize))
                        {
                            cTournament.Prize = Convert.ToInt32(TPrize);
                        }
                        else { MessageBox.Show("Проверьте корректность введенных данных"); return; }



                        var context = new CyberContext();


                        using (var transaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                context.Tournaments.Add(cTournament);
                                context.SaveChanges();
                                transaction.Commit();
                                var window = Application.Current.Windows[1];
                                if (window != null)
                                    window.Close();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Проверьте корректность введенных данных");
                            }
                        }
                        }
                        else { MessageBox.Show("Заполнены не все поля"); }
                    }));
            }
        }
    }
}
