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
    public class TastingViewModel : BaseViewModel
    {
      
        private WhiteVine chosenWhiteWine;

        public WhiteVine ChosenWhiteWine
        {
            get { return chosenWhiteWine; }
            set
            {
                chosenWhiteWine = value;
                OnPropertyChanged(nameof(ChosenWhiteWine));
            }
        }

        private Taster chosenTaster;

        public Taster ChosenTaster
        {
            get { return chosenTaster; }
            set
            {
                chosenTaster = value;
                OnPropertyChanged(nameof(ChosenTaster));
            }
        }


        //NEW
        private WhiteVine newChosenWhiteWine;

        public WhiteVine NewChosenWhiteWine
        {
            get { return newChosenWhiteWine; }
            set
            {
                newChosenWhiteWine = value;
                OnPropertyChanged(nameof(NewChosenWhiteWine));
            }
        }

        private Taster newChosenTaster;

        public Taster NewChosenTaster
        {
            get { return newChosenTaster; }
            set
            {
                newChosenTaster = value;
                OnPropertyChanged(nameof(NewChosenTaster));
            }
        }

        private Tasting selectedTasting;

        public Tasting SelectedTasting
        {
            get { return selectedTasting; }
            set
            {
                selectedTasting = value;
                OnPropertyChanged(nameof(SelectedTasting));
            }
        }


        //KOLEKCIJE
        private ObservableCollection<Tasting> observableTastingList;

        public ObservableCollection<Tasting> ObservableTastingList
        {
            get { return observableTastingList; }
            set
            {
                observableTastingList = value;
                OnPropertyChanged(nameof(ObservableTastingList));
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

        private ObservableCollection<WhiteVine> observableWhiteWineList;

        public ObservableCollection<WhiteVine> ObservableWhiteWineList
        {
            get { return observableWhiteWineList; }
            set
            {
                observableWhiteWineList = value;
                OnPropertyChanged(nameof(ObservableWhiteWineList));
            }
        }



        //KOMANDE
        public MyICommand AddTastingCommand { get; set; }
        public MyICommand RemoveTastingCommand { get; set; }
        public MyICommand EditTastingCommand { get; set; }

        //KONSTRUKTOR
        public TastingViewModel()
        {
            AddTastingCommand = new MyICommand(AddTasting);
            RemoveTastingCommand = new MyICommand(RemoveTasting);
            EditTastingCommand = new MyICommand(EditTasting);
            Refresh();

            ComboBoxTasters();
            ComboBoxWhiteWines();
            Refresh();
        }


        public void AddTasting()
        {
            if (Validate())
            {
                DataAccess.Instance.AddTasting(chosenTaster, ChosenWhiteWine);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveTasting()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveTasting(SelectedTasting.TastingId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali degustaciju!");
            }
        }
        public void EditTasting()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditTasting(SelectedTasting.TastingId, NewChosenTaster, NewChosenWhiteWine);
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
            ObservableTastingList = new ObservableCollection<Tasting>(DataAccess.Instance.GetTasting());
        }
        public void ComboBoxTasters()
        {
            ObservableTasterList = new ObservableCollection<Taster>(DataAccess.Instance.GetTaster());
        }
        public void ComboBoxWhiteWines()
        {
            ObservableWhiteWineList = new ObservableCollection<WhiteVine>(DataAccess.Instance.GetWhiteWine());
        }

        public void Clean()
        {

        }


        public void WriteSelected()
        {
            if (!(SelectedTasting == null))
            {
                NewChosenTaster = SelectedTasting.Taster;
                NewChosenWhiteWine = SelectedTasting.WhiteVine;
            }
        }

        public void ShowWhiteWine()
        {
            ObservableWhiteWineList = new ObservableCollection<WhiteVine>(DataAccess.Instance.GetWhiteWine());
        }

        public void ShowTasting()
        {
            ObservableTastingList = new ObservableCollection<Tasting>(DataAccess.Instance.GetTasting());
        }




        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (ChosenTaster.Equals("") || ChosenWhiteWine.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewChosenWhiteWine.Equals("") || NewChosenTaster.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedTasting == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
