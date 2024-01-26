using CommunicationsShowroom.DbEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommunicationsShowroom.ViewModel
{
    public class InfoClientVM : BaseViewModel
    {
        private ObservableCollection<Client> _clients;

        private Client _client;

        public InfoClientVM()
        {
            Clients = new ObservableCollection<Client>();
            LoadData();
        }
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public Client SelectClient
        {
            get => _client;
            set
            {
                _client = value;
                OnPropertyChanged(nameof(SelectClient));
            }
        }
        public void LoadData()
        {
            if (_clients.Count > 0)
            {
                _clients.Clear();
            }

            var result = DbStorage.Db.Client.ToList();

            result.ForEach(a => Clients?.Add(a));
        }

        public void DeleteData()
        {
            if (!(SelectClient is null))
            {
                using (var db = new CommunicationsShowroomEntities())
                {
                    var client = db.Client.Find(SelectClient.Id);
                    if (client != null)
                    {
                        db.Client.Remove(client);
                        db.SaveChanges();
                        SelectClient = null;
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
