using Client.Commands;
using Client.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Client.ViewModels
{
    
    class LoginViewModel : BaseViewModel, IDataErrorInfo
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
                    case "Login":
                        if (string.IsNullOrWhiteSpace(Login))
                            result = "Поле не может быть пустым";
                        break;

                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
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

        private string _login="";
        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login)
                    return;
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _password="";
        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                    return;
                _password = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _authorization;
        public RelayCommand Authorization
        {
            get
            {
                return _authorization ??
                    (_authorization = new RelayCommand(obj =>
                    {
                    if (Login.Length > 0 & Password.Length > 0)
                    {
                        string UsPass = SingleUser.GetMD5Hash(_password);

                        var context = new CyberContext();
                        var authorization = from c in context.Users
                                            where c.Login == _login && c.Paasword ==UsPass
                                            select c ;
                        if (authorization.Count()==0)
                        {
                            MessageBox.Show("Проверьте введенный логин и пароль");
                            return;
                        }
                        
                        SingleUser.user = authorization.First();
                        if (SingleUser.user.URank == 0)
                        {
                            var PlayerW = new Player();
                            PlayerW.Show();
                            var window = Application.Current.Windows[0];
                            if (window != null)
                                window.Close();
                        }
                        if (SingleUser.user.URank == 1)
                        {
                            var AdminW = new Administrator();
                            AdminW.Show();
                            var window = Application.Current.Windows[0];
                            if (window != null)
                                window.Close();
                        }
                        }
                        else { MessageBox.Show("Заполнены не все поля"); }
                    }));
            }
        }

        private RelayCommand _registration;
        public RelayCommand Registration
        {
            get
            {
                return _registration ??
                    (_registration = new RelayCommand(obj =>
                    {
                        var RegistrW = new Registration();
                        RegistrW.Show();
                        var window = Application.Current.Windows[0];
                        if (window != null)
                            window.Close();


                    }));
            }
        }
    }
   

}
