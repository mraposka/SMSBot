using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{ 
    class Variables
    {
        public void s(object x)
        {
            MessageBox.Show(x.ToString());
        }
        private string _adbPath = @"C:\Users\Win\Desktop\sdk\platform-tools\adb.exe";
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
    }
}
