﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class Customer
    {
        /// <summary>
        /// PhoneNo og password er de properties kunden skal bruge for at logge ind, hvorimod en ny kunde skal bruge alle 4 properties.
        /// Alle properties skal konverteres til en streng, hvorfor vi bruger ToString metoden.
        /// </summary>

        public string PhoneNo { get; set; }
        public string Password { get; set; }

        //Things used to create an account
        public string Name { get; set; }
        public int Id { get; set; }

        public Customer(string phoneNo, string password, string name, int id)
        {
            PhoneNo = phoneNo;
            Password = password;
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return $"{nameof(PhoneNo)}: {PhoneNo}, {nameof(Password)}: {Password}, {nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }
}
