namespace project
{
    partial class SimpleCalcul
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
            this.btndelete = new System.Windows.Forms.Button();
            this.btnequals = new System.Windows.Forms.Button();
            this.btndot = new System.Windows.Forms.Button();
            this.btnmul = new System.Windows.Forms.Button();
            this.btnplus = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(251, 187);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(77, 53);
            this.btndelete.TabIndex = 16;
            this.btndelete.Text = "Del";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnequals
            // 
            this.btnequals.Location = new System.Drawing.Point(478, 328);
            this.btnequals.Name = "btnequals";
            this.btnequals.Size = new System.Drawing.Size(77, 53);
            this.btnequals.TabIndex = 8;
            this.btnequals.Text = "=";
            this.btnequals.UseVisualStyleBackColor = true;
            this.btnequals.Click += new System.EventHandler(this.btnequals_Click);
            // 
            // btndot
            // 
            this.btndot.Location = new System.Drawing.Point(478, 257);
            this.btndot.Name = "btndot";
            this.btndot.Size = new System.Drawing.Size(77, 53);
            this.btndot.TabIndex = 9;
            this.btndot.Text = ".";
            this.btndot.UseVisualStyleBackColor = true;
            this.btndot.Click += new System.EventHandler(this.btndot_Click);
            // 
            // btnmul
            // 
            this.btnmul.Location = new System.Drawing.Point(364, 187);
            this.btnmul.Name = "btnmul";
            this.btnmul.Size = new System.Drawing.Size(77, 53);
            this.btnmul.TabIndex = 10;
            this.btnmul.Text = "*";
            this.btnmul.UseVisualStyleBackColor = true;
            this.btnmul.Click += new System.EventHandler(this.btnmul_Click);
            // 
            // btnplus
            // 
            this.btnplus.Location = new System.Drawing.Point(478, 187);
            this.btnplus.Name = "btnplus";
            this.btnplus.Size = new System.Drawing.Size(77, 53);
            this.btnplus.TabIndex = 11;
            this.btnplus.Text = "+";
            this.btnplus.UseVisualStyleBackColor = true;
            this.btnplus.Click += new System.EventHandler(this.btnplus_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(251, 257);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(77, 53);
            this.btn3.TabIndex = 12;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(364, 257);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(77, 53);
            this.btn2.TabIndex = 13;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(364, 328);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(77, 53);
            this.btn1.TabIndex = 14;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(251, 328);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(77, 53);
            this.btn0.TabIndex = 15;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(235, 90);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Size = new System.Drawing.Size(330, 81);
            this.tbDisplay.TabIndex = 7;
            this.tbDisplay.TextChanged += new System.EventHandler(this.tbDisplay_TextChanged);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(674, 398);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 6;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // SimpleCalcul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnequals);
            this.Controls.Add(this.btndot);
            this.Controls.Add(this.btnmul);
            this.Controls.Add(this.btnplus);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.btnback);
            this.Name = "SimpleCalcul";
            this.Text = "SimpleCalcul";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnequals;
        private System.Windows.Forms.Button btndot;
        private System.Windows.Forms.Button btnmul;
        private System.Windows.Forms.Button btnplus;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button btnback;
    }
}