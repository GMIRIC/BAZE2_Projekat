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
    public class TransportViewModel : BaseViewModel
    {
        private RedVine chosenRedWine;

        public RedVine ChosenRedWine
        {
            get { return chosenRedWine; }
            set
            {
                chosenRedWine = value;
                OnPropertyChanged(nameof(ChosenRedWine));
            }
        }

        private Storehouse chosenStorehouse;

        public Storehouse ChosenStorehouse
        {
            get { return chosenStorehouse; }
            set
            {
                chosenStorehouse = value;
                OnPropertyChanged(nameof(ChosenStorehouse));
            }
        }


        //NEW
        private RedVine newChosenRedWine;

        public RedVine NewChosenRedWine
        {
            get { return newChosenRedWine; }
            set
            {
                newChosenRedWine = value;
                OnPropertyChanged(nameof(NewChosenRedWine));
            }
        }

        private Storehouse newChosenStorehouse;

        public Storehouse NewChosenStorehouse
        {
            get { return newChosenStorehouse; }
            set
            {
                newChosenStorehouse = value;
                OnPropertyChanged(nameof(NewChosenStorehouse));
            }
        }

        private Transport selectedTransport;

        public Transport SelectedTransport
        {
            get { return selectedTransport; }
            set
            {
                selectedTransport = value;
                OnPropertyChanged(nameof(SelectedTransport));
            }
        }


        //KOLEKCIJE
        private ObservableCollection<Transport> observableTransportList;

        public ObservableCollection<Transport> ObservableTransportList
        {
            get { return observableTransportList; }
            set
            {
                observableTransportList = value;
                OnPropertyChanged(nameof(ObservableTransportList));
            }
        }

        private ObservableCollection<Storehouse> observableStorehouseList;

        public ObservableCollection<Storehouse> ObservableStorehouseList
        {
            get { return observableStorehouseList; }
            set
            {
                observableStorehouseList = value;
                OnPropertyChanged(nameof(ObservableStorehouseList));
            }
        }

        private ObservableCollection<RedVine> observableRedWineList;

        public ObservableCollection<RedVine> ObservableRedWineList
        {
            get { return observableRedWineList; }
            set
            {
                observableRedWineList = value;
                OnPropertyChanged(nameof(ObservableRedWineList));
            }
        }



        //KOMANDE
        public MyICommand AddTransportCommand { get; set; }
        public MyICommand RemoveTransportCommand { get; set; }
        public MyICommand EditTransportCommand { get; set; }

        //KONSTRUKTOR
        public TransportViewModel()
        {
            AddTransportCommand = new MyICommand(AddTransport);
            RemoveTransportCommand = new MyICommand(RemoveTransport);
            EditTransportCommand = new MyICommand(EditTransport);
            Refresh();

            ComboBoxStorehouses();
            ComboBoxRedWines();
            Refresh();
        }


        public void AddTransport()
        {
            if (Validate())
            {
                DataAccess.Instance.AddTransport(ChosenStorehouse, ChosenRedWine);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveTransport()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveTransport(SelectedTransport.TransportId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali degustaciju!");
            }
        }
        public void EditTransport()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditTransport(SelectedTransport.TransportId, NewChosenStorehouse, NewChosenRedWine);
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
            ObservableTransportList = new ObservableCollection<Transport>(DataAccess.Instance.GetTransport());
        }
        public void ComboBoxStorehouses()
        {
            ObservableStorehouseList = new ObservableCollection<Storehouse>(DataAccess.Instance.GetStorehouse());
        }
        public void ComboBoxRedWines()
        {
            ObservableRedWineList = new ObservableCollection<RedVine>(DataAccess.Instance.GetRedWine());
        }

        public void Clean()
        {
            ChosenRedWine = null;
            ChosenStorehouse = null;
        }


        public void WriteSelected()
        {
            if (!(SelectedTransport == null))
            {
                NewChosenStorehouse = SelectedTransport.Storehouse;
                NewChosenRedWine = SelectedTransport.RedVine;
            }
        }

        public void ShowRedWine()
        {
            ObservableRedWineList = new ObservableCollection<RedVine>(DataAccess.Instance.GetRedWine());
        }

        public void ShowTransport()
        {
            ObservableTransportList = new ObservableCollection<Transport>(DataAccess.Instance.GetTransport());
        }




        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (ChosenStorehouse.Equals("") || ChosenRedWine.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewChosenRedWine.Equals("") || NewChosenStorehouse.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedTransport == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
