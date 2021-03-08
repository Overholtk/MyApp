using SQLite;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyApp.Services
{
    class SQLiteDataStore : IDataStore<Item>
    {

        //actually our repository but also sort of our database? all direct querying here, call these methods in the VMs

        readonly SQLiteAsyncConnection database;
        public SQLiteDataStore()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fortunes.db3");
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Item>().Wait();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                int addedItem = await database.InsertAsync(item);
                Console.WriteLine("I have been activated");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            return database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
