namespace StandUp.UI
{
    partial class NowStandUp
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
            this.btnHideForm = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.standTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.fadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlFooter.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHideForm
            // 
            this.btnHideForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHideForm.BackColor = System.Drawing.Color.Gray;
            this.btnHideForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideForm.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnHideForm.Location = new System.Drawing.Point(138, 2);
            this.btnHideForm.Name = "btnHideForm";
            this.btnHideForm.Size = new System.Drawing.Size(125, 23);
            this.btnHideForm.TabIndex = 1;
            this.btnHideForm.TabStop = false;
            this.btnHideForm.Text = "Alright, I am standing";
            this.toolTip1.SetToolTip(this.btnHideForm, "Hides the black screen, and shows your desktop. You will be notified when you can" +
        " sit down");
            this.btnHideForm.UseVisualStyleBackColor = false;
            this.btnHideForm.Click += new System.EventHandler(this.btnHideForm_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblTime.ForeColor = System.Drawing.Color.Silver;
            this.lblTime.Location = new System.Drawing.Point(579, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(163, 24);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // standTimer
            // 
            this.standTimer.Interval = 1000;
            this.standTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClose.BackColor = System.Drawing.Color.Gray;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.BtnClose.Location = new System.Drawing.Point(4, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(125, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.TabStop = false;
            this.BtnClose.Text = "Snooze";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblTime);
            this.pnlFooter.Controls.Add(this.pnlButtons);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 418);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(764, 41);
            this.pnlFooter.TabIndex = 3;
            this.pnlFooter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            this.pnlFooter.MouseEnter += new System.EventHandler(this.pnlFooter_MouseEnter);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.BtnClose);
            this.pnlButtons.Controls.Add(this.btnHideForm);
            this.pnlButtons.Location = new System.Drawing.Point(3, 6);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(276, 32);
            this.pnlButtons.TabIndex = 1;
            this.pnlButtons.Visible = false;
            this.pnlButtons.MouseEnter += new System.EventHandler(this.pnlFooter_MouseEnter);
            // 
            // fadeInTimer
            // 
            this.fadeInTimer.Tick += new System.EventHandler(this.fadeInTimer_Tick);
            // 
            // NowStandUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(764, 459);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::StandUp.Properties.Resources.Timer;
            this.MinimizeBox = false;
            this.Name = "NowStandUp";
            this.Text = "NowStandUp";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NowStandUp_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NowStandUp_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            this.pnlFooter.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHideForm;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer standTimer;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Timer fadeInTimer;
    }
}