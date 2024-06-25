using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using App3.Models;

namespace App3.Data
{
    public class DatabaseContext
    {
        private readonly SQLiteAsyncConnection Connection;
        public DatabaseContext(string dbpath)
        {
            Connection = new SQLiteAsyncConnection(dbpath);
            Connection.CreateTableAsync<CV>().Wait();
        }

        public async Task<int> InsertItemASync(CV item)
        {
            return await Connection.InsertAsync(item);
        }
        public async Task<List<CV>> GetItemsAsync()
        {
            return await Connection.Table<CV>().ToListAsync();
        }
        public async Task<int>DeleteItemAsync(CV item)
        {
            return await Connection.DeleteAsync(item);
        }
    }
}
