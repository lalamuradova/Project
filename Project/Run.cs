using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
   
    class Database
    {
        public List<Employer> Employers { get; set; } = new List<Employer>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Join> Users { get; set; } = new List<Join>();
        public string Username { get; set; }       
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
       
    }
    class Run
    {
        public Database DB { get; set; }
        public FileHelper FH { get; set; }
        public Run()
        {
            DB = new Database();
            FH = new FileHelper();
        }
        public void Creat()
        {
            if((File.Exists("Worker.json")) && (File.Exists("Employer.json"))&& (File.Exists("Join.json")))
            {
                FH.JsonDeserializeWorker(DB);
                FH.JsonDeserializeEmployer(DB);
                FH.JsonDeserializeJoin(DB);
            }            

            Display1();

            FH.JsonSerializationEmployer(DB.Employers);
            FH.JsonSerializationWorker(DB.Workers);
            FH.JsonSerializationJoin(DB.Users);
        }
        public void Display1()
        {
            Console.WriteLine(@"



                                    ----------------------------------------------
                                                   Sign in [1]
                                                   Join in [2]
                                    ----------------------------------------------");

            string c = Console.ReadLine();
            Console.Clear();
            if (c == "1")
            { 
                FH.StreamWriterLogs("User choose sign in");
                Display2Sign();               
            }
            else if (c == "2")
            { 
                FH.StreamWriterLogs("User choose join in");
                Display2Join();               
            }
            else
            {
                FH.StreamWriterLogs("User choose incorrect number");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2...");
                Console.ForegroundColor = ConsoleColor.White;
                Display1();
            }
        }
        public void Display2Sign()
        {
           
            Console.Write(@"


                             Username:");
            string username = Console.ReadLine();
            Console.Clear();
            Console.Write(@"


                             Password:");
            string password = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < DB.Users.Count; i++)
            {            
                if (username == DB.Users[i].Username && password == DB.Users[i].Password) 
                {
                    ++counter;
                }
            }
            
            if (counter == 1) 
            {
                DB.Username = username;
                Console.Clear(); 
                Display3(); 
            }
           else{ Display2();}
        }
        public void Display2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"
 
                              Username or password is not correct 
                              Back    [0]
                              Join in [1]
                              Choose: ");
            Console.ForegroundColor = ConsoleColor.White;
            string ch = Console.ReadLine();
            Console.Clear();
            if (ch == "0")
            {                
                Display2Sign();
            }
            else if (ch == "1") 
            {
                Display2Join();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 0 or 1...");
                Console.ForegroundColor = ConsoleColor.White;
                Display2();
            }
        }
        public void Display2Join()
        {
            Console.Write(@"  
                         
                   
                            Enter Username: ");
            string username = Console.ReadLine();
            
            Console.Clear();
            for (int i = 0; i < DB.Users.Count; i++)
            {
                if (username == DB.Users[i].Username)
                {
                    
                    Console.WriteLine("Username has already been used. Please enter another username...");
                    Display2Join();
                }
            }
            Console.Write(@"  
                         
                   
                            Enter Password: ");
            string password = Console.ReadLine();
            Join j = new Join
            {
                Username = username,
                Password = password
            };
            DB.AddUser(j);
            Console.Clear();
            Console.WriteLine("The registration was successful...");
            Display2Sign();
        }
        public bool ControlEmployer()
        {
            var emp = DB.Employers;
            int count = 0;
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].Username == DB.Username)
                {
                    ++count;
                }
            }
            if (count != 0)
            {
                return true;
            }
            return false;
        }
        public void Display3()
        {
            Console.Write(@"


                                     
                                [1] WORKER
                                [2] Employer
                                [0] Back
                                Choose: ");

            string ch = Console.ReadLine();
            Console.Clear();
            if (ch == "1")
            {
                FH.StreamWriterLogs("User choose Worker.");
                Display3Worker();
            }
            else if (ch == "2")
            {
                FH.StreamWriterLogs("User choose Employer.");
                var emp= ControlEmployer();
                if (emp == false)
                {
                    FH.StreamWriterLogs("The employer entered the latest information.");
                    CreatEmployer();
                }
                Display3Employer();
            }
            else if (ch == "0")
            {
                Display1();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2...");
                Console.ForegroundColor = ConsoleColor.White;
                Display3();
            }
        }
        public void Display3Worker()
        {
            Console.WriteLine("[1] Show vacansy ");
            Console.WriteLine("[2] Filter search");
            Console.WriteLine("[0] Back");
            Console.Write("Choose: ");
            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "1")
            {
                FH.StreamWriterLogs("The worker looked at the vacancies");
                ShowVacansy();
                WorkerChoise();
            }
            else if (ch == "2")
            {
                FH.StreamWriterLogs("The worker searched at the vacancies");
                Search();
                WorkerChoise();
            }
            else if (ch == "0")
            {
                FH.StreamWriterLogs("The worker choosed back");
                Display3();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2 or 0...");
                Console.ForegroundColor = ConsoleColor.White;
                Display3Worker();
            }

        }
        public void WorkerChoise()
        {
            Console.WriteLine("Back [0]");
            Console.WriteLine("Apply for a vacancy (Id)  ");
            Console.Write("Choose Id or 0: ");
            string ch = Console.ReadLine();
            int choise = int.Parse(ch);
            Console.Clear();

            if (choise == 0)
            {
                Display3Worker();
            }
            else
            {
                FH.StreamWriterLogs("Worker applied for the vacancy");
                ApplyVacansy(choise);
            }
        }       
        public void ApplyVacansy(int id)
        {
            var e = DB.Employers;
            int counter = 0;
            for (int i = 0; i < e.Count; i++)
            {
                var vacansy = e[i].Vacancies;
                for (int k = 0; k < vacansy.Count; k++)
                {
                    if (vacansy[k].VacancyId == id)
                    {                       
                        ++counter;
                        Apply(vacansy[k],e[i]);
                    }
                }
               
            }
            if (counter == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id is not found...");
                Console.ForegroundColor = ConsoleColor.White;
                Display3Worker();
            }
        }
        public void Apply(Vacancy vacancy, Employer employer)
        {          

            Console.WriteLine("Write your information for the apply.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Age: ");
            string a = Console.ReadLine();
            int age = int.Parse(a);
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Worker worker = new Worker
            {
                Name = name,
                Surname = surname,
                City = city,
                Phone = phone,
                Age = age,
                Email = email
            };
            DB.AddWorker(worker);
            
            string t = vacancy.Speciality;
            string text = "You have an application for " + t;
            Nofication nofication = new Nofication
            {
                Text =text,
                Worker=worker
            };
            employer.AddNotification(nofication);
              FH.StreamWriterLogs("The notification is gone.");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your application has been accepted. Thanks...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Back [0] : ");
            string c = Console.ReadLine();
            if (c == "0")
            {
                Display3Worker();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 0...");
                Console.ForegroundColor = ConsoleColor.White;
                Apply(vacancy,employer);
            }

        }
        public void Display3Employer()
        {
            Console.WriteLine("[1] Show All Vacansy ");
            Console.WriteLine("[2] Show your Vacansy ");
            Console.WriteLine("[3] Creat Vacansy ");
            Console.WriteLine("[4] Search Vacansy");
            Console.WriteLine("[5] Show Notifications");
            Console.WriteLine("[0] Back");

            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "1")
            {
                FH.StreamWriterLogs("Employer looked at vacancies");
                ShowVacansy();
                Back3();
            }
            else if (ch == "2")
            {
                FH.StreamWriterLogs("Employer looked at vacancies of yours shared");
                ShowYourVacansy();
            }
            else if (ch == "3")
            {
                FH.StreamWriterLogs("Employer created vacancies");
                CreatVacansy();
            }
            else if (ch == "4")
            {
                FH.StreamWriterLogs("Employer searched at vacancies");
                Search2();
            }
            else if (ch == "5")
            {
                FH.StreamWriterLogs("Employer looked at notifications");
                ShowNotification();
            }
            else if (ch == "0")
            {
                Display3();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2...");
                Console.ForegroundColor = ConsoleColor.White;
                Display3Employer();
            }
        }
        
        public void CreatEmployer()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Employer employer = new Employer
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Username = DB.Username
            };
            Console.Clear();
        }
        public void ShowNotification()
        {
            int counter = 0;
            var emp = DB.Employers;
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].Username == DB.Username)
                {
                    var not = emp[i].Nofications;
                    for (int k = 0; k < not.Count; k++)
                    {
                        Console.Write($"[{k+1}] ");
                        emp[i].ShowNotifications();
                        Console.WriteLine("\n");
                    }
                    Console.Write("Choose: ");
                    string ch = Console.ReadLine();
                    int index = int.Parse(ch);
                    Console.Clear();
                    var worker = emp[i].Nofications[index - 1].Worker;
                    worker.ShowWorker();
                    var email = worker.Email;
                    FH.StreamWriterLogs("Employer choosed at notification");
                    ChoiseNotification(email);
                    ++counter;
                }
            }
            if (counter != 0)
            {
                Back3();
            }


        }
        public void ShowCv()
        {
            FH.StreamWriterLogs("Employer looked at CV");
            Console.Clear();
            Console.WriteLine("Show CV [1]");
            Console.WriteLine("Back    [0]");
            string ch = Console.ReadLine();
            Console.Clear();
            if (ch == "1")
            {
                FH.JsonDeserializeCV();
            }
            else if (ch == "0")
            {
                Display3Employer();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 0...");
                Console.ForegroundColor = ConsoleColor.White;
                ShowCv();
            }
        }
        public void ChoiseNotification(string mail)
        {
            ShowCv();
            Console.WriteLine("[1]  Accepted");
            Console.WriteLine("[2] Not Accepted");
            Console.WriteLine("Choose: ");
            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "1")
            {
                FH.StreamWriterLogs("The Employer accepted the Worker's application");
                SendMail(mail);
                FH.StreamWriterLogs("Mail sent for Worker");
                Console.Write("Back [0] : ");
                string c = Console.ReadLine();
                if (c == "0")
                {
                    Display3Employer();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect entered. Please choose 0...");
                    Console.ForegroundColor = ConsoleColor.White;
                    ChoiseNotification(mail);
                }
            }
            else if (ch == "2")
            {
                FH.StreamWriterLogs("The Employer not accepted the Worker's application");
                Display3Employer();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2...");
                Console.ForegroundColor = ConsoleColor.White;
                ShowNotification();
            }
        }
        public void CreatVacansy()
        {
            Console.Clear();
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Speciality: ");
            string speciality = Console.ReadLine();
            Console.Write("Requirements: ");
            string requirements = Console.ReadLine();
            Console.Write("WorkTime: ");
            string workTime = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Salary: ");
            string s = Console.ReadLine();
            int salary = int.Parse(s);

            Vacancy vacancy = new Vacancy
            {

                CompanyName = companyName,
                Speciality = speciality,
                Requirements = requirements,
                WorkTime = workTime,
                Age = age,
                City = city,
                Salary = salary
            };

            var emp = DB.Employers;
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].Username == DB.Username)
                {
                    emp[i].AddVacancy(vacancy);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The vacancy was successfully placed...");
            Console.ForegroundColor = ConsoleColor.White;
            Back3();
        }
        public void SendMail(string mail)
        {           

            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            client.Credentials = new NetworkCredential("lalamuradova2021@outlook.com", "lala1995");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            message.To.Add(mail);
            message.From = new MailAddress("lalamuradova2021@outlook.com", "Is elani");
            message.Subject = "Is elani";
            message.Body = "Tebrikler muracietiniz testiqlendi. Sabah 09:00-da interview ucun gelmeyiniz xais olunur." ;
            client.Send(message);
            Console.Clear();
            Console.WriteLine("Email sent\n");            

        }
        public void ShowYourVacansy()
        {
            var emp = DB.Employers;
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].Username == DB.Username)
                {
                    emp[i].Show();
                }
            }
            Back3();
        }
        public void ShowVacansy()
        {
            var e = DB.Employers;
            for (int i = 0; i < e.Count; i++)
            {
                e[i].Show();
            }

        }
        public void Search()
        {            
            Console.WriteLine("[1] Search by Salary");
            Console.WriteLine("[2] Search by City");
            Console.WriteLine("[3] Search by Company name");
            Console.WriteLine("[0] Back");            
            Console.Write("Choose: ");
            string ch = Console.ReadLine();
            List<Vacancy> vacancies = new List<Vacancy>();

            for (int i = 0; i < DB.Employers.Count; i++)
            {
                for (int k = 0; k < DB.Employers[i].Vacancies.Count; k++)
                {
                    vacancies.Add(DB.Employers[i].Vacancies[k]);
                }               
            }
            Console.Clear();

            if (ch == "1")
            {
                
                Console.Write("Enter salary: ");
                string s = Console.ReadLine();
                int salary = int.Parse(s);
                if(salary>0 && salary <= 10000)
                {
                    var list = vacancies.Where(d => d.Salary >= salary);
                    if (list == null)
                    {
                        foreach (var item in list)
                        {
                            item.ShowVacancy();
                        }
                        Search();
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                        Back();
                    }
                }
                else
                {
                    throw new Exception("Salary must be number...");
                }
                
            }
            else if (ch == "2")
            {
                Console.Write("Enter city: ");
                string city = Console.ReadLine();                

                var list = vacancies.Where(d => d.City.Contains(city));                
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.ShowVacancy();
                    }
                    Search();
                }
                else
                {
                    Console.WriteLine("Not found");
                    Back();
                }
            }
            else if (ch == "3")
            {
                Console.Write("Enter Company name: ");
                string name = Console.ReadLine();

                var list = vacancies.FindAll(v => v.CompanyName.Contains(name));
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.ShowVacancy();
                    }
                    Search();
                }
                else
                {
                    Console.WriteLine("Not found");
                    Back();
                }
            }
            else if(ch == "0")
            {
                Display3Worker();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered...");
                Console.ForegroundColor = ConsoleColor.White;
                Search();
            }
        }
        public void Search2()
        {
            Console.WriteLine("[1] Search by Salary");
            Console.WriteLine("[2] Search by City");
            Console.WriteLine("[3] Search by Company name");
            Console.WriteLine("[0] Back");
            Console.Write("Choose: ");
            string ch = Console.ReadLine();
            List<Vacancy> vacancies = new List<Vacancy>();

            for (int i = 0; i < DB.Employers.Count; i++)
            {
                for (int k = 0; k < DB.Employers[i].Vacancies.Count; k++)
                {
                    vacancies.Add(DB.Employers[i].Vacancies[k]);
                }
            }
            Console.Clear();

            if (ch == "1")
            {

                Console.Write("Enter salary: ");
                string s = Console.ReadLine();
                int salary = int.Parse(s);
                if (salary > 0 && salary <= 10000)
                {
                    var list = vacancies.Where(d => d.Salary >= salary);
                    if (list == null)
                    {
                        foreach (var item in list)
                        {
                            item.ShowVacancy();
                        }
                        Search2();
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                        Back2();
                    }
                }
                else
                {
                    throw new Exception("Salary must be number...");
                }

            }
            else if (ch == "2")
            {
                Console.Write("Enter city: ");
                string city = Console.ReadLine();

                var list = vacancies.Where(d => d.City.Contains(city));
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.ShowVacancy();
                    }
                    Search2();
                }
                else
                {
                    Console.WriteLine("Not found");
                    Back2();
                }
            }
            else if (ch == "3")
            {
                Console.Write("Enter Company name: ");
                string name = Console.ReadLine();

                var list = vacancies.FindAll(v => v.CompanyName.Contains(name));
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        item.ShowVacancy();
                    }
                    Search2();
                }
                else
                {
                    Console.WriteLine("Not found");
                    Back2();
                }
            }
            else if (ch == "0")
            {
                Display3Employer();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered...");
                Console.ForegroundColor = ConsoleColor.White;
                Search2();
            }
        }
        public void Back2()
        {
            Console.WriteLine("[0] Back");

            string ch = Console.ReadLine();
            if (ch == "0")
            {
                Display3Employer();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 0...");
                Console.ForegroundColor = ConsoleColor.White;
                Search2();
            }
        }
        public void Back3()
        {
            Console.WriteLine("[0] Back");

            string c = Console.ReadLine();
            Console.Clear();
            if (c == "0")
            {
                Display3Employer();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 1 or 2...");
                Console.ForegroundColor = ConsoleColor.White;
                Display3Employer();
            }
        }
        public void BackEmp()
        {
            Console.WriteLine("[0] Back");

            string ch = Console.ReadLine();
            if (ch == "0")
            {
                Display3Employer();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 0...");
                Console.ForegroundColor = ConsoleColor.White;
                ShowVacansy();
            }
        }
        public void Back()
        {

            Console.Write("Back [0] : ");
            string ch = Console.ReadLine();
            if (ch == "0")
            {
                Search();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect entered. Please choose 0...");
                Console.ForegroundColor = ConsoleColor.White;
                Search();
            }
        }

    }
}
