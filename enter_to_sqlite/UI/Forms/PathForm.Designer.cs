namespace enter_to_sqlite.UI.Forms
{
    partial class PathForm
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
            listRoutes = new ListBox();
            addRoute = new Button();
            editRoute = new Button();
            deleteRoute = new Button();
            SuspendLayout();
            // 
            // listRoutes
            // 
            listRoutes.Dock = DockStyle.Top;
            listRoutes.FormattingEnabled = true;
            listRoutes.ItemHeight = 15;
            listRoutes.Location = new Point(0, 0);
            listRoutes.Name = "listRoutes";
            listRoutes.Size = new Size(325, 154);
            listRoutes.TabIndex = 0;
            listRoutes.SelectedIndexChanged += listRoutes_SelectedIndexChanged;
            // 
            // addRoute
            // 
            addRoute.Location = new Point(0, 160);
            addRoute.Name = "addRoute";
            addRoute.Size = new Size(103, 23);
            addRoute.TabIndex = 1;
            addRoute.Text = "Добавить";
            addRoute.UseVisualStyleBackColor = true;
            addRoute.Click += addRoute_Click;
            // 
            // editRoute
            // 
            editRoute.Location = new Point(109, 160);
            editRoute.Name = "editRoute";
            editRoute.Size = new Size(107, 23);
            editRoute.TabIndex = 2;
            editRoute.Text = "Изменить";
            editRoute.UseVisualStyleBackColor = true;
            editRoute.Click += editRoute_Click;
            // 
            // deleteRoute
            // 
            deleteRoute.Location = new Point(222, 160);
            deleteRoute.Name = "deleteRoute";
            deleteRoute.Size = new Size(103, 23);
            deleteRoute.TabIndex = 3;
            deleteRoute.Text = "Удалить";
            deleteRoute.UseVisualStyleBackColor = true;
            deleteRoute.Click += deleteRoute_Click;
            // 
            // PathForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 193);
            Controls.Add(deleteRoute);
            Controls.Add(editRoute);
            Controls.Add(addRoute);
            Controls.Add(listRoutes);
            Name = "PathForm";
            Text = "Управление маршрутами";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listRoutes;
        private Button addRoute;
        private Button editRoute;
        private Button deleteRoute;
    }
}