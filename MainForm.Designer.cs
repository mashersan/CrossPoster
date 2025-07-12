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
            misskeyCharCountLabel = new Label();
            blueskyCharCountLabel = new Label();
            twitterCharCountLabel = new Label();
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
            postTextBox.Location = new Point(10, 29);
            postTextBox.Margin = new Padding(3, 2, 3, 2);
            postTextBox.Multiline = true;
            postTextBox.Name = "postTextBox";
            postTextBox.Size = new Size(680, 182);
            postTextBox.TabIndex = 1;
            postTextBox.TextChanged += postTextBox_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(misskeyCharCountLabel);
            groupBox1.Controls.Add(blueskyCharCountLabel);
            groupBox1.Controls.Add(twitterCharCountLabel);
            groupBox1.Controls.Add(checkBoxMisskey);
            groupBox1.Controls.Add(checkBoxBluesky);
            groupBox1.Controls.Add(checkBoxX);
            groupBox1.Location = new Point(10, 220);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(320, 103);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "送信先SNSを選択";
            // 
            // misskeyCharCountLabel
            // 
            misskeyCharCountLabel.Location = new Point(127, 55);
            misskeyCharCountLabel.Name = "misskeyCharCountLabel";
            misskeyCharCountLabel.Size = new Size(88, 15);
            misskeyCharCountLabel.TabIndex = 8;
            misskeyCharCountLabel.Text = "0 / 3000";
            misskeyCharCountLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // blueskyCharCountLabel
            // 
            blueskyCharCountLabel.Location = new Point(127, 36);
            blueskyCharCountLabel.Name = "blueskyCharCountLabel";
            blueskyCharCountLabel.Size = new Size(88, 15);
            blueskyCharCountLabel.TabIndex = 7;
            blueskyCharCountLabel.Text = "0 /   300";
            blueskyCharCountLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // twitterCharCountLabel
            // 
            twitterCharCountLabel.Location = new Point(127, 17);
            twitterCharCountLabel.Name = "twitterCharCountLabel";
            twitterCharCountLabel.Size = new Size(88, 15);
            twitterCharCountLabel.TabIndex = 6;
            twitterCharCountLabel.Text = "0 /   140";
            twitterCharCountLabel.TextAlign = ContentAlignment.MiddleRight;
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
            menuStrip1.Size = new Size(700, 24);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(menuStrip1);
            Controls.Add(postButton);
            Controls.Add(groupBox1);
            Controls.Add(postTextBox);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem オプションToolStripMenuItem;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private Label twitterCharCountLabel;
        private Label blueskyCharCountLabel;
        private Label misskeyCharCountLabel;
    }
}