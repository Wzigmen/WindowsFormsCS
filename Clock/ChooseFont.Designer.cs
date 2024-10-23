namespace Clock
{
    partial class ChooseFont
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
            this.OK = new System.Windows.Forms.Button();
            this.labelExample = new System.Windows.Forms.Label();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(220, 156);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(70, 22);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // labelExample
            // 
            this.labelExample.AutoSize = true;
            this.labelExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExample.Location = new System.Drawing.Point(12, 68);
            this.labelExample.Name = "labelExample";
            this.labelExample.Size = new System.Drawing.Size(152, 55);
            this.labelExample.TabIndex = 1;
            this.labelExample.Text = "label1";
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.FormattingEnabled = true;
            this.comboBoxFonts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(365, 21);
            this.comboBoxFonts.TabIndex = 2;
            this.comboBoxFonts.SelectedValueChanged += new System.EventHandler(this.comboBoxFont_SelectedValueChanged);
            // 
            // Cansel
            // 
            this.Cansel.Location = new System.Drawing.Point(296, 156);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(70, 22);
            this.Cansel.TabIndex = 3;
            this.Cansel.Text = "Cansel";
            this.Cansel.UseVisualStyleBackColor = true;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // ChooseFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 190);
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.comboBoxFonts);
            this.Controls.Add(this.labelExample);
            this.Controls.Add(this.OK);
            this.Name = "ChooseFont";
            this.Text = "ChooseFont";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label labelExample;
        private System.Windows.Forms.ComboBox comboBoxFonts;
        private System.Windows.Forms.Button Cansel;
    }
}