using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wakeUp.Service
{
    internal class Util
    {
        private static object _logLock = new object();
        
        public static void WriteLogFile(Exception exception)
        {
            try
            {
                lock (_logLock)
                {
                    string error = DateTime.Now.ToString("yyyyMMddHHmmss\n");
                    error += exception.Message + "\n";
                    error += exception;

                    if (!Directory.Exists("log"))
                    {
                        Directory.CreateDirectory("log");
                    }

                    StreamWriter writer = File.CreateText("log/" + DateTime.Now.ToString("yyyyMMdd") + ".log");
                    writer.WriteLine(error);
                    writer.Close();
                }
            } 
            catch(Exception e)
            {
                
            }
        }
    }
}
