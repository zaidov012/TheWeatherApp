using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheWeatherApp.ViewModel;

namespace TheWeatherApp.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.makeQuery();
        }
    }
}
