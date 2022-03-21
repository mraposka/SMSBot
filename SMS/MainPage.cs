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
        Variables vars = new Variables();
        List<string> deviceIdWithImei = new List<string>();
        List<string> devices = new List<string>();
        Process getDeviceIdProcess = new Process();
        Process imeiProcess = new Process();
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
                    else if (i == lines.Length - 1 && deviceControl==0)
                    { deviceControl = 1; }
                }
            }
            if (deviceControl==1)
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
                NumbersListBox.Items.Add(line);
        }   
        //Functions

        //Events 
        private void Form1_Load(object sender, EventArgs e)
        {
            AllDeviceStatusCheck();
            GetNumbersList();
            CheckSelectedDevice_Timer.Start();
        }

        private void DeviceRegistiraToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void RefreshPictureButton_Click(object sender, EventArgs e)
        {
            deviceList.Items.Clear();
            AllDeviceStatusCheck();
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
            GetNumbersList();
        }

        private void Message_SendAllButton_Click(object sender, EventArgs e)
        {
            int processNumber = NumbersListBox.Items.Count - 1;
            int succesProcess = 0;
            if (deviceList.SelectedItems.Count > 0 && NumbersListBox.Items.Count > 0)
            {
                for (int i = 0; i < processNumber; i++)
                {
                    string output = vars.SendMessage(deviceList.SelectedItems[0].ToString().Split('-')[0].Split(':')[1], NumbersListBox.Items[i].ToString(), MessageText.Text);
                    if (output.Replace(Environment.NewLine, "") == "Result: Parcel(00000000    '....')")
                    {
                        succesProcess++;
                        if (i == processNumber - 1)
                        {
                            //Webe başarılı olduğu logu gönderilecek
                            MessageStatus.Text = succesProcess.ToString() + " message sent " + DateTime.Now.ToString("HH:mm");
                        }
                    }
                    else
                    {
                        //Webe başarısız olduğu logu gönderilecek
                    }
                }
            }
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
                string output = vars.SendMessage(deviceList.SelectedItems[0].ToString().Split('-')[0].Split(':')[1], NumbersListBox.SelectedItem.ToString(), MessageText.Text);
                NumberText.Text = output;
                if (output.Replace(Environment.NewLine, "") == "Result: Parcel(00000000    '....')")
                {
                    MessageStatus.Text = "Message sent " + DateTime.Now.ToString("HH:mm");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                string command = "/c " + vars.adbPath + "adb.exe shell service call isms " + i + " i32 1 s16 \"com.android.internal.telephony.ISms\" s16 \" +905442551381 \" s16 \"null\" s16 \" deneme" + i.ToString() + "\" s16 \"null\" s16 \"null\"";
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = command;
                p.Start();
                Thread.Sleep(1000);
            }
        }

        //Events 


    }
}
