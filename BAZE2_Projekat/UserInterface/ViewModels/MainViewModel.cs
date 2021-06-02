using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Commands;

namespace UserInterface.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel currentViewModel;

        public MainViewModel()
        {
            ViewUpdateCommand = new ViewUpdateCommand(this);

            
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }


        public ICommand ViewUpdateCommand { get; set; }
    }
}
