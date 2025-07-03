namespace HJP_API_ClientTester
{
    partial class Tester
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            loginButton = new Button();
            getProfileButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(loginButton);
            flowLayoutPanel1.Controls.Add(getProfileButton);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(592, 466);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.Location = new Point(3, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(556, 27);
            loginButton.TabIndex = 27;
            loginButton.Text = "users/login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // getProfileButton
            // 
            getProfileButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getProfileButton.AutoSize = true;
            getProfileButton.Location = new Point(3, 36);
            getProfileButton.Name = "getProfileButton";
            getProfileButton.Size = new Size(556, 27);
            getProfileButton.TabIndex = 28;
            getProfileButton.Text = "users/me";
            getProfileButton.UseVisualStyleBackColor = true;
            getProfileButton.Click += getProfileButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 490);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button getProfileButton;
    }
}
