using MvvmHelpers;
using Snapsearch.Models;
using Snapsearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Snapsearch.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public static IList<string> HistoryItemList = new List<string>(10);

        //public IList<Item> items { get; set; }

        public MockDataStore()
        {
            //items = new List<Item>()
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "First item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Second item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Third item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Fourth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Fifth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Sixth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Sixth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Sixth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Sixth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Path = "Sixth item", Description="This is an item description." }
            //};

            var rootDirectory = FileSystem.AppDataDirectory;

            items = new List<Item>();

            //foreach (var file in System.IO.Directory.GetFiles(rootDirectory))
            //{
            //    items.Add(new Item
            //    {
            //        Path = file
            //    });


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

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}