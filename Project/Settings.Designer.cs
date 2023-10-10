namespace DailyChessPuzzle
{
    partial class Settings
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
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.radIntermediate = new System.Windows.Forms.RadioButton();
            this.radHard = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Outfit", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "SETTINGS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Outfit", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Difficulty:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Outfit", 8.25F);
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Note: When EASY difficulty is selected, you will earn 3 points. When MEDIUM diffi" +
    "culty is\r\nselected, you will earn 6 points. When HARD difficult is selected, you" +
    " will earn 9 points.";
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEasy.Location = new System.Drawing.Point(19, 155);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(134, 20);
            this.radEasy.TabIndex = 6;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "EASY (-1400 ELO)";
            this.radEasy.UseVisualStyleBackColor = true;
            this.radEasy.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // radIntermediate
            // 
            this.radIntermediate.AutoSize = true;
            this.radIntermediate.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIntermediate.Location = new System.Drawing.Point(19, 181);
            this.radIntermediate.Name = "radIntermediate";
            this.radIntermediate.Size = new System.Drawing.Size(228, 20);
            this.radIntermediate.TabIndex = 7;
            this.radIntermediate.TabStop = true;
            this.radIntermediate.Text = "INTERMEDIATE (1400-2000 ELO)";
            this.radIntermediate.UseVisualStyleBackColor = true;
            this.radIntermediate.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // radHard
            // 
            this.radHard.AutoSize = true;
            this.radHard.Font = new System.Drawing.Font("Outfit", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHard.Location = new System.Drawing.Point(19, 207);
            this.radHard.Name = "radHard";
            this.radHard.Size = new System.Drawing.Size(141, 20);
            this.radHard.TabIndex = 8;
            this.radHard.TabStop = true;
            this.radHard.Text = "HARD (2000+ ELO)";
            this.radHard.UseVisualStyleBackColor = true;
            this.radHard.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 39);
            this.button2.TabIndex = 67;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 306);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radHard);
            this.Controls.Add(this.radIntermediate);
            this.Controls.Add(this.radEasy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radEasy;
        private System.Windows.Forms.RadioButton radIntermediate;
        private System.Windows.Forms.RadioButton radHard;
        private System.Windows.Forms.Button button2;
    }
}