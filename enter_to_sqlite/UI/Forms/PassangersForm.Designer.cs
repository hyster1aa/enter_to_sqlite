namespace enter_to_sqlite.UI.Forms
{
    partial class PassengersForm
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
            listView1 = new ListView();
            fullNameColumn = new ColumnHeader();
            passportColumn = new ColumnHeader();
            benefitColumn = new ColumnHeader();
            panel1 = new Panel();
            addPassenger = new Button();
            editPassenger = new Button();
            deletePassenger = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { fullNameColumn, passportColumn, benefitColumn });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(351, 209);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // fullNameColumn
            // 
            fullNameColumn.Text = "ФИО";
            // 
            // passportColumn
            // 
            passportColumn.Text = "Паспорт";
            // 
            // benefitColumn
            // 
            benefitColumn.Text = "Льгота";
            // 
            // panel1
            // 
            panel1.Controls.Add(listView1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 215);
            panel1.TabIndex = 1;
            // 
            // addPassenger
            // 
            addPassenger.Location = new Point(12, 233);
            addPassenger.Name = "addPassenger";
            addPassenger.Size = new Size(116, 23);
            addPassenger.TabIndex = 2;
            addPassenger.Text = "Добавить";
            addPassenger.UseVisualStyleBackColor = true;
            addPassenger.Click += addPassenger_Click;
            // 
            // editPassenger
            // 
            editPassenger.Location = new Point(134, 233);
            editPassenger.Name = "editPassenger";
            editPassenger.Size = new Size(116, 23);
            editPassenger.TabIndex = 3;
            editPassenger.Text = "Изменить";
            editPassenger.UseVisualStyleBackColor = true;
            editPassenger.Click += editPassenger_Click;
            // 
            // deletePassenger
            // 
            deletePassenger.Location = new Point(256, 233);
            deletePassenger.Name = "deletePassenger";
            deletePassenger.Size = new Size(116, 23);
            deletePassenger.TabIndex = 4;
            deletePassenger.Text = "Удалить";
            deletePassenger.UseVisualStyleBackColor = true;
            deletePassenger.Click += deletePassenger_Click;
            // 
            // PassengersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 269);
            Controls.Add(deletePassenger);
            Controls.Add(editPassenger);
            Controls.Add(addPassenger);
            Controls.Add(panel1);
            Name = "PassengersForm";
            Text = "PassangersForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader fullNameColumn;
        private ColumnHeader passportColumn;
        private ColumnHeader benefitColumn;
        private Panel panel1;
        private Button addPassenger;
        private Button editPassenger;
        private Button deletePassenger;
    }
}