namespace DailyChessPuzzle
{
    partial class Welcome
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
            this.btnKepler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.radIntermediate = new System.Windows.Forms.RadioButton();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKepler
            // 
            this.btnKepler.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnKepler.FlatAppearance.BorderSize = 10;
            this.btnKepler.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Bold);
            this.btnKepler.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnKepler.Location = new System.Drawing.Point(12, 102);
            this.btnKepler.Name = "btnKepler";
            this.btnKepler.Size = new System.Drawing.Size(250, 66);
            this.btnKepler.TabIndex = 0;
            this.btnKepler.Text = "KEPLER";
            this.btnKepler.UseVisualStyleBackColor = true;
            this.btnKepler.MouseEnter += new System.EventHandler(this.TeamSelect_MouseEnter);
            this.btnKepler.MouseLeave += new System.EventHandler(this.TeamSelect_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Outfit", 8.25F);
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Daily Chess Puzzle. As we have detected that this is you first time pl" +
    "aying, please\r\nselect what House Team you are from, and what Difficulty you woul" +
    "d like to compete in.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Outfit", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "WELCOME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(274, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "NEWTON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseEnter += new System.EventHandler(this.TeamSelect_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.TeamSelect_MouseLeave);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.BorderSize = 10;
            this.button2.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(274, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 66);
            this.button2.TabIndex = 5;
            this.button2.Text = "FARADAY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseEnter += new System.EventHandler(this.TeamSelect_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.TeamSelect_MouseLeave);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button3.FlatAppearance.BorderSize = 10;
            this.button3.Font = new System.Drawing.Font("Montserrat Black", 16F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Gold;
            this.button3.Location = new System.Drawing.Point(12, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 66);
            this.button3.TabIndex = 4;
            this.button3.Text = "KELVIN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseEnter += new System.EventHandler(this.TeamSelect_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.TeamSelect_MouseLeave);
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHard.Location = new System.Drawing.Point(384, 251);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(141, 20);
            this.radHard.TabIndex = 11;
            this.radHard.TabStop = true;
            this.radHard.Text = "HARD (2000+ ELO)";
            this.radHard.UseVisualStyleBackColor = true;
            // 
            // radIntermediate
            // 
            this.radIntermediate.AutoSize = true;
            this.radIntermediate.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIntermediate.Location = new System.Drawing.Point(150, 251);
            this.radIntermediate.Name = "radIntermediate";
            this.radIntermediate.Size = new System.Drawing.Size(228, 20);
            this.radIntermediate.TabIndex = 10;
            this.radIntermediate.TabStop = true;
            this.radIntermediate.Text = "INTERMEDIATE (1400-2000 ELO)";
            this.radIntermediate.UseVisualStyleBackColor = true;
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Checked = true;
            this.radEasy.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEasy.Location = new System.Drawing.Point(10, 251);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(134, 20);
            this.radEasy.TabIndex = 9;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "EASY (-1400 ELO)";
            this.radEasy.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Outfit", 8.25F);
            this.btnSelect.Location = new System.Drawing.Point(150, 282);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(245, 39);
            this.btnSelect.TabIndex = 68;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 333);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.radHard);
            this.Controls.Add(this.radIntermediate);
            this.Controls.Add(this.radEasy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKepler);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKepler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radHard;
        private System.Windows.Forms.RadioButton radIntermediate;
        private System.Windows.Forms.RadioButton radEasy;
        private System.Windows.Forms.Button btnSelect;
    }
}