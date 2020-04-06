using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        private BackgroundWorker backgroundWorker;
        BindingList<PillModel> medications = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";
            pillsToTakeListBox.DisplayMember = "PillInfo";

            PopulateDummyData();

            Task.Run(PillRefresherTask);
        }

        private void PopulateDummyData()
        {
            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.ParseExact("0:15 am", "h:mm tt", null, System.Globalization.DateTimeStyles.AssumeLocal) });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("11:45 pm") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("6:15 pm") });
        }

        public void RefreshPillList()
        {
            if (InvokeRequired)
            {
                this?.Invoke(new Action(RefreshPillList), new object[] { });
                return;
            }

            foreach(var pill in medications)
            {
                var timeToTakeToday = DateTime.Today + pill.TimeToTake.TimeOfDay;
                if (pill.LastTaken < timeToTakeToday && timeToTakeToday <= DateTime.Now)
                {
                    if (!pillsToTakeListBox.Items.Contains(pill))
                        pillsToTakeListBox.Items.Add(pill);
                }
            }
        }

        private Task PillRefresherTask()
        {
            while (true)
            {
                RefreshPillList();
                Thread.Sleep(1000);
            }
        }

        private void refreshPillsToTake_Click(object sender, EventArgs e)
        {
            RefreshPillList();
        }

        private void takePill_Click(object sender, EventArgs e)
        {
            PillModel pill = pillsToTakeListBox.SelectedItem as PillModel;
            pill.LastTaken = DateTime.Now;

            pillsToTakeListBox.Items.RemoveAt(pillsToTakeListBox.SelectedIndex);
        }
    }
}
