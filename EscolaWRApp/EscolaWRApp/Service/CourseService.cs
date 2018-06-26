using EscolaWRApp.Database;
using EscolaWRApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EscolaWRApp.Service
{
    public static class CourseService 
    {
        public static DbAccess<Course> dbAccess = new DbAccess<Course>();

        public static void Insert(Course course)
        {
            course.CreationDate = DateTime.Now;
            dbAccess.Save(course);
        }

        public static void Edit(Course course)
        {
            dbAccess.Update(course);
        }

        public static Course Load(int id)
        {
            return dbAccess.Find(x => x.Id == id);
        }

        public static void Remove(int id)
        {
            dbAccess.Delete(id);
        }

        public static List<Course> List(Expression<Func<Course, bool>> predicate)
        {
            return dbAccess.List(predicate).ToList();
        }

        public static List<Course> ListAll()
        {
            return dbAccess.ListAll().ToList();
        }
    }
}
