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

                    File.AppendAllText("log/" + DateTime.Now.ToString("yyyyMMdd") + ".log", error);
                }
            } 
            catch(Exception e)
            {
                
            }
        }

        public static void WriteLogFile(string message)
        {
            try
            {
                lock (_logLock)
                {
                    string error = DateTime.Now.ToString("\n\n[yyyy.MM.dd HH:mm:ss] : ");
                    error += message;

                    if (!Directory.Exists("log"))
                    {
                        Directory.CreateDirectory("log");
                    }

                    File.AppendAllText("log/" + DateTime.Now.ToString("yyyyMMdd") + ".log", error);
                }
            }
            catch (Exception e)
            {

            }
        }

        public static bool IsWeekend(DateTime date)
        {
            // DateTime.DayOfWeek를 사용하여 요일을 체크합니다.
            // Saturday = 토요일, Sunday = 일요일
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsSaturday(DateTime date)
        {
            // DateTime.DayOfWeek를 사용하여 요일을 체크합니다.
            // Saturday = 토요일, Sunday = 일요일
            return date.DayOfWeek == DayOfWeek.Saturday;
        }

        public static bool IsSunday(DateTime date)
        {
            // DateTime.DayOfWeek를 사용하여 요일을 체크합니다.
            // Saturday = 토요일, Sunday = 일요일
            return date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
