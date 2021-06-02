 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.ViewModels;

namespace UserInterface.Commands
{
    public class ViewUpdateCommand : ICommand
    {
        private MainViewModel mainViewModel;

        public ViewUpdateCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "vinarije")
            {
                mainViewModel.CurrentViewModel = new WinnaryViewModel();
            }
            else if (parameter.ToString() == "grad")
            {
                mainViewModel.CurrentViewModel = new CityViewModel();
            }
            else if (parameter.ToString() == "vina")
            {
                mainViewModel.CurrentViewModel = new WineViewModel();
            }
            else if (parameter.ToString() == "zaposleni")
            {
                mainViewModel.CurrentViewModel = new EmployeesViewModel();
            }
            else if (parameter.ToString() == "kupci")
            {
                mainViewModel.CurrentViewModel = new CustomerViewModel();
            }
            else if (parameter.ToString() == "skladista")
            {
                mainViewModel.CurrentViewModel = new StorehouseViewModel();
            }
            else if (parameter.ToString() == "degustatori")
            {
                mainViewModel.CurrentViewModel = new TasterViewModel();
            }
            else if (parameter.ToString() == "sampanjci")
            {
                mainViewModel.CurrentViewModel = new ChampagneViewModel();
            }
            else if (parameter.ToString() == "degustacije")
            {
                mainViewModel.CurrentViewModel = new TastingViewModel();
            }
            else if (parameter.ToString() == "pravljenje")
            {
                mainViewModel.CurrentViewModel = new TastingChampagneViewModel();
            }
            else if (parameter.ToString() == "transport")
            {
                mainViewModel.CurrentViewModel = new TransportViewModel();
            }
            else if (parameter.ToString() == "paketi")
            {
                mainViewModel.CurrentViewModel = new PackageViewModel();
            }



        }
    }
}
