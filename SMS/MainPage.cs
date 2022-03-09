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
        //Variables
        Variables vars = new Variables();
        List<string> deviceIdWithImei = new List<string>();
        List<string> devices = new List<string>();
        Process getDeviceIdProcess = new Process();
        Process imeiProcess = new Process();
        bool deviceControl = false; 
        //Variables
        public MainPage()
        {
            InitializeComponent();
        }
        //Functions 
        private void AllDeviceStatusCheck()
        {
            string[] lines = File.ReadAllLines(vars.savedDevicesPath);

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
            string[] lines = ReadTxtFile(vars.savedNumbersPath);
            foreach (string line in lines)
                NumbersListBox.Items.Add(line);
        }

        private string[] ReadTxtFile(string file)
        {
            string[] lines;
            using (StreamReader streamReader = new StreamReader(file))
            {
                lines = streamReader.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                streamReader.Close();
            }
            return lines;
        }
         
        private string[] DeleteFromArr(string[] arr, string del)
        {
            List<string> tempList = arr.ToList();
            tempList.Remove(del);
            return tempList.ToArray();
        }

        private string[] AddToArr(string[] arr, string add)
        {
            List<string> tempList = arr.ToList();
            tempList.Add(add);
            return tempList.ToArray();
        }

        static void DelFile(string file)
        {
            File.Delete(file);
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
            vars.s(DevicesListBox.SelectedIndex);
            DevicesListBox.Items.Clear();
            AllDeviceStatusCheck();
        }

        private void Number_AddToListButton_Click(object sender, EventArgs e)
        {
            if (!NumbersListBox.Items.Contains(NumberText.Text)&&!String.IsNullOrEmpty(NumberText.Text))
            { 
                NumbersListBox.Items.Add(NumberText.Text);
                string[] lines = ReadTxtFile(vars.savedNumbersPath);
                string[] newLines = AddToArr(lines, NumberText.Text);
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
                MessageBox.Show("\"" + NumberText.Text+ "\" is already in \"Numbers\" list");
            }
        } 

        private void NumbersListBox_DoubleClick(object sender, EventArgs e)
        {
            string itemToDel = NumbersListBox.SelectedItem.ToString();
            string[] lines;
            string[] newLines;
            NumbersListBox.Items.Remove(itemToDel);
            lines = ReadTxtFile(vars.savedNumbersPath);
            newLines = DeleteFromArr(lines, itemToDel);
            Task thread1 = Task.Factory.StartNew(() => DelFile(vars.savedNumbersPath));
            Task.WaitAll(thread1);
            using (StreamWriter streamWriter = new StreamWriter(vars.savedNumbersPath))
            {
                foreach (string line in newLines)
                    streamWriter.WriteLine(line);

                streamWriter.Close();
            }
            vars.DeleteBlankLinesFromTxt(vars.savedNumbersPath);
        }

        private void Message_SendAllButton_Click(object sender, EventArgs e)
        {
            
            if(DevicesListBox.SelectedIndex!=-1&&NumbersListBox.Items.Count > 0)
            {
                vars.s((object)("Gönderildi"));
            }
        }

        private void CheckSelectedDevice_Timer_Tick(object sender, EventArgs e)
        {
            if (DevicesListBox.SelectedIndex != -1)
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

        //Events 


    }
}
