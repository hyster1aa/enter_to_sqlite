using WSSC.V4.SYS.Lib.Aspose;
using Aspose.Cells;
using System.Text;
using System.Runtime.CompilerServices;
using enter_to_sqlite.UI.Diaglos;
using enter_to_sqlite.Forms;
using enter_to_sqlite.UI.Forms;
using Newtonsoft.Json;
using enter_to_sqlite.BackUpClasses;
using System.Windows.Forms;
using System;

namespace enter_to_sqlite
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        List<City> cities = new List<City>();
        List<Passenger> passengers = new List<Passenger>();
        List<ScheduleItem> schedule = new List<ScheduleItem>();
        List<Ticket> tickets = new List<Ticket>();
        List<Route> routes = new List<Route>();
        public Form1()
        {
            InitializeComponent();
            db.initTables();

            string jsonString = File.ReadAllText("backup.json");
            var backUp = JsonConvert.DeserializeObject<BackUpRename>(jsonString);
            button2.Enabled = false;
            button3.Enabled = false;
            db.openConnection();
            cities = db.getCities();

            db.openConnection();
            tickets = db.getTickets();

            db.openConnection();
            db.getUsers();
            passengers = db.passengers;

            db.openConnection();
            schedule = db.getSchedule();

            routes = db.getRoutes();
            if (backUp.cities.Count > cities.Count)
            {
                foreach (var item in backUp.cities)
                {
                    if (!cities.Any(city => city.Id == item.Id))
                    {
                        cities.Add(item);
                        db.initTableCities(item);
                    }
                }
            }
            if (backUp.passengers.Count > passengers.Count)
            {
                foreach (var item in backUp.passengers)
                {
                    if (!passengers.Any(passenger => passenger.id_p == item.id_p))
                    {
                        passengers.Add(item);
                        db.initTableUsers(item);
                    }
                }
            }
            if (backUp.routes.Count > routes.Count)
            {
                foreach (var item in backUp.routes)
                {
                    if (!routes.Any(routeItem => routeItem.id_route == item.id_route))
                    {
                        db.initTableRoutes(item);
                    }
                }
                routes = db.getRoutes();
            }
            if (backUp.schedule.Count > schedule.Count)
            {
                foreach (var item in backUp.schedule)
                {
                    if (!schedule.Any(scheduleItem => scheduleItem.id_travel == item.id_travel))
                    {
                        db.initTableSchedule(item);
                    }
                }
                db.openConnection();
                schedule = db.getSchedule();
            }
            if (backUp.tickets.Count > tickets.Count)
            {
                foreach (var item in backUp.tickets)
                {
                    if (!tickets.Any(ticket => ticket.id_ticket == item.id_ticket))
                    {
                        db.initTableTicket(item);
                    }
                }
                db.openConnection();
                tickets = db.getTickets();
            }

            initListView(tickets);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            refreshComboBox(cities);
            cbDepPoint.DisplayMember = "Name";
            cbArrPoint.DisplayMember = "Name";

            initSchedule(schedule);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void refreshComboBox(List<City> cities)
        {

            cbDepPoint.Items.Clear();
            cbDepPoint.Items.Add("");
            cbDepPoint.SelectedIndex = 0;
            cbDepPoint.Items.AddRange(cities.Select(item => item.Name).ToArray());

            cbArrPoint.Items.Clear();
            cbArrPoint.Items.Add("");
            cbArrPoint.Items.AddRange(cities.Select(item => item.Name).ToArray());
            cbArrPoint.SelectedIndex = 0;
        }
        private void initSchedule(List<ScheduleItem> schedule)
        {
            listView2.Items.Clear();
            foreach (var item in schedule)
            {
                ListViewItem rowlv = new ListViewItem(new[] { item.typeTrain, item.dateStart, item.timeStart, item.routes.depPoint.Name, item.routes.arrPoint.Name });
                listView2.Items.Add(rowlv);
            }
        }
        private void initListView(List<Ticket> tickets)
        {
            listView1.Items.Clear();
            foreach (var ticket in tickets)
            {
                ListViewItem rowLv = new ListViewItem(new[] {ticket.passenger.full_name,ticket.passenger.passport,
                ticket.passenger.benefit ? "Да" : "Нет", ticket.travelInformation.typeTrain,
                ticket.travelInformation.routes.depPoint.Name,ticket.travelInformation.routes.arrPoint.Name, ticket.travelInformation.timeStart,
                ticket.travelInformation.dateStart, ticket.travelInformation.timeTravel,
                ticket.trainCarNumber.ToString(), ticket.trainCarPlaceNumber.ToString() });
                listView1.Items.Add(rowLv);
            }
        }

        private void refreshListViewFilter()
        {

            List<Ticket> ticketsWithFilter = new List<Ticket>();
            foreach (var item in tickets.Where(item => item.travelInformation.routes.depPoint.Name.Contains(cbDepPoint.SelectedItem.ToString())
                                                    && item.travelInformation.routes.arrPoint.Name.Contains(cbArrPoint.SelectedItem.ToString())
                                                    && (tbDateTravelMask.Text.StartsWith(' ') ? (item.travelInformation.dateStart.Contains(""))
                                                            : (item.travelInformation.dateStart.Contains(tbDateTravelMask.Text)))
                                                ))
            {
                if (benefitCheck.Checked && item.passenger.benefit)
                {
                    ticketsWithFilter.Add(item);
                    continue;
                }
                else if (!benefitCheck.Checked)
                {
                    ticketsWithFilter.Add(item);
                }
            }
            initListView(ticketsWithFilter);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            refreshListViewFilter();
        }

        private void tbDateTravelMask_TextChanged(object sender, EventArgs e)
        {
            if (tbDateTravelMask.MaskCompleted)
                refreshListViewFilter();
            else if (tbDateTravelMask.Text.StartsWith(' '))
            {
                refreshListViewFilter();
            }
        }

        private void cbDepPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepPoint.SelectedIndex != -1 && cbArrPoint.SelectedIndex != -1)
            {
                refreshListViewFilter();
            }

        }

        private void cbArrPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepPoint.SelectedIndex != -1 && cbArrPoint.SelectedIndex != -1)
            {
                refreshListViewFilter();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                groupBox1.Visible = false;
                tabControl1.Dock = DockStyle.Fill;
            }
            else
            {
                groupBox1.Visible = true;
                benefitCheck.Visible = true;
                tabControl1.Dock = DockStyle.Bottom;
            }
        }

        //https://blog.conholdate.com/ru/total/export-data-to-excel-in-csharp/
        private void createExcel_Click(object sender, EventArgs e)
        {
            AsposeContext.SetLicense<Aspose.Cells.License>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Workbook wb = new Workbook();
            Worksheet wsh = wb.Worksheets[0];
            wsh.Cells.ImportArray(new string[] { "Тип поезда", "Пункт отправления", "Пункт прибытия", "Дата отправления", "Время отправления" }, 0, 0, false);
            wsh.Cells.ImportCustomObjects((System.Collections.ICollection)tickets,
                new string[] { "typeTrain", "depPoint", "arrPoint", "dateStart", "timeStart" },
                false,
                1,
                0,
                schedule.Count,
                true,
                null,
                false);
            wb.Save("schedule.xlsx");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lv = listView1.SelectedItems[0];
            Ticket ticket = new Ticket(
                        tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].id_ticket,
                        new Passenger(
                                    tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].passenger.id_p,
                                    lv.SubItems[0].Text, lv.SubItems[1].Text,
                                    lv.SubItems[2].Text.Contains("Да") ? true : false
                                ),
                        new ScheduleItem(
                                tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].travelInformation.id_travel,
                                tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].travelInformation.id_train,
                                lv.SubItems[3].Text,
                                    new Route(
                                        tickets[listView1.Items
                                            .IndexOf(listView1.SelectedItems[0])]
                                            .travelInformation.routes.id_route,
                                        tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].travelInformation.routes.depPoint,
                                        tickets[listView1.Items.IndexOf(listView1.SelectedItems[0])].travelInformation.routes.arrPoint
                                    ),
                                lv.SubItems[6].Text,
                                lv.SubItems[7].Text,
                                lv.SubItems[8].Text
                            ),
                        int.Parse(lv.SubItems[9].Text),
                        int.Parse(lv.SubItems[10].Text)
                        );
            TicketInformation ticketForm = new TicketInformation(ticket);
            ticketForm.Show();
        }

        private void formCities_Click(object sender, EventArgs e)
        {
            CitiesForm citiesForm = new CitiesForm(cities, db);
            if (citiesForm.ShowDialog() == DialogResult.Cancel)
            {
                cities = citiesForm.list;
                refreshComboBox(cities);
            }

        }

        private void formPaths_Click(object sender, EventArgs e)
        {
            db.openConnection();
            routes = db.getRoutes();
            PathForm pathsForm = new PathForm(db, routes, cities, schedule);
            if (pathsForm.ShowDialog() == DialogResult.Cancel)
            {
                routes = pathsForm.routes;
                db.openConnection();
                initSchedule(db.getSchedule());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var backupschedule = new List<BackUpSchedule>();
            foreach (var item in schedule)
            {
                backupschedule.Add(new BackUpSchedule(item.id_travel, item.id_train, item.routes.id_route, item.typeTrain, item.timeStart, item.timeTravel, item.dateStart));
            }
            var backuptickets = new List<BackUpTickets>();
            foreach (var item in tickets)
            {
                backuptickets.Add(new BackUpTickets(item.id_ticket, item.travelInformation.id_travel, item.passenger.id_p, item.trainCarNumber, item.trainCarPlaceNumber));
            }
            var backupRoutes = new List<BackUpRoutes>();
            foreach (var item in routes)
            {
                backupRoutes.Add(new BackUpRoutes(item.id_route, item.depPoint.Id, item.arrPoint.Id));
            }
            var jf = JsonConvert.SerializeObject(new BackUpRename(cities, passengers, backupRoutes, backupschedule, backuptickets));
            File.WriteAllText("backup.json", jf);

        }

        private void formSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm scheduleForm = new ScheduleForm(schedule, routes, db, tickets);
            if (scheduleForm.ShowDialog() == DialogResult.Cancel)
            {
                initSchedule(schedule);
            }
        }

        private void formUsers_Click(object sender, EventArgs e)
        {
            PassengersForm passForm = new PassengersForm(passengers, db, tickets);
            if (passForm.ShowDialog() == DialogResult.Cancel)
            {
                tickets = db.getTickets();
                initListView(tickets);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketDialogForm ticketDialogForm = new TicketDialogForm(schedule, db, passengers, tickets, null);
            if (ticketDialogForm.ShowDialog() == DialogResult.OK)
            {
                var item = ticketDialogForm.ticket;
                tickets.Add(item);
                listView1.Items.Add(new ListViewItem(new string[] { item.passenger.full_name, item.passenger.passport, item.passenger.benefit ? "Да" : "Нет", item.travelInformation.typeTrain, item.travelInformation.routes.depPoint.Name, item.travelInformation.routes.arrPoint.Name, item.travelInformation.timeStart, item.travelInformation.dateStart, item.travelInformation.timeTravel, item.trainCarNumber.ToString(), item.trainCarPlaceNumber.ToString() }));

            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            int index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            TicketDialogForm ticketDialogForm = new TicketDialogForm(schedule, db, passengers, tickets, tickets[index]);
            if (ticketDialogForm.ShowDialog() == DialogResult.OK)
            {
                var item = ticketDialogForm.ticket;
                tickets[index] = ticketDialogForm.ticket;
                listView1.Items[index] = new ListViewItem(new string[] { item.passenger.full_name, item.passenger.passport, item.passenger.benefit ? "Да" : "Нет", item.travelInformation.typeTrain, item.travelInformation.routes.depPoint.Name, item.travelInformation.routes.arrPoint.Name, item.travelInformation.timeStart, item.travelInformation.dateStart, item.travelInformation.timeTravel, item.trainCarNumber.ToString(), item.trainCarPlaceNumber.ToString() });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            db.deleteTicket(tickets[index].id_ticket);
            tickets.RemoveAt(index);
            listView1.Items.RemoveAt(index);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            } else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
    }
}