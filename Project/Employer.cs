using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
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
                             {Speciality}

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
        public Employer(string name, string surname, string phone)
        {
            Id = ++MyId;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public int Id { get; set; }
        static public int MyId { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

        public void AddVacancy(Vacancy vacancy)
        {
            Vacancies.Add(vacancy);
        }
        public void RemoveVacancy(Vacancy v)
        {
            Vacancies.Remove(v);
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
    }
}
