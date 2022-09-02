using PYP_DelegateTask.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PYP_DelegateTask.Models
{
    public class Company
    {
        //delegates
        public delegate void RegisterLogManager(string message);
        public delegate string Generate(string name,string surname);

        private List<User> _users;
        public string Name { get; set; }
        public Company(string name)
        {
            Name = name;
            _users = new List<User>();
        }
        
        public bool Register(string name,string surname,string password)
        {
            //generate email and username
            Generate generate = new Generate(UsernameGenerate);
            string username = generate.Invoke(name, surname);
            generate += EmailGenerate;
            string email = generate.Invoke(name, surname);
            if (_users.Find(x=>x.Username==username)!=null)
            {
                return false;
            }
            User user = new User(name, surname, username, email,password);
            _users.Add(user);
            return true;
        }
        public bool Login(string username,string password)
        {
            if (_users.Find(x=>x.Username== username &&x.Password== password)==null)
            {
                return false;
            }
            return true;
        }
        
        public List<User> GetAll(Predicate<User> filter = null)
        {
            if (filter != null)
                return _users.FindAll(filter);
            return _users;
        }
        public User GetById(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public List<User> ShowUsers()
        {
            return _users;
        }


        /// generate metods
        public string UsernameGenerate(string name,string surname)
        {
            string username = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}";
            return username;
        }
        public string EmailGenerate(string name, string surname)
        {
            int i = 0;
            var email = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}{i++}@gmail.com";
            return email;
        }
    }
}
