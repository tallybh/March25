using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace injection
{
    internal class ConsolePrint:IMessenger
    {
        public void Print(string Message) {
            Console.WriteLine(Message);
        }
    }
}
