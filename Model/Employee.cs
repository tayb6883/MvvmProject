using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_with_wpf.Model
{
    public class Employee : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        //private property should start with smallkeyword
        //public property declaration
        //method declaration
        #endregion

        int employeeNumber;
        string firstName;
        string lastName;
        string department;
        string title;

        public Employee()
        {
            employeeNumber = 0;
            firstName =
            lastName =
            department =
            title = null;
        }
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set
            {
                employeeNumber = value;
                OnPropertyChanged("EmployeeNumber");
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", FirstName, LastName, EmployeeNumber);
        }

        //[System.Runtime.CompilerServices.CallerMemberName]
        //string memberName = "",
        //fody
        public void OnPropertyChanged(string propertyName, [System.Runtime.CompilerServices.CallerMemberNameAttribute] string memberName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }


    }
}
