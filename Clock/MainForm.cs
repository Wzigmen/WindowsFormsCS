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

namespace Clock
{
    public partial class MainForm : Form
    {
        private bool isDragging = false; // Флаг, показывающий, происходит ли перетаскивание
        private Point startPoint;

        static string path = "C:\\Users\\golub\\source\\repos\\WindowsForms\\Clock\\Save.txt";

        ColorDialog backgroundColorDialog;
        ColorDialog foregroundColorDialog;
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        ChooseFont chooseFontDialog;
        public MainForm()
        {
            InitializeComponent();
            SetFontDirectory();
            backgroundColorDialog = new ColorDialog();
            foregroundColorDialog = new ColorDialog();
            //backgroundColorDialog.Color = Color.AliceBlue;
            ApplySaves();

            chooseFontDialog = new ChooseFont();

            this.Location = new Point
                (
                    System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width,
                    50
                );  
            this.Text += $"Location : {this.Location.X} x {this.Location.Y}";
            SetVisibility(false);
            //reg.SetValue("My application", Application.ExecutablePath.ToString()); // автозапуск приложения 

            labelTime.MouseDown += MainForm_MouseDown;
            labelTime.MouseMove += MainForm_MouseMove;
            labelTime.MouseUp += MainForm_MouseUp;

        }
        void ApplySaves ()
        {
            string colorBack = File.ReadAllText(path);
            backgroundColorDialog.Color = Color.FromName(colorBack);
        }
        void SaveSetings (ColorDialog back, ColorDialog fore)
        {
            StreamWriter fileStream = new StreamWriter(path);
                       
            fileStream.Write(back.Color.Name);

            fileStream.Close();
        }
        void SetFontDirectory()
        {
            string location = Assembly.GetExecutingAssembly().Location; // Получаем полный адрес исполняемого файла
            string path = Path.GetDirectoryName(location);            // Из адреса извлекаем пусть к файлу
            //MessageBox.Show(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory($"{path}\\..\\..\\Fonts");    // Переходим в каталог со шрифтами
            //MessageBox.Show(Directory.GetCurrentDirectory());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
            if (cbShowDate.Checked)
            {
                labelTime.Text += $"\n{DateTime.Today.ToString("yyyy.MM.dd")}";
            }
            //notifyIconSystemTray.Text = "Curret time " + labelTime.Text;
        }
        private void SetVisibility(bool visible)
        {
            this.TransparencyKey = visible ? Color.Empty : BackColor;
            this.FormBorderStyle = visible ? FormBorderStyle.Sizable : FormBorderStyle.None;
            this.ShowInTaskbar = visible;
            cbShowDate.Visible = visible;
            btnHideControls.Visible = visible;
            labelTime.BackColor = visible ? Color.Transparent : backgroundColorDialog.Color;
            BackgroundImage = visible ? Clock.Properties.Resources.Chasiki1 : null;
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
            SaveSetings(backgroundColorDialog, foregroundColorDialog);
        }

        private void loadOnWindowStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //if (loadOnWindowStartupToolStripMenuItem.Checked == true)
            //    reg.SetValue("My application", Application.ExecutablePath.ToString());
            //else 
            //    reg.Close();
        }

        private void loadOnWindowStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadOnWindowStartupToolStripMenuItem.Checked = ((CheckBox)sender).Checked;
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
    }
}
