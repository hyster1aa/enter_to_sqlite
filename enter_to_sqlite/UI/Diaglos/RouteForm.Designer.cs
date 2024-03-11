namespace enter_to_sqlite.UI.Diaglos
{
    partial class RouteForm
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
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            addRouteButton = new Button();
            cancelRouteButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(235, 64);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Откуда";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(223, 23);
            comboBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(235, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Куда";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(6, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(223, 23);
            comboBox2.TabIndex = 0;
            // 
            // addRouteButton
            // 
            addRouteButton.DialogResult = DialogResult.OK;
            addRouteButton.Dock = DockStyle.Left;
            addRouteButton.Location = new Point(0, 129);
            addRouteButton.Name = "addRouteButton";
            addRouteButton.Size = new Size(115, 41);
            addRouteButton.TabIndex = 2;
            addRouteButton.Text = "ОК";
            addRouteButton.UseVisualStyleBackColor = true;
            addRouteButton.Click += addRouteButton_Click;
            // 
            // cancelRouteButton
            // 
            cancelRouteButton.DialogResult = DialogResult.Cancel;
            cancelRouteButton.Dock = DockStyle.Right;
            cancelRouteButton.Location = new Point(121, 129);
            cancelRouteButton.Name = "cancelRouteButton";
            cancelRouteButton.Size = new Size(114, 41);
            cancelRouteButton.TabIndex = 3;
            cancelRouteButton.Text = "Отмена";
            cancelRouteButton.UseVisualStyleBackColor = true;
            // 
            // RouteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 170);
            Controls.Add(cancelRouteButton);
            Controls.Add(addRouteButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "RouteForm";
            Text = "RouteForm";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private ComboBox comboBox2;
        private Button addRouteButton;
        private Button cancelRouteButton;
    }
}