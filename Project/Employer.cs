using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
     class Nofication
    {
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public Worker Worker { get; set; }
        public Nofication() { }
        public Nofication(string text,Worker worker)
        {
            Text = text;
            Worker = worker;
        }
        public void ShowNotification()
        {
            Console.WriteLine($@"{Text}
                                    Time: {Time}");
        }
    }
    class Vacancy
    {
     public Vacancy() { VacancyId = ++MyId; }
        public Vacancy(string companyName, string speciality, string requirements, string workTime, string age, string city, int salary)
        {
            VacancyId = ++MyId;
            CompanyName = companyName;
            Speciality = speciality;
            Requirements = requirements;
            WorkTime = workTime;
            Age = age;
            City = city;
            Salary = salary;
        }
        public int VacancyId { get; set; }
        static public int MyId { get; set; } = 0;
        public string CompanyName { get; set; }
        public string Speciality { get; set; }
        public string Requirements { get; set; }
        public string WorkTime { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }

        public void ShowVacancy()
        {
            Console.WriteLine($@"
                          [{VacancyId}] {Speciality}



Company: {CompanyName} 
City: {City}
         REQUIREMENTS
{Requirements}

Age: {Age}
         Work Time
{WorkTime}
Salary: {Salary}");
        }

    }
    class Employer
    {
        public Employer() { Id = ++MyId; }
        public Employer(string name, string surname, string phone,string username)
        {
            Id = ++MyId;
            Name = name;
            Surname = surname;
            Phone = phone;
            Username = username;
        }

        public int Id { get; set; }
        static public int MyId { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
        public List<Nofication> Nofications { get; set; } = new List<Nofication>();

        public void AddVacancy(Vacancy vacancy)
        {
            Vacancies.Add(vacancy);
        }
        public void RemoveVacancy(Vacancy v)
        {
            Vacancies.Remove(v);
        }
        public void AddNotification(Nofication nofication)
        {
            Nofications.Add(nofication);
        }
        public void RemoveNotification(Nofication not)
        {            
            Nofications.Remove(not);
        }
        public void Show()
        {
            foreach (var vacancy in Vacancies)
            {
                vacancy.ShowVacancy();
                Console.WriteLine($@"
Relevant person: {Name} {Surname}
Contact: {Phone}
-----------------------------------------------------------------------------------
");
            }
            
        }
        public void ShowNotifications()
        {
            foreach (var notification in Nofications)
            {
                notification.ShowNotification();
            }
        }
    }

}
