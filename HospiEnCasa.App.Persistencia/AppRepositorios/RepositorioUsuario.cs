using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using BC = BCrypt.Net.BCrypt;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppContext db;
        public RepositorioUsuario(AppContext db)
        {
            this.db = db;
        }

        Usuario IRepositorioUsuario.CreateUser(string email, string username, string password)
        {
            Usuario newUser = new Usuario {
                Email = email,
                UserName = username,
                Password = BC.HashPassword(password)
                };
            db.Usuarios.Add(newUser);
            db.SaveChanges();

            return newUser;
        }
    }
}