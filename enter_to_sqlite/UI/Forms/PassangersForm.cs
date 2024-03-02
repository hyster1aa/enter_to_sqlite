using enter_to_sqlite.UI.Diaglos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace enter_to_sqlite.UI.Forms
{
    public partial class PassengersForm : Form
    {
        private List<Passenger> passengers = new List<Passenger>();
        private DataBase db;
        private List<Ticket> tickets = new List<Ticket>();
        public PassengersForm(List<Passenger> passengers, DataBase db, List<Ticket> tickets)
        {
            InitializeComponent();
            this.db = db;
            this.passengers = passengers;
            this.tickets = tickets;
            editPassenger.Enabled = false;
            deletePassenger.Enabled = false;
            foreach (var item in passengers)
            {
                listView1.Items.Add(new ListViewItem(new[] { item.full_name, item.passport, item.benefit ? "Да" : "Нет" }));
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void addPassenger_Click(object sender, EventArgs e)
        {
            PassengerDialogForm pdf = new PassengerDialogForm(passengers, null, db);
            if (pdf.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Add(new ListViewItem(new[] { pdf.passenger.full_name, pdf.passenger.passport, pdf.passenger.benefit ? "Да" : "Нет" }));
                passengers.Add(pdf.passenger);
            }
        }

        private void editPassenger_Click(object sender, EventArgs e)
        {
            int index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            PassengerDialogForm pdf = new PassengerDialogForm(passengers, passengers[index], db);
            if (pdf.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(passengers[index].benefit.ToString());

                listView1.Items[index] = new ListViewItem(new[] { pdf.passenger.full_name, pdf.passenger.passport, pdf.passenger.benefit ? "Да" : "Нет" });
                passengers[index] = pdf.passenger;
                MessageBox.Show(passengers[index].benefit.ToString());
            }
        }

        private void deletePassenger_Click(object sender, EventArgs e)
        {
            int index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            if (!tickets.Any(item => item.passenger.id_p.Equals(passengers[index].id_p)))
            {
                listView1.Items.RemoveAt(index);
                db.deletePassenger(passengers[index].id_p);
                passengers.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Невозможно удалить. На пользователя зарегистрирован билет!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count > 0)
            {
                editPassenger.Enabled = true;
                deletePassenger.Enabled = true;
            } else
            {
                editPassenger.Enabled = false;
                deletePassenger.Enabled = false;
            }
        }
    }
}
