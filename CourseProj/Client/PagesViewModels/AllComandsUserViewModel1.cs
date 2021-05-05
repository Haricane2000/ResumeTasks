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
using System.Windows.Controls;
using System.Windows.Documents;

namespace Client.PagesViewModels
{
    class AllComandsUserViewModel1 : BaseViewModel
    {
        public AllComandsUserViewModel1()
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

        private Command _selectedCommand;
        public Command SelectedCommand
        {
            get { return _selectedCommand; }
            set
            {
                if (value == _selectedCommand)
                    return;
                _selectedCommand = value;

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

        private RelayCommand _createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return _createCommand ??
                    (_createCommand = new RelayCommand(obj =>
                    {
                        var cComW = new CreateCommand();
                        cComW.Show();

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
                        ShowedCommand.Clear();
                        var dx = new CyberContext();
                        var coms = dx.Commands.ToList();
                        foreach (var c in coms)
                        {
                            ShowedCommand.Add(c);
                        }
                        SearchString="";

                    }));
            }
        }

        private RelayCommand _inviteCommamd;
        public RelayCommand InviteCommand
        {
            get
            {
                return _inviteCommamd ??
                    (_inviteCommamd = new RelayCommand(obj =>
                    {
                        if (SelectedCommand != null)
                        {
                            var dx = new CyberContext();

                            var size = dx.Users
                                        .Where(s => s.Command == SelectedCommand.Title);
                            int sizec = size.Count();

                            if (sizec < SelectedCommand.MaxSize)
                            {
                                var us = dx.Users
                                         .Where(c => c.Login == SingleUser.user.Login && c.Paasword == SingleUser.user.Paasword)
                                         .FirstOrDefault();

                                us.Command = SelectedCommand.Title;
                                SingleUser.user = us;
                                dx.SaveChanges();

                                MessageBox.Show("Вы вступили в комманду " + SelectedCommand.Title);
                            }
                            else { MessageBox.Show("Комманда переполнена"); }
                        }
                        else { MessageBox.Show("Выберите комманду из списка"); }
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

                        var size = dx.Commands
                    .Where(c => c.Title.Contains(SearchString) || c.Admin.Contains(SearchString) || c.FullName.Contains(SearchString))
                    .ToList();

                        if (size.Count > 0)
                        {
                            ShowedCommand.Clear();
                            foreach(var com in size)
                            {
                                ShowedCommand.Add(com);
                            }
                            //SearchString = "";
                        }
                        else { MessageBox.Show("Ничего не найдено"); }


                    }));
            }
        }
    }
}
