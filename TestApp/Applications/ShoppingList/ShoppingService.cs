using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Applications
{
    public static class ShoppingService
    {
        static SQLiteAsyncConnection db;
        
        static async Task Init()
        {
            // Get an absolute path to the database file
            if(db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<ShoppingItem>();
        }

        public static async Task AddItem(string name, int qty)
        {
            await Init();
            var shoppingItem = new ShoppingItem
            {
                Name = name,
                Qty = qty
            };

            var id = await db.InsertAsync(shoppingItem);
        }

        public static async Task DeleteItem(int id)
        {
            await Init();

            await db.DeleteAsync<ShoppingItem>(id);
        }

        public static async Task<IEnumerable<ShoppingItem>> GetItem()
        {
            await Init();

            var shoppingList = await db.Table<ShoppingItem>().ToListAsync();

            return shoppingList;
        }

        public static async Task<IEnumerable<ShoppingItem>> GetItems()
        {
            await Init();

            var shoppingList = await db.Table<ShoppingItem>().ToListAsync();

            return shoppingList;
        }

        
    }
}
