using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using AccountingOfResonantComponent.View.Window;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace AccountingOfResonantComponents.View.Window
{
    /// <summary>
    /// Логика взаимодействия для ChangeAccount.xaml
    /// </summary>
    public partial class ChangeAccount
    {
        private Account _accountClient;
        // private TableInfoViewModel _tableInfoViewModel;
        public ChangeAccount(Account accountClient)
        {
            InitializeComponent();
            if (accountClient is null)
            {
                _accountClient = accountClient = new Account();
            }
            else
            {
                _accountClient = accountClient;
            }

            this.DataContext = _accountClient;
        }
        public void btnSaveAccount_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new YchotRemontnihKomplektuishuhEntities())
            {
                try
                {
                    var validateEntity = ValidateEntity();
                    if (validateEntity.Length > 0)
                    {
                        MessageBox.Show(validateEntity.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    db.Account.AddOrUpdate(_accountClient);
                    db.SaveChanges();

                    MessageBox.Show("Данные успешно внесены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    (Owner as MainMenu)?.RefrashDataTable();
                    Owner?.Focus();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        private StringBuilder ValidateEntity()
        {
            var error = new StringBuilder();
            if (_accountClient != null)
            {
                if (_accountClient != null)
                {
                    if (string.IsNullOrEmpty(_accountClient.Login))
                    {
                        error.AppendLine("Поле (Имя) пустое , или некорректное");
                    }
                    if (string.IsNullOrEmpty(_accountClient.Password))
                    {
                        error.AppendLine("Поле (Фамилия) пустое, или некорректное");
                    }
                    if (string.IsNullOrEmpty(_accountClient.Id_Account_data.ToString()))
                    {
                        error.AppendLine("Поле (Id Данных сотрудника) пустое, или некорректное");
                    }
                    if (string.IsNullOrEmpty(_accountClient.Privilege_account.ToString()))
                    {
                        error.AppendLine("Поле (Должность) пустое, или некорректное");
                    }
                    if (string.IsNullOrEmpty(_accountClient.Date_Created.ToString()))
                    {
                        error.AppendLine("Поле (Дата создания) пустое, или некорректное");
                    }
                }
            }
            return error;
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}

