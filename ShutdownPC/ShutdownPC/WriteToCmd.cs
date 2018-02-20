using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShutdownPC
{
    class WriteToCmd
    {
        private int hour { get; set; }
        private int min { get; set; }

        private System.Diagnostics.Process process = new System.Diagnostics.Process();
        private System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        public WriteToCmd() { }

        public WriteToCmd(string message)
        {
            WriteFile(message);
        }

        public WriteToCmd(int hour, int min, string message)
        {
            this.hour = hour;
            this.min = min;
            int result = ((60 * 60) * hour) + (60 * min);
            sentCommand(result);
            WriteFile(message);
        }

        private void sentCommand(int time)
        {
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C shutdown -s -t " + time.ToString();
            process.StartInfo = startInfo;
            process.Start();
        }

        public void disconnectommand()
        {
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C shutdown -a";
            process.StartInfo = startInfo;
            process.Start();
        }

        public void WriteFile(string message)
        {
            using (StreamWriter fileStream = File.AppendText("LogFile.txt"))
            {
                fileStream.WriteLine(message);
            }
        }

        public string ReadFile()
        {
            string message = "";
            using (StreamReader r = File.OpenText("LogFile.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {       
                        message += Environment.NewLine + line; 
                }
                return message;
            }
        }
    }
}
