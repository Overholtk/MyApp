using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CookiePage : ContentPage
    {
        readonly CookieViewModel _vm;
        public CookiePage()
        {
            InitializeComponent();
            BindingContext = _vm = new CookieViewModel();
        }

        protected override void OnAppearing()
        {
            
        }

        private void OnTappedClosed(object sender, EventArgs e)
        {
            MoveCookie(sender);
            DisplayFortune();
        }

        private void MoveCookie(object sender)
        {
            var newImg = (Image)sender;
            int maxMoves = _vm.rnd.Next(1, 4);
            //TODO: figure out how to delay animations so the cookie can make multiple moves

            //for(int i  = 0; i < maxMoves; i++) 
            //{
            double x = _vm.rnd.Next(0, 200);
            double y = _vm.rnd.Next(0, 200);
            CookieImg.TranslateTo(x, y, 200);

            _vm.movesCount++;
            //}
            newImg.Source = "open";
        }

        private async Task DisplayFortune()
        {
            string fortune = await _vm.GetFortune();
            await DisplayAlert("The Cookie Says...", fortune, "OK");
        }
    }
}