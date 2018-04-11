using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HelpYou.Data
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int PrimaryId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
        public string Days { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
