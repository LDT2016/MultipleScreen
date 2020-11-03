namespace MultipleScreen.Control
{
    partial class FormNetInner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetInner));
            this.backLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Browser = new MultipleScreen.Control.WebBrowserControl();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // backLbl
            // 
            this.backLbl.AccessibleName = "";
            this.backLbl.BackColor = System.Drawing.Color.Transparent;
            this.backLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backLbl.ForeColor = System.Drawing.Color.Transparent;
            this.backLbl.Location = new System.Drawing.Point(696, 407);
            this.backLbl.Name = "backLbl";
            this.backLbl.Size = new System.Drawing.Size(92, 38);
            this.backLbl.TabIndex = 9;
            this.backLbl.Tag = "";
            this.backLbl.Click += new System.EventHandler(this.backLbl_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Browser);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 331);
            this.panel1.TabIndex = 11;
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.ScriptErrorsSuppressed = true;
            this.Browser.Size = new System.Drawing.Size(776, 331);
            this.Browser.TabIndex = 10;
            //this.Browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // FormNetInner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backLbl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormNetInner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTaxPublicity";
            this.Load += new System.EventHandler(this.FormBigEvent_Load);
            this.Click += new System.EventHandler(this.FormBigEvent_Click);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label backLbl;
        public WebBrowserControl Browser;
        private System.Windows.Forms.Panel panel1;
        private System.Diagnostics.EventLog eventLog1;
    }
}