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
    public class StorehouseViewModel : BaseViewModel
    {
        private String storehouseCapacity;

        public String StorehouseCapacity
        {
            get { return storehouseCapacity; }
            set
            {
                storehouseCapacity = value;
                OnPropertyChanged(nameof(StorehouseCapacity));
            }
        }

       

        //NEW
        private String newStorehouseCapacity;

        public String NewStorehouseCapacity
        {
            get { return newStorehouseCapacity; }
            set
            {
                newStorehouseCapacity = value;
                OnPropertyChanged(nameof(NewStorehouseCapacity));
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

        private Storehouse selectedStorehouse;

        public Storehouse SelectedStorehouse
        {
            get { return selectedStorehouse; }
            set
            {
                selectedStorehouse = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedStorehouse));
            }
        }



        public MyICommand AddStorehouseCommand { get; set; }
        public MyICommand RemoveStorehouseCommand { get; set; }
        public MyICommand EditStorehouseCommand { get; set; }

        public StorehouseViewModel()
        {
            AddStorehouseCommand = new MyICommand(AddStorehouse);
            RemoveStorehouseCommand = new MyICommand(RemoveStorehouse);
            EditStorehouseCommand = new MyICommand(EditStorehouse);
            Refresh();
        }


        public void AddStorehouse()
        {
            if (Validate())
            {
                DataAccess.Instance.AddStorehouse(new Storehouse { Capacity = StorehouseCapacity});
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveStorehouse()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveStorehouse(SelectedStorehouse.StorehouseId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali Skladiste!");
            }
        }
        public void EditStorehouse()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditStorehouse(SelectedStorehouse.StorehouseId, new Storehouse { Capacity = StorehouseCapacity });
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
                MessageBox.Show("Niste selektovali Skladiste!");
            }


        }


        public void Refresh()
        {
            ObservableStorehouseList = new ObservableCollection<Storehouse>(DataAccess.Instance.GetStorehouse());
        }

        public void Clean()
        {
           StorehouseCapacity  = "";
            
        }


        public void WriteSelected()
        {
            if (!(SelectedStorehouse == null))
            {
                NewStorehouseCapacity = SelectedStorehouse.Capacity;
            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (StorehouseCapacity.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewStorehouseCapacity.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedStorehouse == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
