namespace enter_to_sqlite.UI.Diaglos
{
    partial class ScheduleItemDialog
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
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            maskedTextBox3 = new MaskedTextBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new Point(5, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 52);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Маршрут";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(194, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 19);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(194, 23);
            comboBox2.TabIndex = 2;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Dock = DockStyle.Fill;
            maskedTextBox1.Location = new Point(3, 19);
            maskedTextBox1.Mask = "00:00:00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(194, 23);
            maskedTextBox1.TabIndex = 3;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Dock = DockStyle.Fill;
            maskedTextBox2.Location = new Point(3, 19);
            maskedTextBox2.Mask = "00:00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(194, 23);
            maskedTextBox2.TabIndex = 4;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Dock = DockStyle.Fill;
            maskedTextBox3.Location = new Point(3, 19);
            maskedTextBox3.Mask = "0000-00-00";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(194, 23);
            maskedTextBox3.TabIndex = 5;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Location = new Point(5, 102);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 52);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Тип поезда";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(maskedTextBox1);
            groupBox4.Location = new Point(5, 150);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 52);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Времят отправления";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(maskedTextBox2);
            groupBox5.Location = new Point(5, 198);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(200, 52);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Время в пути";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(maskedTextBox3);
            groupBox6.Location = new Point(5, 246);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(200, 52);
            groupBox6.TabIndex = 9;
            groupBox6.TabStop = false;
            groupBox6.Text = "Дата отправления";
            // 
            // button1
            // 
            button1.Location = new Point(5, 304);
            button1.Name = "button1";
            button1.Size = new Size(200, 23);
            button1.TabIndex = 10;
            button1.Text = "ОК";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(5, 333);
            button2.Name = "button2";
            button2.Size = new Size(200, 23);
            button2.TabIndex = 11;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 52);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Номер поезда";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // ScheduleItemDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(210, 363);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ScheduleItemDialog";
            Text = "ScheduleItemDialog";
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox3;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private TextBox textBox1;
    }
}