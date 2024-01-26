using AccountingOfResonantComponent.View;
using System.Windows;
using System.Windows.Input;

namespace AccountingOfResonantComponents.View.Window
{
    /// <summary>
    /// Логика взаимодействия для Handbook.xaml
    /// </summary>
    public partial class Handbook
    {
        public Handbook()
        {
            InitializeComponent();
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
            var autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
