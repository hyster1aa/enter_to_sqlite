using enter_to_sqlite.UI.Diaglos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enter_to_sqlite.UI.Forms
{
    public partial class PathForm : Form
    {
        public List<City> cities = new List<City>();
        public List<Route> routes = new List<Route>();
        private DataBase db;
        public List<ScheduleItem> schedule = new List<ScheduleItem>();
        public PathForm(DataBase db, List<Route> routes, List<City> cities, List<ScheduleItem> schedule)
        {
            InitializeComponent();
            this.db = db;
            this.cities = cities;
            this.routes = routes;
            this.schedule = schedule;
            deleteRoute.Enabled = false;
            editRoute.Enabled = false;
            listRoutes.DisplayMember = "ToString";
            listRoutes.Items.AddRange(routes.ToArray());
        }

        private void addRoute_Click(object sender, EventArgs e)
        {
            RouteForm routeForm = new RouteForm(db, cities, routes, null);
            if (routeForm.ShowDialog() == DialogResult.OK)
            {
                routes.Add(routeForm.newRoute);
                listRoutes.Items.Add(routeForm.newRoute);
            }
        }

        private void editRoute_Click(object sender, EventArgs e)
        {
            RouteForm routeForm = new RouteForm(db, cities, routes, routes[listRoutes.SelectedIndex]);
            if (routeForm.ShowDialog() == DialogResult.OK)
            {
                routes[listRoutes.SelectedIndex] = routeForm.newRoute;
                listRoutes.Items[listRoutes.SelectedIndex] = routeForm.newRoute;
            }
        }

        private void deleteRoute_Click(object sender, EventArgs e)
        {
            if (!schedule.Any(item => item.routes.Equals(routes[listRoutes.SelectedIndex])))
            {
                db.DeleteRoute(routes[listRoutes.SelectedIndex].id_route);
                routes.RemoveAt(listRoutes.SelectedIndex);
                listRoutes.Items.RemoveAt(listRoutes.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Невозможно удалить. Маршрут указан в расписании!");
            }
        }

        private void listRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listRoutes.SelectedIndex != -1)
            {
                deleteRoute.Enabled = true;
                editRoute.Enabled = true;
            }else
            {
                deleteRoute.Enabled = false;
                editRoute.Enabled = false;
            }
        }
    }
}
