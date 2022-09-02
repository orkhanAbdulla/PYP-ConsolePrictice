using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_DelegateTask.Models
{
    public class User
    {
        public int Id { get; }
        private static int _id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string name, string surname, string username, string email, string password)
        {
            Id = ++_id;
            Name = name;
            Surname = surname;
            Username = username;
            Email = email;
            Password = password;
        }
        public override string ToString()
        {
            return $" Id = {Id}  Username = {Username} Email = {Email}";
        }

    }
}
