using Client.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    class CreateSponsorAdminViewModel : BaseViewModel
    {
        public CreateSponsorAdminViewModel()
        {
            var dx = new CyberContext();
            var com = from c in dx.Members
                      where c.NTournament == SingleUser.SelectTournament.TName
                      select c;
            foreach (var c in com)
            {
                ShowedMember.Add(c);
            }
        }

        public ObservableCollection<Member> _showedMember;
        public ObservableCollection<Member> ShowedMember
        {
            get { return _showedMember ?? (_showedMember = new ObservableCollection<Member>()); }
            set
            {
                _showedMember = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _saveMembers;
        public RelayCommand SaveMembers
        {
            get
            {
                return _saveMembers ??
                    (_saveMembers = new RelayCommand(obj =>
                    {


                        var dx = new CyberContext();
                        using (var transaction = dx.Database.BeginTransaction())
                        {
                            try
                            {
                                var com = from c in dx.Members
                                          where c.NTournament == SingleUser.SelectTournament.TName
                                          select c;
                                foreach (var c in com)
                                {
                                    for (int i = 0; i < ShowedMember.Count; i++)
                                    {
                                        if (c.NCommand == ShowedMember[i].NCommand)
                                        {
                                            if (c.Confirm.CompareTo(ShowedMember[i].Confirm) != 0)
                                            {
                                                c.Confirm = ShowedMember[i].Confirm;

                                            }
                                        }
                                    }
                                }
                                dx.SaveChanges();
                                transaction.Commit();
                                MessageBox.Show("Изменения приняты");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Повторите попытку еще раз");
                            }
                        }
                    }));
            }
        }
    }
}
