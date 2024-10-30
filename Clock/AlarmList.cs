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
    public partial class AlarmList : Form
    {
        public AlarmList()
        {
            InitializeComponent();
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
            this.listBoxAlarms.Items.Clear();
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
    }
}
