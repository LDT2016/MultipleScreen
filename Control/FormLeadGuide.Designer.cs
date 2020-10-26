namespace MultipleScreen.Control
{
    partial class FormLeadGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLeadGuide));
            this.PicPanel = new System.Windows.Forms.Panel();
            this.previousLbl = new System.Windows.Forms.Label();
            this.nextLbl = new System.Windows.Forms.Label();
            this.backLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PicPanel
            // 
            this.PicPanel.BackColor = System.Drawing.Color.Transparent;
            this.PicPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicPanel.Location = new System.Drawing.Point(22, 69);
            this.PicPanel.Name = "PicPanel";
            this.PicPanel.Size = new System.Drawing.Size(504, 318);
            this.PicPanel.TabIndex = 5;
            this.PicPanel.Click += new System.EventHandler(this.PicPanel_Click);
            // 
            // previousLbl
            // 
            this.previousLbl.AccessibleName = "";
            this.previousLbl.BackColor = System.Drawing.Color.Transparent;
            this.previousLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previousLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.previousLbl.ForeColor = System.Drawing.Color.Transparent;
            this.previousLbl.Location = new System.Drawing.Point(585, 199);
            this.previousLbl.Name = "previousLbl";
            this.previousLbl.Size = new System.Drawing.Size(183, 50);
            this.previousLbl.TabIndex = 6;
            this.previousLbl.Tag = "";
            this.previousLbl.Click += new System.EventHandler(this.previousLbl_Click);
            // 
            // nextLbl
            // 
            this.nextLbl.AccessibleName = "";
            this.nextLbl.BackColor = System.Drawing.Color.Transparent;
            this.nextLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextLbl.ForeColor = System.Drawing.Color.Transparent;
            this.nextLbl.Location = new System.Drawing.Point(585, 306);
            this.nextLbl.Name = "nextLbl";
            this.nextLbl.Size = new System.Drawing.Size(183, 50);
            this.nextLbl.TabIndex = 7;
            this.nextLbl.Tag = "";
            this.nextLbl.Click += new System.EventHandler(this.nextLbl_Click);
            // 
            // backLbl
            // 
            this.backLbl.AccessibleName = "";
            this.backLbl.BackColor = System.Drawing.Color.Transparent;
            this.backLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backLbl.ForeColor = System.Drawing.Color.Transparent;
            this.backLbl.Location = new System.Drawing.Point(696, 406);
            this.backLbl.Name = "backLbl";
            this.backLbl.Size = new System.Drawing.Size(92, 38);
            this.backLbl.TabIndex = 8;
            this.backLbl.Tag = "";
            this.backLbl.Click += new System.EventHandler(this.backLbl_Click);
            // 
            // FormLeadGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backLbl);
            this.Controls.Add(this.nextLbl);
            this.Controls.Add(this.previousLbl);
            this.Controls.Add(this.PicPanel);
            this.Name = "FormLeadGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLeadGuide";
            this.Load += new System.EventHandler(this.FormLeadGuide_Load);
            this.Click += new System.EventHandler(this.FormLeadGuide_Click);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel PicPanel;
        private System.Windows.Forms.Label previousLbl;
        private System.Windows.Forms.Label nextLbl;
        private System.Windows.Forms.Label backLbl;
    }
}