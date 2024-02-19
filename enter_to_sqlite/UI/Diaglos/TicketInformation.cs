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
    public partial class TicketInformation : Form
    {
        public TicketInformation(Ticket ticketInformation)
        {
            InitializeComponent();
            labelFullName.Text = ticketInformation.passenger.full_name;
            label3.Text = ticketInformation.passenger.passport;
            label5.Text = ticketInformation.passenger.benefit ? "Присутствует" : "Отсутствует";
            label15.Text = $"Вагон №{ticketInformation.trainCarNumber}";
            label17.Text = $"Место №{ticketInformation.trainCarPlaceNumber}";
            label7.Text = ticketInformation.travelInformation.depPoint;
            label9.Text = ticketInformation.travelInformation.arrPoint;
            label11.Text = ticketInformation.travelInformation.dateStart;
            label13.Text = ticketInformation.travelInformation.typeTrain;
            label20.Text = ticketInformation.travelInformation.timeStart;
            label21.Text = $"{ticketInformation.travelInformation.timeTravel} ч";
        }
    }
}
