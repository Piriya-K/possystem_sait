using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_System.ViewModels
{
    public class LoginScreenViewModel : ViewModelBase
    {
        //Fields
        //binding the View and ViewModel
        //Howard: skip password for now. will be completed later
        private int _id;
        private string _errorMessage;
        private bool _success = true;

        //Properties
        //add propertyChange to notify the value has changed 
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnpropertyChanged(nameof(Id));
            }


        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnpropertyChanged(nameof(ErrorMessage));
            }


        }
        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;
                OnpropertyChanged(nameof(Success));
            }


        }

        //Commands
        public ICommand LoginCommand { get; }

        //Constructor
        public LoginScreenViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommad, CanExecuteLoginCommand);
        }

        //Here is the login validation 
        
        private bool CanExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();


        }

        private void ExecuteLoginCommad(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
