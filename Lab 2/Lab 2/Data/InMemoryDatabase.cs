using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_2.Data.Entities;

namespace Lab_2.Data
{
    public static class InMemoryDatabase
    {
        public static List<User> Users = new List<User>();
        public static int id = 0;
        public static int NextId()
        {
            return id++;
        }
        public static void DeleteUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            Users.Remove(user);
        }
        public static User FindUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            return user;
        }
    }
}