using Client.Commands;
using Client.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Client.ViewModels
{
    class PlayerViewModel : BaseViewModel
    {
        private Page userTournament;
        private Page profile;
        private Page myCommand;
        private Page allCommands;
        private Page allGames;

        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged();
            }
        }

        private double _frameOpacity;
        public double FrameOpacity {
            get { return _frameOpacity; }
            set 
            {
                if (_frameOpacity == value)
                    return;
                _frameOpacity = value;
                OnPropertyChanged();
            } 
        }

        public PlayerViewModel()
        {
            userTournament = new Pages.UserTournament();
            profile = new Pages.Profile();
            myCommand = new Pages.MyCommand();
            allCommands = new Pages.AllCommands();
            allGames = new Pages.AllGames();

            FrameOpacity = 1;

            CurrentPage = profile;
        }

        private RelayCommand menuProfile;
        public RelayCommand MenuProfile
        {
            get
            {
                return menuProfile??
                    (menuProfile = new RelayCommand(obj=>
                {
                    SlowOpacity(profile);
                }));
            }
        }

        private RelayCommand menuUserTournament;
        public RelayCommand MenuUserTournament
        {
            get
            {
                return menuUserTournament ??
                    (menuUserTournament = new RelayCommand(obj =>
                    {
                        SlowOpacity(userTournament);
                    }));
            }
        }

        private RelayCommand menuMyCommand;
        public RelayCommand MenuMyCommand
        {
            get
            {
                return menuMyCommand ??
                    (menuMyCommand = new RelayCommand(obj =>
                    {
                        SlowOpacity(myCommand);
                    }));
            }
        }

        private RelayCommand menuAllCommands;
        public RelayCommand MenuAllCommands
        {
            get
            {
                return menuAllCommands ??
                    (menuAllCommands = new RelayCommand(obj =>
                    {
                       
                        SlowOpacity(allCommands);
                    }));
            }
        }

        private RelayCommand menuAllGames;
        public RelayCommand MenuAllGames
        {
            get
            {
                return menuAllGames ??
                    (menuAllGames = new RelayCommand(obj =>
                    {
                        SlowOpacity(allGames);
                    }));
            }
        }

        private RelayCommand _exit;
        public RelayCommand Exit
        {
            get
            {
                return _exit ??
                    (_exit = new RelayCommand(obj =>
                    {
                        var AutoW = new Login();
                        AutoW.Show();
                        var window = Application.Current.Windows[0];
                        if (window != null)
                            window.Close();


                    }));
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }

                CurrentPage = page;

                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
            
        }
    }
}
