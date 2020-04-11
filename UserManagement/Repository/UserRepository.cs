using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repository
{
    public static class UserRepository
    {
        private static List<User> users = new List<User>
        {
            new User{Id = 1, Name = "Gurmeet", Age = 45, Email = "gurmeet45@gmail.com"},
            new User{Id = 2, Name = "Priyanka", Age = 28, Email = "priyanka@yahoo.com"}
        };

        public static User GetUserDetails(int Id)
        {
            var user = users.Find(x => x.Id == Id);
            return user;
        } 
    }
}
