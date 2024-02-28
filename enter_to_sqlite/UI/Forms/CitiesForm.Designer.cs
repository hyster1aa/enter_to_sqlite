namespace enter_to_sqlite.Forms
{
    partial class CitiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            deleteCity = new Button();
            editCity = new Button();
            addCity = new Button();
            textBox1 = new TextBox();
            listCities = new ListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(deleteCity);
            groupBox1.Controls.Add(editCity);
            groupBox1.Controls.Add(addCity);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(listCities);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(504, 412);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Список городов";
            // 
            // deleteCity
            // 
            deleteCity.Location = new Point(396, 374);
            deleteCity.Name = "deleteCity";
            deleteCity.Size = new Size(102, 23);
            deleteCity.TabIndex = 4;
            deleteCity.Text = "Удалить";
            deleteCity.UseVisualStyleBackColor = true;
            deleteCity.Click += deleteCity_Click;
            // 
            // editCity
            // 
            editCity.Location = new Point(288, 374);
            editCity.Name = "editCity";
            editCity.Size = new Size(102, 23);
            editCity.TabIndex = 3;
            editCity.Text = "Изменить";
            editCity.UseVisualStyleBackColor = true;
            editCity.Click += editCity_Click;
            // 
            // addCity
            // 
            addCity.Location = new Point(180, 374);
            addCity.Name = "addCity";
            addCity.Size = new Size(102, 23);
            addCity.TabIndex = 2;
            addCity.Text = "Добавить";
            addCity.UseVisualStyleBackColor = true;
            addCity.Click += addCity_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 374);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 23);
            textBox1.TabIndex = 1;
            // 
            // listCities
            // 
            listCities.Dock = DockStyle.Top;
            listCities.FormattingEnabled = true;
            listCities.ItemHeight = 15;
            listCities.Location = new Point(3, 19);
            listCities.Name = "listCities";
            listCities.Size = new Size(498, 349);
            listCities.TabIndex = 0;
            listCities.SelectedIndexChanged += listCities_SelectedIndexChanged;
            // 
            // CitiesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 412);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "CitiesForm";
            Text = "Управление городами";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button deleteCity;
        private Button editCity;
        private Button addCity;
        private TextBox textBox1;
        private ListBox listCities;
    }
}