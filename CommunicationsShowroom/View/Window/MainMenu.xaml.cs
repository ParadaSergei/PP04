using AccountingOfResonantComponent.ViewModel;
using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponents.View.Page;
using AccountingOfResonantComponents.View.Window;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AccountingOfResonantComponent.View.Window
{
    public partial class MainMenu
    {
        public int role = 1;
        private Account_Data _accountEmployees;
        public static MainMenu mainMenu;
        private readonly ScladMV _scladPageVM;
        private readonly RemontMV _remontMV;
        private readonly AccountEmployeesMV _accountEmployeesVM;
        private readonly AccountDataMV _accountDataMV;
        public Account_Data AccountEmployees
        {
            get => _accountEmployees;
            set
            {
                _accountEmployees = value;
            }
        }
        public MainMenu(Account accountEmployees, int role)
        {
            _scladPageVM = new ScladMV();
            _remontMV = new RemontMV();
            _accountEmployeesVM = new AccountEmployeesMV();
            _accountDataMV = new AccountDataMV();

            InitializeComponent();
            FramePageAdmin.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainMenu = this;
            TableComboAdmin.SelectedIndex = 0;
            if (role == 1)
            {
                TableComboAdmin.ItemsSource = new Table[]
             {
                new Table { Name = "Склад"},
                new Table { Name = "Ремонт"},
                new Table { Name = "Инф. аккаунта"},
                new Table { Name = "Аккаунты"},
             };
                DeleteButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                InsertButton.Visibility = Visibility.Visible;
                Position.Content = "Администратор";
            }
            if (role == 2)
            {
                TableComboAdmin.ItemsSource = new Table[]
              {
                new Table { Name = "Склад"},
                new Table { Name = "Ремонт"},
              };

                InsertButton.Visibility = Visibility.Visible;
                Position.Content = "Сотрудник";
            }
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainMenu.mainMenu.DragMove();
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
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }
        private void adminComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TableComboAdmin.SelectedIndex)
            {
                case 0:
                    { 
                    FramePageAdmin.Navigate(new ScladPage { DataContext = _scladPageVM });
                        _scladPageVM.LoadData();
                    }
                    break;
                case 1:
                    { 
                    FramePageAdmin.Navigate(new RemontPage { DataContext = _remontMV });
                        _remontMV.LoadData();
                    }
                    break;
                case 2:
                    { 
                    FramePageAdmin.Navigate(new AccountDataPage { DataContext = _accountDataMV });
                        _accountDataMV.LoadData();
                    }
                    break;
                case 3:
                    { 
                    FramePageAdmin.Navigate(new AccountEmployeesPage { DataContext = _accountEmployeesVM });
                        _accountEmployeesVM.LoadData();
                    }
                    break;
                default:
                    break;
            }
        }
        public void RefrashDataTable()
        {
            (DataContext as ScladMV).LoadData();
        }
        public class Table
        {
            public string Name { get; set; } = "";
            public override string ToString() => $"{Name}";
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (TableComboAdmin.SelectedIndex)
            {
                case 0:
                    _scladPageVM.DeleteData();
                    break;
                case 1:
                    _remontMV.DeleteData();
                    break;
                case 2:
                    _accountDataMV.DeleteData();
                    break;
                case 3:
                    _accountEmployeesVM.DeleteData();
                    break;
                default:
                    break;
            }
        }
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            switch (TableComboAdmin.SelectedIndex)
            {
                case 0:
                    {
                        var changeTableSclad = new ChangeTableSclad(null);
                        changeTableSclad.Show();
                    }
                    break;
                case 1:
                    {
                        var changeTableRemont = new ChangeTableRemont(null);
                        changeTableRemont.Show();
                    }
                    break;
                case 2:
                    {
                        var changeInfoEmployees = new ChangeAccountData(null);
                        changeInfoEmployees.Show();
                    }
                    break;
                case 3:
                    {
                        var changeAccount = new ChangeAccount(null);
                        changeAccount.Show();
                    }
                    break;
                default:
                    break;
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            switch (TableComboAdmin.SelectedIndex)
            {
                case 0:
                    {
                        var changeTableSclad = new ChangeTableSclad(_scladPageVM.SelectSclad);
                        changeTableSclad.Show();
                    }
                    break;
                case 1:
                    {
                        var changeTableRemont = new ChangeTableRemont(_remontMV.SelectRemont);
                        changeTableRemont.Show();
                    }
                    break;
                case 2:
                    {
                        var changeInfoEmployees = new ChangeAccountData(_accountDataMV.SelectAccountData);
                        changeInfoEmployees.Show();
                    }
                    break;
                case 3:
                    {
                        var changeAccount = new ChangeAccount(_accountEmployeesVM.SelectAccountEmployees);
                        changeAccount.Show();
                    }
                    break;
                default:
                    break;

            }
        }
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            switch (TableComboAdmin.SelectedIndex)
            {
                case 0:
                    _scladPageVM.LoadData();
                    break;
                case 1:
                    _remontMV.LoadData();
                    break;
                case 2:
                    _accountDataMV.LoadData();
                    break;
                case 3:
                    _accountEmployeesVM.LoadData();
                    break;
                default:
                    break;

            }
        }
    }
}
