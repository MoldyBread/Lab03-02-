using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Lab03_02_
{
    internal class PersonControlViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth=DateTime.Today;

        private Visibility _loaderVisibility = Visibility.Hidden;
        private Visibility _buttonVisibility = Visibility.Visible;

        private RelayCommand<object> _submitCommand;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility ButtonVisibility
        {
            get { return _buttonVisibility; }
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand<object>(
                    SubmitImplementation ,o=>CanExecuteCommand()));
            }
        }


        private async void SubmitImplementation(object obj)
        {
            ButtonVisibility = Visibility.Hidden;
            LoaderVisibility = Visibility.Visible;

            await Task.Run(() => Thread.Sleep(2000));

            ButtonVisibility = Visibility.Visible;
            LoaderVisibility = Visibility.Hidden;
            try
            {
                _person = new Person(_firstName, _lastName, _email, _dateOfBirth);

                if (_person.IsBirthday)
                    MessageBox.Show("Happy birthday, bruh !!!");


                //Output type not mentioned, so I show all 8 properties in MessageBox
                MessageBox.Show(_person.FirstName + " " + _person.LastName + "\n" +
                                _person.Email + "\n" +
                                _person.DateOfBirth.Day+"."+_person.DateOfBirth.Month+"."+ _person.DateOfBirth.Year + "\n" +  //Own output to not show the time
                                "IsAdult: " + _person.IsAdult + "\n" +
                                "SunSign: " + _person.SunSign + "\n" +
                                "ChineseSign: " + _person.ChineseSign + "\n" +
                                "IsBirthday: " + _person.IsBirthday,"Person");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        
        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_email);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
