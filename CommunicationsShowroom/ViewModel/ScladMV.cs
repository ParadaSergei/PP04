using AccountingOfResonantComponents.DbEntity;
using AccountingOfResonantComponent.DbEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOfResonantComponent.ViewModel
{
    public class ScladMV : BaseViewModel
    {
        private ObservableCollection<Sclad> _devices;

        private Sclad _SelectDevice;

        public ScladMV()
        {
            Detali = new ObservableCollection<Sclad>();
            LoadData();
        }
        public ObservableCollection<Sclad> Detali
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged(nameof(Detali));
            }
        }

        public Sclad SelectSclad
        {
            get => _SelectDevice;
            set
            {
                _SelectDevice = value;
                OnPropertyChanged(nameof(SelectSclad));
            }
        }


        public void LoadData()
        {
            if (_devices.Count > 0)
            {
                _devices.Clear();
            }
            var result = DbStorage.Db.Sclad.ToList();

            result.ForEach(a => Detali.Add(a));
        }

        public void DeleteData()
        {
            if (SelectSclad != null)
            {
                using (var db = new YchotRemontnihKomplektuishuhEntities())
                {
                    var device = db.Sclad.Find(SelectSclad.id);
                    if (device != null)
                    {
                        db.Sclad.Remove(device);
                        db.SaveChanges();
                        SelectSclad = null;
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
