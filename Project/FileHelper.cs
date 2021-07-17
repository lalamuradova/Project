﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class FileHelper
    {
        public void JsonSerializationCV()
        {
            CV cv = new CV
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
            cv.AddCompany(company1);
            cv.AddLanguage(lang1);
            cv.AddLanguage(lang2);

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("CV.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, cv);
                }
            }
        }
        public void JsonDeserializeCV()
        {
            CV cv = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("CV.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    cv = serializer.Deserialize<CV>(jr);
                }                
                    Console.WriteLine(cv);                
            }

        }

        public void JsonSerializationWorker(List<Worker> workers)
        {      
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("Worker.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, workers);
                }
            }
        }
        public void JsonDeserializeWorker()
        {
            Worker[] workers = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Worker.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    workers = serializer.Deserialize<Worker[]>(jr);
                }
                //add.database
                foreach (var item in workers)
                {
                    item.ShowWorker();
                }
            }

        }

        public void JsonSerializationEmployer(List<Employer> employers)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("Employer.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, employers);
                }
            }
        }
        public void JsonDeserializeEmployer()
        {
            Employer[] employers = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Employer.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employers = serializer.Deserialize<Employer[]>(jr);
                }
                //add.database
                foreach (var item in employers)
                {
                    item.Show();
                }
            }

        }

        public void StreamWriter(string text)
        {
            using (FileStream fs = new FileStream("Log.txt", FileMode.Append,FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                {
                    sw.WriteLine(text);
                }
            }
        }

        public void StreamReader()
        {
            using (var fs = new FileStream("Log.txt", FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fs, Encoding.ASCII))
                {                    
                    var text = sr.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
        }



    }
}