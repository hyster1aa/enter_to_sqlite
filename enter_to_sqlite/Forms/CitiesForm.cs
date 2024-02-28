using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enter_to_sqlite.Forms
{
    public partial class CitiesForm : Form
    {
        private List<string> list = new List<string>();
        public CitiesForm(List<string> currentCities)
        {
            InitializeComponent();
            list = currentCities;
            editCity.Enabled = false;
            deleteCity.Enabled = false;
            //listCities.Items.Clear();
            listCities.Items.AddRange(list.ToArray());
        }

        private void listCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCities.SelectedIndex != -1)
            {
                editCity.Enabled = true;
                deleteCity.Enabled = true;
                textBox1.Text = list[listCities.SelectedIndex];
            }
            else
            {
                editCity.Enabled = false;
                deleteCity.Enabled = false;
            }
        }

        private void addCity_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length > 0)
            {
                if (!list.Contains(textBox1.Text.Trim()))
                {
                    list.Add(textBox1.Text.Trim());
                    listCities.Items.Add(textBox1.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Город уже есть в списке.");
                }

            }
            else
            {
                MessageBox.Show("Невозможно добавить пустое значение");
            }
        }

        private void editCity_Click(object sender, EventArgs e)
        {
            int index = listCities.SelectedIndex;
            if (textBox1.Text.Trim().Length > 0)
            {
                if(list[listCities.SelectedIndex] == textBox1.Text.Trim())
                {
                } else if (!list.Contains(textBox1.Text.Trim()))
                {
                    list[listCities.SelectedIndex] = textBox1.Text.Trim();
                    listCities.Items[index] = textBox1.Text.Trim();
                } else
                {
                    MessageBox.Show("Город уже есть в списке.");
                }
            }
            else
            {
                MessageBox.Show("Невозможно изменить на пустое значение");
            }
        }

        private void deleteCity_Click(object sender, EventArgs e)
        {

        }
    }
}
