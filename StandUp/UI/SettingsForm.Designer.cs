namespace StandUp.UI
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnSaveDuration = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chkEscapeMessage = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRedColor = new System.Windows.Forms.TextBox();
            this.chkSnooze = new System.Windows.Forms.CheckBox();
            this.chkAllowPrepareNotification = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStandUpSeconds = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFadeInSeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSnoozeTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Duration (seconds):";
            this.toolTip1.SetToolTip(this.label1, "The maximum duration you want to sit down");
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(176, 39);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 2;
            // 
            // btnSaveDuration
            // 
            this.btnSaveDuration.Location = new System.Drawing.Point(514, 276);
            this.btnSaveDuration.Name = "btnSaveDuration";
            this.btnSaveDuration.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDuration.TabIndex = 11;
            this.btnSaveDuration.Text = "Save";
            this.btnSaveDuration.UseVisualStyleBackColor = true;
            this.btnSaveDuration.Click += new System.EventHandler(this.btnSaveDuration_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(595, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message:";
            this.toolTip1.SetToolTip(this.label2, "The message which is shown to stand you up");
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(176, 143);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(461, 20);
            this.txtMessage.TabIndex = 6;
            // 
            // chkEscapeMessage
            // 
            this.chkEscapeMessage.AutoSize = true;
            this.chkEscapeMessage.Location = new System.Drawing.Point(176, 170);
            this.chkEscapeMessage.Name = "chkEscapeMessage";
            this.chkEscapeMessage.Size = new System.Drawing.Size(160, 17);
            this.chkEscapeMessage.TabIndex = 7;
            this.chkEscapeMessage.Text = "Allow escaping the message";
            this.toolTip1.SetToolTip(this.chkEscapeMessage, "If checked, you can press Esc (escape on your keyboard) to close the message. Not" +
        "e that this will make the message get snoozed if \"Allow snooze\" is checked and t" +
        "he form has not been shown long enough");
            this.chkEscapeMessage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seconds in Red Color:";
            this.toolTip1.SetToolTip(this.label3, "The time when the timer becomes red. Also if \"Allow showing notification when get" +
        "ting close\" is checked, a notification will be shown to tell you to prepare to s" +
        "tand up");
            // 
            // txtRedColor
            // 
            this.txtRedColor.Location = new System.Drawing.Point(176, 117);
            this.txtRedColor.Name = "txtRedColor";
            this.txtRedColor.Size = new System.Drawing.Size(100, 20);
            this.txtRedColor.TabIndex = 5;
            // 
            // chkSnooze
            // 
            this.chkSnooze.AutoSize = true;
            this.chkSnooze.Location = new System.Drawing.Point(176, 193);
            this.chkSnooze.Name = "chkSnooze";
            this.chkSnooze.Size = new System.Drawing.Size(88, 17);
            this.chkSnooze.TabIndex = 8;
            this.chkSnooze.Text = "Allow snooze";
            this.toolTip1.SetToolTip(this.chkSnooze, "If checked, everytime you close the message, if the message form has not been sho" +
        "wn enough (as set in \"Standup duration\" box), the form will re-show in 1 minute." +
        "");
            this.chkSnooze.UseVisualStyleBackColor = true;
            this.chkSnooze.CheckedChanged += new System.EventHandler(this.chkSnooze_CheckedChanged);
            // 
            // chkAllowPrepareNotification
            // 
            this.chkAllowPrepareNotification.AutoSize = true;
            this.chkAllowPrepareNotification.Location = new System.Drawing.Point(176, 242);
            this.chkAllowPrepareNotification.Name = "chkAllowPrepareNotification";
            this.chkAllowPrepareNotification.Size = new System.Drawing.Size(239, 17);
            this.chkAllowPrepareNotification.TabIndex = 10;
            this.chkAllowPrepareNotification.Text = "Allow showing notification when getting close";
            this.toolTip1.SetToolTip(this.chkAllowPrepareNotification, "Shows a notification for you to prepare for standing up when entered in the \"Red " +
        "Color\" time to stand up.");
            this.chkAllowPrepareNotification.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Standup duration (seconds):";
            this.toolTip1.SetToolTip(this.label4, "The minimum duration you want to stand up each time");
            // 
            // txtStandUpSeconds
            // 
            this.txtStandUpSeconds.Location = new System.Drawing.Point(176, 65);
            this.txtStandUpSeconds.Name = "txtStandUpSeconds";
            this.txtStandUpSeconds.Size = new System.Drawing.Size(100, 20);
            this.txtStandUpSeconds.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Settings File Path:";
            this.toolTip1.SetToolTip(this.label5, "You can change setting file path, to put it in a DropBox or other cload space dir" +
        "ectories and sync your settings in different PCs");
            // 
            // txtFilePath
            // 
            this.txtFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtFilePath.Location = new System.Drawing.Point(176, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(461, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Help With Settings";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(643, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Message Fade In Time (seconds):";
            // 
            // txtFadeInSeconds
            // 
            this.txtFadeInSeconds.Location = new System.Drawing.Point(176, 91);
            this.txtFadeInSeconds.Name = "txtFadeInSeconds";
            this.txtFadeInSeconds.Size = new System.Drawing.Size(100, 20);
            this.txtFadeInSeconds.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "(0 = No Fade In)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Snooze Time (seconds):";
            // 
            // txtSnoozeTime
            // 
            this.txtSnoozeTime.Location = new System.Drawing.Point(176, 216);
            this.txtSnoozeTime.Name = "txtSnoozeTime";
            this.txtSnoozeTime.Size = new System.Drawing.Size(100, 20);
            this.txtSnoozeTime.TabIndex = 9;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSaveDuration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(682, 308);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.chkAllowPrepareNotification);
            this.Controls.Add(this.chkSnooze);
            this.Controls.Add(this.chkEscapeMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveDuration);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSnoozeTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRedColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStandUpSeconds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFadeInSeconds);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::StandUp.Properties.Resources.Timer;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSaveDuration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.CheckBox chkEscapeMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRedColor;
        private System.Windows.Forms.CheckBox chkSnooze;
        private System.Windows.Forms.CheckBox chkAllowPrepareNotification;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStandUpSeconds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFadeInSeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSnoozeTime;
    }
}