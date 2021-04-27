using ReablementApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ReablementApp.Services
{
    public class ClientService : SqlNetService
    {

       
        //Removes client from the clients table
        public static async Task RemoveClient(int id)
        {
            await Init();

            await db.DeleteAsync<Client>(id);
        }

        //Gets a list of clients fron the clients table in the database
        public static async Task<IEnumerable<Client>> GetClients()
        {
            await Init();

            var clients = await db.Table<Client>().ToListAsync();
            return clients;
        }

        // Method gets a client from the clients table in the database via their ID
        public static Task<Client> GetClientAsync(int id)
        {
            // Get a specific client.
            return db.Table<Client>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        // Method to get a client from the clients table in the databasse by their CHI Number
        public static Task<Client> GetClientChiNumberAsync(string ChiNumber)
        {
            // Get a specific client by chi number.
            return db.Table<Client>()
                            .Where(i => i.ChiNumber == ChiNumber)
                            .FirstOrDefaultAsync();
        }


        //Method to add or update an existing client to the clients table in the database. 
        public static Task<int> SaveClientAsync(Client client)
        {
            if (client.Id != 0)
            {
                // Update an existing client.
                return db.UpdateAsync(client);
            }
            else
            {
                // Save a new client.
                return db.InsertAsync(client);
            }
        }

    }
}
