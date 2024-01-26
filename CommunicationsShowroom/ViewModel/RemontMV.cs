using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AccountingOfResonantComponent.ViewModel
{
    public class RemontMV : BaseViewModel
    {
        private ObservableCollection<Remont> _remontOC;

        private Remont _remont;

        public RemontMV()
        {
            Remont = new ObservableCollection<Remont>();
            LoadData();
        }
        public ObservableCollection<Remont> Remont
        {
            get => _remontOC;
            set
            {
                _remontOC = value;
                OnPropertyChanged(nameof(Remont));
            }
        }

        public Remont SelectRemont
        {
            get => _remont;
            set
            {
                _remont = value;
                OnPropertyChanged(nameof(SelectRemont));
            }
        }


        public void LoadData()
        {
            if (_remontOC.Count > 0)
            {
                _remontOC.Clear();
            }

            var result = DbStorage.Db.Remont.ToList();
            result.ForEach(a => Remont.Add(a));
        }

        public void DeleteData()
        {
            if (SelectRemont != null)
            {
                using (var db = new YchotRemontnihKomplektuishuhEntities())
                {
                    var repairOrders = db.Remont.Find(SelectRemont.id);
                    if (repairOrders != null)
                    {
                        db.Remont.Remove(repairOrders);
                        db.SaveChanges();
                        SelectRemont = null;
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
