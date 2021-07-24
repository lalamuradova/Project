using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class EmailFormatException:Exception
    {
        public override string Message
        {
            get
            {
                return "Email cannot be written in this form";
            }
        }
    }
    class NumberException : Exception
    {
        public override string Message
        {
            get
            {
                return "a negative number or letter cannot be written";
            }
        }
    }

}
