using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using AccountingOfResonantComponent.View;
using AccountingOfResonantComponent.View.Window;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOfResonantComponent.ViewModel
{
    public class AutorizVM : BaseViewModel
    {
        private string _buttonDescription = "Войти";
        public Account _account;
       // public AccountEmployees _accountEmployees;
       // public Client client;
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ButtonDes
        {
            get => _buttonDescription;
            set
            {
                _buttonDescription = value;
                OnPropertyChanged(nameof(ButtonDes));
            }
        }
        public async Task<bool> Authorizations(string login, string password)
        {
            try
            {

                /*  var resultClient = await DbStorage.Db.Account.FirstOrDefaultAsync(client => client.Login == login && client.Password == password);
                  _account = resultClient;*/
                var resultEmployees = await DbStorage.Db.Account.FirstOrDefaultAsync(employees => employees.Login== login && employees.Password == password);
                _account = resultEmployees;
                if (_account != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Исключения!", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
        }

        public async void AuthorInApp()
        {
            ButtonDes = "Подождите";

            if (await Authorizations(Login, Password))
            {
                if(_account != null)
                {
                    if (_account.Privilege_account == "admin")
                    {
                        var role = 1;
                        var mainMenu = new MainMenu(_account, role);
                        mainMenu.Show();
                    }
                    if (_account.Privilege_account == "employee")
                    {
                        var role = 2;
                        var mainMenu = new MainMenu(_account, role);
                        mainMenu.Show();
                    }
                }             
                foreach (var item in App.Current.Windows)
                {
                    if (item is Autorization)
                    {
                        (item as Window)?.Hide();
                    }
                }
                ButtonDes = "Подождите";
                return;
            }
            MessageBox.Show("Неверный логин или пароль", "Авторизация!", MessageBoxButton.OK, MessageBoxImage.Error);
            ButtonDes = "Войти";
        }
    }
}

