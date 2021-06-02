using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Repository;

namespace UserInterface.ViewModels
{
    public class WinnaryViewModel : BaseViewModel
    {
        private String winnaryName;

        public String WinnaryName
        {
            get { return winnaryName; }
            set
            {
                winnaryName = value;
                OnPropertyChanged(nameof(WinnaryName));
            }
        }

        private string winnaryAddress;

        public string WinnaryAddress
        {
            get { return winnaryAddress; }
            set
            {
                winnaryAddress = value;
                OnPropertyChanged(nameof(WinnaryAddress));
            }
        }

        

        //NEW
        private String newWinnaryName;

        public String NewWinnaryName
        {
            get { return newWinnaryName; }
            set
            {
                newWinnaryName = value;
                OnPropertyChanged(nameof(NewWinnaryName));
            }
        }

        private string newWinnaryAddress;

        public string NewWinnaryAddress
        {
            get { return newWinnaryAddress; }
            set
            {
                newWinnaryAddress = value;
                OnPropertyChanged(nameof(NewWinnaryAddress));
            }
        }

       

        private ObservableCollection<Winnary> observableWinnaryList;

        public ObservableCollection<Winnary> ObservableWinnaryList
        {
            get { return observableWinnaryList; }
            set
            {
                observableWinnaryList = value;
                OnPropertyChanged(nameof(ObservableWinnaryList));
            }
        }
        private ObservableCollection<City> observableCityList;

        public ObservableCollection<City> ObservableCityList
        {
            get { return observableCityList; }
            set
            {
                observableCityList = value;
                OnPropertyChanged(nameof(ObservableCityList));
            }
        }

        private Winnary selectedWinnary;

        public Winnary SelectedWinnary
        {
            get { return selectedWinnary; }
            set
            {
                selectedWinnary = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedWinnary));
            }
        }

        private City chosenCity;

        public City ChosenCity
        {
            get { return chosenCity; }
            set
            {
                chosenCity = value;
                OnPropertyChanged(nameof(ChosenCity));
            }
        }

        private City newChosenCity;

        public City NewChosenCity
        {
            get { return newChosenCity; }
            set
            {
                newChosenCity = value;
                OnPropertyChanged(nameof(NewChosenCity));
            }
        }




        public MyICommand AddWinnaryCommand { get; set; }
        public MyICommand RemoveWinnaryCommand { get; set; }
        public MyICommand EditWinnaryCommand { get; set; }

        public WinnaryViewModel()
        {
            AddWinnaryCommand = new MyICommand(AddWinnary);
            RemoveWinnaryCommand = new MyICommand(RemoveWinnary);
            EditWinnaryCommand = new MyICommand(EditWinnary);
            Refresh();
            ComboBoxCities();
        }


        public void AddWinnary()
        {
            if (Validate())
            {
                DataAccess.Instance.AddWinnary(new Winnary { Name = WinnaryName, Address = WinnaryAddress }, ChosenCity);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveWinnary()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveWinnary(SelectedWinnary.Id);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali vinariju!");
            }
        }
        public void EditWinnary()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditWinnary(SelectedWinnary.Id, new Winnary { Name = NewWinnaryName, Address = NewWinnaryAddress }, NewChosenCity);
                    Refresh();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Nisu uneta sva polja!");
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali vinariju!");
            }


        }


        public void Refresh()
        {
            ObservableWinnaryList = new ObservableCollection<Winnary>(DataAccess.Instance.GetWinnaries());
        }
        public void ComboBoxCities()
        {
            ObservableCityList = new ObservableCollection<City>(DataAccess.Instance.GetCities());
        }

        public void Clean()
        {
            WinnaryName = "";
            WinnaryAddress = "";
        }


        public void WriteSelected()
        {
            if (!(SelectedWinnary == null))
            {
                NewWinnaryName = SelectedWinnary.Name;
                NewWinnaryAddress = SelectedWinnary.Address;
                NewChosenCity = SelectedWinnary.City;
            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (WinnaryName.Equals("") || WinnaryAddress.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewWinnaryName.Equals("") || NewWinnaryAddress.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedWinnary == null)
            {
                selected = false;
            }
            return selected;
        }




    }
}
