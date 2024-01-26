using AccountingOfResonantComponent.ViewModel;

namespace AccountingOfResonantComponents.View.Page
{
    /// <summary>
    /// Логика взаимодействия для ScladPage.xaml
    /// </summary>
    public partial class ScladPage
    {
        public ScladPage()
        {
            InitializeComponent();
            this.DataContext = new ScladMV();
        }
    }
}
