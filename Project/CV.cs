using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [Serializable]
    class Company
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public string EndTime { get; set; }
        public Company() { }
        public override string ToString()
        {
            return $@"Company: {Name}  
Start time: {StartTime.Day} / {StartTime.Month} / {StartTime.Year} - End time: {EndTime}
";
        }
    }
    class Language
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public Language() { }
        public override string ToString()
        {
            return $"{Name}   Level: {Level}\n";
        }

    }
    class CV
    {
        public CV() { }
        public CV(string specialty, string university, int admissionScore, string skills, string honorsDiploma, string gITLINK, string lINKEDIN)
        {
            Specialty = specialty;
            University = university;
            AdmissionScore = admissionScore;
            Skills = skills;
            HonorsDiploma = honorsDiploma;
            GITLINK = gITLINK;
            LINKEDIN = lINKEDIN;
        }

        public string Specialty { get; set; }
        public string University { get; set; }
        public int AdmissionScore { get; set; }
        public string Skills { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public string HonorsDiploma { get; set; }
        public string GITLINK { get; set; }
        public string LINKEDIN { get; set; }

        public void AddCompany(Company company)
        {
            Companies.Add(company);
        }
        public void AddLanguage(Language language)
        {
            Languages.Add(language);
        }
        public override string ToString()
        {
           
            if (Companies != null)
            {
                Console.WriteLine("                  <<<<<<<<<<< WORK EXPERIENCE >>>>>>>>>>\n");
                foreach (var item in Companies)
                {
                    Console.WriteLine(item);
                }
            }
            if (Languages != null)
            {
                Console.WriteLine("\n                  <<<<<<<<<<< LANGUAGES >>>>>>>>>>>>>>>\n");
                foreach (var item in Languages)
                {
                    Console.WriteLine(item);
                }
            }
            return $@"
                  <<<<<<<<<<<<< EDUCATION >>>>>>>>>>>>>

University: {University}
Speciality: {Specialty}
Admission Score: {AdmissionScore}
Honors Diploma: {HonorsDiploma}

                  <<<<<<<<<<<<< Skills >>>>>>>>>>>>>>>

{Skills}
                                     
                                                                 Contacts 

                                                           LINKEDIN: {LINKEDIN}
                                                           GITLINK: {GITLINK}";
        }

    }
}
