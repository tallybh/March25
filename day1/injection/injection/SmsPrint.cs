using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace injection
{
    internal class SmsPrint : IMessenger
    {
        public void Print(string message)
        {
            Console.WriteLine(message + " in sms");
        }
    }
}
