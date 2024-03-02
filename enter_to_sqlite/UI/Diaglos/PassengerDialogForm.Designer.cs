namespace enter_to_sqlite.UI.Diaglos
{
    partial class PassengerDialogForm
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(299, 61);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ФИО";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(12, 79);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(299, 69);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Паспорт";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Location = new Point(12, 154);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(299, 62);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Льгота";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(63, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Льгота";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(293, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 19);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(293, 23);
            textBox2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 222);
            button1.Name = "button1";
            button1.Size = new Size(296, 23);
            button1.TabIndex = 3;
            button1.Text = "ОК";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 251);
            button2.Name = "button2";
            button2.Size = new Size(296, 23);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // PassengerDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 281);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PassengerDialogForm";
            Text = "PassengerDialogForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private GroupBox groupBox3;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
    }
}