
namespace minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menulbl = new System.Windows.Forms.Label();
            this.difficultygroupbox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.startgamebtn = new System.Windows.Forms.Button();
            this.difficultygroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menulbl
            // 
            this.menulbl.AutoSize = true;
            this.menulbl.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menulbl.Location = new System.Drawing.Point(317, 43);
            this.menulbl.Name = "menulbl";
            this.menulbl.Size = new System.Drawing.Size(164, 65);
            this.menulbl.TabIndex = 0;
            this.menulbl.Text = "MENU";
            // 
            // difficultygroupbox
            // 
            this.difficultygroupbox.Controls.Add(this.radioButton3);
            this.difficultygroupbox.Controls.Add(this.radioButton2);
            this.difficultygroupbox.Controls.Add(this.radioButton1);
            this.difficultygroupbox.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.difficultygroupbox.Location = new System.Drawing.Point(91, 111);
            this.difficultygroupbox.Name = "difficultygroupbox";
            this.difficultygroupbox.Size = new System.Drawing.Size(356, 504);
            this.difficultygroupbox.TabIndex = 4;
            this.difficultygroupbox.TabStop = false;
            this.difficultygroupbox.Text = "Difficulty:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(27, 365);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(130, 58);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hard";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(27, 230);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(191, 58);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Medium";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButton1.Location = new System.Drawing.Point(27, 103);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 58);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Easy";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // startgamebtn
            // 
            this.startgamebtn.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.startgamebtn.Location = new System.Drawing.Point(532, 193);
            this.startgamebtn.Name = "startgamebtn";
            this.startgamebtn.Size = new System.Drawing.Size(190, 103);
            this.startgamebtn.TabIndex = 3;
            this.startgamebtn.Text = "Start game";
            this.startgamebtn.UseVisualStyleBackColor = true;
            this.startgamebtn.Click += new System.EventHandler(this.startgamebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.startgamebtn);
            this.Controls.Add(this.difficultygroupbox);
            this.Controls.Add(this.menulbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.difficultygroupbox.ResumeLayout(false);
            this.difficultygroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menulbl;
        private System.Windows.Forms.GroupBox difficultygroupbox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button startgamebtn;
    }
}

