using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement
{
    public static class Util
    {
        public static void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public static void Log(Exception ex)
        {
            if (ex == null)
                return;
            Util.Log(ex.Message);
            Log(ex.InnerException);
        }
    }
}