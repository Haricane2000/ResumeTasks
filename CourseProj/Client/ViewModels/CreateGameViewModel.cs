using Client.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    class CreateGameViewModel : BaseViewModel, IDataErrorInfo
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
                    case "GameName":
                        if (string.IsNullOrWhiteSpace(GameName))
                            result = "Поле не может быть пустым";
                        break;

                    case "CompanyName":
                        if (string.IsNullOrWhiteSpace(CompanyName))
                            result = "Поле не может быть пустым";
                        break;

                    case "GameType":
                        if (string.IsNullOrWhiteSpace(GameType))
                            result = "Поле не может быть пустым";
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

        private string _gameName="";
        public string GameName
        {
            get { return _gameName; }
            set
            {
                if (value == _gameName)
                    return;
                _gameName = value;
                OnPropertyChanged();
            }
        }

        private string _companyName="";
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (value == _companyName)
                    return;
                _companyName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if (value == _createDate)
                    return;
                _createDate = value;
                OnPropertyChanged();
            }
        }

        private string _gameType="";
        public string GameType
        {
            get { return _gameType; }
            set
            {
                if (value == _gameType)
                    return;
                _gameType = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _createGame;
        public RelayCommand CreateGame
        {
            get
            {
                return _createGame ??
                    (_createGame = new RelayCommand(obj =>
                    {
                    if (GameName.Length > 0 & CompanyName.Length > 0 & GameType.Length > 0)
                    {
                        var cGame = new Game();
                        cGame.GameName = GameName;
                        cGame.CompanyName = CompanyName; 
                        cGame.Year = CreateDate;
                        cGame.GameType = GameType;


                        var context = new CyberContext();

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.Games.Add(cGame);
                      
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
