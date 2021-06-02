using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterface.ViewModels
{
    public class CityViewModel : BaseViewModel
    {
        private String cityName;

        public String CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                OnPropertyChanged(nameof(CityName));
            }
        }

        private string cityRegion;

        public string CityRegion
        {
            get { return cityRegion; }
            set
            {
                cityRegion = value;
                OnPropertyChanged(nameof(CityRegion));
            }
        }

        private string cityZipcode;

        public string CityZipcode
        {
            get { return cityZipcode; }
            set
            {
                cityZipcode = value;
                OnPropertyChanged(nameof(CityZipcode));
            }
        }

        //NEW
        private String newCityName;

        public String NewCityName
        {
            get { return newCityName; }
            set
            {
                newCityName = value;
                OnPropertyChanged(nameof(NewCityName));
            }
        }

        private string newCityRegion;

        public string NewCityRegion
        {
            get { return newCityRegion; }
            set
            {
                newCityRegion = value;
                OnPropertyChanged(nameof(NewCityRegion));
            }
        }

        private string newCityZipcode;

        public string NewCityZipcode
        {
            get { return newCityZipcode; }
            set
            {
                newCityZipcode = value;
                OnPropertyChanged(nameof(NewCityZipcode));
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

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedCity));
            }
        }



        public MyICommand AddCityCommand { get; set; }
        public MyICommand RemoveCityCommand { get; set; }
        public MyICommand EditCityCommand { get; set; }

        public CityViewModel()
        {
            AddCityCommand = new MyICommand(AddCity);
            RemoveCityCommand = new MyICommand(RemoveCity);
            EditCityCommand = new MyICommand(EditCity);
            Refresh();
        }


        public void AddCity()
        {
            if (Validate())
            {
                DataAccess.Instance.AddCity(new City { Name = CityName, Region = CityRegion, Zipcode = CityZipcode });
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveCity()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveCity(SelectedCity.CityId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali grad!");
            }
        }
        public void EditCity()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditCity(SelectedCity.CityId, new City { Name = NewCityName, Region = NewCityRegion, Zipcode = NewCityZipcode });
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
                MessageBox.Show("Niste selektovali grad!");
            }
            
           
        }


        public void Refresh()
        {
            ObservableCityList = new ObservableCollection<City>(DataAccess.Instance.GetCities());
        }

        public void Clean()
        {
            CityName = "";
            CityRegion = "";
            CityZipcode = "";
        }
       

        public void WriteSelected()
        {
            if(!(SelectedCity == null))
            {
                NewCityName = SelectedCity.Name;
                NewCityRegion = SelectedCity.Region;
                NewCityZipcode = SelectedCity.Zipcode;
            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (CityName.Equals("") || CityRegion.Equals("") || CityZipcode.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewCityName.Equals("") || NewCityRegion.Equals("") || NewCityZipcode.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if(SelectedCity == null)
            {
                selected = false;
            }
            return selected;
        }

    }
}
