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
            getBalanceButton = new Button();
            getTransactionsButton = new Button();
            getStatsButton = new Button();
            depositButton = new Button();
            withdrawButton = new Button();
            transferButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(loginButton);
            flowLayoutPanel1.Controls.Add(getProfileButton);
            flowLayoutPanel1.Controls.Add(getBalanceButton);
            flowLayoutPanel1.Controls.Add(getTransactionsButton);
            flowLayoutPanel1.Controls.Add(getStatsButton);
            flowLayoutPanel1.Controls.Add(depositButton);
            flowLayoutPanel1.Controls.Add(withdrawButton);
            flowLayoutPanel1.Controls.Add(transferButton);
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
            // getBalanceButton
            // 
            getBalanceButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getBalanceButton.AutoSize = true;
            getBalanceButton.Location = new Point(3, 69);
            getBalanceButton.Name = "getBalanceButton";
            getBalanceButton.Size = new Size(556, 27);
            getBalanceButton.TabIndex = 29;
            getBalanceButton.Text = "users/balance";
            getBalanceButton.UseVisualStyleBackColor = true;
            getBalanceButton.Click += getBalanceButton_Click;
            // 
            // getTransactionsButton
            // 
            getTransactionsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getTransactionsButton.AutoSize = true;
            getTransactionsButton.Location = new Point(3, 102);
            getTransactionsButton.Name = "getTransactionsButton";
            getTransactionsButton.Size = new Size(556, 27);
            getTransactionsButton.TabIndex = 30;
            getTransactionsButton.Text = "users/transactions";
            getTransactionsButton.UseVisualStyleBackColor = true;
            getTransactionsButton.Click += getTransactionsButton_Click;
            // 
            // getStatsButton
            // 
            getStatsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getStatsButton.AutoSize = true;
            getStatsButton.Location = new Point(3, 135);
            getStatsButton.Name = "getStatsButton";
            getStatsButton.Size = new Size(556, 27);
            getStatsButton.TabIndex = 31;
            getStatsButton.Text = "users/stats";
            getStatsButton.UseVisualStyleBackColor = true;
            getStatsButton.Click += getStatsButton_Click;
            // 
            // depositButton
            // 
            depositButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            depositButton.AutoSize = true;
            depositButton.Location = new Point(3, 168);
            depositButton.Name = "depositButton";
            depositButton.Size = new Size(556, 27);
            depositButton.TabIndex = 32;
            depositButton.Text = "users/deposit";
            depositButton.UseVisualStyleBackColor = true;
            depositButton.Click += depositButton_Click;
            // 
            // withdrawButton
            // 
            withdrawButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            withdrawButton.AutoSize = true;
            withdrawButton.Location = new Point(3, 201);
            withdrawButton.Name = "withdrawButton";
            withdrawButton.Size = new Size(556, 27);
            withdrawButton.TabIndex = 33;
            withdrawButton.Text = "users/withdraw";
            withdrawButton.UseVisualStyleBackColor = true;
            withdrawButton.Click += withdrawButton_Click;
            // 
            // transferButton
            // 
            transferButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            transferButton.AutoSize = true;
            transferButton.Location = new Point(3, 234);
            transferButton.Name = "transferButton";
            transferButton.Size = new Size(556, 27);
            transferButton.TabIndex = 34;
            transferButton.Text = "users/transfer";
            transferButton.UseVisualStyleBackColor = true;
            transferButton.Click += transferButton_Click;
            // 
            // Tester
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 490);
            Controls.Add(flowLayoutPanel1);
            Name = "Tester";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button getProfileButton;
        private Button getBalanceButton;
        private Button getTransactionsButton;
        private Button getStatsButton;
        private Button depositButton;
        private Button withdrawButton;
        private Button transferButton;
    }
}
