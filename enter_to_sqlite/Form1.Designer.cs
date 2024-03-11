namespace enter_to_sqlite
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            benefitCheck = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            listView1 = new ListView();
            passengerName = new ColumnHeader();
            passengerPassport = new ColumnHeader();
            passengerBenefit = new ColumnHeader();
            typeTrain = new ColumnHeader();
            depPoint = new ColumnHeader();
            arrPoint = new ColumnHeader();
            timeStart = new ColumnHeader();
            dataStart = new ColumnHeader();
            timeTravel = new ColumnHeader();
            trainCarNumber = new ColumnHeader();
            trainCarPlaceNumber = new ColumnHeader();
            label3 = new Label();
            label4 = new Label();
            tbDateTravelMask = new MaskedTextBox();
            cbDepPoint = new ComboBox();
            cbArrPoint = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            formUsers = new Button();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            createExcel = new Button();
            formSchedule = new Button();
            formPaths = new Button();
            formCities = new Button();
            listView2 = new ListView();
            scheduleTypeTrain = new ColumnHeader();
            scheduleDateStart = new ColumnHeader();
            scheduleTimeStart = new ColumnHeader();
            schDepPoint = new ColumnHeader();
            schArrPoint = new ColumnHeader();
            saveFileDialog1 = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // benefitCheck
            // 
            benefitCheck.AutoSize = true;
            benefitCheck.Location = new Point(429, 39);
            benefitCheck.Name = "benefitCheck";
            benefitCheck.Size = new Size(63, 19);
            benefitCheck.TabIndex = 2;
            benefitCheck.Text = "Льгота";
            benefitCheck.UseVisualStyleBackColor = true;
            benefitCheck.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 5;
            label1.Text = "Пункт отправления";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(180, 16);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { passengerName, passengerPassport, passengerBenefit, typeTrain, depPoint, arrPoint, timeStart, dataStart, timeTravel, trainCarNumber, trainCarPlaceNumber });
            listView1.Dock = DockStyle.Bottom;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(3, 150);
            listView1.Name = "listView1";
            listView1.Size = new Size(813, 294);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // passengerName
            // 
            passengerName.Text = "ФИО";
            // 
            // passengerPassport
            // 
            passengerPassport.Text = "Паспорт";
            // 
            // passengerBenefit
            // 
            passengerBenefit.Text = "Льгота";
            // 
            // typeTrain
            // 
            typeTrain.Text = "Тип поезда";
            // 
            // depPoint
            // 
            depPoint.Text = "Пункт отправления";
            // 
            // arrPoint
            // 
            arrPoint.Text = "Пункт прибытия";
            // 
            // timeStart
            // 
            timeStart.Text = "Время отправелния";
            // 
            // dataStart
            // 
            dataStart.Text = "Дата отправления";
            // 
            // timeTravel
            // 
            timeTravel.Text = "Время в пути";
            // 
            // trainCarNumber
            // 
            trainCarNumber.Text = "Номер вагона";
            // 
            // trainCarPlaceNumber
            // 
            trainCarPlaceNumber.Text = "Номер места";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 19);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 8;
            label3.Text = "Пункт прибытия";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 19);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Дата отправления";
            // 
            // tbDateTravelMask
            // 
            tbDateTravelMask.Location = new Point(287, 37);
            tbDateTravelMask.Mask = "0000-00-00";
            tbDateTravelMask.Name = "tbDateTravelMask";
            tbDateTravelMask.Size = new Size(88, 23);
            tbDateTravelMask.TabIndex = 10;
            tbDateTravelMask.TextChanged += tbDateTravelMask_TextChanged;
            // 
            // cbDepPoint
            // 
            cbDepPoint.FormattingEnabled = true;
            cbDepPoint.Location = new Point(6, 39);
            cbDepPoint.Name = "cbDepPoint";
            cbDepPoint.Size = new Size(121, 23);
            cbDepPoint.TabIndex = 12;
            cbDepPoint.SelectedIndexChanged += cbDepPoint_SelectedIndexChanged;
            // 
            // cbArrPoint
            // 
            cbArrPoint.FormattingEnabled = true;
            cbArrPoint.Location = new Point(142, 39);
            cbArrPoint.Name = "cbArrPoint";
            cbArrPoint.Size = new Size(121, 23);
            cbArrPoint.TabIndex = 13;
            cbArrPoint.SelectedIndexChanged += cbArrPoint_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(827, 475);
            tabControl1.TabIndex = 14;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(listView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(819, 447);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Билеты";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Left;
            button3.Location = new Point(257, 113);
            button3.Name = "button3";
            button3.Size = new Size(127, 37);
            button3.TabIndex = 18;
            button3.Text = "Удалить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Left;
            button2.Location = new Point(130, 113);
            button2.Name = "button2";
            button2.Size = new Size(127, 37);
            button2.TabIndex = 17;
            button2.Text = "Изменить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(3, 113);
            button1.Name = "button1";
            button1.Size = new Size(127, 37);
            button1.TabIndex = 16;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(formUsers);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbDepPoint);
            groupBox1.Controls.Add(cbArrPoint);
            groupBox1.Controls.Add(tbDateTravelMask);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(benefitCheck);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(813, 110);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // formUsers
            // 
            formUsers.Location = new Point(689, 15);
            formUsers.Name = "formUsers";
            formUsers.Size = new Size(121, 43);
            formUsers.TabIndex = 14;
            formUsers.Text = "Управление пользователями";
            formUsers.UseVisualStyleBackColor = true;
            formUsers.Click += formUsers_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(listView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(819, 447);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Расписание";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(createExcel);
            panel1.Controls.Add(formSchedule);
            panel1.Controls.Add(formPaths);
            panel1.Controls.Add(formCities);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(813, 94);
            panel1.TabIndex = 1;
            // 
            // createExcel
            // 
            createExcel.Location = new Point(688, 3);
            createExcel.Name = "createExcel";
            createExcel.Size = new Size(122, 40);
            createExcel.TabIndex = 12;
            createExcel.Text = "Отчет";
            createExcel.UseVisualStyleBackColor = true;
            // 
            // formSchedule
            // 
            formSchedule.Location = new Point(133, 3);
            formSchedule.Name = "formSchedule";
            formSchedule.Size = new Size(122, 40);
            formSchedule.TabIndex = 2;
            formSchedule.Text = "Управление расписанием";
            formSchedule.UseVisualStyleBackColor = true;
            formSchedule.Click += formSchedule_Click;
            // 
            // formPaths
            // 
            formPaths.Location = new Point(5, 49);
            formPaths.Name = "formPaths";
            formPaths.Size = new Size(122, 40);
            formPaths.TabIndex = 1;
            formPaths.Text = "Управление маршрутами";
            formPaths.UseVisualStyleBackColor = true;
            formPaths.Click += formPaths_Click;
            // 
            // formCities
            // 
            formCities.Location = new Point(5, 3);
            formCities.Name = "formCities";
            formCities.Size = new Size(122, 40);
            formCities.TabIndex = 0;
            formCities.Text = "Управление списком городов";
            formCities.UseVisualStyleBackColor = true;
            formCities.Click += formCities_Click;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { scheduleTypeTrain, scheduleDateStart, scheduleTimeStart, schDepPoint, schArrPoint });
            listView2.Dock = DockStyle.Bottom;
            listView2.Location = new Point(3, 103);
            listView2.Name = "listView2";
            listView2.Size = new Size(813, 341);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // scheduleTypeTrain
            // 
            scheduleTypeTrain.Text = "Тип поезда";
            // 
            // scheduleDateStart
            // 
            scheduleDateStart.Text = "Дата отправления";
            // 
            // scheduleTimeStart
            // 
            scheduleTimeStart.Text = "Время отправления";
            // 
            // schDepPoint
            // 
            schDepPoint.Text = "Пункт отправления";
            // 
            // schArrPoint
            // 
            schArrPoint.Text = "Пункт прибытия";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 475);
            Controls.Add(tabControl1);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox benefitCheck;
        private Label label1;
        private Label label2;
        private ListView listView1;
        private ColumnHeader passengerName;
        private ColumnHeader passengerPassport;
        private ColumnHeader passengerBenefit;
        private ColumnHeader typeTrain;
        private ColumnHeader depPoint;
        private ColumnHeader arrPoint;
        private ColumnHeader timeStart;
        private ColumnHeader dataStart;
        private ColumnHeader timeTravel;
        private ColumnHeader trainCarNumber;
        private ColumnHeader trainCarPlaceNumber;
        private Label label3;
        private Label label4;
        private MaskedTextBox tbDateTravelMask;
        private ComboBox cbDepPoint;
        private ComboBox cbArrPoint;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView listView2;
        private ColumnHeader scheduleTypeTrain;
        private ColumnHeader scheduleDateStart;
        private ColumnHeader scheduleTimeStart;
        private ColumnHeader schDepPoint;
        private ColumnHeader schArrPoint;
        private GroupBox groupBox1;
        private Button formUsers;
        private Panel panel1;
        private Button createExcel;
        private Button formSchedule;
        private Button formPaths;
        private Button formCities;
        private SaveFileDialog saveFileDialog1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}