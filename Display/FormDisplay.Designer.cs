namespace MultipleScreen.Display
{
    partial class FormDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisplay));
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.PicPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Browser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(3, 61);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(415, 222);
            this.Player.TabIndex = 3;
            this.Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange);
            // 
            // PicPanel
            // 
            this.PicPanel.BackColor = System.Drawing.Color.Transparent;
            this.PicPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicPanel.Location = new System.Drawing.Point(449, 72);
            this.PicPanel.Name = "PicPanel";
            this.PicPanel.Size = new System.Drawing.Size(346, 253);
            this.PicPanel.TabIndex = 4;
            this.PicPanel.Click += new System.EventHandler(this.RestoreEvent);
            // 
            // Browser
            // 
            this.Browser.Location = new System.Drawing.Point(12, 331);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.ScriptErrorsSuppressed = true;
            this.Browser.Size = new System.Drawing.Size(384, 193);
            this.Browser.TabIndex = 5;
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.PicPanel);
            this.Controls.Add(this.Player);
            this.Name = "FormDisplay";
            this.Text = "FormDisplay";
            this.Load += new System.EventHandler(this.RestoreEvent);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel PicPanel;
        public AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.WebBrowser Browser;
    }
}