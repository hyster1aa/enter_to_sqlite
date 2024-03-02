using Microsoft.VisualBasic;
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
    public partial class RouteForm : Form
    {
        private Route route;
        private DataBase db;
        public List<Route> routes = new List<Route>();
        public List<City> cities = new List<City>();
        public RouteForm(DataBase db, List<City> cities, List<Route>routes, Route route)
        {
            InitializeComponent();
            this.db = db;
            this.routes = routes;
            this.cities = cities;
            this.route = route;
            comboBox1.DisplayMember = "Name";
            comboBox1.Items.AddRange(cities.ToArray());
            comboBox2.DisplayMember = "Name";
            comboBox2.Items.AddRange(cities.ToArray());
            if(this.route != null)
            {
                comboBox1.SelectedIndex = cities.FindIndex(item => item.Equals(route.depPoint));
                comboBox2.SelectedIndex = cities.FindIndex(item => item.Equals(route.arrPoint));
            }
        }
        public Route newRoute => new Route(db.getLastRowIdRoute(), comboBox1.SelectedItem as City, comboBox2.SelectedItem as City);

        private void addRouteButton_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (comboBox1.SelectedIndex == -1)
            {
                msg += "Необходимо выбрать пункт отправления.\n";
            }
            if (comboBox2.SelectedIndex == -1)
            {
                msg += "Необходимо выбрать пункт прибытия.";
            }
            if (msg =="")
            {
                if (!routes.Any(item => item.depPoint.Equals(comboBox1.SelectedItem) && item.arrPoint == comboBox2.SelectedItem))
                {
                    if(route == null)
                    {
                        db.insertRoute(cities[comboBox1.SelectedIndex].Id, cities[comboBox2.SelectedIndex].Id);
                    } else
                    {
                        db.UpdateRoute(cities[comboBox1.SelectedIndex].Id, cities[comboBox2.SelectedIndex].Id, route.id_route);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Маршрут уже существует");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show(msg);
                this.DialogResult = DialogResult.None;
            }
            
        }
    }
}
