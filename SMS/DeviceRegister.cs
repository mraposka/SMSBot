using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class DeviceRegister : Form
    {
        Variables vars = new Variables();
        List<string> deviceIdWithImei = new List<string>();
        List<string> devices = new List<string>();
        Process getDeviceIdProcess = new Process();
        Process imeiProcess = new Process();
        string selectedDeviceIdWithImei = "";
        string selectedDeviceOldName = "";
        public DeviceRegister()
        {
            InitializeComponent();
        }

        private void LoadDevices()
        {
            DeviceListbox.Items.Clear();
            try
            {
                if (deviceIdWithImei.Count > 0) { deviceIdWithImei.Clear(); }
                if (devices.Count > 0) { devices.Clear(); }
                //Get device id with adb.exe and read the output of cmd
                getDeviceIdProcess.StartInfo.UseShellExecute = false;
                getDeviceIdProcess.StartInfo.RedirectStandardOutput = true;
                getDeviceIdProcess.StartInfo.CreateNoWindow = true;
                getDeviceIdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                getDeviceIdProcess.StartInfo.Arguments = "devices";
                getDeviceIdProcess.StartInfo.FileName = vars.adbPath;
                getDeviceIdProcess.Start();
                string output = getDeviceIdProcess.StandardOutput.ReadToEnd();
                getDeviceIdProcess.WaitForExit();
                //Get device id with adb.exe and read the output of cmd

                string[] lines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);//Get all devices by dividing with new line
                devices = lines.ToList();

                devices.RemoveAt(0);//delete the first row whic is:List of attached devices(unnecessary)
                for (int i = 0; i < devices.Count; i++)
                {
                    if (devices[i] == "" || devices[i] == " " || devices[i] == String.Empty || devices[i] == Environment.NewLine) devices.RemoveAt(i);
                    {
                        devices[i] = devices[i].Replace("device", "");
                        devices[i] = devices[i].Replace(" ", "");
                        devices[i] = devices[i].Replace("\t", "");
                    }//remove the device word(unnecessary)
                }
                //Get device's imei number
                foreach (string device in devices)
                {
                    if (!String.IsNullOrEmpty(device))
                    {
                        imeiProcess.StartInfo.UseShellExecute = false;
                        imeiProcess.StartInfo.RedirectStandardOutput = true;
                        imeiProcess.StartInfo.CreateNoWindow = true;
                        imeiProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        imeiProcess.StartInfo.Arguments = device;
                        imeiProcess.StartInfo.FileName = vars.imeiBatPath;
                        imeiProcess.Start();
                        imeiProcess.WaitForExit();
                        string deviceImei = System.IO.File.ReadAllText(vars.imeisTxtPath);
                        File.Delete(vars.imeisTxtPath);
                        deviceIdWithImei.Add(device + ":" + deviceImei);
                    }
                }
                //Get device's imei number
                DeviceListbox.Items.Clear();
                //listing devices
                foreach (string device in deviceIdWithImei)
                {
                    DeviceListbox.Items.Add(device);
                }
                //listing devices

            }
            catch { }
        }

        private void DeviceRegister_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDevices();
            }
            catch { }
        }

        private void DeviceRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Process[] runingProcess = Process.GetProcessesByName("SMS");
                for (int i = 0; i < runingProcess.Length; i++)
                {
                    runingProcess[i].Kill();
                }
            }
            catch { }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadDevices();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string newRecord = DeviceNameText.Text + ":" + selectedDeviceIdWithImei.Split(':')[0] + ":" + selectedDeviceIdWithImei.Split(':')[1];
            string[] lines = ReadAllLines(vars.savedDevicesPath);
            if (selectedDeviceOldName != "")
            {
                string oldRecord = (selectedDeviceOldName + ":" + selectedDeviceIdWithImei.Split(':')[0] + ":" + selectedDeviceIdWithImei.Split(':')[1]).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                LineChanger(newRecord, vars.savedDevicesPath, oldRecord);
            }
            else
                {
                LineChanger(newRecord, vars.savedDevicesPath, "");
            }
            selectedDeviceOldName = "";
        }
        private string[] ReadAllLines(string path)
        {
            string lines;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            { lines = sr.ReadToEnd(); fs.Close(); sr.Close(); }
            return lines.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }
        private void LineChanger(string newText, string fileName, string oldText)
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
                    { writer.WriteLine(line); MessageBox.Show(line); }
                    writer.Close();
                    }
                }

            }
        private int LineNumberFinder(string record)
        {
            int counter = 0;
            string line;
            StreamReader file = new StreamReader(vars.savedDevicesPath);
            while ((line = file.ReadLine()) != null)
            {

                if (line.Contains(record))
                {
                    Console.WriteLine(counter.ToString() + ": " + line); return counter;
        }

                counter++;
            }
            file.Close();
            return -1;
        }
        private void DeviceListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedDeviceIdWithImei = DeviceListbox.SelectedItem.ToString();
                string deviceId = selectedDeviceIdWithImei.Split(':')[0];
                string[] lines = File.ReadAllLines(vars.savedDevicesPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]) && lines[i].Split(':')[1] == deviceId)
                    {
                        DeviceNameText.Text = lines[i].Split(':')[0];
                        selectedDeviceOldName = lines[i].Split(':')[0]; break;
                    }
                }
            }
            catch { }

        } 
    }
}
