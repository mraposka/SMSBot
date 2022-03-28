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
        public void LineChanger(string newText, string fileName, string oldText)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string lines = reader.ReadToEnd();
                reader.Close();
                List<string> newLines = lines.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();
                newLines.Add(newText);
                if (oldText != "") newLines.Remove(oldText);
                File.Delete(fileName);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string line in newLines)
                    { writer.WriteLine(line.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "")); }
                    writer.Close();
                }
            }
            var tempFileName = Path.GetTempFileName();
            try
            {
                using (var streamReader = new StreamReader(fileName))
                using (var streamWriter = new StreamWriter(tempFileName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            streamWriter.WriteLine(line);
                    }
                }
                File.Copy(tempFileName, fileName.Split('\\').Last(), true);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
        public string GetAndroidVersion(string deviceId) {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c "+ _adbPath + "adb.exe -s "+deviceId+" shell getprop ro.build.version.release";
            p.Start();
            p.WaitForExit();
            return p.StandardOutput.ReadToEnd().Replace(" ", "\\ ").Replace("\n" ,"").Replace("\r","").Replace("\r\n", "");
        }
        public string SendMessage(string sender, string phoneNumber, string message, string version)
        {
            //System.Threading.Thread.Sleep(1000);
            string command;
            if (version == "10" || version == "9")
            {
                command = "/c " + _adbPath + "adb.exe -s " + sender + " shell service call isms 7 i32 1 s16 \"com.android.internal.telephony.ISms\" s16 \"" + phoneNumber + "\" s16 \"null\" s16 \"" + message.Replace(" ", "\\ ") + "\" s16 \"null\" s16 \"null\"";
            }
            else
            {
                command = "/c " + _adbPath + "adb.exe -s " + sender + " shell service call isms 5 i32 1 s16 \"com.android.mms.service\" s16 \"null\" s16 \"" + phoneNumber + "\" s16 \"null\" s16 \"" + message.Replace(" ", "\\ ") + "\" s16 \"null\" s16 \"null\" i32 0 i64 0";
            }
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = command;
            p.Start();
            p.WaitForExit();
            return p.StandardOutput.ReadToEnd();
        }
        public void deleteLineFromTxt(string file, string _itemToDel)
        {
            string itemToDel = _itemToDel;
            string[] lines;
            string[] newLines;
            lines = ReadTxtFile(file);
            newLines = DeleteFromArr(lines, itemToDel);
            Task thread1 = Task.Factory.StartNew(() => DelFile(file));
            Task.WaitAll(thread1);
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                foreach (string line in newLines)
                    streamWriter.WriteLine(line);

                streamWriter.Close();
            }
            DeleteBlankLinesFromTxt(file);
        }
        public string[] ReadTxtFile(string file)
        {
            string[] lines;
            using (StreamReader streamReader = new StreamReader(file))
            {
                lines = streamReader.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                streamReader.Close();
            }
            return lines;
        }
        public string[] DeleteFromArr(string[] arr, string del)
        {
            List<string> tempList = arr.ToList();
            tempList.Remove(del);
            return tempList.ToArray();
        }

        public string[] AddToArr(string[] arr, string add)
        {
            List<string> tempList = arr.ToList();
            tempList.Add(add);
            return tempList.ToArray();
        }

        public void DelFile(string file)
        {
            File.Delete(file);
        }
        //Functions
    }
}
