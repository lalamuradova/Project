using Newtonsoft.Json;
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
        public void JsonSerializationCV(List<CV>CVs)
        {          

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("CV.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, CVs);
                }
            }
        }
        public void JsonDeserializeCV(Database db)
        {
            List<CV> cvs = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("CV.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    cvs = serializer.Deserialize<List<CV>>(jr);
                }
                foreach (var cv in cvs)
                {
                    db.AddCV(cv);
                }                
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
        public void JsonDeserializeWorker(Database db)
        {
           List<Worker> workers = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Worker.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    workers = serializer.Deserialize<List<Worker>>(jr);
                }
                foreach (var worker in workers)
                {
                    db.AddWorker(worker);
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
        public void JsonDeserializeEmployer(Database db)
        {
            List<Employer> employers = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Employer.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    employers = serializer.Deserialize<List<Employer>>(jr);
                }
                
                foreach (var employer in employers)
                {
                    db.AddEmployer(employer);
                }
            }

        }

        public void JsonSerializationJoin(List<Join> users)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("Join.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, users);
                }
            }
        }
        public void JsonDeserializeJoin(Database db)
        {
            List<Join> users = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Join.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<List<Join>>(jr);
                }
                
                foreach (var user in users)
                {
                    db.AddUser(user);
                }
            }

        }

        public void StreamWriterLogs(string text)
        {
            using (FileStream fs = new FileStream("Log.txt", FileMode.Append,FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                {
                    sw.WriteLine(text);
                }
            }
        }
        public void StreamReaderLogs()
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
