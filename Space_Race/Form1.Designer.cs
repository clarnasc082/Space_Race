
namespace Space_Race
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.rocket1ScoreLabel = new System.Windows.Forms.Label();
            this.rocket2ScoreLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.winnrLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // rocket1ScoreLabel
            // 
            this.rocket1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.rocket1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rocket1ScoreLabel.ForeColor = System.Drawing.Color.Green;
            this.rocket1ScoreLabel.Location = new System.Drawing.Point(130, 350);
            this.rocket1ScoreLabel.Name = "rocket1ScoreLabel";
            this.rocket1ScoreLabel.Size = new System.Drawing.Size(53, 48);
            this.rocket1ScoreLabel.TabIndex = 4;
            // 
            // rocket2ScoreLabel
            // 
            this.rocket2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.rocket2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rocket2ScoreLabel.ForeColor = System.Drawing.Color.Green;
            this.rocket2ScoreLabel.Location = new System.Drawing.Point(510, 341);
            this.rocket2ScoreLabel.Name = "rocket2ScoreLabel";
            this.rocket2ScoreLabel.Size = new System.Drawing.Size(59, 48);
            this.rocket2ScoreLabel.TabIndex = 5;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(211, 103);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(189, 23);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "SPACE RACE :)";
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitleLabel.ForeColor = System.Drawing.Color.Green;
            this.subTitleLabel.Location = new System.Drawing.Point(211, 203);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(291, 39);
            this.subTitleLabel.TabIndex = 7;
            this.subTitleLabel.Text = "Space to start, escape to exit";
            // 
            // winnrLabel
            // 
            this.winnrLabel.BackColor = System.Drawing.Color.Transparent;
            this.winnrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnrLabel.ForeColor = System.Drawing.Color.Green;
            this.winnrLabel.Location = new System.Drawing.Point(211, 148);
            this.winnrLabel.Name = "winnrLabel";
            this.winnrLabel.Size = new System.Drawing.Size(291, 39);
            this.winnrLabel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(674, 398);
            this.Controls.Add(this.winnrLabel);
            this.Controls.Add(this.subTitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.rocket2ScoreLabel);
            this.Controls.Add(this.rocket1ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label rocket1ScoreLabel;
        private System.Windows.Forms.Label rocket2ScoreLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label winnrLabel;
    }
}

