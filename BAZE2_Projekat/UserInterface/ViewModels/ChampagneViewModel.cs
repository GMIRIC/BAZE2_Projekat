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
    public class ChampagneViewModel : BaseViewModel
    {
        private String champagneName;

        public String ChampagneName
        {
            get { return champagneName; }
            set
            {
                champagneName = value;
                OnPropertyChanged(nameof(ChampagneName));
            }
        }

        private DateTime chosenChampagneDate;

        public DateTime ChosenChampagneDate
        {
            get { return chosenChampagneDate; }
            set
            {
                chosenChampagneDate = value;
                OnPropertyChanged(nameof(ChosenChampagneDate));
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
        private String newChampagneName;

        public String NewChampagneName
        {
            get { return newChampagneName; }
            set
            {
                newChampagneName = value;
                OnPropertyChanged(nameof(NewChampagneName));
            }
        }

        private DateTime newChosenChampagneDate;

        public DateTime NewChosenChampagneDate
        {
            get { return newChosenChampagneDate; }
            set
            {
                newChosenChampagneDate = value;
                OnPropertyChanged(nameof(NewChosenChampagneDate));
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

        private Champagne selectedChampagne;

        public Champagne SelectedChampagne
        {
            get { return selectedChampagne; }
            set
            {
                selectedChampagne = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedChampagne));
            }
        }


        //KOMANDE
        public MyICommand AddChampagneCommand { get; set; }
        public MyICommand RemoveChampagneCommand { get; set; }
        public MyICommand EditChampagneCommand { get; set; }


        //KONSTRUKTOR
        public ChampagneViewModel()
        {
            AddChampagneCommand = new MyICommand(AddChampagne);
            RemoveChampagneCommand = new MyICommand(RemoveChampagne);
            EditChampagneCommand = new MyICommand(EditChampagne);
            Refresh();

          
            ChosenChampagneDate = DateTime.Now;

            Refresh();
        }


        public void AddChampagne()
        {
            if (Validate())
            {
                DataAccess.Instance.AddChampagne(new Champagne { Name = ChampagneName, ProductionDate = ChosenChampagneDate });
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemoveChampagne()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveChampagne(SelectedChampagne.ChampagneId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali sampanjac!");
            }
        }
        public void EditChampagne()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditChampagne(SelectedChampagne.ChampagneId, new Champagne { Name = NewChampagneName, ProductionDate = NewChosenChampagneDate });
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
                MessageBox.Show("Niste selektovali sampanjac!");
            }
        }


        public void Refresh()
        {
            ObservableChampagneList = new ObservableCollection<Champagne>(DataAccess.Instance.GetChampagne());
        }
       

        public void Clean()
        {
            ChampagneName = "";
            ChosenChampagneDate = DateTime.Now;

        }


        public void WriteSelected()
        {
            if (!(SelectedChampagne == null))
            {
                NewChampagneName = SelectedChampagne.Name;
                NewChosenChampagneDate = SelectedChampagne.ProductionDate;

            }
        }


        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (ChampagneName.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewChampagneName.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedChampagne == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
