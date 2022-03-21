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
        bool changingPage = false;
        public DeviceRegister()
        {
            InitializeComponent();
        }

        private void LoadDevices()
        {
            deviceList.Clear();
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
                getDeviceIdProcess.StartInfo.FileName = vars.adbPath + "adb.exe";
                getDeviceIdProcess.Start();
                string output = getDeviceIdProcess.StandardOutput.ReadToEnd();
                getDeviceIdProcess.WaitForExit();
                //Get device id with adb.exe and read the output of cmd

                string[] lines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);//Get all devices by dividing with new line
                devices = lines.ToList();

                devices.RemoveAt(0);//delete the first row which is:"List of attached devices"(unnecessary)
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
                        deviceIdWithImei.Add(device.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "") + ":" + deviceImei.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));
                    }
                }
                //Get device's imei number
                //  deviceList.Items[i].BackColor = Color.Yellow;
                deviceList.Clear();
                vars.DeleteBlankLinesFromTxt(vars.savedDevicesPath);
                string[] savedDevices = ReadAllLines(vars.savedDevicesPath);
                //listing devices
                if (savedDevices[0] != "")
                {
                    for (int i = 0; i < savedDevices.Length; i++)
                    {
                        if (deviceIdWithImei.Contains(savedDevices[i].Split(':')[1] + ":" + savedDevices[i].Split(':')[2].Split('-')[0]))
                        { 
                            if (!String.IsNullOrEmpty(savedDevices[i]))
                            {
                                MessageBox.Show(savedDevices[i] + " bağlı ve kayıtlı");
                                deviceList.Items.Add(savedDevices[i]);
                                deviceList.Items[deviceList.Items.Count - 1].BackColor = Color.Green;
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(savedDevices[i]))
                            {
                                deviceList.Items.Add(savedDevices[i]);
                                deviceList.Items[deviceList.Items.Count - 1].BackColor = Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    foreach (string device in deviceIdWithImei)
                    {
                        if (!String.IsNullOrEmpty(device))
                        {
                            deviceList.Items.Add(device);
                            deviceList.Items[deviceList.Items.Count - 1].BackColor = Color.Yellow;
                        }
                    }
                }

                //foreach (string device in deviceIdWithImei)
                //{
                //    if (savedDevices[0] == "")
                //    {
                //        DeviceListbox.Items.Add(device);
                //    }
                //    else
                //    {
                //        for (int i = 0; i < savedDevices.Length; i++)
                //        {
                //            if (savedDevices[i].Split('-')[0].Split(':')[1] + ":" + savedDevices[i].Split('-')[0].Split(':')[2] != device)
                //            {
                //                DeviceListbox.Items.Add(device);
                //            }
                //            else
                //            {
                //                DeviceListbox.Items.Add(savedDevices[i]);
                //            }
                //        }
                //    }
                //}
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
            if (!changingPage)
            {
                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Show();
            }
            else { changingPage = false; }
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadDevices();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DeviceNameText.Text))
            {
                MessageBox.Show("Device name cannot be empty");
                return;
            }
            else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Message quota cannot be empty");
                return;
            }
            string newRecord = "";
            if (!selectedDeviceIdWithImei.Contains("-"))
            { newRecord = (DeviceNameText.Text + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[0] + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[1] + "-" + textBox1.Text).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""); }
            else
            { newRecord = (DeviceNameText.Text + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[1] + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[2] + "-" + textBox1.Text).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""); }
            string[] lines = ReadAllLines(vars.savedDevicesPath);
            if (selectedDeviceOldName != "")
            {
                string oldRecord = (selectedDeviceOldName + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[1] + ":" + selectedDeviceIdWithImei.Split('-')[0].Split(':')[2] + "-" + selectedDeviceIdWithImei.Split('-')[1]).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                LineChanger(newRecord, vars.savedDevicesPath, oldRecord);
            }
            else
            {
                LineChanger(newRecord, vars.savedDevicesPath, "");
            }
            selectedDeviceOldName = "";
            LoadDevices();
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
                    { writer.WriteLine(line.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "")); }
                    writer.Close();
                }
            }
            var tempFileName = Path.GetTempFileName();
            try
            {
                using (var streamReader = new StreamReader(vars.savedDevicesPath))
                using (var streamWriter = new StreamWriter(tempFileName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            streamWriter.WriteLine(line);
                    }
                }
                File.Copy(tempFileName, vars.savedDevicesPath.Split('\\').Last(), true);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            changingPage = true;
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedDeviceIdWithImei = deviceList.SelectedItems[0].Text;
                string deviceId = selectedDeviceIdWithImei.Split('-')[0].Split(':')[1];
                string[] lines = File.ReadAllLines(vars.savedDevicesPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]) && lines[i].Split('-')[0].Split(':')[1] == deviceId)
                    {
                        DeviceNameText.Text = lines[i].Split('-')[0].Split(':')[0];
                        textBox1.Text = lines[i].Split('-')[1];
                        selectedDeviceOldName = lines[i].Split('-')[0].Split(':')[0]; break;
                    }
                }
            }
            catch { }
        }
    }
}
