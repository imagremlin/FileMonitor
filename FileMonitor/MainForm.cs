using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class MainForm : Form
    {
        private Timer timer = new Timer();
        private long fileSize = 0;

        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;            
            timer.Tick += Timer_Tick;
        }
       
        private void SendNotification(string subject, string body)
        {
            Status.Text = "Sending eMail, Please wait...";
            Refresh();
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["UserName"], "File Monitor");
            MailAddress toAddress = new MailAddress(eMail.Text, eMail.Text);            
            string fromPassword = ConfigurationManager.AppSettings["Password"];

            var smtp = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["SMTPServer"],
                Port = int.Parse(ConfigurationManager.AppSettings["Port"]),
                EnableSsl = bool.Parse(ConfigurationManager.AppSettings["UseSsl"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings1.Default.File = FileName.Text;
            Settings1.Default.eMail = eMail.Text;
            Settings1.Default.Period = (int)Period.Value;
            Settings1.Default.Save();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                long newfileSize = new FileInfo(FileName.Text).Length;
                if (fileSize == newfileSize)
                {
                    Stop();
                    SendNotification($"Notification for {Path.GetFileName(FileName.Text)}", $"File {FileName.Text} has not changed size in the last {Period.Value} minutes");
                    MessageBox.Show($"{FileName.Text} has not changed size in {Period.Value} minutes", "File Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fileSize = newfileSize;
                Status.Text = $"Monitoring last check {DateTime.Now.ToShortTimeString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FileName.Text = Settings1.Default.File;
            eMail.Text = Settings1.Default.eMail;
            Period.Value = Settings1.Default.Period;

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SMTPServer"]) ||
                string.IsNullOrEmpty(ConfigurationManager.AppSettings["Port"]) ||
                string.IsNullOrEmpty(ConfigurationManager.AppSettings["UseSsl"]) ||
                string.IsNullOrEmpty(ConfigurationManager.AppSettings["UserName"]))
            {
                MessageBox.Show("Before receiving eMail notifications, you need to configure your eMail server information by opening the FileMonitor.exe.config file with a text editor such as Notepad and adding the required information.\r\n\r\nReview the information from your eMail provider if you need help.\r\n\r\nUse the test button to ensure your eMail is working correctly","File Monitor",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Action.Enabled = false;
                Test.Enabled = false;
            }
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileName.Text = dlg.FileName;
            }
        }

        private void Start()
        {
            try
            {
                if (!File.Exists(FileName.Text))
                {
                    throw new Exception($"{FileName.Text} does not exist");
                }
                MailAddress toAddress = new MailAddress(eMail.Text, eMail.Text);
                FileName.ReadOnly = true;
                Period.ReadOnly = true;
                BrowseFile.Enabled = false;
                Action.Text = "Stop";
                Status.Text = $"Monitoring last check {DateTime.Now.ToShortTimeString()}";
                Status.ForeColor = Color.Green;
                fileSize = new FileInfo(FileName.Text).Length;
                timer.Interval = (int)Period.Value * 60000;
                timer.Start();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void ShowErrorMessage(Exception ex)
        {
            StringBuilder b = new StringBuilder();
            while (ex != null)
            {
                b.Append(ex.Message + "\r\n");
                ex = ex.InnerException;
            }

            MessageBox.Show(b.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Stop()
        {
            timer.Stop();
            Status.ForeColor = Color.Black;
            Status.Text = "Idle";
            Action.Text = "Start";
            FileName.ReadOnly = false;
            Period.ReadOnly = false;
            BrowseFile.Enabled = true;
        }

        private void Action_Click(object sender, EventArgs e)
        {
            if (Action.Text == "Start")
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void Test_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("This will send an email to test your current configuration.\r\nDo you want to proceed?", "FileMonitor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;                
                SendNotification("Test Notification", "Your email configuration is working correctly");
                MessageBox.Show($"A message has been sent to {eMail.Text}.\r\n\r\nPlease check your email, it may take some minutes to arrive. If you don't receive the email, review your configuration on FileMonitor.exe.config","File Monitor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            finally
            {
                Status.Text = "Idle";
            }
        }
    }
}
