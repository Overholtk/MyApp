using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                //Fortunes 1-10: random ominousness
                new Item { Id = 1, Description="Get your hands on the nude lip kit, it leaves no mark at all upon the soul." },
                new Item { Id = 2, Description="Tap OK once to remember, twice to forget." },
                new Item { Id = 3, Description="Did you notice the change in your sock drawer?" },
                new Item { Id = 4, Description="[Ominous Phrase]" },
                new Item { Id = 5, Description="Run." },
                new Item { Id = 6, Description="Your fate is already sealed, knowing wont save you." },
                new Item { Id = 7, Description="16.... f... 91... albatross..." },
                new Item { Id = 8, Description="I could tell you how you die, but that would take the fun out." },
                new Item { Id = 9, Description="Have you actually read the permissions on this app?" },
                new Item { Id = 10, Description="You have completely forgotten the piece of information that will save your life!" },
                new Item { Id = 11, Description="Why are you on this app when your battery is so low?" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}