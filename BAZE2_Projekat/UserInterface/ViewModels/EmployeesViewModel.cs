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
    public class EmployeesViewModel : BaseViewModel
    {
        private String employeeFirstName;

        public String EmployeeFirstName
        {
            get { return employeeFirstName; }
            set
            {
                employeeFirstName = value;
                OnPropertyChanged(nameof(EmployeeFirstName));
            }
        }

        private string employeeLastName;

        public string EmployeeLastName
        {
            get { return employeeLastName; }
            set
            {
                employeeLastName = value;
                OnPropertyChanged(nameof(EmployeeLastName));
            }
        }

        private string employeeSalary;

        public string EmployeeSalary
        {
            get { return employeeSalary; }
            set
            {
                employeeSalary = value;
                OnPropertyChanged(nameof(EmployeeSalary));
            }
        }

        private string chosenEmployeeRole;

        public string ChosenEmployeeRole
        {
            get { return chosenEmployeeRole; }
            set
            {
                chosenEmployeeRole = value;
                OnPropertyChanged(nameof(ChosenEmployeeRole));
            }
        }


        //NEW
        private String newEmployeeFirstName;

        public String NewEmployeeFirstName
        {
            get { return newEmployeeFirstName; }
            set
            {
                newEmployeeFirstName = value;
                OnPropertyChanged(nameof(NewEmployeeFirstName));
            }
        }

        private string newEmployeeLastName;

        public string NewEmployeeLastName
        {
            get { return newEmployeeLastName; }
            set
            {
                newEmployeeLastName = value;
                OnPropertyChanged(nameof(NewEmployeeLastName));
            }
        }

        private string newEmployeeSalary;

        public string NewEmployeeSalary
        {
            get { return newEmployeeSalary; }
            set
            {
                newEmployeeSalary = value;
                OnPropertyChanged(nameof(NewEmployeeSalary));
            }
        }

        private string newChosenEmployeeRole;

        public string NewChosenEmployeeRole
        {
            get { return newChosenEmployeeRole; }
            set
            {
                newChosenEmployeeRole = value;
                OnPropertyChanged(nameof(NewChosenEmployeeRole));
            }
        }


        private ObservableCollection<Employees> observableEmployeesList;

        public ObservableCollection<Employees> ObservableEmployeesList
        {
            get { return observableEmployeesList; }
            set
            {
                observableEmployeesList = value;
                OnPropertyChanged(nameof(ObservableEmployeesList));
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
        private ObservableCollection<String> observableRoleList;

        public ObservableCollection<String> ObservableRoleList
        {
            get { return observableRoleList; }
            set
            {
                observableRoleList = value;
                OnPropertyChanged(nameof(ObservableRoleList));
            }
        }

        private Employees selectedEmployee;

        public Employees SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                Clean();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        //WINNARY
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


        public MyICommand AddEmployeeCommand { get; set; }
        public MyICommand RemoveEmployeeCommand { get; set; }
        public MyICommand EditEmployeeCommand { get; set; }

        public MyICommand ShowPackersCommand { get; set; }
        public MyICommand ShowSellersCommand { get; set; }
        public MyICommand ShowAllCommand { get; set; }

        public EmployeesViewModel()
        {
            AddEmployeeCommand = new MyICommand(AddEmployee);
            RemoveEmployeeCommand = new MyICommand(RemoveEmployee);
            EditEmployeeCommand = new MyICommand(EditEmployee);
            Refresh();
            ComboBoxWinnaries();
            ComboBoxRoles();

            ShowPackersCommand = new MyICommand(ShowPackers);
            ShowSellersCommand = new MyICommand(ShowSellers);
            ShowAllCommand = new MyICommand(ShowAll);
        }


        public void AddEmployee()
        {
            if(ChosenEmployeeRole == "Paker")
            {
                if (Validate())
                {
                    DataAccess.Instance.AddPacker(new Packer { FirstName = EmployeeFirstName, LastName = EmployeeLastName, Salary = EmployeeSalary }, ChosenWinnary);
                    Refresh();
                    Clean();
                }
                else
                {
                    MessageBox.Show("Nisu popunjena sva polja!");
                    Clean();
                }
            }
            else if(ChosenEmployeeRole == "Prodavac")
            {
                if (Validate())
                {
                    DataAccess.Instance.AddSeller(new Seller { FirstName = EmployeeFirstName, LastName = EmployeeLastName, Salary = EmployeeSalary }, ChosenWinnary);
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
        public void RemoveEmployee()
        {
            if (ValidateSelect())
            {
                DataAccess.Instance.RemoveEmployee(SelectedEmployee.EmployeesId);
                Refresh();
                Clean();
            }
            else
            {
                MessageBox.Show("Niste selektovali vinariju!");
            }
        }
        public void EditEmployee()
        {
            if (ValidateSelect())
            {
                if(SelectedEmployee is Packer)
                {
                    if (ValidateNew())
                    {
                        DataAccess.Instance.EditPacker(SelectedEmployee.EmployeesId, new Packer { FirstName = NewEmployeeFirstName, LastName = NewEmployeeLastName, Salary = NewEmployeeSalary }, NewChosenWinnary);
                        Refresh();
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show("Nisu uneta sva polja!");
                    }
                }
                else if(SelectedEmployee is Seller)
                {
                    if (ValidateNew())
                    {
                        DataAccess.Instance.EditSeller(SelectedEmployee.EmployeesId, new Seller { FirstName = NewEmployeeFirstName, LastName = NewEmployeeLastName, Salary = NewEmployeeSalary }, NewChosenWinnary);
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
            ObservableEmployeesList = new ObservableCollection<Employees>(DataAccess.Instance.GetEmployees());
        }
        public void ComboBoxWinnaries()
        {
            ObservableWinnaryList = new ObservableCollection<Winnary>(DataAccess.Instance.GetWinnaries());
        }
        public void ComboBoxRoles()
        {
            ObservableRoleList = new ObservableCollection<String>() { "Paker", "Prodavac"};
        }

        public void Clean()
        {
            EmployeeFirstName = "";
            EmployeeLastName = "";
            EmployeeSalary = "";
        }


        public void WriteSelected()
        {
            if (!(SelectedEmployee == null))
            {
                NewEmployeeFirstName = SelectedEmployee.FirstName;
                NewEmployeeLastName = SelectedEmployee.LastName;
                NewEmployeeSalary = SelectedEmployee.Salary;
            }
        }

        public void ShowPackers()
        {
            ObservableEmployeesList = new ObservableCollection<Employees>(DataAccess.Instance.GetPackers());
        }

        public void ShowSellers()
        {
            ObservableEmployeesList = new ObservableCollection<Employees>(DataAccess.Instance.GetSellers());
        }
        public void ShowAll()
        {
            ObservableEmployeesList = new ObservableCollection<Employees>(DataAccess.Instance.GetEmployees());
        }



        //VALIDACIJE
        public bool Validate()
        {
            bool valid = true;

            if (EmployeeFirstName.Equals("") || EmployeeLastName.Equals("") || EmployeeSalary.Equals(""))
            {
                valid = false;
            }

            return valid;
        }
        public bool ValidateNew()
        {
            bool validNew = true;

            if (NewEmployeeFirstName.Equals("") || NewEmployeeLastName.Equals("") || NewEmployeeSalary.Equals(""))
            {
                validNew = false;
            }

            return validNew;
        }
        public bool ValidateSelect()
        {
            bool selected = true;

            if (SelectedEmployee == null)
            {
                selected = false;
            }
            return selected;
        }
    }
}
