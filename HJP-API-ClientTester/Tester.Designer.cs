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
            getMaintenanceStatusButton = new Button();
            loginButton = new Button();
            getProfileButton = new Button();
            getBalanceButton = new Button();
            getTransactionsButton = new Button();
            getStatsButton = new Button();
            depositButton = new Button();
            withdrawButton = new Button();
            transferButton = new Button();
            lotteryButton = new Button();
            getLotteryBank = new Button();
            moderatorLoginButton = new Button();
            moderatorRegisterUserButton = new Button();
            moderatorResetAccessTokenButton = new Button();
            adminLoginButton = new Button();
            adminGetUserProfileButton = new Button();
            searchUserButton = new Button();
            adminUserDepositButton = new Button();
            adminUserWithdrawButton = new Button();
            adminTransactionsButton = new Button();
            pingButton = new Button();
            getVersionButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pingButton);
            flowLayoutPanel1.Controls.Add(getMaintenanceStatusButton);
            flowLayoutPanel1.Controls.Add(getVersionButton);
            flowLayoutPanel1.Controls.Add(loginButton);
            flowLayoutPanel1.Controls.Add(getProfileButton);
            flowLayoutPanel1.Controls.Add(getBalanceButton);
            flowLayoutPanel1.Controls.Add(getTransactionsButton);
            flowLayoutPanel1.Controls.Add(getStatsButton);
            flowLayoutPanel1.Controls.Add(depositButton);
            flowLayoutPanel1.Controls.Add(withdrawButton);
            flowLayoutPanel1.Controls.Add(transferButton);
            flowLayoutPanel1.Controls.Add(lotteryButton);
            flowLayoutPanel1.Controls.Add(getLotteryBank);
            flowLayoutPanel1.Controls.Add(moderatorLoginButton);
            flowLayoutPanel1.Controls.Add(moderatorRegisterUserButton);
            flowLayoutPanel1.Controls.Add(moderatorResetAccessTokenButton);
            flowLayoutPanel1.Controls.Add(adminLoginButton);
            flowLayoutPanel1.Controls.Add(adminGetUserProfileButton);
            flowLayoutPanel1.Controls.Add(searchUserButton);
            flowLayoutPanel1.Controls.Add(adminUserDepositButton);
            flowLayoutPanel1.Controls.Add(adminUserWithdrawButton);
            flowLayoutPanel1.Controls.Add(adminTransactionsButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(584, 743);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // getMaintenanceStatusButton
            // 
            getMaintenanceStatusButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getMaintenanceStatusButton.AutoSize = true;
            getMaintenanceStatusButton.Location = new Point(3, 36);
            getMaintenanceStatusButton.Name = "getMaintenanceStatusButton";
            getMaintenanceStatusButton.Size = new Size(556, 27);
            getMaintenanceStatusButton.TabIndex = 45;
            getMaintenanceStatusButton.Text = "system/maintenance";
            getMaintenanceStatusButton.UseVisualStyleBackColor = true;
            getMaintenanceStatusButton.Click += getMaintenanceStatusButton_Click;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.Location = new Point(3, 102);
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
            getProfileButton.Location = new Point(3, 135);
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
            getBalanceButton.Location = new Point(3, 168);
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
            getTransactionsButton.Location = new Point(3, 201);
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
            getStatsButton.Location = new Point(3, 234);
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
            depositButton.Location = new Point(3, 267);
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
            withdrawButton.Location = new Point(3, 300);
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
            transferButton.Location = new Point(3, 333);
            transferButton.Name = "transferButton";
            transferButton.Size = new Size(556, 27);
            transferButton.TabIndex = 34;
            transferButton.Text = "users/transfer";
            transferButton.UseVisualStyleBackColor = true;
            transferButton.Click += transferButton_Click;
            // 
            // lotteryButton
            // 
            lotteryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lotteryButton.AutoSize = true;
            lotteryButton.Location = new Point(3, 366);
            lotteryButton.Name = "lotteryButton";
            lotteryButton.Size = new Size(556, 27);
            lotteryButton.TabIndex = 46;
            lotteryButton.Text = "me/lottery/draw";
            lotteryButton.UseVisualStyleBackColor = true;
            lotteryButton.Click += lotteryButton_Click;
            // 
            // getLotteryBank
            // 
            getLotteryBank.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getLotteryBank.AutoSize = true;
            getLotteryBank.Location = new Point(3, 399);
            getLotteryBank.Name = "getLotteryBank";
            getLotteryBank.Size = new Size(556, 27);
            getLotteryBank.TabIndex = 47;
            getLotteryBank.Text = "lottery/bank";
            getLotteryBank.UseVisualStyleBackColor = true;
            getLotteryBank.Click += getLotteryBank_Click;
            // 
            // moderatorLoginButton
            // 
            moderatorLoginButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            moderatorLoginButton.AutoSize = true;
            moderatorLoginButton.Location = new Point(3, 432);
            moderatorLoginButton.Name = "moderatorLoginButton";
            moderatorLoginButton.Size = new Size(556, 27);
            moderatorLoginButton.TabIndex = 38;
            moderatorLoginButton.Text = "moderator/login";
            moderatorLoginButton.UseVisualStyleBackColor = true;
            moderatorLoginButton.Click += moderatorLoginButton_Click;
            // 
            // moderatorRegisterUserButton
            // 
            moderatorRegisterUserButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            moderatorRegisterUserButton.AutoSize = true;
            moderatorRegisterUserButton.Location = new Point(3, 465);
            moderatorRegisterUserButton.Name = "moderatorRegisterUserButton";
            moderatorRegisterUserButton.Size = new Size(556, 27);
            moderatorRegisterUserButton.TabIndex = 35;
            moderatorRegisterUserButton.Text = "moderator/users/register";
            moderatorRegisterUserButton.UseVisualStyleBackColor = true;
            moderatorRegisterUserButton.Click += moderatorRegisterUserButton_Click;
            // 
            // moderatorResetAccessTokenButton
            // 
            moderatorResetAccessTokenButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            moderatorResetAccessTokenButton.AutoSize = true;
            moderatorResetAccessTokenButton.Location = new Point(3, 498);
            moderatorResetAccessTokenButton.Name = "moderatorResetAccessTokenButton";
            moderatorResetAccessTokenButton.Size = new Size(556, 27);
            moderatorResetAccessTokenButton.TabIndex = 37;
            moderatorResetAccessTokenButton.Text = "moderator/users/{discordUserId}/access-token/reset";
            moderatorResetAccessTokenButton.UseVisualStyleBackColor = true;
            moderatorResetAccessTokenButton.Click += moderatorResetAccessTokenButton_Click;
            // 
            // adminLoginButton
            // 
            adminLoginButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminLoginButton.AutoSize = true;
            adminLoginButton.Location = new Point(3, 531);
            adminLoginButton.Name = "adminLoginButton";
            adminLoginButton.Size = new Size(556, 27);
            adminLoginButton.TabIndex = 39;
            adminLoginButton.Text = "admin/login";
            adminLoginButton.UseVisualStyleBackColor = true;
            adminLoginButton.Click += adminLoginButton_Click;
            // 
            // adminGetUserProfileButton
            // 
            adminGetUserProfileButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetUserProfileButton.AutoSize = true;
            adminGetUserProfileButton.Location = new Point(3, 564);
            adminGetUserProfileButton.Name = "adminGetUserProfileButton";
            adminGetUserProfileButton.Size = new Size(556, 27);
            adminGetUserProfileButton.TabIndex = 40;
            adminGetUserProfileButton.Text = "admin/users/{discordUserId}";
            adminGetUserProfileButton.UseVisualStyleBackColor = true;
            adminGetUserProfileButton.Click += adminGetUserProfileButton_Click;
            // 
            // searchUserButton
            // 
            searchUserButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchUserButton.AutoSize = true;
            searchUserButton.Location = new Point(3, 597);
            searchUserButton.Name = "searchUserButton";
            searchUserButton.Size = new Size(556, 27);
            searchUserButton.TabIndex = 44;
            searchUserButton.Text = "admin/users/search";
            searchUserButton.UseVisualStyleBackColor = true;
            searchUserButton.Click += searchUserButton_Click;
            // 
            // adminUserDepositButton
            // 
            adminUserDepositButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminUserDepositButton.AutoSize = true;
            adminUserDepositButton.Location = new Point(3, 630);
            adminUserDepositButton.Name = "adminUserDepositButton";
            adminUserDepositButton.Size = new Size(556, 27);
            adminUserDepositButton.TabIndex = 41;
            adminUserDepositButton.Text = "admin/users/{discordUserId}/deposit";
            adminUserDepositButton.UseVisualStyleBackColor = true;
            adminUserDepositButton.Click += adminUserDepositButton_Click;
            // 
            // adminUserWithdrawButton
            // 
            adminUserWithdrawButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminUserWithdrawButton.AutoSize = true;
            adminUserWithdrawButton.Location = new Point(3, 663);
            adminUserWithdrawButton.Name = "adminUserWithdrawButton";
            adminUserWithdrawButton.Size = new Size(556, 27);
            adminUserWithdrawButton.TabIndex = 42;
            adminUserWithdrawButton.Text = "admin/users/{discordUserId}/withdraw";
            adminUserWithdrawButton.UseVisualStyleBackColor = true;
            adminUserWithdrawButton.Click += adminUserWithdrawButton_Click;
            // 
            // adminTransactionsButton
            // 
            adminTransactionsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminTransactionsButton.AutoSize = true;
            adminTransactionsButton.Location = new Point(3, 696);
            adminTransactionsButton.Name = "adminTransactionsButton";
            adminTransactionsButton.Size = new Size(556, 27);
            adminTransactionsButton.TabIndex = 43;
            adminTransactionsButton.Text = "admin/transactions";
            adminTransactionsButton.UseVisualStyleBackColor = true;
            adminTransactionsButton.Click += adminTransactionsButton_Click;
            // 
            // pingButton
            // 
            pingButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pingButton.AutoSize = true;
            pingButton.Location = new Point(3, 3);
            pingButton.Name = "pingButton";
            pingButton.Size = new Size(556, 27);
            pingButton.TabIndex = 48;
            pingButton.Text = "system/ping";
            pingButton.UseVisualStyleBackColor = true;
            // 
            // getVersionButton
            // 
            getVersionButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getVersionButton.AutoSize = true;
            getVersionButton.Location = new Point(3, 69);
            getVersionButton.Name = "getVersionButton";
            getVersionButton.Size = new Size(556, 27);
            getVersionButton.TabIndex = 49;
            getVersionButton.Text = "system/version";
            getVersionButton.UseVisualStyleBackColor = true;
            // 
            // Tester
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 767);
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
        private Button moderatorRegisterUserButton;
        private Button moderatorResetAccessTokenButton;
        private Button moderatorLoginButton;
        private Button adminLoginButton;
        private Button adminGetUserProfileButton;
        private Button adminUserDepositButton;
        private Button adminUserWithdrawButton;
        private Button adminTransactionsButton;
        private Button searchUserButton;
        private Button getMaintenanceStatusButton;
        private Button lotteryButton;
        private Button getLotteryBank;
        private Button pingButton;
        private Button getVersionButton;
    }
}
