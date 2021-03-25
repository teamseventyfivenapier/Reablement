using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using ReablementApp.Models;

namespace ReablementApp.Services
{
   public class SqlNetService
   {

        public static SQLiteAsyncConnection db;
        //Create database and tables.

        public static async Task init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            
            db = new SQLiteAsyncConnection(databasePath);

            //This is creating the tables
            //Client Table 
            await db.CreateTableAsync<Client>();
            //Manager Table 
            await db.CreateTableAsync<Manager>();
            //Carer Table
            await db.CreateTableAsync<Carer>();
            //OccupationalTherapist Table 
            await db.CreateTableAsync<OccupationalTherapist>();
            //Account Table 
            await db.CreateTableAsync<Account>();
            //Goals Table 
            await db.CreateTableAsync<Goals>();


        }


    }
}
