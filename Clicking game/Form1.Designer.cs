namespace Clicking_game
{
    partial class Form1
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
            this.stopbutton = new System.Windows.Forms.Button();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stopbutton
            // 
            this.stopbutton.Location = new System.Drawing.Point(341, 402);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(107, 36);
            this.stopbutton.TabIndex = 0;
            this.stopbutton.Text = "Завершити";
            this.stopbutton.UseVisualStyleBackColor = true;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Location = new System.Drawing.Point(358, 180);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(115, 16);
            this.gameOverLabel.TabIndex = 1;
            this.gameOverLabel.Text = "Гру завершено...\r\n";
            this.gameOverLabel.Visible = false;
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(341, 350);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(107, 36);
            this.restartButton.TabIndex = 2;
            this.restartButton.Text = "Повторити";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Visible = false;
            //this.restartButton.Click += new System.EventHandler(this.restartButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.stopbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopbutton;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button restartButton;
    }
}

