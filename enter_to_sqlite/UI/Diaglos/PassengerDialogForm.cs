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
    public partial class PassengerDialogForm : Form
    {
        private List<Passenger> passengers = new List<Passenger>();
        public Passenger passenger;
        private DataBase db;
        private string oldname;
        public PassengerDialogForm(List<Passenger>passengers, Passenger passenger, DataBase db)
        {
            InitializeComponent();
            this.passengers = passengers;
            this.passenger = passenger;
            this.db = db;
            if(this.passenger != null)
            {
                oldname = passenger.full_name;
                textBox1.Text = passenger.full_name;
                textBox2.Text = passenger.passport;
                if (passenger.benefit)
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if(textBox1.Text =="")
            {
                msg += "Укажите ФИО.\n";
            }
            if(textBox2.Text =="")
            {
                msg += "Укажите паспорт";
            }
            if(msg == string.Empty)
            {
                
                if (passenger != null)
                {
                    if (passengers.Any(item => item.passport.Contains(textBox2.Text) && item.full_name != textBox1.Text && item.full_name != oldname))
                    {
                        MessageBox.Show("Пользователь с таким паспортными данными уже существует в базе. Задумайтесь!");
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        passenger = new Passenger(passenger.id_p, textBox1.Text, textBox2.Text, checkBox1.Checked ? true : false);
                        db.updatePassenger(passenger);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    passenger = new Passenger(0, textBox1.Text, textBox2.Text, checkBox1.Checked ? true : false);
                    if (passengers.Any(item => item.passport.Contains(textBox2.Text)) )
                    {
                        MessageBox.Show("Пользователь с таким паспортными данными уже существует в базе. Задумайтесь!");
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        passenger.id_p = db.insertPassenger(passenger);
                        this.DialogResult = DialogResult.OK;
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
