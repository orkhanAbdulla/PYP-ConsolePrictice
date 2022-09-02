using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_DelegateTask.Services
{
    public interface ILogger
    {
        void SetLog(string message);
    }
    public class SetLogger : ILogger 
    { 
        public void SetLog(string message) 
        { Console.WriteLine($"SetLogger ---> {message}"); 
        } 
    }


 


}
