using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPitStop
{
    class Util
    {        
        public static string fileUniqueName()
        {
            return String.Concat(DateTime.Now.ToString("yyyyMMddTHHmmss"), "-", new Random().Next(10000, 99999), "-", new Random().Next(100000, 999999));
        }
    }
}
