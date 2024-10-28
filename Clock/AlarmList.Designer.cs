namespace Clock
{
    partial class AlarmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmList));
            this.listBoxAlarms = new System.Windows.Forms.ListBox();
            this.buttonAddAlarm = new System.Windows.Forms.Button();
            this.buttonDeletAlarms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAlarms
            // 
            this.listBoxAlarms.FormattingEnabled = true;
            this.listBoxAlarms.Location = new System.Drawing.Point(12, 12);
            this.listBoxAlarms.Name = "listBoxAlarms";
            this.listBoxAlarms.Size = new System.Drawing.Size(447, 251);
            this.listBoxAlarms.TabIndex = 0;
            // 
            // buttonAddAlarm
            // 
            this.buttonAddAlarm.Location = new System.Drawing.Point(465, 12);
            this.buttonAddAlarm.Name = "buttonAddAlarm";
            this.buttonAddAlarm.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAlarm.TabIndex = 1;
            this.buttonAddAlarm.Text = "Add";
            this.buttonAddAlarm.UseVisualStyleBackColor = true;
            this.buttonAddAlarm.Click += new System.EventHandler(this.buttonAddAlarm_Click);
            // 
            // buttonDeletAlarms
            // 
            this.buttonDeletAlarms.Location = new System.Drawing.Point(465, 41);
            this.buttonDeletAlarms.Name = "buttonDeletAlarms";
            this.buttonDeletAlarms.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletAlarms.TabIndex = 2;
            this.buttonDeletAlarms.Text = "Delete";
            this.buttonDeletAlarms.UseVisualStyleBackColor = true;
            this.buttonDeletAlarms.Click += new System.EventHandler(this.buttonDeletAlarms_Click);
            // 
            // AlarmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 274);
            this.Controls.Add(this.buttonDeletAlarms);
            this.Controls.Add(this.buttonAddAlarm);
            this.Controls.Add(this.listBoxAlarms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlarmList";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxAlarms;
        private System.Windows.Forms.Button buttonAddAlarm;
        private System.Windows.Forms.Button buttonDeletAlarms;
    }
}