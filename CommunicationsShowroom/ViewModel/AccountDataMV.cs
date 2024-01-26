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
    public class AccountDataMV : BaseViewModel
    {
        private ObservableCollection<Account_Data> _employees;

        private Account_Data _employee;

        public AccountDataMV()
        {
            AccountData = new ObservableCollection<Account_Data>();
            LoadData();
        }
        public ObservableCollection<Account_Data> AccountData
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(AccountData));
            }
        }

        public Account_Data SelectAccountData
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Account_Data));
            }
        }
        public void LoadData()
        {
            if (_employees.Count > 0)
            {
                _employees.Clear();
            }

            var result = DbStorage.Db.Account_Data.ToList();

            result.ForEach(a => AccountData.Add(a));
        }

        public void DeleteData()
        {
            if (SelectAccountData != null)
            {
                using (var db = new YchotRemontnihKomplektuishuhEntities())
                {
                    var infoEmployees = db.Account_Data.Find(SelectAccountData.id);
                    if (infoEmployees != null)
                    {
                        db.Account_Data.Remove(infoEmployees);
                        db.SaveChanges();
                        SelectAccountData = null;
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
