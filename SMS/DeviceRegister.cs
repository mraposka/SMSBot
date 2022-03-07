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
            string[] lines = File.ReadAllLines(vars.savedDevicesPath);
            if (selectedDeviceOldName != "")
            {
                string oldRecord = selectedDeviceOldName + ":" + selectedDeviceIdWithImei.Split(':')[0] + ":" + selectedDeviceIdWithImei.Split(':')[1];
                
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace(" ","");
                    lines[i] = lines[i].Replace("\t","");
                    if (lines[i] == oldRecord)
                    {
                        lines[i] = newRecord;
                    }
                }
            }
            List<string> newLines = lines.ToList();
            newLines.Add(newRecord);
            File.WriteAllLines(vars.savedDevicesPath, newLines);
            selectedDeviceOldName = "";
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
