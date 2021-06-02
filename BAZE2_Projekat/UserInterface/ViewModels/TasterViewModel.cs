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
    public class TasterViewModel :BaseViewModel
    {
        private String tasterFirstName;

        public String TasterFirstName
        {
            get { return tasterFirstName; }
            set
            {
                tasterFirstName = value;
                OnPropertyChanged(nameof(TasterFirstName));
            }
        }

        private String tasterLastName;

        public String TasterLastName
        {
            get { return tasterLastName; }
            set
            {
                tasterLastName = value;
                OnPropertyChanged(nameof(TasterLastName));
            }
        }




        //NEW
        private String newTasterFirstName;

        public String NewTasterFirstName
        {
            get { return newTasterFirstName; }
            set
            {
                newTasterFirstName = value;
                OnPropertyChanged(nameof(NewTasterFirstName));
            }
        }

        private String newTasterLastName;

        public String NewTasterLastName
        {
            get { return newTasterLastName; }
            set
            {
                newTasterLastName = value;
                OnPropertyChanged(nameof(NewTasterLastName));
            }
        }



        private ObservableCollection<Taster> observableTasterList;

        public ObservableCollection<Taster> ObservableTasterList
        {
            get { return observableTasterList; }
            set
            {
                observableTasterList = value;
                OnPropertyChanged(nameof(ObservableTasterList));
            }
        }

        private Taster selectedTaster;

        public Taster SelectedTaster
        {
            get { return selectedTaster; }
            set
            {
                selectedTaster = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedTaster));
            }
        }



        public MyICommand AddTasterCommand { get; set; }
        public MyICommand RemoveTasterCommand { get; set; }
        public MyICommand EditTasterCommand { get; set; }

        public TasterViewModel()
        {
            AddTasterCommand = new MyICommand(AddTaster);
            RemoveTasterCommand = new MyICommand(RemoveTaster);
            EditTasterCommand = new MyICommand(EditTaster);
            Refresh();
        }


        public void AddTaster()
        {
            if (Validate())
            {
                DataAccess.Instance.AddTaster(new Taster { FirstName = TasterFirstName, LastName = TasterLastName });
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveTaster()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveTaster(SelectedTaster.TasterId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali degustatora!");
            }
        }
        public void EditTaster()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditTaster(SelectedTaster.TasterId, new Taster { FirstName = NewTasterFirstName, LastName = NewTasterLastName });
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
                MessageBox.Show("Niste selektovali degustatora!");
            }


        }


        public void Refresh()
        {
            ObservableTasterList = new ObservableCollection<Taster>(DataAccess.Instance.GetTaster());
        }

        public void Clean()
        {
            TasterFirstName = "";
            TasterLastName = "";

        }


        public void WriteSelected()
        {
            if (!(SelectedTaster == null))
            {
                NewTasterFirstName = SelectedTaster.FirstName;
                NewTasterLastName = SelectedTaster.LastName;
            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (TasterFirstName.Equals("") || TasterLastName.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewTasterFirstName.Equals("") || NewTasterLastName.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedTaster == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
