using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AddAlarm : Form
    {
        public Alarm Alarm { get; set; }
        AlarmList alarmList;
        public AddAlarm()
        {
            InitializeComponent();
            Alarm = new Alarm();
            //labelFileName.SetBounds(labelFileName.Location.X, labelFileName.Location.Y, this.Width - 10, 25);
            labelFileName.MaximumSize = new Size(this.Width - 25, 75);
            openFileDialogSound.Filter = "MP-3 (*.mp3)|*.mp3|Flac (*.flac)|*.flac|All Audio|*.mp3;*.flac";
        }
        void AlarmInit()
        {
            Alarm.Date = dateTimePickerDate.Enabled ? dateTimePickerDate.Value : DateTime.MinValue;
            Alarm.Time = dateTimePickerTime.Value;
            Alarm.FileName = labelFileName.Text;
            for (int i = 0; i < checkedListBoxWeek.CheckedIndices.Count; i++)
            {
                // Cвойство CheckedIndices - это коллекция которая содержит индексы выбранных галочек в checkedListBox
                //Alarm.WeekDays[i] = (checkedListBoxWeek.Items[i] as CheckBox).Checked;
                Alarm.WeekDays[checkedListBoxWeek.CheckedIndices[i]] = true;
                Console.Write(checkedListBoxWeek.CheckedIndices[i] + "\t");
            }
            Console.WriteLine();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            AlarmInit();
            if(Alarm.FileName == "Filename:")
            {
                MessageBox.Show("Выберите файл", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void checkBoxExactDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDate.Enabled = ((CheckBox)sender).Checked;
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelFileName_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void buttonChoosFile_Click(object sender, EventArgs e)
        {
            if(openFileDialogSound.ShowDialog(this) == DialogResult.OK)
            {
                Alarm.FileName = labelFileName.Text = openFileDialogSound.FileName;
                
            }
        }
    }
}
