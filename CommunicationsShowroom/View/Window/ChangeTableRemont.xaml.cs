using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.View.Window;
using System;
using System.Data.Entity.Migrations;
using System.Text;
using System.Windows;

namespace AccountingOfResonantComponents.View.Window
{
    /// <summary>
    /// Логика взаимодействия для ChangeTableRemont.xaml
    /// </summary>
    public partial class ChangeTableRemont
    {
        private Remont _remont;
        // private TableInfoViewModel _tableInfoViewModel;
        public ChangeTableRemont(Remont remont)
        {
            InitializeComponent();
            if (remont is null)
            {
                _remont = remont = new Remont();
            }
            else
            {
                _remont = remont;
            }

            this.DataContext = _remont;
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
                    db.Remont.AddOrUpdate(_remont);
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
            if (_remont != null)
            {
                if (string.IsNullOrEmpty(_remont.Name))
                {
                    error.AppendLine("Поле (Имя клиента) некорректное");
                }
                if (_remont.Id_Account_Data < 0 || _remont.Id_Account_Data == null)
                {
                    error.AppendLine("Поле (Id Сотрудника) некорректное");
                }
                if (_remont.Id_Detail < 0 || _remont.Id_Detail == null)
                {
                    error.AppendLine("Поле (Id Детали на складе) некорректное");
                }
                if (string.IsNullOrEmpty(_remont.Type_neispravnosti))
                {
                    error.AppendLine("Поле (Тип неисправности) некорректное");
                }
                if (string.IsNullOrEmpty(_remont.Device_names))
                {
                    error.AppendLine("Поле (Устройство) некорректное");
                }
                if (_remont.Price < 0 || _remont.Price == null)
                {
                    error.AppendLine("Поле (Стоимость ремонта) некорректное");
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

