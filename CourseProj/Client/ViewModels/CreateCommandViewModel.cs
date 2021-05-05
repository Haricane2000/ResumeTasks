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
    class CreateCommandViewModel : BaseViewModel, IDataErrorInfo
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
                    case "ShortName":
                        if (string.IsNullOrWhiteSpace(ShortName))
                            result = "Поле не может быть пустым";
                        else if (ShortName.Length >5)
                            result = "Макс 5 символов в кратком названии";
                        break;

                    case "FullName":
                        if (string.IsNullOrWhiteSpace(FullName))
                            result = "Поле не может быть пустым";
                        break;

                    case "Size":
                        if (string.IsNullOrWhiteSpace(Size))
                            result = "Поле не может быть пустым";
                        else if (IsDigitalsOnly(Size) != true)
                            result = "Поле не может содержать буквы";
                        else if (Convert.ToInt32 (Size) > 10 || Convert.ToInt32( Size)<2)
                            result = "Кол-во участников в диапозоне от 2 до 10";
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

        private string _shortName="";
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                if (value == _shortName)
                    return;
                _shortName = value;
                OnPropertyChanged();
            }
        }

        private string _fullName="";
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (value == _fullName)
                    return;
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private string _size="";
        public string Size
        {
            get { return _size; }
            set
            {
                if (value == _size)
                    return;
                _size = value;
                OnPropertyChanged();
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

        private RelayCommand _createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return _createCommand ??
                    (_createCommand = new RelayCommand(obj =>
                    {
                        if (FullName.Length>2 & ShortName.Length>1 & Size.Length>0)
                        {
                            var cCommand = new Command();
                            cCommand.Title = _shortName;
                            cCommand.FullName = _fullName;
                            if (IsDigitalsOnly(Size))
                            {
                                cCommand.MaxSize = Convert.ToInt32(_size);
                            }
                            else { MessageBox.Show("Проверьте корректность введенных данных"); return; }
                            cCommand.Admin = SingleUser.user.Login;


                            var context = new CyberContext();
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    context.Commands.Add(cCommand);
                                    var us = context.Users
                                             .Where(c => c.Login == SingleUser.user.Login && c.Paasword == SingleUser.user.Paasword)

                                             .FirstOrDefault();
                                    us.Command = _shortName;
                                    SingleUser.user = us;
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
                        else { MessageBox.Show("Заполните все поля"); }

                    }));
            }
        }
    }
}
