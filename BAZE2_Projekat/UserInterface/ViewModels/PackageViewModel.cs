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
    public class PackageViewModel : BaseViewModel
    {
        private Packer chosenPacker;

        public Packer ChosenPacker
        {
            get { return chosenPacker; }
            set
            {
                chosenPacker = value;
                OnPropertyChanged(nameof(ChosenPacker));
            }
        }

        private Transport chosenTransport;

        public Transport ChosenTransport
        {
            get { return chosenTransport; }
            set
            {
                chosenTransport = value;
                OnPropertyChanged(nameof(ChosenTransport));
            }
        }


        //NEW
        private Packer newChosenPacker;

        public Packer NewChosenPacker
        {
            get { return newChosenPacker; }
            set
            {
                newChosenPacker = value;
                OnPropertyChanged(nameof(NewChosenPacker));
            }
        }

        private Transport newChosenTransport;

        public Transport NewChosenTransport
        {
            get { return newChosenTransport; }
            set
            {
                newChosenTransport = value;
                OnPropertyChanged(nameof(NewChosenTransport));
            }
        }

        private Package selectedPackage;

        public Package SelectedPackage
        {
            get { return selectedPackage; }
            set
            {
                selectedPackage = value;
                OnPropertyChanged(nameof(SelectedPackage));
            }
        }


        //KOLEKCIJE
        private ObservableCollection<Package> observablePackageList;

        public ObservableCollection<Package> ObservablePackageList
        {
            get { return observablePackageList; }
            set
            {
                observablePackageList = value;
                OnPropertyChanged(nameof(ObservablePackageList));
            }
        }

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

        private ObservableCollection<Packer> observablePackerList;

        public ObservableCollection<Packer> ObservablePackerList
        {
            get { return observablePackerList; }
            set
            {
                observablePackerList = value;
                OnPropertyChanged(nameof(ObservablePackerList));
            }
        }



        //KOMANDE
        public MyICommand AddPackageCommand { get; set; }
        public MyICommand RemovePackageCommand { get; set; }
        public MyICommand EditPackageCommand { get; set; }

        //KONSTRUKTOR
        public PackageViewModel()
        {
            AddPackageCommand = new MyICommand(AddPackage);
            RemovePackageCommand = new MyICommand(RemovePackage);
            EditPackageCommand = new MyICommand(EditPackage);
            Refresh();

            ComboBoxTransport();
            ComboBoxPackers();
            Refresh();
        }


        public void AddPackage()
        {
            if (Validate())
            {
                DataAccess.Instance.AddPackage(ChosenTransport, ChosenPacker);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja!");
                Clean();
            }
        }
        public void RemovePackage()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemovePackage(SelectedPackage.PackageId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali paket!");
            }
        }
        public void EditPackage()
        {
            if (ValidateSelect())
            {
                if (ValidateNew())
                {
                    DataAccess.Instance.EditPackage(SelectedPackage.PackageId, NewChosenTransport, NewChosenPacker);
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
                MessageBox.Show("Niste selektovali paket!");
            }
        }


        public void Refresh()
        {
            ObservablePackageList = new ObservableCollection<Package>(DataAccess.Instance.GetPackage());
        }
        public void ComboBoxTransport()
        {
            ObservableTransportList = new ObservableCollection<Transport>(DataAccess.Instance.GetTransport());
        }
        public void ComboBoxPackers()
        {
            ObservablePackerList = new ObservableCollection<Packer>(DataAccess.Instance.GetPacker());
        }

        public void Clean()
        {
            ChosenPacker = null;
            ChosenTransport = null;
        }


        public void WriteSelected()
        {
            if (!(SelectedPackage == null))
            {
                NewChosenTransport = SelectedPackage.Transport;
            }
        }




        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (ChosenTransport is null || ChosenPacker is null)
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewChosenPacker is null || NewChosenTransport is null)
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedPackage == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
