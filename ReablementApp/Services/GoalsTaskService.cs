using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReablementApp.Services
{
    public class GoalsTaskService : SqlNetService
    {
        //Gets a list of tasks fron the GoalsTasks table in the database
        public static async Task<IEnumerable<GoalsTasks>> GetTasks()
        {
            await Init();

            var tasks = await db.Table<GoalsTasks>().Where(i => i.CurrentGoalID == CurrentGoalModel.CurrentGoalID).ToListAsync();


            return tasks;
        }

        //Removes task from the GoalsTasks table
        public static async Task RemoveTask(int id)
        {
            await Init();

            await db.DeleteAsync<GoalsTasks>(id);
        }


        //Method to add or update an existing task to the GoalsTasks table in the database. 
        public static Task<int> SaveTaskAsync(GoalsTasks task)
        {
            if (task.Id != 0)
            {
                // Update an existing task.
                return db.UpdateAsync(task);
            }
            else
            {
                // Save a new task.
                return db.InsertAsync(task);
            }
        }

    }
}
