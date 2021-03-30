using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Table;
using UITable.ViewModel.Commands;

namespace UITable.ViewModel
{
    class MainWindowViewModel : BaseModel
    {
        private CreateTable<City> createTable;
        public IEnumerable<City> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }
        private IEnumerable<City> cities;

        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;

                OnPropertyChanged(nameof(CityName));

                Cities = createTable.GetCitiesByName(value);
            }
        }
        private string cityName;

        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));

                if (value)
                {
                    MessageBox.Show("Таблица создана. Данные загружены.");
                }
            }
        }
        private bool status;

        public ICommand CreateTableCommand { get; set; }

        public MainWindowViewModel()
        {
            createTable = new CreateTable<City>();

            CreateTableCommand = new CreateTableCommand(this);

            createTable.AddCity("Москва");

            createTable.AddCity("Санкт-Петербург");

            createTable.AddCity("Самара");

            createTable.AddCity("Рязань");

            createTable.AddCity("Владивосток");

            Cities = createTable.GetCities();
        }
    }
}
