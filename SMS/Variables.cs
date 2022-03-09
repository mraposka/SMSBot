using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{ 
    class Variables
    {
        //Class For Global Variables
        public void s(object x)
        {
            MessageBox.Show(x.ToString());
        }
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
        private string _adbPath = @"C:\Users\Win\Desktop\sdk\platform-tools\adb.exe";
        private string _savedNumbersPath = @"savedNumbers.txt";
        public static string _imeiBatPath = @"getimei.bat";
        string _imeisTxtPath = @"imeis.txt";
        public string _savedDevicesPath = @"devices.txt";
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
    }
}
