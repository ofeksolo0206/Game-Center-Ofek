using GameCenter.Projects.UsersManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Projects.UsersManagment.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogIn { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            Status = UserStatusTypes.Logged_Off.ToString();
            Created = DateTime.Now;
        }
    }
}
