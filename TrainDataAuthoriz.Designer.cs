namespace Social_Processor
{
    partial class TrainDataAuthoriz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainDataAuthoriz));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.stop_traning = new System.Windows.Forms.Button();
            this.start_detecting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 475);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.stop_traning);
            this.tabPage2.Controls.Add(this.start_detecting);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.imageBoxFrameGrabber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(352, 449);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Security Mangament";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 364);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(320, 73);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "Please Notes :\nAsk any one appered on the seen of camera gone for a while,\nUse a " +
    "Good Camera and Light to Extract Good Feature,\nWe advice to take several Image t" +
    "o traine of classifier. ";
            // 
            // stop_traning
            // 
            this.stop_traning.Location = new System.Drawing.Point(211, 18);
            this.stop_traning.Name = "stop_traning";
            this.stop_traning.Size = new System.Drawing.Size(86, 23);
            this.stop_traning.TabIndex = 32;
            this.stop_traning.Text = "Stop Training";
            this.stop_traning.UseVisualStyleBackColor = true;
            // 
            // start_detecting
            // 
            this.start_detecting.Location = new System.Drawing.Point(55, 18);
            this.start_detecting.Name = "start_detecting";
            this.start_detecting.Size = new System.Drawing.Size(86, 23);
            this.start_detecting.TabIndex = 31;
            this.start_detecting.Text = "Start Training";
            this.start_detecting.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(44, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 36);
            this.button1.TabIndex = 30;
            this.button1.Text = "Add New Image Training";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(17, 47);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(320, 240);
            this.imageBoxFrameGrabber.TabIndex = 29;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // TrainDataAuthoriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 475);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainDataAuthoriz";
            this.Text = "User Managment";
            this.Load += new System.EventHandler(this.UserManagment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button stop_traning;
        private System.Windows.Forms.Button start_detecting;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
    }
}