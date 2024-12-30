namespace CAR_REBTAL_SYSTEM_PROJECT
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Myprogress = new CircularProgressBar.CircularProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Myprogress
            // 
            this.Myprogress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.Myprogress.AnimationSpeed = 500;
            this.Myprogress.BackColor = System.Drawing.Color.Transparent;
            this.Myprogress.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Myprogress.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.Myprogress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Myprogress.InnerColor = System.Drawing.Color.Transparent;
            this.Myprogress.InnerMargin = 2;
            this.Myprogress.InnerWidth = -1;
            this.Myprogress.Location = new System.Drawing.Point(227, 275);
            this.Myprogress.MarqueeAnimationSpeed = 2000;
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.OuterColor = System.Drawing.Color.Gray;
            this.Myprogress.OuterMargin = -25;
            this.Myprogress.OuterWidth = 26;
            this.Myprogress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.Myprogress.ProgressWidth = 25;
            this.Myprogress.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.Myprogress.Size = new System.Drawing.Size(140, 135);
            this.Myprogress.StartAngle = 270;
            this.Myprogress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.Myprogress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.Myprogress.SubscriptText = ".23";
            this.Myprogress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.Myprogress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.Myprogress.SuperscriptText = "°C";
            this.Myprogress.TabIndex = 0;
            this.Myprogress.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.Myprogress.Value = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "CAR RENTAL MANNAGEMENT";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Myprogress);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CircularProgressBar.CircularProgressBar Myprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

