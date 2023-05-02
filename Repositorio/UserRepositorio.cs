using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticatiosAutorization.Models;

namespace AutenticatiosAutorization.Repositorio
{
    public static class UserRepositorio
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>()
            {
                new() {Id = 1, UserName = "batman", Password = "batman",
                Role = "admin"},

                new(){Id = 2, UserName = "batwoman", Password = "batwoman",
                Role = "gerente"},

                new(){Id = 3, UserName = "robin", Password = "robin",
                Role = "empregado"
                }
            };

            return users.FirstOrDefault(x => x.UserName == username &&
            x.Password == password);
        }
    }
}