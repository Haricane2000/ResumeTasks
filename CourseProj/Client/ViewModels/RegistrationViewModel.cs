using Client.Commands;
using Client.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    class RegistrationViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;
                switch(name)
                {
                    case "Login":
                        if (string.IsNullOrWhiteSpace(Login))
                            result = "Поле не может быть пустым";
                        else if (Login.Length < 3)
                            result = "Логин должен быть не меньше 3 символов";
                        break;

                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
                            result = "Поле не может быть пустым";
                        else if (Password.Length < 7)
                            result = "Пароль должен быть не меньше 7 символов";
                        break;

                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Поле не может быть пустым";
                        else if (IsCharsOnly(Name) != true)
                            result = "Имя не может содержать цифры";
                        break;

                    case "SecondName":
                        if (string.IsNullOrWhiteSpace(SecondName))
                            result = "Поле не может быть пустым";
                        else if (IsCharsOnly(SecondName) != true)
                            result = "Фамилия не может содержать цифры";
                        break;

                    case "Patronymic":
                        if (string.IsNullOrWhiteSpace(Patronymic))
                            result = "Поле не может быть пустым";
                        else if (IsCharsOnly(Patronymic) != true)
                            result = "Отчество не может содержать цифры";
                        break;

                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            result = "Поле не может быть пустым";
                        else if (isValidEmail(Email) != true)
                            result = "Неверный формат почты";
                        break;

                    case "PhoneNumber":
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            result = "Поле не может быть пустым";
                        else if (IsDigitalsOnly(PhoneNumber) != true)
                            result = "Номер не может содержать буквы";
                        else if (PhoneNumber.Length > 9)
                            result = "В номере не может быть больше 9 цифр";
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
        bool IsCharsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c > '0' & c < '9')
                    return false;
            }

            return true;
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

        bool isValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
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

        private string _password = "";
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

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _secondName = "";
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (value == _secondName)
                    return;
                _secondName = value;
                OnPropertyChanged();
            }
        }

        private string _patronymic = "";
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (value == _patronymic)
                    return;
                _patronymic = value;
                OnPropertyChanged();
            }
        }

        private DateTime _birthYear= DateTime.Today;
        public DateTime BirthYear
        {
            get { return _birthYear; }
            set
            {
                if (value == _birthYear)
                    return;
                _birthYear = value;
                OnPropertyChanged();
            }
        }

        private string _email = "";
        public string Email
        {
            get { return _email; }
            set
            {
                if (value == _email)
                    return;
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value == _phoneNumber)
                    return;
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private int _rank;
        public int Rank
        {
            get { return _rank; }
            set
            {
                if (value == _rank)
                    return;
                _rank = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _getRank;
        public RelayCommand GetRank
        {
            get
            {
                return _getRank ??
                    (_getRank = new RelayCommand(obj =>
                    {
                        Rank = Convert.ToInt32(obj.ToString());


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
                        if (Login.Length > 0 & Password.Length > 0 & Name.Length > 0 & SecondName.Length > 0 & Patronymic.Length > 0 & Email.Length > 0 & PhoneNumber.Length > 0)
                        {
                            string UsPass = SingleUser.GetMD5Hash(_password);

                            var regUser = new User();
                            regUser.Login = _login;
                            regUser.Paasword = UsPass;
                            regUser.FirstName = _name;
                            regUser.SecondName = _secondName;
                            regUser.Patronymic = _patronymic;
                            regUser.BirthYear = Convert.ToString(_birthYear.ToShortDateString());
                            regUser.Email = _email;
                            regUser.PhoneNumber = "+375"+_phoneNumber;
                            regUser.URank = _rank;

                            var context = new CyberContext();

                            using (var transaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    context.Users.Add(regUser);
                                    context.SaveChanges();
                                    transaction.Commit();
                                    MessageBox.Show("Вы успешно зарегистрировались");
                                    var LoginW = new Login();
                                    LoginW.Show();
                                    var window = Application.Current.Windows[0];
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

        private RelayCommand _back;
        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(obj =>
                    {
                        var AutoW = new Login();
                        AutoW.Show();
                        var window = Application.Current.Windows[0];
                        if (window != null)
                            window.Close();


                    }));
            }
        }
    }
}
