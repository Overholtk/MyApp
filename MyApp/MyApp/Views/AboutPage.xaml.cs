using MyApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    public partial class AboutPage : ContentPage
    {
        //This is the controller compared to MVC
        //Here we call methods from the ViewModel
        //Bring in the View Model:
        readonly AboutViewModel _vm;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _vm = new AboutViewModel();
        }

        public void ButtonPress(object sender, EventArgs e)
        {
            _vm.Save();
        }
    }
}