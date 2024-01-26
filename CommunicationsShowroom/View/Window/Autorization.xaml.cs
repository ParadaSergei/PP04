using AccountingOfResonantComponents.View.Window;
using AccountingOfResonantComponent.DbEntity;
using AccountingOfResonantComponent.ViewModel;
using System;
using System.Collections.Generic;
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

namespace AccountingOfResonantComponent.View
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization
    {
        public static Autorization autorizationWindow;
        public Autorization()
        {
            InitializeComponent();
            this.DataContext = new AutorizMV();
            autorizationWindow = this;
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Autorization.autorizationWindow.DragMove();
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AutorizMV).Password = pswBox.Password.ToString();
            (DataContext as AutorizMV).AuthorInApp();
        }

        private void ButtonHandbook_Click(object sender, RoutedEventArgs e)
        {
            var handbook = new Handbook();
            handbook.Show();
            this.Close();
        }
    }
}
