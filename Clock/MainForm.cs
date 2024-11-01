using Microsoft.Win32;
using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
//using System.Reflection;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace Clock
{
    public partial class MainForm : Form
    {
        private bool isDragging = false; // Флаг, показывающий, происходит ли перетаскивание
        private Point startPoint;

        static string path = "C:\\Users\\golub\\source\\repos\\WindowsForms\\Clock\\Save.txt";

        ColorDialog backgroundColorDialog;
        ColorDialog foregroundColorDialog;
        ChooseFont chooseFontDialog;
        AlarmList alarmList;
        Alarm alarm;
        static string FontFile { get; set; }
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            SetFontDirectory();
            backgroundColorDialog = new ColorDialog();
            foregroundColorDialog = new ColorDialog();
            //backgroundColorDialog.Color = Color.AliceBlue;

            chooseFontDialog = new ChooseFont();
            LoadSettings();
            alarmList = new AlarmList();

            alarm = new Alarm();
            this.Location = new Point
                (
                    System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width,
                    50
                );  
            this.Text += $"Location : {this.Location.X} x {this.Location.Y}";
            SetVisibility(false);
            //reg.SetValue("My application", Application.ExecutablePath.ToString()); // автозапуск приложения 
            GetNextAlarm();

            //this.axWindowsMediaPlayer1.Visible = false;

            labelTime.MouseDown += MainForm_MouseDown;
            labelTime.MouseMove += MainForm_MouseMove;
            labelTime.MouseUp += MainForm_MouseUp;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            Object run = rk.GetValue("Clock318");
            if (run != null) loadOnWindowStartupToolStripMenuItem.Checked = true;
            rk.Dispose();

        }
        void LoadSettings ()
        {
            StreamReader sr = new StreamReader(path);
            try
            {
                List<string> settings = new List<string>();
                while (!sr.EndOfStream)
                {
                    settings.Add(sr.ReadLine());
                }

                backgroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(settings.ToArray()[0]));
                foregroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(settings.ToArray()[1]));
                FontFile = settings.ToArray()[2];

                topmostToolStripMenuItem.Checked = bool.Parse(settings.ToArray()[3]);
                showDateToolStripMenuItem.Checked = bool.Parse(settings.ToArray()[4]);
                labelTime.Font = chooseFontDialog.SetFontFile(FontFile);
                labelTime.ForeColor = foregroundColorDialog.Color;
                labelTime.BackColor = backgroundColorDialog.Color;
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
            }
        }
        void SaveSettings ()
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(backgroundColorDialog.Color.ToArgb());
            sw.WriteLine(foregroundColorDialog.Color.ToArgb());
            sw.WriteLine(chooseFontDialog.FontFile.Split('\\').Last());
            sw.WriteLine(topmostToolStripMenuItem.Checked);
            sw.WriteLine(showDateToolStripMenuItem.Checked);
            sw.Close();
            //Process.Start("notepad", path); // открывает файл для просмотра 
        }
        void GetNextAlarm()
        {
            List<Alarm> alarms = new List<Alarm>();
            foreach (Alarm alarm in alarmList.ListBoxAlarms.Items)
            {
                if(alarm.Time > DateTime.Now) alarms.Add(alarm);
            }
            if (alarms.Min() != null) alarm = alarms.Min();
            //List<TimeSpan> intervals = new List<TimeSpan>(); // TimeSpan - это
            //foreach (Alarm item in alarmList.ListBoxAlarms.Items)
            //{
            //    TimeSpan min = new TimeSpan(24,0,0);
            //    if (DateTime.Now - item.Time < min) alarm = item;   
            //}
            Console.WriteLine(alarm);          
        }
        void SetFontDirectory()
        {
            string location = Assembly.GetExecutingAssembly().Location; // Получаем полный адрес исполняемого файла
            string path = Path.GetDirectoryName(location);            // Из адреса извлекаем пусть к файлу
            //MessageBox.Show(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory($"{path}\\..\\..\\Fonts");    // Переходим в каталог со шрифтами
            //MessageBox.Show(Directory.GetCurrentDirectory());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
            if (cbShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Today.ToString("yyyy.MM.dd")}";
            }
            if(showWeekdayToolStripMenuItem.Checked)
            {
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            }
            //notifyIconSystemTray.Text = "Curret time " + labelTime.Text;
            if (
                alarm.WeekDays[(int)DateTime.Now.DayOfWeek == 0 ? 6 : (int)DateTime.Now.DayOfWeek - 1] == true && 
                DateTime.Now.Hour == alarm.Time.Hour && 
                DateTime.Now.Minute == alarm.Time.Minute && 
                DateTime.Now.Second == alarm.Time.Second
                )
            {
                //MessageBox.Show(alarm.FileName, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlayAlarm();
                GetNextAlarm();
            }
            if(DateTime.Now.Second == 0)
            {
                GetNextAlarm();
                Console.WriteLine("Minute");
            }
        }
        void PlayAlarm()
        {
            axWindowsMediaPlayer.URL = alarm.FileName;
            axWindowsMediaPlayer.settings.volume = 100;
            axWindowsMediaPlayer.Ctlcontrols.play();
            axWindowsMediaPlayer.Visible = true;
        }
        private void SetVisibility(bool visible)
        {
            this.TransparencyKey = visible ? Color.Empty : BackColor;
            this.FormBorderStyle = visible ? FormBorderStyle.Sizable : FormBorderStyle.None;
            this.ShowInTaskbar = visible;
            cbShowDate.Visible = visible;
            btnHideControls.Visible = visible;
            labelTime.BackColor = visible ? backgroundColorDialog.Color : backgroundColorDialog.Color;
            BackgroundImage = visible ? Clock.Properties.Resources.Chasiki1 : null;
            axWindowsMediaPlayer.Visible = false;
        }
        private void btnHideControls_Click(object sender, EventArgs e)
        {
            //SetVisibility(false);
            showControlsToolStripMenuItem.Checked = false;
            notifyIconSystemTray.ShowBalloonTip(3, "Alert", "Для того чтобы вернуть как было, нужно нажать 2 раза по иконке", ToolTipIcon.Info);
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            showControlsToolStripMenuItem.Checked = true;
        }

        private void notifyIconSystemTray_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIconSystemTray.Text = "Curret time:\n" + labelTime.Text;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = topmostToolStripMenuItem.Checked;
        }

        private void showControlsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility(((ToolStripMenuItem)sender).Checked);
        }

        private void showDateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            cbShowDate.Checked = ((ToolStripMenuItem)sender).Checked;
        }
        private void cbShowDate_CheckedChanged(object sender, EventArgs e)
        {
            showDateToolStripMenuItem.Checked = ((CheckBox)sender).Checked;
        }

        private void notifyIconSystemTray_DoubleClick(object sender, EventArgs e)
        {
            if(!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (foregroundColorDialog.ShowDialog(this) == DialogResult.OK)
            {
                labelTime.ForeColor = foregroundColorDialog.Color;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog(this) == DialogResult.OK)
            {
                labelTime.BackColor = backgroundColorDialog.Color;
            }
        }

        private void loadOnWindowStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (loadOnWindowStartupToolStripMenuItem.Checked)
                rk.SetValue("Clock318", System.Windows.Forms.Application.ExecutablePath);
            else rk.DeleteValue("Clock318", false);
            rk.Dispose();
        }

        private void loadOnWindowStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //loadOnWindowStartupToolStripMenuItem.Checked = ((CheckBox)sender).Checked;
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(chooseFontDialog.ShowDialog(this) == DialogResult.OK)
            {
                labelTime.Font = chooseFontDialog.ChoseFont;
            }
        }

        private void labelTime_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int newX = Location.X + (e.X - startPoint.X);
                int newY = Location.Y + (e.Y - startPoint.Y);

                Location = new Point(newX, newY);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void alarmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alarmList.ShowDialog(this);
            GetNextAlarm();
        }
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
    }
}
