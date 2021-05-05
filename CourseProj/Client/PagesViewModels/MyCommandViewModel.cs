using Client.Commands;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.PagesViewModels
{
    class MyCommandViewModel : BaseViewModel
    {
        public MyCommandViewModel()
        {
            if (SingleUser.user.Command != null)
            {
                _cName = SingleUser.user.Command1.Title;
                _cFullName = SingleUser.user.Command1.FullName;
                _cSize = SingleUser.user.Command1.MaxSize;
                _cAdmin = SingleUser.user.Command1.Admin;
            }
        }

        private string _cName;

        public string CName
        {
            get { return _cName; }
            set
            {
                if (value == _cName)
                    return;
                _cName = value;
                OnPropertyChanged();
            }
        }

        private string _cFullName;
        public string CFullName
        {
            get { return _cFullName; }
            set
            {
                if (value == _cFullName)
                    return;
                _cFullName = value;
                OnPropertyChanged();
            }
        }

        private int? _cSize;
        public int? CSize
        {
            get { return _cSize; }
            set
            {
                if (value == _cSize)
                    return;
                _cSize = value;
                OnPropertyChanged();
            }
        }

        private string _cAdmin;
        public string CAdmin
        {
            get { return _cAdmin; }
            set
            {
                if (value == _cAdmin)
                    return;
                _cAdmin = value;
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

                        var com = context.Commands
                                 .Where(c => c.Title == SingleUser.user.Command)

                                 .FirstOrDefault();
                        if (CName == null || CFullName == null || CSize == null)
                        {
                            if (com != null)
                            {
                                CName = com.Title;
                                CFullName = com.FullName;
                                CSize = com.MaxSize;
                                CAdmin = com.Admin;
                            }
                        }
                        else
                        {

                            if (CName != com.Title || CFullName != com.FullName || CSize != com.MaxSize)
                            {
                                if (SingleUser.user.Login == SingleUser.user.Command1.Admin)
                                {
                                    try
                                    {
                                        com.Title = CName;
                                        com.FullName = CFullName;
                                        com.MaxSize = CSize;
                                        context.SaveChanges();
                                        MessageBox.Show("Изменения сохранены");
                                        return;
                                    }
                                    catch { MessageBox.Show("Проверьте введенные данные"); }
                                }
                                else { MessageBox.Show("У вас недостаточно прав"); }
                            }

                            if (com != null)
                            {
                                CName = com.Title;
                                CFullName = com.FullName;
                                CSize = com.MaxSize;
                                CAdmin = com.Admin;
                            }
                        }
                    }));
            }
        }
    }
}
