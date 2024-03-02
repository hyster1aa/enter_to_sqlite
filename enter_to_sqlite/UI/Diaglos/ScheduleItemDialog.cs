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
    public partial class ScheduleItemDialog : Form
    {
        public List<Route> routes = new List<Route>();
        private DataBase db;
        public ScheduleItem schItem;
        public ScheduleItemDialog(List<Route> routes, DataBase db, ScheduleItem scheduleItem)
        {
            InitializeComponent();
            this.routes = routes;
            this.db = db;
            schItem = scheduleItem;
            comboBox1.Items.AddRange(routes.ToArray());
            comboBox2.Items.AddRange(new[] { "Пассажирский", "Скоростной", "Скорый" });
            if (schItem != null )
            {
                textBox1.Text = schItem.id_train.ToString();
                comboBox1.SelectedIndex = routes.FindIndex(item => item.id_route.Equals(scheduleItem.routes.id_route));
                comboBox2.SelectedItem = scheduleItem.typeTrain;
                maskedTextBox1.Text = scheduleItem.timeStart;
                maskedTextBox2.Text = scheduleItem.timeTravel;
                maskedTextBox3.Text = scheduleItem.dateStart;
            }
            comboBox1.DisplayMember = "ToString";
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (textBox1.Text == "")
            {
                msg += "Укажите номер поезда.\n";
            }
            if (comboBox1.Text == "")
            {
                msg += "Выберите маршрут.\n";
            }
            if (comboBox2.Text == "")
            {
                msg += "Выберите тип поезда.\n";
            }
            if (!maskedTextBox1.MaskCompleted)
            {
                msg += "Укажите корректную дату отправления.\n";
            }
            if (!maskedTextBox2.MaskCompleted)
            {
                msg += "Укажите корректное время в пути.\n";
            }
            if (!maskedTextBox3.MaskCompleted)
            {
                msg += "Укажите корректную дату отправления.";
            }
            if (msg == string.Empty)
            {
                if (schItem != null)
                {
                    schItem = new ScheduleItem(schItem.id_travel, int.Parse(textBox1.Text), comboBox2.Text, comboBox1.SelectedItem as Route, maskedTextBox1.Text, maskedTextBox3.Text, maskedTextBox2.Text);
                    db.updateScheduleItem(schItem);
                }
                else
                {
                    schItem = new ScheduleItem(0, int.Parse(textBox1.Text), comboBox2.Text, comboBox1.SelectedItem as Route, maskedTextBox1.Text, maskedTextBox3.Text, maskedTextBox2.Text);
                    schItem.id_travel = db.insertScheduleItem(schItem);
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(msg);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(routes[comboBox1.SelectedIndex].id_route.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
