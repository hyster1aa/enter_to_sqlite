namespace enter_to_sqlite.UI.Forms
{
    partial class ScheduleForm
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
            listSchedule = new ListView();
            idTrainColumn = new ColumnHeader();
            idRouteColumn = new ColumnHeader();
            typeTrainColumn = new ColumnHeader();
            timeStartColumn = new ColumnHeader();
            timeTravelColumn = new ColumnHeader();
            dateStartColumn = new ColumnHeader();
            addScheduleItem = new Button();
            editScheduleItem = new Button();
            deleteScheduleItem = new Button();
            SuspendLayout();
            // 
            // listSchedule
            // 
            listSchedule.Columns.AddRange(new ColumnHeader[] { idTrainColumn, idRouteColumn, typeTrainColumn, timeStartColumn, timeTravelColumn, dateStartColumn });
            listSchedule.Dock = DockStyle.Bottom;
            listSchedule.FullRowSelect = true;
            listSchedule.Location = new Point(0, 32);
            listSchedule.Name = "listSchedule";
            listSchedule.Size = new Size(800, 418);
            listSchedule.TabIndex = 1;
            listSchedule.UseCompatibleStateImageBehavior = false;
            listSchedule.View = View.Details;
            listSchedule.SelectedIndexChanged += listSchedule_SelectedIndexChanged;
            // 
            // idTrainColumn
            // 
            idTrainColumn.Text = "Номер поезда";
            // 
            // idRouteColumn
            // 
            idRouteColumn.Text = "Номер маршрута";
            // 
            // typeTrainColumn
            // 
            typeTrainColumn.Text = "Тип поезда";
            // 
            // timeStartColumn
            // 
            timeStartColumn.Text = "Время отправления";
            // 
            // timeTravelColumn
            // 
            timeTravelColumn.Text = "Время в пути";
            // 
            // dateStartColumn
            // 
            dateStartColumn.Text = "Дата отправеления";
            // 
            // addScheduleItem
            // 
            addScheduleItem.Location = new Point(5, 3);
            addScheduleItem.Name = "addScheduleItem";
            addScheduleItem.Size = new Size(137, 23);
            addScheduleItem.TabIndex = 2;
            addScheduleItem.Text = "Добавить";
            addScheduleItem.UseVisualStyleBackColor = true;
            addScheduleItem.Click += addScheduleItem_Click;
            // 
            // editScheduleItem
            // 
            editScheduleItem.Location = new Point(148, 3);
            editScheduleItem.Name = "editScheduleItem";
            editScheduleItem.Size = new Size(137, 23);
            editScheduleItem.TabIndex = 3;
            editScheduleItem.Text = "Изменить";
            editScheduleItem.UseVisualStyleBackColor = true;
            editScheduleItem.Click += editScheduleItem_Click;
            // 
            // deleteScheduleItem
            // 
            deleteScheduleItem.Location = new Point(291, 3);
            deleteScheduleItem.Name = "deleteScheduleItem";
            deleteScheduleItem.Size = new Size(137, 23);
            deleteScheduleItem.TabIndex = 4;
            deleteScheduleItem.Text = "Удалить";
            deleteScheduleItem.UseVisualStyleBackColor = true;
            deleteScheduleItem.Click += deleteScheduleItem_Click;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteScheduleItem);
            Controls.Add(editScheduleItem);
            Controls.Add(addScheduleItem);
            Controls.Add(listSchedule);
            Name = "ScheduleForm";
            Text = "ScheduleForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView listSchedule;
        private Button addScheduleItem;
        private Button editScheduleItem;
        private Button deleteScheduleItem;
        private ColumnHeader idTrainColumn;
        private ColumnHeader idRouteColumn;
        private ColumnHeader typeTrainColumn;
        private ColumnHeader timeStartColumn;
        private ColumnHeader timeTravelColumn;
        private ColumnHeader dateStartColumn;
    }
}