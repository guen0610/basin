namespace WindowsFormsApplication1
{
    partial class AddUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.phoneTB = new System.Windows.Forms.TextBox();
            this.uldNUD = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.cardIndicatorL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uldNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Овог";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Нэр";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Утас";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Үлдэгдэл";
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(101, 29);
            this.lastNameTB.MaxLength = 20;
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(120, 20);
            this.lastNameTB.TabIndex = 4;
            this.lastNameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(101, 58);
            this.nameTB.MaxLength = 20;
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(120, 20);
            this.nameTB.TabIndex = 5;
            this.nameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // phoneTB
            // 
            this.phoneTB.Location = new System.Drawing.Point(101, 88);
            this.phoneTB.MaxLength = 8;
            this.phoneTB.Name = "phoneTB";
            this.phoneTB.Size = new System.Drawing.Size(120, 20);
            this.phoneTB.TabIndex = 6;
            this.phoneTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // uldNUD
            // 
            this.uldNUD.Location = new System.Drawing.Point(101, 118);
            this.uldNUD.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.uldNUD.Name = "uldNUD";
            this.uldNUD.Size = new System.Drawing.Size(120, 20);
            this.uldNUD.TabIndex = 7;
            this.uldNUD.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(29, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 68);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cardIndicatorL
            // 
            this.cardIndicatorL.AutoSize = true;
            this.cardIndicatorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cardIndicatorL.Location = new System.Drawing.Point(50, 267);
            this.cardIndicatorL.Name = "cardIndicatorL";
            this.cardIndicatorL.Size = new System.Drawing.Size(147, 25);
            this.cardIndicatorL.TabIndex = 9;
            this.cardIndicatorL.Text = "Карт таниулах";
            this.cardIndicatorL.Visible = false;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 335);
            this.Controls.Add(this.cardIndicatorL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uldNUD);
            this.Controls.Add(this.phoneTB);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.Text = "Хэрэглэгч нэмэх";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUserForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.uldNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lastNameTB;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox phoneTB;
        private System.Windows.Forms.NumericUpDown uldNUD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label cardIndicatorL;
    }
}