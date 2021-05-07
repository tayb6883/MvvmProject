using Microsoft.VisualStudio.PlatformUI;
using mvvm_with_wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp1.CommonHelper;

namespace mvvm_with_wpf.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region properties declaration
     
        public event PropertyChangedEventHandler PropertyChanged;
        private Common helper = new Common();

        #endregion

        #region Getter/ Setters for properties
        public DelegateCommand<object> MyCommand { get; private set; }
        public DelegateCommand<object> buttonCommand { get; private set; }

        private ObservableCollection<Employee> empList = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> EmpList
        {
            get { return empList; }
            set
            {
                EmpList = value;
                new Employee().OnPropertyChanged("EmpList");
            }
        }

        private ObservableCollection<Employee> toggleEmpList = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> ToggleEmpList
        {
            get { return toggleEmpList; }
            set
            {
                if (ToggleEmpList == null)
                {
                    ToggleEmpList = new ObservableCollection<Employee>(value);
                }
                else
                {
                    ToggleEmpList = value;
                }
                new Employee().OnPropertyChanged("EmpList");
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                NotifyPropertyChanged("SelectedEmployee");
            }
        }

        #endregion

        #region Class Constructor
        public MainWindowViewModel()
        {
            MyCommand = new DelegateCommand<object>(Excute);
            buttonCommand = new DelegateCommand<object>(ExcuteButton);
            ObservableCollection<Employee> elist = new ObservableCollection<Employee>();
        }

        #endregion

        #region Methods
        public void Excute(object employee)
        {
            SelectedEmployee = (Employee)employee;
        }
        public void ExcuteButton(object employee)
        {
            try
            {
                ObservableCollection<Employee> elist = EmpList;
                EmpList.Add(new Employee()
                {
                    EmployeeNumber = EmpList.Count + 1,
                    FirstName = helper.RandomString(4),
                    LastName = helper.RandomString(7),
                    Title = helper.RandomString(3),
                    Department = "Development"
                });

                //var result = EmpList.Where(x => x.EmployeeNumber % 2 == (EmpList.Count % 2)).ToList();
                ToggleEmpList.Clear();
                foreach (var obj in EmpList)
                {
                    if (obj.EmployeeNumber % 2 == (EmpList.Count % 2))
                    {
                        ToggleEmpList.Add(obj);
                    }
                }
                CollectionViewSource.GetDefaultView(this.ToggleEmpList).Refresh();
            }
            catch (Exception ex)
            {
            }
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                    this.PropertyChanged(this, args);
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
