namespace WindowsFormsApplication1
{
    partial class GetQuantityDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.uldNUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uldL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uldNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(43, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 37);
            this.button1.TabIndex = 26;
            this.button1.Text = "Цэнэглэх";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uldNUD
            // 
            this.uldNUD.Location = new System.Drawing.Point(130, 58);
            this.uldNUD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.uldNUD.Name = "uldNUD";
            this.uldNUD.Size = new System.Drawing.Size(48, 20);
            this.uldNUD.TabIndex = 25;
            this.uldNUD.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Цэнэглэх тоо";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Үлдэгдэл: ";
            // 
            // uldL
            // 
            this.uldL.AutoSize = true;
            this.uldL.Location = new System.Drawing.Point(127, 30);
            this.uldL.Name = "uldL";
            this.uldL.Size = new System.Drawing.Size(0, 13);
            this.uldL.TabIndex = 28;
            // 
            // GetQuantityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 169);
            this.Controls.Add(this.uldL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uldNUD);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetQuantityDialog";
            this.Text = "GetQuantityDialog";
            ((System.ComponentModel.ISupportInitialize)(this.uldNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown uldNUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uldL;
    }
}