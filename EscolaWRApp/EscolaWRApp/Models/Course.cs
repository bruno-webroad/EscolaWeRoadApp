using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaWRApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkLoad { get; set; }
        public double Price { get; set; }
        public string Teacher { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }

        [ManyToOne]
        public User User { get; set; }
    }
}
