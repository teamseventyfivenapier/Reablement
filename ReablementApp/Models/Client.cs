using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReablementApp.Models
{
    //Clients model to store clients details
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //The CHI number is a unique is a 10-character numeric identifier
        public string ChiNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MedicalConditions { get; set; }
        public string AccidentHistory { get; set; }
        public double TimeOnRE { get; set; }
        public DateTime JoinedRE { get; set; }
        public DateTime AppointedOT { get; set; }
        public DateTime AppointedCarer { get; set; }
    }
}
