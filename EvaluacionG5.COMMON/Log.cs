using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EvaluacionG5.COMMON
{
    public class Log
    {
        string fileName;
        // si pasamos la ruta de un archivo, su utilizará ese para hacer el log
        public Log(string file)
        {
            fileName = file;
        }

        // caso contrario se utiliza uno por defecto
        public Log()
        {

            fileName = System.AppDomain.CurrentDomain.BaseDirectory + "/log/log.txt";
        }
        public void EscribirLog(string logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine(DateTime.Now.ToString() + " - " + logText);
                }
            }
            catch { }
        }
        public void EscribirLog(Exception ex)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.WriteLine("--------------------------------------------------------------------------------");
                    w.WriteLine(DateTime.Now.ToString() + " - EXCEPCION");
                    w.WriteLine("Message: " + ex.Message);
                    w.WriteLine("Source: " + ex.Source);
                    w.WriteLine("TargetSite: " + ex.TargetSite);
                    w.WriteLine("StackTrace: ");
                    w.WriteLine(ex.StackTrace);
                    w.WriteLine("InnerException: " + ex.InnerException);
                    w.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
