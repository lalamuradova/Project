using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
        public List<CV> CVs { get; set; } = new List<CV>();

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
        public void AddCV(CV cv)
        {
            CVs.Add(cv);
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
            if (File.Exists("Worker.json"))
            {
                FH.JsonDeserializeWorker(DB);
            }
            if (File.Exists("Employer.json"))
            {
                FH.JsonDeserializeEmployer(DB);
            }
            if (File.Exists("Join.json"))
            {            
                FH.JsonDeserializeJoin(DB);
            }
            if (File.Exists("CV.json"))
            {
                FH.JsonDeserializeCV(DB);
            }
            else
            {
                CV cv1 = new CV
                {
                    Specialty = "Komputer Elmleri",
                    University = "Azerbaycan Dovlet Neft ve Senaye Universiteti",
                    AdmissionScore = 470,
                    Skills = "C++ , C#",
                    HonorsDiploma = "Yox",
                    GITLINK = "https://github.com/lalamuradova",
                    LINKEDIN = "https://www.linkedin.com/in/lala-mamedova-253579217/"
                };
                Language lang1 = new Language
                {
                    Name = "Ingilis dili",
                    Level = "Orta"
                };
                Language lang2 = new Language
                {
                    Name = "Rus dili",
                    Level = "Baslangic"
                };
                Company company1 = new Company
                {
                    Name = "Azerbaijan Milli Elmler Akademiyasi",
                    StartTime = new DateTime(2015, 3, 1),
                    EndTime = "Davam edir"
                };
                cv1.AddCompany(company1);
                cv1.AddLanguage(lang1);
                cv1.AddLanguage(lang2);

                CV cv2 = new CV
                {
                    Specialty = "Komputer Muhendisliyi",
                    University = "Azerbaycan Dovlet Neft ve Senaye Universiteti",
                    AdmissionScore = 650,
                    Skills = "C++ , C#, Java",
                    HonorsDiploma = "Yox",
                    GITLINK = "https://github.com/lalamuradova",
                    LINKEDIN = "https://www.linkedin.com/in/lala-mamedova-253579217/"
                };
                
                Language lang = new Language
                {
                    Name = "Rus dili",
                    Level = "Baslangic"
                };
                Company company2 = new Company
                {
                    Name = "Azerbaijan Milli Elmler Akademiyasi",
                    StartTime = new DateTime(2015, 3, 1),
                    EndTime = "Davam edir"
                };
                cv2.AddCompany(company2);
                cv2.AddLanguage(lang);

                DB.AddCV(cv1);
                DB.AddCV(cv2);

                List<CV> cvs = new List<CV>();
                cvs.Add(cv1);
                cvs.Add(cv2);
                FH.JsonSerializationCV(cvs);

                Worker worker = new Worker()
                {
                    Name = "Lala",
                    Surname = "Muradova",
                    City = "Baki",
                    Phone = "0779876543",
                    Age = 26,
                    Email = "lalamuradova2017@gmail.com",
                    Username= "Worker",
                    cv =cv1
                };
                Worker worker2 = new Worker()
                {
                    Name = "Nura",
                    Surname = "Cabbarova",
                    City = "Baki",
                    Phone = "0223334445",
                    Age = 21,
                    Email = "Nura@gmail.com",
                    Username= "Worker",
                    cv = cv2
                };
                List<Worker> workers = new List<Worker>();
                workers.Add(worker);
                workers.Add(worker2);
                
                DB.AddWorker(worker);
                DB.AddWorker(worker2);
                FH.JsonSerializationWorker(workers);

                Vacancy vacancy1 = new Vacancy
                {
                    CompanyName = "Qscepter LLC",
                    Speciality = "FULL STACK PHP PROQRAMCI",
                    Requirements = "- Proqramlaşdırma uzre en azı +5 il is tecrubesi olan - MySQL,JSON,Git,Linux",
                    WorkTime = "Bazar ertesi-Cume (10:00-dan 18:00-dək) - Senbe(10:00 - dan 13:00 - dek) ",
                    Age = "24 - 40",
                    City = "Baki",
                    Salary = 1200
                };
                Vacancy vacancy2 = new Vacancy
                {
                    CompanyName = "İrşad",
                    Speciality = "SAYT UZRE MUTEXESSİS",
                    Requirements = "30-yaşa kimi bey namizedler ,İs tecrubesi - 2 il, Photoshop proqrami uzre mukemmel bilik ",
                    WorkTime = "Bazar ertesi - Senbe(10:00 - dan 19:00 - dek) ",
                    Age = "23 - 30",
                    City = "Baki",
                    Salary = 500
                };
                Vacancy vacancy3 = new Vacancy
                {
                    CompanyName = "Miner AZ",
                    Speciality = "LİSP PROQRAMCI",
                    Requirements = "Java / Python guclu alqoritmik bacariqlari, Menbeli ve ya ticaret Lisp layihelerinde istirak ",
                    WorkTime = "Bazar ertesi - Senbe(09:00 - dan 18:00 - dek) ",
                    Age = "20 - 36",
                    City = "Baki",
                    Salary = 5000
                };
                Join join1 = new Join
                {
                    Username = "Worker",
                    Password = "worker1234"
                };
                Join join2 = new Join
                {
                    Username = "Admin",
                    Password = "adminadmin"
                };
                DB.AddUser(join2);
                DB.AddUser(join1);
                List<Join> joins = new List<Join>();
                joins.Add(join1);
                joins.Add(join2);
                FH.JsonSerializationJoin(joins);

                Employer employer = new Employer
                {
                    Name = "Nermin",
                    Surname = "Hesenzade",
                    Phone = "1234567",
                    Username = join1.Username
                };
                employer.AddVacancy(vacancy1);
                employer.AddVacancy(vacancy2);


                Employer employer2 = new Employer
                {
                    Name = "Aynur",
                    Surname = "Novruzova",
                    Phone = "0987654321",
                    Username = join2.Username
                };
                employer2.AddVacancy(vacancy3);

                DB.AddEmployer(employer);
                DB.AddEmployer(employer2);

                List<Employer> employers = new List<Employer>();
                employers.Add(employer);
                employers.Add(employer2);

                FH.JsonSerializationEmployer(employers);

            }

            Display1();
           
        }
        public void Display1()
        {
            Console.WriteLine(@"



                                    ----------------------------------------------
                                                   Sign in [1]
                                                   Sign up [2]
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
                FH.StreamWriterLogs("User choose sign up");
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
                              Sign up [1]
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
            if (username.Length < 4) 
            {
                Console.Clear();
                Console.WriteLine("Username must be more than 4 characters...");
                Display2Join();
            }
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
            if (password.Length < 4)
            {
                Console.Clear();
                Console.WriteLine("Password must be more than 4 characters...");
                Display2Join();
            }
            Join j = new Join
            {
                Username = username,
                Password = password
            };
            DB.AddUser(j);            
            FH.JsonSerializationJoin(DB.Users);
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
        public bool ControlWorker()
        {
            var worker = DB.Workers;
            int count = 0;
            for (int i = 0; i < worker.Count; i++)
            {
                if (worker[i].Username == DB.Username)
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
                var w = ControlWorker();
                if (w == false)
                {
                    FH.StreamWriterLogs("The worker entered the latest information.");
                    CreatWorker();
                }
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
            Console.Write("Choose Id or Back(0) : ");
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
        public void CreatWorker()
        {
            Console.WriteLine("Write your information for the apply.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            if (name.Length < 4 || surname.Length < 4 || city.Length < 4) 
            {
                Console.Clear();
                Console.WriteLine("Name, surname and city must be more than 4 characters...");
                CreatWorker();
            }
            
            Console.Write("Age: ");
            string a = Console.ReadLine();
            int age = 0;
            try
            {
                 age = int.Parse(a);
            }
            catch (FormatException)
            {
                Console.WriteLine("Cannot be letter");
                Console.Write("Age: ");
                string ag = Console.ReadLine();
                age = int.Parse(ag);
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();

            try
            {                
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (!match.Success)
                {
                    throw new EmailFormatException();
                }                
            }
            catch (EmailFormatException text)
            {
                Console.WriteLine(text.Message);
            }
            

            var Cv = CreatCv();
            Worker worker = new Worker
            {
                Name = name,
                Surname = surname,
                City = city,
                Phone = "055-788-88-88",
                Age = age,
                Email = email,
                Username = DB.Username,
                cv = Cv
            };
            
            DB.AddWorker(worker);
            FH.JsonSerializationWorker(DB.Workers);

            Console.Clear();
        }
        public CV CreatCv()
        {
            Console.Write("Speciality: ");
            string speciality = Console.ReadLine();
            Console.Write("University: ");
            string university = Console.ReadLine();
            Console.Write("AdmissionScore: ");
            string s = Console.ReadLine();         
            
            int score = 0;
            try
            {
                score = int.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Cannot be letter");
                Console.Write("Score: ");
                string sc = Console.ReadLine();
                score = int.Parse(sc);
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
            }

            Console.Write("Skills: ");
            string skills = Console.ReadLine();           

            CV cv = new CV
            {
                Specialty = speciality,
                University = university,
                AdmissionScore = score,
                Skills = skills,
                GITLINK = "https://github.com/huiu",
                LINKEDIN = "https://www.linkedin.com/in/k-mjiii-253579217/"
            };
            string lang = string.Empty;
            string level = string.Empty;
            int counter = 0;
            while (counter<3)
            {
                Console.Write(@"Language:
[1] English   [2] Russian  [3] Italian
Choose: ");
                 lang = Console.ReadLine();

                Console.Write(@"Level:
[1] Begginer  [2] Intermediate [3] Professional
Choose:");
                level = Console.ReadLine();

                Console.Write("Add in another language (yes) or (no): ");
                string add = Console.ReadLine();
                if (add == "yes")
                {
                    ++counter;
                }
                else
                {
                    counter = 4;
                }
            }
            
            if (lang == "1")
            {
                lang = "English";
                if (level == "1")
                {
                    level = "Beginner";

                }
                else if (level == "2")
                {
                    level = "Intermediate";
                }
                else if (level == "3")
                {
                    level = "Professional";
                }
                Language lang1 = new Language
                {
                    Name = lang,
                    Level = level
                };
                cv.AddLanguage(lang1);
            }
            else if (lang == "2")
            {
                lang = "Russian";
                
                if (level == "1")
                {
                    level = "Beginner";

                }
                else if (level == "2")
                {
                    level = "Intermediate";
                }
                else if (level == "3")
                {
                    level = "Professional";
                }
                Language lang1 = new Language
                {
                    Name = lang,
                    Level = level
                };

                cv.AddLanguage(lang1);
            }
            else if (lang == "3")
            {
                lang = "Italian";
                
                if (level == "1")
                {
                    level = "Beginner";

                }
                else if (level == "2")
                {
                    level = "Intermediate";
                }
                else if (level == "3")
                {
                    level = "Professional";
                }
                Language lang1 = new Language
                {
                    Name = lang,
                    Level = level
                };

                cv.AddLanguage(lang1);
            }
            else
            {

            }

            Console.Write("Company name: ");
            string name = Console.ReadLine();
            Company company1 = new Company
            {
                Name = name,
                StartTime = new DateTime(2015, 3, 1),
                EndTime = "Davam edir"
            };
            cv.AddCompany(company1);

            DB.AddCV(cv);
            FH.JsonSerializationCV(DB.CVs);
            return cv;
        }
        public void Apply(Vacancy vacancy, Employer employer)
        {
            var w = DB.Workers;
            Worker worker = new Worker();
            for (int i = 0; i < w.Count; i++)
            {
                if (w[i].Username == DB.Username)
                {
                    worker = w[i];
                }
            }

            string t = vacancy.Speciality;
            string text = "You have an application for " + t;
            Nofication nofication = new Nofication
            {
                Text =text,
                Worker=worker
            };
            employer.AddNotification(nofication);
            FH.JsonSerializationEmployer(DB.Employers);
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
            DB.AddEmployer(employer);
            FH.JsonSerializationEmployer(DB.Employers);
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
        public void ChoiseNotification(string mail)
        {            
            Console.WriteLine("[1]  Accepted");
            Console.WriteLine("[2] Not Accepted");
            Console.WriteLine("Choose: ");
            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "1")
            {
                FH.StreamWriterLogs("The Employer accepted the Worker's application");
                try
                {
                    SendMail(mail);
                }
                catch (SmtpException)
                {
                    Console.WriteLine("There is a problem with the connection");                   
                }

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
            Console.Write(@"WorkTime: 
[1] 09:00 - 18:00
[2] 10:00 - 19:00
[3] 09:00 - 14:00
choose: ");
            string ch = Console.ReadLine();
            string workTime = string.Empty;
            if (ch == "1")
            {
                workTime = "09:00 - 18:00-dek";
            }
            else if (ch == "2")
            {
                workTime = "10:00 - 19:00-dek";
            }
            else if (ch == "3")
            {
                workTime = "09:00 - 14:00-dek";
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect entered");
                CreatVacansy();
            }
            Console.Write("Age: ");
            string age = Console.ReadLine();
            int a = 0;
            try
            {
                a = int.Parse(age);
            }
            catch (FormatException)
            {
                Console.WriteLine("age cannot be letter");
                Console.Write("Age: ");
                age = Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
            }
            Console.Write(@"City: 
[1] Baki
[2] Sumqayit
[3] Ganca
choose: ");
            string chc = Console.ReadLine();
            string city = string.Empty;
            if (ch == "1")
            {
                workTime = "Baki";
            }
            else if (ch == "2")
            {
                workTime = "Sumqayit";
            }
            else if (ch == "3")
            {
                workTime = "Ganca";
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect entered");
                CreatVacansy();
            }
            Console.Write("Salary: ");
            string s = Console.ReadLine();
            int salary = 0;
            
            try
            {
                salary = int.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Salary cannot be letter");
                Console.Write("Salary: ");
                 s = Console.ReadLine();
                salary = int.Parse(s);
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Unexpected error:  { exception.Message }");
            }
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
                    FH.JsonSerializationEmployer(DB.Employers);
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
