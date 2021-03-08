using MyApp.Models;
using MyApp.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        //bring in our interface:
        //Funky dependency injection?
        //Sort of our repository? feels like there is an extra layer of abstraction and this is the middle man
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private string text = string.Empty;

        public string Text
        {
            get { return text; }

            set
            {
                if (text == value)
                {
                    return;
                }
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public AboutViewModel()
        {
            //What do we need here?
        }

        public async void Save()
        {
            Item newItem = new Item()
            {
                Description = Text
            };

            await DataStore.AddItemAsync(newItem);
        }
    }
}