using MyApp.Models;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    class CookieViewModel : BaseViewModel
    {

        public int movesCount = 0;
        public Random rnd = new Random();
        public double level = Battery.ChargeLevel;
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public async Task<string> GetFortune()
        {
            var items = await DataStore.GetItemsAsync();
            if(level < 0.15)
            {
                Item fortune = await DataStore.GetItemAsync(11);
                return fortune.Description;
            }
            else
            {
                int max = items.Count;
                int id = rnd.Next(items.Count + 1);
                Item fortune = await DataStore.GetItemAsync(id);
                return fortune.Description;
            }
        }

    }
}
