using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Clock
{
    public partial class AlarmList : Form
    {
        public ListBox ListBoxAlarms 
        {  
            get => listBoxAlarms;
            private set => listBoxAlarms = value; 
        }
        public AlarmList()
        {
            InitializeComponent();
            LoadAlarmsFromFile("alarms.csv");
        }

        private void buttonAddAlarm_Click(object sender, EventArgs e)
        {
            AddAlarm addAlarm = new AddAlarm();
            if (addAlarm.ShowDialog(this) == DialogResult.OK)
            { 
                listBoxAlarms.Items.Add(addAlarm.Alarm);
                Console.WriteLine(listBoxAlarms.Items.Count);
            }
        }

        private void buttonDeletAlarms_Click(object sender, EventArgs e)
        {
            listBoxAlarms.Items.Remove(listBoxAlarms.SelectedItem);
        }

        private void listBoxAlarms_DoubleClick(object sender, EventArgs e)
        {
#if false
            Alarm selectedAlarm = (Alarm)listBoxAlarms.SelectedItem;

            // Создаем форму для редактирования будильника
            AddAlarm addAlarm = new AddAlarm();
            addAlarm.Alarm = selectedAlarm; // Передаем выбранный будильник
            addAlarm.ShowDialog(this);
#endif
            AddAlarm addAlarm = new AddAlarm((sender as ListBox).SelectedItem as Alarm);
            if (addAlarm.ShowDialog(this) == DialogResult.OK)
            {
                listBoxAlarms.SelectedItem = addAlarm.Alarm;
                listBoxAlarms.Items[listBoxAlarms.SelectedIndex] = listBoxAlarms.Items[listBoxAlarms.SelectedIndex];
            }
        }
        public void SaveAlarmsToFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (Alarm alarm in listBoxAlarms.Items)
            {
                sw.WriteLine(alarm.ToFileString());
            }
            sw.Close();
            Process.Start("notepad", filename);
        }
        public void LoadAlarmsFromFile(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string alarm = sr.ReadLine();
                    listBoxAlarms.Items.Add(new Alarm(alarm));
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //private void SaveDataToFile()
        //{
        //    string filePath = "C:\\Users\\golub\\source\\repos\\WindowsForms\\Clock\\data.txt";
        // 
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath))
        //        {
        //            foreach (var item in listBoxAlarms.Items)
        //            {
        //                writer.WriteLine(item.ToString());
        //            }
        //        }
        //
        //        MessageBox.Show("Данные успешно сохранены в файл " + filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
        //    }
        //}

        private void listBoxAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SaveDataToFile();
        }
    }
}
