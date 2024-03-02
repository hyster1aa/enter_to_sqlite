using enter_to_sqlite.UI.Diaglos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace enter_to_sqlite.UI.Forms
{
    public partial class ScheduleForm : Form
    {
        public List<ScheduleItem> schedule = new List<ScheduleItem>();
        public List<Route> routes = new List<Route>();
        private DataBase db;
        private List<Ticket> tickets = new List<Ticket>();
        public ScheduleForm(List<ScheduleItem> schedule, List<Route> routes, DataBase db, List<Ticket> tickets)
        {
            InitializeComponent();
            this.db = db;
            this.schedule = schedule;
            this.routes = routes;
            this.tickets = tickets;
            editScheduleItem.Enabled = false;
            deleteScheduleItem.Enabled = false;
            initListSchedule();
            listSchedule.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void initListSchedule()
        {
            listSchedule.Items.Clear();
            foreach (var item in schedule)
            {
                ListViewItem rowlv = new ListViewItem(new[] { item.id_train.ToString(), item.routes.id_route.ToString(), item.typeTrain, item.timeStart, item.timeTravel, item.dateStart });
                listSchedule.Items.Add(rowlv);
            }
            listSchedule.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void addScheduleItem_Click(object sender, EventArgs e)
        {
            ScheduleItemDialog newItem = new ScheduleItemDialog(routes, db, null);
            if (newItem.ShowDialog() == DialogResult.OK)
            {
                schedule.Add(newItem.schItem);
                ListViewItem rowlv = new ListViewItem(new[] { newItem.schItem.id_train.ToString(), newItem.schItem.routes.id_route.ToString(), newItem.schItem.typeTrain, newItem.schItem.timeStart, newItem.schItem.timeTravel, newItem.schItem.dateStart });
                listSchedule.Items.Add(rowlv);
            }
        }

        private void editScheduleItem_Click(object sender, EventArgs e)
        {
            int index = listSchedule.Items.IndexOf(listSchedule.SelectedItems[0]);
            ScheduleItemDialog newItem = new ScheduleItemDialog(routes, db, schedule[listSchedule.SelectedIndices[0]]);
            if (newItem.ShowDialog() == DialogResult.OK)
            {
                schedule[index] = newItem.schItem;
                listSchedule.Items[index] = new ListViewItem(new[] { newItem.schItem.id_train.ToString(), newItem.schItem.routes.id_route.ToString(), newItem.schItem.typeTrain, newItem.schItem.timeStart, newItem.schItem.timeTravel, newItem.schItem.dateStart });
            }
        }

        private void deleteScheduleItem_Click(object sender, EventArgs e)
        {
            int index = listSchedule.Items.IndexOf(listSchedule.SelectedItems[0]);
            if (!tickets.Any(item => item.travelInformation.id_travel.Equals(schedule[index].id_travel)))
            {
                db.DeleteScheduleItem(schedule[index].id_travel);
                schedule.RemoveAt(index);
                listSchedule.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Невозможно удалить. На данный рейс куплены билеты!");
            }
        }

        private void listSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSchedule.SelectedIndices.Count > 0)
            {
                editScheduleItem.Enabled = true;
                deleteScheduleItem.Enabled = true;
            }
            else
            {
                editScheduleItem.Enabled = false;
                deleteScheduleItem.Enabled = false;
            }
        }
    }
}
