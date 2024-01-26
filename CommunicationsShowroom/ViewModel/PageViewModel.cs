using AccountingOfResonantComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfResonantComponent.ViewModel
{
    public class PageViewModel : BaseViewModel
    {
        private readonly FileWorker _fileWorker;
        private string _category;
        private Date _selectedDate;
        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public Date SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));

                LoadInfo();
            }
        }

        public PageViewModel(string name)
        {
            _category = name;

            _fileWorker = new FileWorker();
        }

        private async void LoadInfo()
        {
            Text = await _fileWorker.ReadFile(_category, SelectedDate.Name);
        }
    }
}
