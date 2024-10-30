namespace Clock
{
    partial class AddAlarm
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
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxWeek = new System.Windows.Forms.CheckedListBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonChoosFile = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.checkBoxExactDate = new System.Windows.Forms.CheckBox();
            this.openFileDialogSound = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerDate.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.dateTimePickerDate.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerDate.CalendarTrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dateTimePickerDate.Enabled = false;
            this.dateTimePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(12, 40);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerDate.Size = new System.Drawing.Size(139, 35);
            this.dateTimePickerDate.TabIndex = 0;
            // 
            // checkedListBoxWeek
            // 
            this.checkedListBoxWeek.BackColor = System.Drawing.Color.CornflowerBlue;
            this.checkedListBoxWeek.CheckOnClick = true;
            this.checkedListBoxWeek.ColumnWidth = 55;
            this.checkedListBoxWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxWeek.FormattingEnabled = true;
            this.checkedListBoxWeek.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб",
            "Вс"});
            this.checkedListBoxWeek.Location = new System.Drawing.Point(12, 81);
            this.checkedListBoxWeek.MultiColumn = true;
            this.checkedListBoxWeek.Name = "checkedListBoxWeek";
            this.checkedListBoxWeek.Size = new System.Drawing.Size(402, 25);
            this.checkedListBoxWeek.TabIndex = 1;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileName.Location = new System.Drawing.Point(12, 123);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(66, 16);
            this.labelFileName.TabIndex = 2;
            this.labelFileName.Text = "Filename:";
            this.labelFileName.TextChanged += new System.EventHandler(this.labelFileName_TextChanged);
            // 
            // buttonChoosFile
            // 
            this.buttonChoosFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChoosFile.Location = new System.Drawing.Point(12, 142);
            this.buttonChoosFile.Name = "buttonChoosFile";
            this.buttonChoosFile.Size = new System.Drawing.Size(112, 28);
            this.buttonChoosFile.TabIndex = 3;
            this.buttonChoosFile.Text = "Выбрать файл";
            this.buttonChoosFile.UseVisualStyleBackColor = true;
            this.buttonChoosFile.Click += new System.EventHandler(this.buttonChoosFile_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(339, 147);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 4;
            this.buttonCansel.Text = "Cansel";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(258, 147);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerTime.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.dateTimePickerTime.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dateTimePickerTime.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerTime.CalendarTrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dateTimePickerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(275, 40);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(139, 35);
            this.dateTimePickerTime.TabIndex = 6;
            // 
            // checkBoxExactDate
            // 
            this.checkBoxExactDate.AutoSize = true;
            this.checkBoxExactDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxExactDate.Location = new System.Drawing.Point(12, 13);
            this.checkBoxExactDate.Name = "checkBoxExactDate";
            this.checkBoxExactDate.Size = new System.Drawing.Size(160, 20);
            this.checkBoxExactDate.TabIndex = 7;
            this.checkBoxExactDate.Text = "На конкретную дату";
            this.checkBoxExactDate.UseVisualStyleBackColor = true;
            this.checkBoxExactDate.CheckedChanged += new System.EventHandler(this.checkBoxExactDate_CheckedChanged);
            // 
            // openFileDialogSound
            // 
            this.openFileDialogSound.FileName = "openFileDialog1";
            // 
            // AddAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImage = global::Clock.Properties.Resources.фон_атом_часы;
            this.ClientSize = new System.Drawing.Size(423, 180);
            this.Controls.Add(this.checkBoxExactDate);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonChoosFile);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.checkedListBoxWeek);
            this.Controls.Add(this.dateTimePickerDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddAlarm";
            this.Load += new System.EventHandler(this.AddAlarm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.CheckedListBox checkedListBoxWeek;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonChoosFile;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.CheckBox checkBoxExactDate;
        private System.Windows.Forms.OpenFileDialog openFileDialogSound;
    }
}