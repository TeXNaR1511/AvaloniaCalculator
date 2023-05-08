using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Tmds.DBus;

namespace AvaloniaCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        

        private static Random random = new Random();
        public string Greeting => "Welcome to Avalonia!";
        public string passgen => "PASSWORD GENERATOR";
        public string calcul => "CALCULATOR";

        private string check = "Password:";

        private Calculator calc = new Calculator();
       
        //private bool handle = true;

        public Calculator Calc
        {
            get => calc;
            set => this.RaiseAndSetIfChanged(ref calc, value);
        }

        public string Check 
        {
            get => check; 
            set => this.RaiseAndSetIfChanged(ref check, value); 
        }

        private bool handle = true;
        public bool Handle
        {
            get => handle;
            set => this.RaiseAndSetIfChanged(ref handle, value);
        }

        public void changeHandle()
        {
            Handle = !Handle;
        }

        private string selIndex = "0";
        public string SelIndex
        {
            get => selIndex;
            set
            {
                changeHandle();
                //System.Diagnostics.Debug.WriteLine(handle);
                this.RaiseAndSetIfChanged(ref selIndex, value);
            }
        }

        //private string _mySelectedItem;
        //public string MySelectedItem
        //{
        //    get { return _mySelectedItem; }
        //    set
        //    {
        //        // Some logic here
        //        if (value != "")
        //        {
        //            changeHandle();
        //        }
        //        System.Diagnostics.Debug.WriteLine(value);
        //        this.RaiseAndSetIfChanged(ref _mySelectedItem, value);
        //    }
        //}

        public void ChangeText()
        {
            Check = "art";
        }

        public void RandomString(int length)
        {
            if (length > 0) 
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&-_+=";
                Check = "Password: " + new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

        //public void ComboBox_SelectionChanged()
        //{
        //    handle = !handle;
        //    System.Diagnostics.Debug.WriteLine(handle);
        //}
        //
        //public void ComboBox_DropDownClosed()
        //{
        //    System.Diagnostics.Debug.WriteLine(handle);
        //}

        
    }
}