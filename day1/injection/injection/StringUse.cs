using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace injection
{
    internal class StringUse
    {
        private IMessenger printer;

        public StringUse(IMessenger printer)
        {
            this.printer = printer;
        }
        public void Send(string message)
        {
            printer.Print(message);
        }

        public void Send(string message, IMessenger localPrinter)
        {
            printer.Print(message);
        }
    }
}
