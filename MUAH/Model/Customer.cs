using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class Customer
    {
        //Things being checked during login
        public string PhoneNo { get; set; }
        public string Password { get; set; }

        //Things used to create an account
        public string CustomerName { get; set; }
        public int Id { get; set; }

        public Customer(string phoneNo, string password, string customerName, int id)
        {
            PhoneNo = phoneNo;
            Password = password;
            CustomerName = customerName;
            Id = id;
        }

        public override string ToString()
        {
            return $"{nameof(PhoneNo)}: {PhoneNo}, {nameof(Password)}: {Password}, {nameof(CustomerName)}: {CustomerName}, {nameof(Id)}: {Id}";
        }
    }
}
