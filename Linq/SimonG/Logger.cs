using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Logger
    {
        private Action<string> logMethods;

        public void AddLogMethod(Action<string> method)
        {
            logMethods += method;
        }

        public void Log(string message)
        {
            logMethods?.Invoke(DateTime.Now.ToString() + ": " + message); // if Invoke != null, than call delegate (logMethods)
        }
    }
}
