using Client.Commands;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.PagesViewModels
{
    class UserProfileViewModel : BaseViewModel
    {
        private string _login= SingleUser.user.Login;
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

        private string _name= SingleUser.user.FirstName;
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

        private string _seconName= SingleUser.user.SecondName;
        public string SecondName
        {
            get { return _seconName; }
            set
            {
                if (value == _seconName)
                    return;
                _seconName = value;
                OnPropertyChanged();
            }
        }

        private string _patronymic= SingleUser.user.Patronymic;
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

        private string _birthYear= SingleUser.user.BirthYear;
        public string BirthYear
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

        private string _email= SingleUser.user.Email;
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

        private string _phoneNumber= SingleUser.user.PhoneNumber;
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

        private string _command= SingleUser.user.Command;
        public string MyCommand
        {
            get { return _command; }
            set
            {
                if (value == _command)
                    return;
                _command = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _refresh;
        public RelayCommand Refresh
        {
            get
            {
                return _refresh ??
                    (_refresh = new RelayCommand(obj =>
                    {
                        var context = new CyberContext();

                        var us = context.Users
                                 .Where(c => c.Login == SingleUser.user.Login && c.Paasword==SingleUser.user.Paasword)

                                 .FirstOrDefault();

                        Login = us.Login;
                        Name = us.FirstName;
                        SecondName = us.SecondName;
                        Patronymic = us.Patronymic;
                        BirthYear = us.BirthYear;
                        Email = us.Email;
                        PhoneNumber = us.PhoneNumber;
                        MyCommand = us.Command;
                    }));
            }
        }
    }
}
