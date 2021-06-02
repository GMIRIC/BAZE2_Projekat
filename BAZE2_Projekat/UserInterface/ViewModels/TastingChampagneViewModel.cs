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
    public class TastingChampagneViewModel : BaseViewModel
    {
        private Champagne chosenChampagne;

        public Champagne ChosenChampagne
        {
            get { return chosenChampagne; }
            set
            {
                chosenChampagne = value;
                OnPropertyChanged(nameof(ChosenChampagne));
            }
        }

        private Tasting chosenTasting;

        public Tasting ChosenTasting
        {
            get { return chosenTasting; }
            set
            {
                chosenTasting = value;
                OnPropertyChanged(nameof(ChosenTasting));
            }
        }


        //NEW
        private Champagne newChosenChampagne;

        public Champagne NewChosenChampagne
        {
            get { return newChosenChampagne; }
            set
            {
                newChosenChampagne = value;
                OnPropertyChanged(nameof(NewChosenChampagne));
            }
        }

        private Tasting newChosenTasting;

        public Tasting NewChosenTasting
        {
            get { return newChosenTasting; }
            set
            {
                newChosenTasting = value;
                OnPropertyChanged(nameof(NewChosenTasting));
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

        private ObservableCollection<Champagne> observableChampagneList;

        public ObservableCollection<Champagne> ObservableChampagneList
        {
            get { return observableChampagneList; }
            set
            {
                observableChampagneList = value;
                OnPropertyChanged(nameof(ObservableChampagneList));
            }
        }

        private ObservableCollection<TastingChampagne> observableTastingChampagneList;

        public ObservableCollection<TastingChampagne> ObservableTastingChampagneList
        {
            get { return observableTastingChampagneList; }
            set
            {
                observableTastingChampagneList = value;
                OnPropertyChanged(nameof(ObservableTastingChampagneList));
            }
        }


        private TastingChampagne selectedTastingChampagne;

        public TastingChampagne SelectedTastingChampagne
        {
            get { return selectedTastingChampagne; }
            set
            {
                selectedTastingChampagne = value;
                OnPropertyChanged(nameof(SelectedTastingChampagne));
            }
        }



        //KOMANDE
        public MyICommand AddTastingChampagneCommand { get; set; }
        public MyICommand RemoveTastingChampagneCommand { get; set; }
        public MyICommand EditTastingChampagneCommand { get; set; }

        //KONSTRUKTOR
        public TastingChampagneViewModel()
        {
            AddTastingChampagneCommand = new MyICommand(AddTastingChampagne);
            RemoveTastingChampagneCommand = new MyICommand(RemoveTastingChampagne);
            EditTastingChampagneCommand = new MyICommand(EditTastingChampagne);
            Refresh();

            ComboBoxChampagnes();
            ComboBoxTastings();
            Refresh();
        }


        public void AddTastingChampagne()
        {
            if (Validate())
            {
                DataAccess.Instance.AddTastingChampagne(chosenChampagne, ChosenTasting);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveTastingChampagne()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveTastingChampagne(SelectedTastingChampagne.TastingChampagneId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali pravljenje!");
            }
        }
        public void EditTastingChampagne()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditTastingChampagne(SelectedTastingChampagne.TastingChampagneId, NewChosenChampagne, NewChosenTasting);
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
                MessageBox.Show("Niste selektovali pravljenje!");
            }
        }


        public void Refresh()
        {
            ObservableTastingChampagneList = new ObservableCollection<TastingChampagne>(DataAccess.Instance.GetTastingChampagne());
        }
        public void ComboBoxChampagnes()
        {
            ObservableChampagneList = new ObservableCollection<Champagne>(DataAccess.Instance.GetChampagne());
        }
        public void ComboBoxTastings()
        {
            ObservableTastingList = new ObservableCollection<Tasting>(DataAccess.Instance.GetTasting());
        }

        public void Clean()
        {
            ChosenChampagne = null;
            ChosenTasting = null;
        }


        public void WriteSelected()
        {
            if (!(SelectedTastingChampagne == null))
            {
                NewChosenChampagne = SelectedTastingChampagne.Champagne;
                NewChosenTasting = SelectedTastingChampagne.Tasting;
            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (ChosenChampagne is null || ChosenTasting is null)
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewChosenTasting is null || NewChosenChampagne is null)
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedTastingChampagne == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
