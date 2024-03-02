using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enter_to_sqlite.UI.Diaglos
{
    public partial class TicketDialogForm : Form
    {
        private List<ScheduleItem> schedule = new List<ScheduleItem>();
        private DataBase db;
        private List<Passenger> passengers = new List<Passenger>();
        private List<Ticket> tickets = new List<Ticket>();
        public Ticket ticket;
        public TicketDialogForm(List<ScheduleItem> schedule, DataBase db, List<Passenger> passengers, List<Ticket> tickets, Ticket ticket)
        {
            InitializeComponent();
            this.schedule = schedule;
            this.db = db;
            this.passengers = passengers;
            this.tickets = tickets;
            this.ticket = ticket;
            if(this.ticket != null)
            {

            }
            comboBox1.DisplayMember = "ToString";
            comboBox2.DisplayMember = "full_name";
            comboBox2.Items.AddRange(passengers.ToArray());
            comboBox1.Items.AddRange(schedule.ToArray());
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (comboBox1.Text == "")
            {
                msg += "выберите рейс.\n";
            }
            if (comboBox2.Text == "")
            {
                msg += "выберите пользователя.\n";
            }
            if (textBox1.Text == "")
            {
                msg += "Укажите номер вагона.\n";
            } else if (int.Parse(textBox1.Text) <= 0)
            {
                msg += "Номер вагона не может быть отрицательным или равным 0.\n";
            }
            if(textBox2.Text == "")
            {
                msg += "Укажите место.\n";
            } else if (int.Parse(textBox2.Text) <= 0) {
                msg += "Место не может быть отрицательным или равным 0.\n";
            }
            if(msg == string.Empty)
            {
                if (ticket == null)
                {
                    ticket = new Ticket(0, comboBox2.SelectedItem as Passenger, comboBox1.SelectedItem as ScheduleItem, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                    if (!tickets.Any(item => item.travelInformation.id_travel == ticket.travelInformation.id_travel && item.trainCarNumber == int.Parse(textBox1.Text) && item.trainCarPlaceNumber == int.Parse(textBox2.Text)))
                    {
                        ticket.id_ticket = db.insertTicket(ticket);
                        this.DialogResult = DialogResult.OK;
                    } else
                    {
                        MessageBox.Show("Место занято");
                        this.DialogResult = DialogResult.None;
                    }
                    
                } else
                {
                    ticket = new Ticket(ticket.id_ticket, comboBox2.SelectedItem as Passenger, comboBox1.SelectedItem as ScheduleItem, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                    if (!tickets.Any(item => item.travelInformation.id_travel == ticket.travelInformation.id_travel && item.trainCarNumber == int.Parse(textBox1.Text) && item.trainCarPlaceNumber == int.Parse(textBox2.Text) && item.passenger.id_p == ticket.passenger.id_p))
                    {
                        db.updateTicket(ticket);
                        this.DialogResult = DialogResult.OK;
                    } else
                    {
                        MessageBox.Show("Место занято");
                        this.DialogResult = DialogResult.None;
                    }
                }
            } else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(msg);
            }

        }
    }
}
