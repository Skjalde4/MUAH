using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CVRNo { get; set; }

        public Admin(int id, string username, string password, int cvrNo)
        {
            Id = id;
            Username = username;
            Password = password;
            CVRNo = cvrNo;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(CVRNo)}: {CVRNo}";
        }
    }
}
