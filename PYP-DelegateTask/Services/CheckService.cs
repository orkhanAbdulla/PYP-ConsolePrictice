using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_DelegateTask.Services
{
    public static class CheckService
    {
        public static bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            return true;  
        }
        public static bool PasswordCheck(string password)
        {
            Regex regex = new Regex(@"^[A-Z]{1,}[a-z]{2,}\d*$");
            Match match = regex.Match(password.ToString());
            if (!match.Success)
                return false;
            return true;
        }
     
    }
}
