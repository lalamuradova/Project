using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Worker
    {
        public Worker() { Id = ++MyId; }
        public Worker(string name, string surname, string city, string phone, int age, string email)
        {
            Id = ++MyId;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
            Email = email;
        }

        public int Id { get; set; }
        static public int MyId { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        
        public void ShowWorker()
        {
            Console.WriteLine($@"Fullname: {Name} {Surname}
City: {City}
Age: {Age}
Email: {Email}

");
        }

    }
}
