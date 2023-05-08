using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.FreeDesktop.DBusIme;
using Avalonia.Interactivity;
using AvaloniaCalculator.ViewModels;
using Avalonia.Logging;
using Avalonia;
using System.Reflection.Metadata;
using System;
using Avalonia.Animation;

namespace AvaloniaCalculator.Views
{
    public partial class MainWindow : Window
    {
        //public bool handle = true;
        //public MainWindowViewModel viewModel;

        //pub

        //private PixelPoint newPosition = new(0, 0);

        public MainWindow()
        {
            //var DataContext = new MainWindowViewModel();
            //viewModel.Check = "Artem";
            
            Logger.TryGet(LogEventLevel.Fatal, LogArea.Control)?.Log(this, "Avalonia Infrastructure");
            //System.Diagnostics.Debug.WriteLine("System Diagnostics Debug");
            InitializeComponent();
            //this.DataContext = viewModel;
            //Width = 400;
            //Height = 600;
            //System.Diagnostics.Debug.WriteLine(Position);
            //System.Diagnostics.Debug.WriteLine(Position);
            //Position = new Avalonia.PixelPoint((Screens.Primary.Bounds.Width - (int)Width) / 2 - 76, (Screens.Primary.Bounds.Height - (int)Height) / 2 - 76);
            //System.Diagnostics.Debug.WriteLine((Screens.Primary.Bounds.Width - (int)Width) / 2);
            //System.Diagnostics.Debug.WriteLine((Screens.Primary.Bounds.Height - (int)Height) / 2);
            //System.Diagnostics.Debug.WriteLine(Position);
            //System.Diagnostics.Debug.WriteLine(Screens.Primary.WorkingArea.Height);
            //System.Diagnostics.Debug.WriteLine(Screens.Primary.Bounds.Width);
            //System.Diagnostics.Debug.WriteLine(Screens.Primary.Bounds.Height);
            //System.Diagnostics.Debug.WriteLine((Screens.Primary.WorkingArea.Width - (int)Width) / 2);
            //System.Diagnostics.Debug.WriteLine((Screens.Primary.WorkingArea.Height - (int)Height) / 2);
            //System.Diagnostics.Debug.WriteLine(ClientSize.Width);
            //ClientSize.Width
            //Console

            //viewModel.Check = "Mark";

            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //protected override void OnOpened(EventArgs e)
        //{
        //    Position = newPosition;
        //    base.OnOpened(e);
        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    handle = !handle;
        //    System.Diagnostics.Debug.WriteLine(handle);
        //}
        //
        //private void ComboBox_DropDownClosed(object sender, RoutedEventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine(handle);
        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Some logic here
        //    //MainWindowViewModel().Handle = true;
        //    viewModel.Handle = !(viewModel.Handle);
        //    System.Diagnostics.Debug.WriteLine(viewModel.Handle);
        //}

    }
}