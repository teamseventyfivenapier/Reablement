using ReablementApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ReablementApp.Services
{
    public class SqlNetService
    {
        public static SQLiteAsyncConnection db;

        //create our database and our tables
        public static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Client>();
            await db.CreateTableAsync<Account>();
        }

    }
}
