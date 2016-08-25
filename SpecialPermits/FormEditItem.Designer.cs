namespace SpecialPermits
{
    partial class FormEditItem
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelMonster = new System.Windows.Forms.Label();
            this.numericTickets = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(133, 67);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(9, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelMonster
            // 
            this.labelMonster.AutoSize = true;
            this.labelMonster.Location = new System.Drawing.Point(35, 31);
            this.labelMonster.Name = "labelMonster";
            this.labelMonster.Size = new System.Drawing.Size(35, 13);
            this.labelMonster.TabIndex = 2;
            this.labelMonster.Text = "label1";
            // 
            // numericTickets
            // 
            this.numericTickets.Location = new System.Drawing.Point(106, 28);
            this.numericTickets.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericTickets.Name = "numericTickets";
            this.numericTickets.Size = new System.Drawing.Size(52, 20);
            this.numericTickets.TabIndex = 3;
            this.numericTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 102);
            this.Controls.Add(this.numericTickets);
            this.Controls.Add(this.labelMonster);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditItem";
            this.Text = "Editing Tickets For: ";
            this.Load += new System.EventHandler(this.FormEditItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelMonster;
        private System.Windows.Forms.NumericUpDown numericTickets;
    }
}