using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Run run = new Run();

            try
            {
                run.Creat();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }

    }
}
