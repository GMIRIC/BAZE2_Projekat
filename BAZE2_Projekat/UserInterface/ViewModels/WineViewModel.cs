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
    public class WineViewModel : BaseViewModel
    {
        private String wineName;

        public String WineName
        {
            get { return wineName; }
            set
            {
                wineName = value;
                OnPropertyChanged(nameof(WineName));
            }
        }

        private DateTime chosenWineDate;

        public DateTime ChosenWineDate
        {
            get { return chosenWineDate; }
            set
            {
                chosenWineDate = value;
                OnPropertyChanged(nameof(ChosenWineDate));
            }
        }

        private Winnary chosenWinnary;

        public Winnary ChosenWinnary
        {
            get { return chosenWinnary; }
            set
            {
                chosenWinnary = value;
                OnPropertyChanged(nameof(ChosenWinnary));
            }
        }

        private String chosenType;

        public String ChosenType
        {
            get { return chosenType; }
            set
            {
                chosenType = value;
                OnPropertyChanged(nameof(ChosenType));
            }
        }


        //NEW
        private String newWineName;

        public String NewWineName
        {
            get { return newWineName; }
            set
            {
                newWineName = value;
                OnPropertyChanged(nameof(NewWineName));
            }
        }

        private DateTime newChosenWineDate;

        public DateTime NewChosenWineDate
        {
            get { return newChosenWineDate; }
            set
            {
                newChosenWineDate = value;
                OnPropertyChanged(nameof(NewChosenWineDate));
            }
        }

        private Winnary newChosenWinnary;

        public Winnary NewChosenWinnary
        {
            get { return newChosenWinnary; }
            set
            {
                newChosenWinnary = value;
                OnPropertyChanged(nameof(NewChosenWinnary));
            }
        }

        //KOLEKCIJE
        private ObservableCollection<Vine> observableWineList;

        public ObservableCollection<Vine> ObservableWineList
        {
            get { return observableWineList; }
            set
            {
                observableWineList = value;
                OnPropertyChanged(nameof(ObservableWineList));
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

        private ObservableCollection<String> observableTypeList;

        public ObservableCollection<String> ObservableTypeList
        {
            get { return observableTypeList; }
            set
            {
                observableTypeList = value;
                OnPropertyChanged(nameof(ObservableTypeList));
            }
        }


        private Vine selectedWine;

        public Vine SelectedWine
        {
            get { return selectedWine; }
            set
            {
                selectedWine = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedWine));
            }
        }

        
//KOMANDE
        public MyICommand AddWineCommand { get; set; }
        public MyICommand RemoveWineCommand { get; set; }
        public MyICommand EditWineCommand { get; set; }

        public MyICommand ShowRedCommand { get; set; }
        public MyICommand ShowWhiteCommand { get; set; }
        public MyICommand ShowAllCommand { get; set; }


//KONSTRUKTOR
        public WineViewModel()
        {
            AddWineCommand = new MyICommand(AddWine);
            RemoveWineCommand = new MyICommand(RemoveWine);
            EditWineCommand = new MyICommand(EditWine);
            Refresh();
            ComboBoxWinnaries();
            ComboBoxTypes();

            ShowRedCommand = new MyICommand(ShowRed);
            ShowWhiteCommand = new MyICommand(ShowWhite);
            ShowAllCommand = new MyICommand(ShowAll);

            ChosenWineDate = DateTime.Now;

            Refresh();
        }


        public void AddWine()
        {
            if (ChosenType == "Crno")
            {
                if (Validate())
                {
                    DataAccess.Instance.AddRed(new RedVine { Name = WineName, ProductionDate = ChosenWineDate }, ChosenWinnary);
                    Refresh();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    Clean();
                }
            }
            else if (ChosenType == "Belo")
            {
                if (Validate())
                {
                    DataAccess.Instance.AddWhite(new WhiteVine { Name = WineName, ProductionDate = ChosenWineDate }, ChosenWinnary);
                    Refresh();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    Clean();
                }
            }

        }
        public void RemoveWine()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveWine(SelectedWine.VineId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali vinariju!");
            }
        }
        public void EditWine()
        {
            if (ValidateSelect())
            {
                if (SelectedWine is RedVine)
                {
                    if (ValidateNew())
                    {
                        DataAccess.Instance.EditRed(SelectedWine.VineId, new RedVine { Name = NewWineName, ProductionDate = NewChosenWineDate }, NewChosenWinnary);
                        Refresh();
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Nisu uneta sva polja!");
                    }
                }
                else if (SelectedWine is WhiteVine)
                {
                    if (ValidateNew())
                    {
                        DataAccess.Instance.EditWhite(SelectedWine.VineId, new WhiteVine { Name = NewWineName, ProductionDate = NewChosenWineDate }, NewChosenWinnary);
                        Refresh();
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Nisu uneta sva polja!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Niste selektovali vinariju!");
            }
        }


        public void Refresh()
        {
            ObservableWineList = new ObservableCollection<Vine>(DataAccess.Instance.GetWine());
        }
        public void ComboBoxWinnaries()
        {
            ObservableWinnaryList = new ObservableCollection<Winnary>(DataAccess.Instance.GetWinnaries());
        }
        public void ComboBoxTypes()
        {
            ObservableTypeList = new ObservableCollection<String>() { "Crno", "Belo" };
        }

        public void Clean()
        {
            WineName = "";
            
        }


        public void WriteSelected()
        {
            if (!(SelectedWine == null))
            {
                NewWineName = SelectedWine.Name;
                NewChosenWineDate = SelectedWine.ProductionDate;
                NewChosenWinnary = SelectedWine.Winnary;

               
            }
        }

        public void ShowRed()
        {
            ObservableWineList = new ObservableCollection<Vine>(DataAccess.Instance.GetRed());
        }

        public void ShowWhite()
        {
            ObservableWineList = new ObservableCollection<Vine>(DataAccess.Instance.GetWhite());
        }
        public void ShowAll()
        {
            ObservableWineList = new ObservableCollection<Vine>(DataAccess.Instance.GetWine());
        }



        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (WineName.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewWineName.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedWine == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
