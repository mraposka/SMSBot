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
    public partial class MainPage : Form
    {
        Variables vars = new Variables(); 
        List<string> deviceIdWithImei = new List<string>();
        List<string> devices = new List<string>();
        Process getDeviceIdProcess = new Process();
        Process imeiProcess = new Process();
        bool deviceControl = false;  
        public MainPage()
        {
            InitializeComponent();
        }
        private void AllDeviceStatusCheck()
        {
            string[] lines = File.ReadAllLines(vars.savedDevicesPath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!String.IsNullOrEmpty(lines[i]))
                {
                    string deviceName = lines[i].Split(':')[0];
                    string deviceId = lines[i].Split(':')[1];
                    string deviceImei = lines[i].Split(':')[2];
                    if (!CheckDeviceId(deviceImei, deviceId))
                    {
                        MessageBox.Show(deviceName + "'s id seems changed. If it's not plugged in connect "+deviceName+" or update device id on registering page.");
                        deviceControl = false;
                        i = 999;//breaking the loop(controlling with loop variable)
                    }
                    else if (i == lines.Length - 1 && !deviceControl)
                    { deviceControl = true; }
                }
            }
            if (deviceControl)
            {
                StatusLabel.Text = "OK";
                Message_SendNowButton.Enabled = true;
                Message_SendAllButton.Enabled = true;
                Message_SendSelectedButton.Enabled = true;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]))
                    {
                        DevicesListBox.Items.Add(lines[i]);
                    }
                }
            }
            else
            {
                StatusLabel.Text = "Update Device Properties";
                Message_SendNowButton.Enabled = false;
                Message_SendAllButton.Enabled = false;
                Message_SendSelectedButton.Enabled = false;
            }
        }
        private bool CheckDeviceId(string imei, string id)
        { 
            imeiProcess.StartInfo.UseShellExecute = false;
            imeiProcess.StartInfo.RedirectStandardOutput = true;
            imeiProcess.StartInfo.CreateNoWindow = true;
            imeiProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            imeiProcess.StartInfo.Arguments = id;
            imeiProcess.StartInfo.FileName = vars.imeiBatPath;
            imeiProcess.Start();
            imeiProcess.WaitForExit();
            string deviceImei = System.IO.File.ReadAllText(vars.imeisTxtPath);
            deviceImei= deviceImei.Replace("\n", "").Replace("\r", "");
            deviceImei = deviceImei.Replace(" ", ""); 
            deviceImei = deviceImei.Replace("\t", "");
            File.Delete(vars.imeisTxtPath);
            if (deviceImei == imei)
                return true;
            else
                return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllDeviceStatusCheck();
        }

        private void deviceRegistiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeviceRegister registerForm = new DeviceRegister();
            registerForm.ShowDialog();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
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
         
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DevicesListBox.Items.Clear();
            AllDeviceStatusCheck();
        }

        private void Number_AddToListButton_Click(object sender, EventArgs e)
        {
            NumbersListBox.Items.Add(NumberText.Text);
            using (StreamWriter streamWriter=new StreamWriter(vars.savedNumbersPath))
            {
                streamWriter.WriteLine(NumberText.Text);
                streamWriter.Close();
            }
        }

        private void DeleteSelectedNumberButton_Click(object sender, EventArgs e)
        {
           
        }

        private void NumbersListBox_DoubleClick(object sender, EventArgs e)
        {
            string itemToDel=NumbersListBox.SelectedItem.ToString();
            NumbersListBox.Items.Remove(itemToDel);
            using (StreamWriter streamWriter = new StreamWriter(vars.savedNumbersPath))
            {
                //delete?
                streamWriter.Close();
            }
        }
    }
}
