﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReablementApp.Models
{
    //Stores the clients goals. 
    public class GoalsTasks
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CurrentGoalID { get; set; }
        public string GoalTasks { get; set; }
     
    }
}
