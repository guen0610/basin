namespace WindowsFormsApplication1
{
    partial class Alert
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
            this.alertText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // alertText
            // 
            this.alertText.AutoSize = true;
            this.alertText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.alertText.Location = new System.Drawing.Point(58, 115);
            this.alertText.Name = "alertText";
            this.alertText.Size = new System.Drawing.Size(202, 25);
            this.alertText.TabIndex = 0;
            this.alertText.Text = "Амжилттай боллоо";
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 290);
            this.Controls.Add(this.alertText);
            this.Name = "Alert";
            this.Text = "Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label alertText;
    }
}