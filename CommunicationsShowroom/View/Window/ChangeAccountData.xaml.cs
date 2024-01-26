using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using AccountingOfResonantComponent.View;
using AccountingOfResonantComponent.View.Window;
using AccountingOfResonantComponent.ViewModel;
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
namespace AccountingOfResonantComponents.View.Window
{
    /// <summary>
    /// Логика взаимодействия для ChangeAccountData.xaml
    /// </summary>
    public partial class ChangeAccountData
    {
        private Account_Data _infoEmployees;
        public ChangeAccountData(Account_Data infoEmployees)
        {
            InitializeComponent();
            if (infoEmployees is null)
            {
                _infoEmployees = infoEmployees = new Account_Data();
            }
            else
            {
                _infoEmployees = infoEmployees;
            }

            this.DataContext = _infoEmployees;
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
                    db.Account_Data.AddOrUpdate(_infoEmployees);
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
            if (_infoEmployees != null)
            {
                if (string.IsNullOrEmpty(_infoEmployees.Name))
                {
                    error.AppendLine("Поле (Имя) пустое , или некорректное");
                }
                if (string.IsNullOrEmpty(_infoEmployees.Familia))
                {
                    error.AppendLine("Поле (Фамилия) пустое, или некорректное");
                }
                if (string.IsNullOrEmpty(_infoEmployees.Device_Remont_type))
                {
                    error.AppendLine("Поле (Тип устройста на ремонт) пустое, или некорректное");
                }
                if (string.IsNullOrEmpty(_infoEmployees.Raspisanie_work))
                {
                    error.AppendLine("Поле (Рассписание) пустое, или некорректное");
                }
                if (_infoEmployees.Zarplata == null || _infoEmployees.Zarplata < 0)
                {
                    error.AppendLine("Поле (Зарплата) пустое, или некорректное");
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
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

    }
}

