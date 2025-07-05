namespace CrossPoster
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
            twitterSettingGroup = new GroupBox();
            settingTwitterAccessTokenSecret = new TextBox();
            settingTwitterAccessToken = new TextBox();
            settingTwitterConsumerKeySecret = new TextBox();
            settingTwitterConsumerKey = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            saveButton = new Button();
            cancelBtn = new Button();
            groupBox1 = new GroupBox();
            settingBlueskyAppPassword = new TextBox();
            label6 = new Label();
            settingBlueskyAccount = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            settingMisskeyAccessToken = new TextBox();
            settingMisskeyBaseUrl = new TextBox();
            label8 = new Label();
            label7 = new Label();
            twitterSettingGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // twitterSettingGroup
            // 
            twitterSettingGroup.Controls.Add(settingTwitterAccessTokenSecret);
            twitterSettingGroup.Controls.Add(settingTwitterAccessToken);
            twitterSettingGroup.Controls.Add(settingTwitterConsumerKeySecret);
            twitterSettingGroup.Controls.Add(settingTwitterConsumerKey);
            twitterSettingGroup.Controls.Add(label4);
            twitterSettingGroup.Controls.Add(label3);
            twitterSettingGroup.Controls.Add(label2);
            twitterSettingGroup.Controls.Add(label1);
            twitterSettingGroup.Location = new Point(12, 12);
            twitterSettingGroup.Name = "twitterSettingGroup";
            twitterSettingGroup.Size = new Size(575, 170);
            twitterSettingGroup.TabIndex = 0;
            twitterSettingGroup.TabStop = false;
            twitterSettingGroup.Text = "Twitter 設定";
            // 
            // settingTwitterAccessTokenSecret
            // 
            settingTwitterAccessTokenSecret.Location = new Point(165, 127);
            settingTwitterAccessTokenSecret.Name = "settingTwitterAccessTokenSecret";
            settingTwitterAccessTokenSecret.Size = new Size(389, 27);
            settingTwitterAccessTokenSecret.TabIndex = 7;
            // 
            // settingTwitterAccessToken
            // 
            settingTwitterAccessToken.Location = new Point(165, 94);
            settingTwitterAccessToken.Name = "settingTwitterAccessToken";
            settingTwitterAccessToken.Size = new Size(389, 27);
            settingTwitterAccessToken.TabIndex = 6;
            // 
            // settingTwitterConsumerKeySecret
            // 
            settingTwitterConsumerKeySecret.Location = new Point(165, 61);
            settingTwitterConsumerKeySecret.Name = "settingTwitterConsumerKeySecret";
            settingTwitterConsumerKeySecret.Size = new Size(389, 27);
            settingTwitterConsumerKeySecret.TabIndex = 5;
            // 
            // settingTwitterConsumerKey
            // 
            settingTwitterConsumerKey.Location = new Point(165, 28);
            settingTwitterConsumerKey.Name = "settingTwitterConsumerKey";
            settingTwitterConsumerKey.Size = new Size(389, 27);
            settingTwitterConsumerKey.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 130);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 3;
            label4.Text = "AccessTokenSecret";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 97);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "AccessToken";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 64);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 1;
            label2.Text = "ConsumerKeySecret";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 31);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "ConsumerKey";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(492, 452);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 1;
            saveButton.Text = "保存";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(392, 452);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "キャンセル";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(settingBlueskyAppPassword);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(settingBlueskyAccount);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 188);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(575, 107);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bluesky 設定";
            // 
            // settingBlueskyAppPassword
            // 
            settingBlueskyAppPassword.Location = new Point(165, 61);
            settingBlueskyAppPassword.Name = "settingBlueskyAppPassword";
            settingBlueskyAppPassword.Size = new Size(389, 27);
            settingBlueskyAppPassword.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 64);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 9;
            label6.Text = "AppPassword";
            // 
            // settingBlueskyAccount
            // 
            settingBlueskyAccount.Location = new Point(165, 28);
            settingBlueskyAccount.Name = "settingBlueskyAccount";
            settingBlueskyAccount.Size = new Size(389, 27);
            settingBlueskyAccount.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 31);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 8;
            label5.Text = "Account";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(settingMisskeyAccessToken);
            groupBox2.Controls.Add(settingMisskeyBaseUrl);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(12, 301);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(575, 110);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Misskey 設定";
            // 
            // settingMisskeyAccessToken
            // 
            settingMisskeyAccessToken.Location = new Point(165, 61);
            settingMisskeyAccessToken.Name = "settingMisskeyAccessToken";
            settingMisskeyAccessToken.Size = new Size(389, 27);
            settingMisskeyAccessToken.TabIndex = 12;
            // 
            // settingMisskeyBaseUrl
            // 
            settingMisskeyBaseUrl.Location = new Point(165, 28);
            settingMisskeyBaseUrl.Name = "settingMisskeyBaseUrl";
            settingMisskeyBaseUrl.Size = new Size(389, 27);
            settingMisskeyBaseUrl.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 64);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 11;
            label8.Text = "AccessToken";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 31);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 9;
            label7.Text = "BaseURL";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 493);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(cancelBtn);
            Controls.Add(saveButton);
            Controls.Add(twitterSettingGroup);
            Name = "Form2";
            Text = "設定";
            twitterSettingGroup.ResumeLayout(false);
            twitterSettingGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox twitterSettingGroup;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox settingTwitterAccessTokenSecret;
        private TextBox settingTwitterAccessToken;
        private TextBox settingTwitterConsumerKeySecret;
        private TextBox settingTwitterConsumerKey;
        private Button saveButton;
        private Button cancelBtn;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox settingBlueskyAccount;
        private Label label5;
        private TextBox settingBlueskyAppPassword;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox settingMisskeyAccessToken;
        private TextBox settingMisskeyBaseUrl;
    }
}