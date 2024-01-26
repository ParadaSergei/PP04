using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOfResonantComponent.ViewModel
{
    public class AccountEmployeesMV : BaseViewModel
    {
        private ObservableCollection<Account> _accountEmployees;

        private Account _accountEmployee;

        public AccountEmployeesMV()
        {
            AccountEmployees = new ObservableCollection<Account>();
            LoadData();
        }
        public ObservableCollection<Account> AccountEmployees
        {
            get => _accountEmployees;
            set
            {
                _accountEmployees = value;
                OnPropertyChanged(nameof(AccountEmployees));
            }
        }

        public Account SelectAccountEmployees
        {
            get => _accountEmployee;
            set
            {
                _accountEmployee = value;
                OnPropertyChanged(nameof(SelectAccountEmployees));
            }
        }
        public void LoadData()
        {
            if (_accountEmployees.Count > 0)
            {
                _accountEmployees.Clear();
            }

            var result = DbStorage.Db.Account.ToList();

            result.ForEach(a => AccountEmployees?.Add(a));
        }

        public void DeleteData()
        {
            if (SelectAccountEmployees != null)
            {
                using (var db = new YchotRemontnihKomplektuishuhEntities())
                {
                    var accountEmployees = db.Account.Find(SelectAccountEmployees.id);
                    if (accountEmployees != null)
                    {
                        db.Account.Remove(accountEmployees);
                        db.SaveChanges();
                        SelectAccountEmployees = null;
                        LoadData();
                        MessageBox.Show("Объект успешно удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
