using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class MainPage : Form
    {
        //Variables
        private readonly Variables vars = new Variables();
        private readonly Process getDeviceIdProcess = new Process();
        private readonly Process imeiProcess = new Process();
        int deviceControl = 0;
        //Variables
        public MainPage()
        {
            InitializeComponent();
        }
        //Functions 
        private void AllDeviceStatusCheck()
        {
            string[] lines = File.ReadAllLines(vars.savedDevicesPath);
            deviceControl = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!String.IsNullOrEmpty(lines[i]))
                {
                    string deviceName = lines[i].Split('-')[0].Split(':')[0];
                    string deviceId = lines[i].Split('-')[0].Split(':')[1];
                    string deviceImei = lines[i].Split('-')[0].Split(':')[2];
                    if (!CheckDeviceId(deviceImei, deviceId))
                    {
                        MessageBox.Show(deviceName + "'s id seems changed. If it's not plugged in connect " + deviceName + " or update device id on registering page.");
                        deviceControl = -1;
                    }
                    else if (i == lines.Length - 1 && deviceControl == 0)
                    { deviceControl = 1; }
                }
            }
            if (deviceControl == 1)
            {
                StatusLabel.Text = "OK";
                Message_SendAllButton.Enabled = true;
                Message_SendSelectedButton.Enabled = true;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]))
                    {
                        deviceList.Items.Add(lines[i]);
                    }
                }
            }
            else
            {
                StatusLabel.Text = "Update Device Properties";
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
            deviceImei = deviceImei.Replace("\n", "").Replace("\r", "");
            deviceImei = deviceImei.Replace(" ", "");
            deviceImei = deviceImei.Replace("\t", "");
            File.Delete(vars.imeisTxtPath);
            if (deviceImei == imei)
                return true;
            else
                return false;
        }
        private void GetNumbersList()
        {
            string[] lines = vars.ReadTxtFile(vars.savedNumbersPath);
            foreach (string line in lines)
                if (!String.IsNullOrEmpty(line)) NumbersListBox.Items.Add(line);
        }
        //Functions

        //Events 
        private void Form1_Load(object sender, EventArgs e)
        {
            AllDeviceStatusCheck();
            GetNumbersList();
            CheckSelectedDevice_Timer.Start();
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
        private void RefreshPictureButton_Click(object sender, EventArgs e)
        {
            deviceList.Items.Clear();
            AllDeviceStatusCheck();
            NumbersListBox.Items.Clear();
            GetNumbersList();
        }
        private void Number_AddToListButton_Click(object sender, EventArgs e)
        {
            if (!NumbersListBox.Items.Contains(NumberText.Text) && !String.IsNullOrEmpty(NumberText.Text))
            {
                NumbersListBox.Items.Add(NumberText.Text);
                string[] lines = vars.ReadTxtFile(vars.savedNumbersPath);
                string[] newLines = vars.AddToArr(lines, NumberText.Text);
                using (StreamWriter streamWriter = new StreamWriter(vars.savedNumbersPath))
                {
                    foreach (string line in newLines)
                        streamWriter.WriteLine(line);
                    streamWriter.Close();
                }
                vars.DeleteBlankLinesFromTxt(vars.savedNumbersPath);
            }
            else
            {
                MessageBox.Show("\"" + NumberText.Text + "\" is already in \"Numbers\" list");
            }
            NumberText.Clear();
        }
        private void NumbersListBox_DoubleClick(object sender, EventArgs e)
        {
            string itemToDel = NumbersListBox.SelectedItem.ToString();
            vars.deleteLineFromTxt(vars.savedNumbersPath, itemToDel);
            NumbersListBox.Items.Clear();
            GetNumbersList();
        }
        Task X(List<string> deviceId, int i, int numbers)
        {
            System.Threading.Thread.Sleep(Int16.Parse(NumberText.Text));
            return Task.Run(() =>
            {
                string output = vars.SendMessage(deviceId[i], NumbersListBox.Items[numbers].ToString(), MessageText.Text);
                if (output.Replace(Environment.NewLine, "") == "Result: Parcel(00000000    '....')")
                {
                    //Webe başarılı olduğu logu gönderilecek 
                    //MessageBox.Show(NumbersListBox.Items[numbers].ToString(), MessageText.Text);
                }
                else
                { 
                    //Webe başarısız olduğu logu gönderilecek
                }
            });
        }
        private async void Message_SendAllButton_Click(object sender, EventArgs e)
        {
            if (NumbersListBox.Items.Count == 0 || String.IsNullOrEmpty(MessageText.Text))
                return;

            List<string> deviceId = new List<string>();
            List<int> deviceQuota = new List<int>();
            for (int i = 0; i < deviceList.Items.Count; i++)
            {
                string device = deviceList.Items[i].Text;
                deviceId.Add(device.Split('-')[0].Split(':')[1]);
                deviceQuota.Add(Int16.Parse(device.Split('-')[1]));
            }
            int quota = deviceQuota.Sum();
            int process = NumbersListBox.Items.Count;
            int numbers = 0;
            if (quota < process)
            {
                MessageBox.Show("Last " + (process - quota).ToString() + " messages going to fail. There is not enough quota.");
            }
            for (int i = 0; i < deviceId.Count; i++)
            {
                int selectedDeviceQuota = deviceQuota[i];
                for (int j = 0; j < selectedDeviceQuota; j++)
                {
                    if (numbers == process)
                    { break; }
                    Task.WaitAll(X(deviceId, i, numbers));
                    ++numbers;
                    --deviceQuota[i];
                }
            }
            List<string> lines = new List<string>();
            for (int i = 0; i < deviceId.Count; i++)
            {
                string _deviceId = deviceId[i];
                string _deviceQuota = deviceQuota[i].ToString();
                for (int j = 0; j < deviceList.Items.Count; j++)
                {
                    string deviceOnList = deviceList.Items[j].Text;
                    deviceOnList = deviceOnList.Split('-')[0].Split(':')[1];
                    if (_deviceId == deviceOnList)
                    {
                        lines.Add(deviceList.Items[j].Text + "/" + deviceList.Items[j].Text.Split('-')[0] + "-" + _deviceQuota);
                        break;
                    }
                }
            }
            foreach (string line in lines)
                MessageBox.Show(line);



            /*int processNumber = NumbersListBox.Items.Count - 1;
            int succesProcess = 0;
            if (deviceList.SelectedItems.Count > 0 && NumbersListBox.Items.Count > 0)
            {
                for (int i = 0; i < processNumber; i++)
                {
                    string output = vars.SendMessage(deviceList.SelectedItems[0].Text.Split('-')[0].Split(':')[1], NumbersListBox.Items[i].ToString(), MessageText.Text);
                    if (output.Replace(Environment.NewLine, "") == "Result: Parcel(00000000    '....')")
                    {
                        //Webe başarılı olduğu logu gönderilecek
                        succesProcess++; 
                    }
                    else
                    {
                        //Webe başarısız olduğu logu gönderilecek
                    }
                    if (i == processNumber - 1)
                    {
                        //Webe başarılı olduğu logu gönderilecek
                        MessageStatus.Text = succesProcess.ToString() + " message sent " + DateTime.Now.ToString("HH:mm");
                    }
                }
            }*/
        }
        private void CheckSelectedDevice_Timer_Tick(object sender, EventArgs e)
        {
            if (deviceList.SelectedItems.Count > 0)
            {
                Message_SendAllButton.Enabled = true;
                Message_SendSelectedButton.Enabled = true;
            }
            else
            {
                Message_SendAllButton.Enabled = false;
                Message_SendSelectedButton.Enabled = false;
            }
        }
        private void Message_SendSelectedButton_Click(object sender, EventArgs e)
        {
            if (deviceList.SelectedItems.Count > 0 && !String.IsNullOrEmpty(MessageText.Text) && !String.IsNullOrEmpty(MessageText.Text))
            {
                string output = vars.SendMessage(deviceList.SelectedItems[0].Text.Split('-')[0].Split(':')[1], NumbersListBox.SelectedItem.ToString(), MessageText.Text);
                if (output.Replace(Environment.NewLine, "") == "Result: Parcel(00000000    '....')")
                {
                    MessageStatus.Text = "Message sent " + DateTime.Now.ToString("HH:mm");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeviceRegister registerForm = new DeviceRegister();
            registerForm.ShowDialog();
        }
        //Events 


    }
}
