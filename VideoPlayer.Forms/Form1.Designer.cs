namespace VideoPlayer.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.stream2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.stream1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.stream2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stream1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(698, 145);
            this.button1.TabIndex = 1;
            this.button1.Text = "Switch Xamarin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(73, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(698, 145);
            this.button2.TabIndex = 1;
            this.button2.Text = "SwitchWeb";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // stream2
            // 
            this.stream2.Enabled = true;
            this.stream2.Location = new System.Drawing.Point(3, 298);
            this.stream2.Name = "stream2";
            this.stream2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("stream2.OcxState")));
            this.stream2.Size = new System.Drawing.Size(520, 281);
            this.stream2.TabIndex = 0;
            // 
            // stream1
            // 
            this.stream1.Enabled = true;
            this.stream1.Location = new System.Drawing.Point(3, 3);
            this.stream1.Name = "stream1";
            this.stream1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("stream1.OcxState")));
            this.stream1.Size = new System.Drawing.Size(520, 289);
            this.stream1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.stream1);
            this.flowLayoutPanel1.Controls.Add(this.stream2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(59, 464);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(743, 1098);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 1811);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stream2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stream1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer stream1;
        private AxWMPLib.AxWindowsMediaPlayer stream2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

