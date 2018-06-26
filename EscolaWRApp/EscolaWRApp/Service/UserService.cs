using EscolaWRApp.Database;
using EscolaWRApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EscolaWRApp.Service
{
    public static class UserService
    {
        public static DbAccess<User> dbAccess = new DbAccess<User>();

        public static void Insert(User user)
        {
            user.CreationDate = DateTime.Now;
            user.IsLogged = true;
            dbAccess.Save(user);
        }

        public static User Authenticate(string email, string password)
        {
            var user = dbAccess.Find(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password));
            if(user != null)
            {
                user.IsLogged = true;
                Edit(user);
                return user;
            }

            return null;
        }

        public static void Edit(User user)
        {
            dbAccess.Update(user);
        }

        public static User Load(int id)
        {
            return dbAccess.Find(x => x.Id == id);
        }

        public static void Remove(int id)
        {
            dbAccess.Delete(id);
        }

        public static User GetUserLogged()
        {
            return List(x => x.IsLogged).FirstOrDefault();
        }

        public static void Logout(User user)
        {
            user.IsLogged = false;
            Edit(user);
        }

        public static List<User> List(Expression<Func<User, bool>> predicate)
        {
            return dbAccess.List(predicate).ToList();
        }

        public static List<User> ListAll()
        {
            return dbAccess.ListAll().ToList();
        }
    }
}
