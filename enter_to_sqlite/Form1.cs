using WSSC.V4.SYS.Lib.Aspose;
using Aspose.Cells;
using System.Text;
using System.Runtime.CompilerServices;
using enter_to_sqlite.UI.Diaglos;
using enter_to_sqlite.Forms;

namespace enter_to_sqlite
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();

        List<City> cities = new List<City>();
        public Form1()
        {
            InitializeComponent();
            

            refreshComboBox();
            cbDepPoint.DisplayMember = "Name";
            cbArrPoint.DisplayMember = "Name";
            db.openConnection();
            db.getTickets();


            initListView(db.tickets);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            db.openConnection();
            db.getSchedule();
            initSchedule(db.schedule);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void refreshComboBox()
        {
            db.openConnection();
            cities = db.getCities();
            cbDepPoint.Items.Clear();
            cbDepPoint.Items.Add("");
            cbDepPoint.SelectedIndex = 0;
            cbDepPoint.Items.AddRange(cities.ToArray());

            cbArrPoint.Items.Clear();
            cbArrPoint.Items.Add("");
            cbArrPoint.Items.AddRange(cities.ToArray());
            cbArrPoint.SelectedIndex = 0;
        }
        private void initSchedule(List<schedule> schedule)
        {
            foreach (var item in schedule)
            {
                ListViewItem rowlv = new ListViewItem(new[] { item.typeTrain, item.dateStart, item.timeStart, item.depPoint, item.arrPoint });
                listView2.Items.Add(rowlv);
            }
        }
        private void initListView(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                ListViewItem rowLv = new ListViewItem(new[] {ticket.passenger.full_name,ticket.passenger.passport,
                ticket.passenger.benefit ? "Да" : "Нет", ticket.travelInformation.typeTrain,
                ticket.travelInformation.depPoint,ticket.travelInformation.arrPoint, ticket.travelInformation.timeStart,
                ticket.travelInformation.dateStart, ticket.travelInformation.timeTravel,
                ticket.trainCarNumber.ToString(), ticket.trainCarPlaceNumber.ToString() });
                listView1.Items.Add(rowLv);
            }
        }

        private void refreshListViewFilter()
        {
            listView1.Items.Clear();
            List<Ticket> tickets = new List<Ticket>();
            foreach (var item in db.tickets.Where(item => item.travelInformation.depPoint.Contains(cbDepPoint.SelectedItem.ToString())
                                                    && item.travelInformation.arrPoint.Contains(cbArrPoint.SelectedItem.ToString())
                                                    && (tbDateTravelMask.Text.StartsWith(' ') ? (item.travelInformation.dateStart.Contains(""))
                                                            : (item.travelInformation.dateStart.Contains(tbDateTravelMask.Text)))
                                                ))
            {
                if (benefitCheck.Checked && item.passenger.benefit)
                {
                    tickets.Add(item);
                    continue;
                }
                else if (!benefitCheck.Checked)
                {
                    tickets.Add(item);
                }
            }
            initListView(tickets);
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
            refreshListViewFilter();
        }

        private void cbArrPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshListViewFilter();
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
            wsh.Cells.ImportCustomObjects((System.Collections.ICollection)db.schedule,
                new string[] { "typeTrain", "depPoint", "arrPoint", "dateStart", "timeStart" },
                false,
                1,
                0,
                db.schedule.Count,
                true,
                null,
                false);
            wb.Save("schedule.xlsx");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lv = listView1.SelectedItems[0];
            Ticket ticket = new Ticket(new Passenger(
                                                lv.SubItems[0].Text, lv.SubItems[1].Text,
                                                lv.SubItems[2].Text.Contains("Да") ? true : false),
                                        new schedule(
                                                lv.SubItems[3].Text, lv.SubItems[4].Text,
                                                lv.SubItems[5].Text, lv.SubItems[6].Text,
                                                lv.SubItems[7].Text, lv.SubItems[8].Text),
                                        int.Parse(lv.SubItems[9].Text),
                                        int.Parse(lv.SubItems[10].Text)
                                       );
            TicketInformation ticketForm = new TicketInformation(ticket);
            ticketForm.Show();
        }

        private void formCities_Click(object sender, EventArgs e)
        {
            CitiesForm citiesForm = new CitiesForm(cities, db);
            if(citiesForm.ShowDialog() == DialogResult.Cancel)
            {
                refreshComboBox();
            }
            
        }
    }
}