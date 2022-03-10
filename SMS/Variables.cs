using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{ 
    class Variables
    {
        //Class For Global Variables And Functions
        private string _adbPath = @"C:\Users\Win\Desktop\sdk\platform-tools\"; 
        private string _savedNumbersPath = @"savedNumbers.txt";
        public static string _imeiBatPath = @"getimei.bat";
        string _imeisTxtPath = @"imeis.txt";
        public string _savedDevicesPath = @"devices.txt";
        //Variables
        public string adbPath
        {
            get
            {
                return _adbPath;
            }
        }
        public string imeiBatPath
        {
            get
            {
                return _imeiBatPath;
            }
        }
        public string imeisTxtPath
        {
            get
            {
                return _imeisTxtPath;
            }
        }
        public string savedDevicesPath
        {
            get
            {
                return _savedDevicesPath;
            }
        }
        public string savedNumbersPath
        {
            get
            {
                return _savedNumbersPath;
            }
        }
        //Variables

        //Functions
        public void DeleteBlankLinesFromTxt(string file)
        {
            var tempFileName = Path.GetTempFileName();
            try
            {
                using (var streamReader = new StreamReader(file))
                using (var streamWriter = new StreamWriter(tempFileName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            streamWriter.WriteLine(line);
                    }
                }
                File.Copy(tempFileName, file, true);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
        public string SendMessage(string sender, string phoneNumber, string message)
        {
            string command = "/c "+_adbPath+"adb.exe -s " + sender + " shell service call isms 7 i32 1 s16 \"com.android.internal.telephony.ISms\" s16 \"" + phoneNumber + "\" s16 \"null\" s16 \"" + message.Replace(" ","\\ ") + "\" s16 \"null\" s16 \"null\"";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments =  command; 
            p.Start(); 
            return p.StandardOutput.ReadToEnd();
        }
        //Functions
    }
}
