namespace CrossPoster
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            postTextBox = new TextBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            postMisskeyTextLength = new Label();
            postBlueskyTextLength = new Label();
            postTwitterTextLength = new Label();
            checkBoxMisskey = new CheckBox();
            checkBoxBluesky = new CheckBox();
            checkBoxX = new CheckBox();
            postButton = new Button();
            menuStrip1 = new MenuStrip();
            オプションToolStripMenuItem = new ToolStripMenuItem();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // postTextBox
            // 
            postTextBox.Location = new Point(15, 26);
            postTextBox.Margin = new Padding(3, 2, 3, 2);
            postTextBox.Multiline = true;
            postTextBox.Name = "postTextBox";
            postTextBox.Size = new Size(680, 177);
            postTextBox.TabIndex = 1;
            postTextBox.TextChanged += postTextBox_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(postMisskeyTextLength);
            groupBox1.Controls.Add(postBlueskyTextLength);
            groupBox1.Controls.Add(postTwitterTextLength);
            groupBox1.Controls.Add(checkBoxMisskey);
            groupBox1.Controls.Add(checkBoxBluesky);
            groupBox1.Controls.Add(checkBoxX);
            groupBox1.Location = new Point(10, 230);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(320, 103);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "送信先SNSを選択";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 55);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 8;
            label3.Text = "/ 3000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 36);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 7;
            label2.Text = "/ 300";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 17);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 6;
            label1.Text = "/ 140";
            // 
            // postMisskeyTextLength
            // 
            postMisskeyTextLength.AutoSize = true;
            postMisskeyTextLength.Location = new Point(131, 55);
            postMisskeyTextLength.Name = "postMisskeyTextLength";
            postMisskeyTextLength.Size = new Size(13, 15);
            postMisskeyTextLength.TabIndex = 5;
            postMisskeyTextLength.Text = "0";
            // 
            // postBlueskyTextLength
            // 
            postBlueskyTextLength.AutoSize = true;
            postBlueskyTextLength.Location = new Point(131, 36);
            postBlueskyTextLength.Name = "postBlueskyTextLength";
            postBlueskyTextLength.Size = new Size(13, 15);
            postBlueskyTextLength.TabIndex = 4;
            postBlueskyTextLength.Text = "0";
            // 
            // postTwitterTextLength
            // 
            postTwitterTextLength.AutoSize = true;
            postTwitterTextLength.Location = new Point(131, 17);
            postTwitterTextLength.Name = "postTwitterTextLength";
            postTwitterTextLength.Size = new Size(13, 15);
            postTwitterTextLength.TabIndex = 3;
            postTwitterTextLength.Text = "0";
            // 
            // checkBoxMisskey
            // 
            checkBoxMisskey.AutoSize = true;
            checkBoxMisskey.Location = new Point(5, 54);
            checkBoxMisskey.Margin = new Padding(3, 2, 3, 2);
            checkBoxMisskey.Name = "checkBoxMisskey";
            checkBoxMisskey.Size = new Size(102, 19);
            checkBoxMisskey.TabIndex = 2;
            checkBoxMisskey.Text = "Misskeyへ投稿";
            checkBoxMisskey.UseVisualStyleBackColor = true;
            // 
            // checkBoxBluesky
            // 
            checkBoxBluesky.AutoSize = true;
            checkBoxBluesky.Location = new Point(5, 35);
            checkBoxBluesky.Margin = new Padding(3, 2, 3, 2);
            checkBoxBluesky.Name = "checkBoxBluesky";
            checkBoxBluesky.Size = new Size(100, 19);
            checkBoxBluesky.TabIndex = 1;
            checkBoxBluesky.Text = "Blueskyへ投稿";
            checkBoxBluesky.UseVisualStyleBackColor = true;
            // 
            // checkBoxX
            // 
            checkBoxX.AutoSize = true;
            checkBoxX.Location = new Point(5, 16);
            checkBoxX.Margin = new Padding(3, 2, 3, 2);
            checkBoxX.Name = "checkBoxX";
            checkBoxX.Size = new Size(110, 19);
            checkBoxX.TabIndex = 0;
            checkBoxX.Text = "X(Twitter)へ投稿";
            checkBoxX.UseVisualStyleBackColor = true;
            // 
            // postButton
            // 
            postButton.Location = new Point(624, 311);
            postButton.Margin = new Padding(3, 2, 3, 2);
            postButton.Name = "postButton";
            postButton.Size = new Size(66, 22);
            postButton.TabIndex = 3;
            postButton.Text = "送信";
            postButton.UseVisualStyleBackColor = true;
            postButton.Click += postButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { オプションToolStripMenuItem, 終了ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(703, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // オプションToolStripMenuItem
            // 
            オプションToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 設定ToolStripMenuItem });
            オプションToolStripMenuItem.Name = "オプションToolStripMenuItem";
            オプションToolStripMenuItem.Size = new Size(63, 20);
            オプションToolStripMenuItem.Text = "オプション";
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size = new Size(98, 22);
            設定ToolStripMenuItem.Text = "設定";
            設定ToolStripMenuItem.Click += 設定ToolStripMenuItem_Click;
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.Size = new Size(43, 20);
            終了ToolStripMenuItem.Text = "終了";
            終了ToolStripMenuItem.Click += 終了ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 365);
            Controls.Add(menuStrip1);
            Controls.Add(postButton);
            Controls.Add(groupBox1);
            Controls.Add(postTextBox);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "CrossPoster";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox postTextBox;
        private GroupBox groupBox1;
        private CheckBox checkBoxMisskey;
        private CheckBox checkBoxBluesky;
        private CheckBox checkBoxX;
        private Button postButton;
        private Label postMisskeyTextLength;
        private Label postBlueskyTextLength;
        private Label postTwitterTextLength;
        private Label label3;
        private Label label2;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem オプションToolStripMenuItem;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
    }
}