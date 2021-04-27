using ReablementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReablementApp.Services
{
    public class GoalsService : SqlNetService
    {
        //Gets a list of goals fron the goals table in the database
        public static async Task<IEnumerable<Goal>> GetGoals()
        {
            await Init();

            var goals = await db.Table<Goal>().Where(i => i.CurrentClientID == CurrentClientModel.CurrentClientID).ToListAsync();



            return goals;
        }

        //Removes goal from the goals table
        public static async Task RemoveGoal(int id)
        {
            await Init();

            await db.DeleteAsync<Goal>(id);
        }


        //Method to add or update an existing goal to the goals table in the database. 
        public static Task<int> SaveGoalAsync(Goal goal)
        {
            if (goal.Id != 0)
            {
                // Update an existing goal.
                return db.UpdateAsync(goal);
            }
            else
            {
                // Save a new goal.
                return db.InsertAsync(goal);
            }
        }

        //Method to add or update an existing goal to the goal table in the database. 
        public static Task<int> SaveTaskAsync(GoalsTasks tasks)
        {
            if (tasks.Id != 0)
            {
                // Update an existing goal.
                return db.UpdateAsync(tasks);
            }
            else
            {
                // Save a new goal.
                return db.InsertAsync(tasks);
            }
        }

    }
}
