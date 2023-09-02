using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Srv.Cliente.LogUtility
{
    public interface ILoggerHelper
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message, Exception? ex = null);
    }
}
