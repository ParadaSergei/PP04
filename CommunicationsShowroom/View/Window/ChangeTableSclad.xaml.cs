using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
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
    /// Логика взаимодействия для ChangeTableSclad.xaml
    /// </summary>
    public partial class ChangeTableSclad
    {
        private Sclad _sclad;
        // private TableInfoViewModel _tableInfoViewModel;
        public ChangeTableSclad(Sclad sclad )
        {
            InitializeComponent();
            if (sclad  is null)
            {
                _sclad = sclad  = new Sclad();
            }
            else
            {
                _sclad = sclad ;
            }

            this.DataContext = _sclad;
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
                    db.Sclad.AddOrUpdate(_sclad);
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
            if (_sclad != null)
            {
                if (string.IsNullOrEmpty(_sclad.Detali))
                {
                    error.AppendLine("Поле (Деталь) пустое , или некорректное");
                }
                if (string.IsNullOrEmpty(_sclad.Device_type))
                {
                    error.AppendLine("Поле (Тип устройства) пустое, или некорректное");
                }
                if (_sclad.Kolichestvo < 0)
                {
                    error.AppendLine("Поле (Количество) некорректное");
                }
                if (_sclad.Pribitie_time == null)
                {
                    error.AppendLine("Поле (Время прибытия) некорректное");
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

