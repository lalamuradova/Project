using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Join
    {
        public Join() { }
        public Join(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        
    }
    class Nofication
    {
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

        public Nofication() { }
        public Nofication(string text)
        {
            Text = text;
        }
        public void ShowNotification()
        {
            Console.WriteLine($@"{Text}
                                    Time: {Time}");
        }
    }
    class Database
    {
        public List<Employer> Employers { get; set; } = new List<Employer>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Join> Users { get; set; } = new List<Join>();
        public List<Nofication> Nofications { get; set; } = new List<Nofication>();
        public Database() { }
        public void AddEmployer(Employer employer)
        {
            Employers.Add(employer);
        }
        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }
        public void AddUser(Join user)
        {
            Users.Add(user);
        }
        public void AddNotification(Nofication nofication)
        {
            Nofications.Add(nofication);
        }
    }
    class Run
    {
        public Database DB { get; set; }
        public Run()
        {
            DB = new Database();
        }



    }
}
