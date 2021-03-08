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

        public async Task<Item> GetFortune()
        {
            var items = await DataStore.GetItemsAsync();
            var source = BatterySource();
            if(level < 0.15)
            {
                return await DataStore.GetItemAsync(11);
            }
            else if(source == BatteryPowerSource.AC)
            {
                return await DataStore.GetItemAsync(12);
            }
            else if(source == BatteryPowerSource.Usb)
            {
                return await DataStore.GetItemAsync(13);
            }
            else
            {
                int max = items.Count;
                int id = rnd.Next(items.Count + 1);
                return await DataStore.GetItemAsync(id);
            }
        }

        public BatteryPowerSource BatterySource()
        {
            var source = Battery.PowerSource;
            switch (source)
            {
                case BatteryPowerSource.Battery:
                    // Being powered by the battery
                    break;
                case BatteryPowerSource.AC:
                    // Being powered by A/C unit
                    break;
                case BatteryPowerSource.Usb:
                    // Being powered by USB cable
                    break;
                case BatteryPowerSource.Wireless:
                    // Powered via wireless charging
                    break;
                case BatteryPowerSource.Unknown:
                    // Unable to detect power source
                    break;
            }

            return source;
        }

    }
}
