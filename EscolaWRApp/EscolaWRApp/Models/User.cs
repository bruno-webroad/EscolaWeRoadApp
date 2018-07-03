using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaWRApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UrlPhoto { get; set; }
        public bool IsScholarship { get; set; }        
        public DateTime CreationDate { get; set; }
        public bool IsLogged { get; set; }

        [OneToMany]
        public List<Course> Courses { get; set; }
    }
}
