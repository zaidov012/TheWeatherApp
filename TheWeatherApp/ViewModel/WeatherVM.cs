using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeatherApp.Commands;
using TheWeatherApp.Model;
using TheWeatherApp.ViewModel.Helpers;

namespace TheWeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }
        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
        }

        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions currectConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currectConditions; }
            set 
            { 
                currectConditions = value;
                OnPropertyChanged("CurrentConditions");

            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void makeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }
    }
}
