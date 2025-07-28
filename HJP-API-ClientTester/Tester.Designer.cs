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
            pingButton = new Button();
            getMaintenanceStatusButton = new Button();
            getVersionButton = new Button();
            loginButton = new Button();
            searchUserButton = new Button();
            getProfileButton = new Button();
            getBalanceButton = new Button();
            getTransactionsButton = new Button();
            getStatsButton = new Button();
            depositButton = new Button();
            withdrawButton = new Button();
            transferButton = new Button();
            lotteryButton = new Button();
            getLotteryBank = new Button();
            getNoticeListButton = new Button();
            getNoticesCountButton = new Button();
            getNoticeDetailButton = new Button();
            moderatorRegisterUserButton = new Button();
            moderatorResetAccessTokenButton = new Button();
            adminGetUserProfileButton = new Button();
            adminSearchUserButton = new Button();
            adminUserDepositButton = new Button();
            adminUserWithdrawButton = new Button();
            adminTransactionsButton = new Button();
            adminGetNoticeListButton = new Button();
            adminPostNoticeButton = new Button();
            adminGetNoticesCountButton = new Button();
            adminGetNoticeDetailButton = new Button();
            adminEditNoticeButton = new Button();
            adminDeleteNoticeButton = new Button();
            adminGetIntegrationApplicationsButton = new Button();
            adminPostIntegrationApplicationButton = new Button();
            adminEditIntegrationApplicationButton = new Button();
            logTextBox = new TextBox();
            getBalanceHistoryButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pingButton);
            flowLayoutPanel1.Controls.Add(getMaintenanceStatusButton);
            flowLayoutPanel1.Controls.Add(getVersionButton);
            flowLayoutPanel1.Controls.Add(loginButton);
            flowLayoutPanel1.Controls.Add(searchUserButton);
            flowLayoutPanel1.Controls.Add(getProfileButton);
            flowLayoutPanel1.Controls.Add(getBalanceButton);
            flowLayoutPanel1.Controls.Add(getBalanceHistoryButton);
            flowLayoutPanel1.Controls.Add(getTransactionsButton);
            flowLayoutPanel1.Controls.Add(getStatsButton);
            flowLayoutPanel1.Controls.Add(depositButton);
            flowLayoutPanel1.Controls.Add(withdrawButton);
            flowLayoutPanel1.Controls.Add(transferButton);
            flowLayoutPanel1.Controls.Add(lotteryButton);
            flowLayoutPanel1.Controls.Add(getLotteryBank);
            flowLayoutPanel1.Controls.Add(getNoticeListButton);
            flowLayoutPanel1.Controls.Add(getNoticesCountButton);
            flowLayoutPanel1.Controls.Add(getNoticeDetailButton);
            flowLayoutPanel1.Controls.Add(moderatorRegisterUserButton);
            flowLayoutPanel1.Controls.Add(moderatorResetAccessTokenButton);
            flowLayoutPanel1.Controls.Add(adminGetUserProfileButton);
            flowLayoutPanel1.Controls.Add(adminSearchUserButton);
            flowLayoutPanel1.Controls.Add(adminUserDepositButton);
            flowLayoutPanel1.Controls.Add(adminUserWithdrawButton);
            flowLayoutPanel1.Controls.Add(adminTransactionsButton);
            flowLayoutPanel1.Controls.Add(adminGetNoticeListButton);
            flowLayoutPanel1.Controls.Add(adminPostNoticeButton);
            flowLayoutPanel1.Controls.Add(adminGetNoticesCountButton);
            flowLayoutPanel1.Controls.Add(adminGetNoticeDetailButton);
            flowLayoutPanel1.Controls.Add(adminEditNoticeButton);
            flowLayoutPanel1.Controls.Add(adminDeleteNoticeButton);
            flowLayoutPanel1.Controls.Add(adminGetIntegrationApplicationsButton);
            flowLayoutPanel1.Controls.Add(adminPostIntegrationApplicationButton);
            flowLayoutPanel1.Controls.Add(adminEditIntegrationApplicationButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(334, 743);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // pingButton
            // 
            pingButton.AutoSize = true;
            pingButton.Dock = DockStyle.Top;
            pingButton.ForeColor = Color.Green;
            pingButton.Location = new Point(3, 3);
            pingButton.Name = "pingButton";
            pingButton.Size = new Size(293, 25);
            pingButton.TabIndex = 48;
            pingButton.Text = "system/ping";
            pingButton.UseVisualStyleBackColor = true;
            pingButton.Click += pingButton_Click;
            // 
            // getMaintenanceStatusButton
            // 
            getMaintenanceStatusButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getMaintenanceStatusButton.AutoSize = true;
            getMaintenanceStatusButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getMaintenanceStatusButton.ForeColor = Color.Green;
            getMaintenanceStatusButton.Location = new Point(3, 34);
            getMaintenanceStatusButton.Name = "getMaintenanceStatusButton";
            getMaintenanceStatusButton.Size = new Size(293, 25);
            getMaintenanceStatusButton.TabIndex = 45;
            getMaintenanceStatusButton.Text = "system/maintenance";
            getMaintenanceStatusButton.UseVisualStyleBackColor = true;
            getMaintenanceStatusButton.Click += getMaintenanceStatusButton_Click;
            // 
            // getVersionButton
            // 
            getVersionButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getVersionButton.AutoSize = true;
            getVersionButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getVersionButton.ForeColor = Color.Green;
            getVersionButton.Location = new Point(3, 65);
            getVersionButton.Name = "getVersionButton";
            getVersionButton.Size = new Size(293, 25);
            getVersionButton.TabIndex = 49;
            getVersionButton.Text = "system/version";
            getVersionButton.UseVisualStyleBackColor = true;
            getVersionButton.Click += getVersionButton_Click;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButton.ForeColor = Color.Red;
            loginButton.Location = new Point(3, 96);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(293, 25);
            loginButton.TabIndex = 27;
            loginButton.Text = "auth/login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // searchUserButton
            // 
            searchUserButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchUserButton.AutoSize = true;
            searchUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchUserButton.ForeColor = Color.Blue;
            searchUserButton.Location = new Point(3, 127);
            searchUserButton.Name = "searchUserButton";
            searchUserButton.Size = new Size(293, 25);
            searchUserButton.TabIndex = 50;
            searchUserButton.Text = "users/search";
            searchUserButton.UseVisualStyleBackColor = true;
            searchUserButton.Click += searchUserButton_Click;
            // 
            // getProfileButton
            // 
            getProfileButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getProfileButton.AutoSize = true;
            getProfileButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getProfileButton.ForeColor = Color.DodgerBlue;
            getProfileButton.Location = new Point(3, 158);
            getProfileButton.Name = "getProfileButton";
            getProfileButton.Size = new Size(293, 25);
            getProfileButton.TabIndex = 28;
            getProfileButton.Text = "me";
            getProfileButton.UseVisualStyleBackColor = true;
            getProfileButton.Click += getProfileButton_Click;
            // 
            // getBalanceButton
            // 
            getBalanceButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getBalanceButton.AutoSize = true;
            getBalanceButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getBalanceButton.ForeColor = Color.DodgerBlue;
            getBalanceButton.Location = new Point(3, 189);
            getBalanceButton.Name = "getBalanceButton";
            getBalanceButton.Size = new Size(293, 25);
            getBalanceButton.TabIndex = 29;
            getBalanceButton.Text = "me/balance";
            getBalanceButton.UseVisualStyleBackColor = true;
            getBalanceButton.Click += getBalanceButton_Click;
            // 
            // getTransactionsButton
            // 
            getTransactionsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getTransactionsButton.AutoSize = true;
            getTransactionsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getTransactionsButton.ForeColor = Color.DodgerBlue;
            getTransactionsButton.Location = new Point(3, 251);
            getTransactionsButton.Name = "getTransactionsButton";
            getTransactionsButton.Size = new Size(293, 25);
            getTransactionsButton.TabIndex = 30;
            getTransactionsButton.Text = "me/transactions";
            getTransactionsButton.UseVisualStyleBackColor = true;
            getTransactionsButton.Click += getTransactionsButton_Click;
            // 
            // getStatsButton
            // 
            getStatsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getStatsButton.AutoSize = true;
            getStatsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getStatsButton.ForeColor = Color.DodgerBlue;
            getStatsButton.Location = new Point(3, 282);
            getStatsButton.Name = "getStatsButton";
            getStatsButton.Size = new Size(293, 25);
            getStatsButton.TabIndex = 31;
            getStatsButton.Text = "me/stats";
            getStatsButton.UseVisualStyleBackColor = true;
            getStatsButton.Click += getStatsButton_Click;
            // 
            // depositButton
            // 
            depositButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            depositButton.AutoSize = true;
            depositButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            depositButton.ForeColor = Color.DodgerBlue;
            depositButton.Location = new Point(3, 313);
            depositButton.Name = "depositButton";
            depositButton.Size = new Size(293, 25);
            depositButton.TabIndex = 32;
            depositButton.Text = "me/deposit";
            depositButton.UseVisualStyleBackColor = true;
            depositButton.Click += depositButton_Click;
            // 
            // withdrawButton
            // 
            withdrawButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            withdrawButton.AutoSize = true;
            withdrawButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            withdrawButton.ForeColor = Color.DodgerBlue;
            withdrawButton.Location = new Point(3, 344);
            withdrawButton.Name = "withdrawButton";
            withdrawButton.Size = new Size(293, 25);
            withdrawButton.TabIndex = 33;
            withdrawButton.Text = "me/withdraw";
            withdrawButton.UseVisualStyleBackColor = true;
            withdrawButton.Click += withdrawButton_Click;
            // 
            // transferButton
            // 
            transferButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            transferButton.AutoSize = true;
            transferButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            transferButton.ForeColor = Color.DodgerBlue;
            transferButton.Location = new Point(3, 375);
            transferButton.Name = "transferButton";
            transferButton.Size = new Size(293, 25);
            transferButton.TabIndex = 34;
            transferButton.Text = "me/transfer";
            transferButton.UseVisualStyleBackColor = true;
            transferButton.Click += transferButton_Click;
            // 
            // lotteryButton
            // 
            lotteryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lotteryButton.AutoSize = true;
            lotteryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            lotteryButton.ForeColor = Color.DodgerBlue;
            lotteryButton.Location = new Point(3, 406);
            lotteryButton.Name = "lotteryButton";
            lotteryButton.Size = new Size(293, 25);
            lotteryButton.TabIndex = 46;
            lotteryButton.Text = "me/lottery/draw";
            lotteryButton.UseVisualStyleBackColor = true;
            lotteryButton.Click += lotteryButton_Click;
            // 
            // getLotteryBank
            // 
            getLotteryBank.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getLotteryBank.AutoSize = true;
            getLotteryBank.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getLotteryBank.ForeColor = Color.DarkOrange;
            getLotteryBank.Location = new Point(3, 437);
            getLotteryBank.Name = "getLotteryBank";
            getLotteryBank.Size = new Size(293, 25);
            getLotteryBank.TabIndex = 47;
            getLotteryBank.Text = "lottery/bank";
            getLotteryBank.UseVisualStyleBackColor = true;
            getLotteryBank.Click += getLotteryBank_Click;
            // 
            // getNoticeListButton
            // 
            getNoticeListButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getNoticeListButton.AutoSize = true;
            getNoticeListButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getNoticeListButton.ForeColor = Color.Green;
            getNoticeListButton.Location = new Point(3, 468);
            getNoticeListButton.Name = "getNoticeListButton";
            getNoticeListButton.Size = new Size(293, 25);
            getNoticeListButton.TabIndex = 52;
            getNoticeListButton.Text = "notices";
            getNoticeListButton.UseVisualStyleBackColor = true;
            getNoticeListButton.Click += getNoticeListButton_Click;
            // 
            // getNoticesCountButton
            // 
            getNoticesCountButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getNoticesCountButton.AutoSize = true;
            getNoticesCountButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getNoticesCountButton.ForeColor = Color.Green;
            getNoticesCountButton.Location = new Point(3, 499);
            getNoticesCountButton.Name = "getNoticesCountButton";
            getNoticesCountButton.Size = new Size(293, 25);
            getNoticesCountButton.TabIndex = 51;
            getNoticesCountButton.Text = "notices/count";
            getNoticesCountButton.UseVisualStyleBackColor = true;
            getNoticesCountButton.Click += getNoticesCountButton_Click;
            // 
            // getNoticeDetailButton
            // 
            getNoticeDetailButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getNoticeDetailButton.AutoSize = true;
            getNoticeDetailButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getNoticeDetailButton.ForeColor = Color.Green;
            getNoticeDetailButton.Location = new Point(3, 530);
            getNoticeDetailButton.Name = "getNoticeDetailButton";
            getNoticeDetailButton.Size = new Size(293, 25);
            getNoticeDetailButton.TabIndex = 53;
            getNoticeDetailButton.Text = "notices/{noticeId}";
            getNoticeDetailButton.UseVisualStyleBackColor = true;
            getNoticeDetailButton.Click += getNoticeDetailButton_Click;
            // 
            // moderatorRegisterUserButton
            // 
            moderatorRegisterUserButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            moderatorRegisterUserButton.AutoSize = true;
            moderatorRegisterUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            moderatorRegisterUserButton.ForeColor = Color.DarkViolet;
            moderatorRegisterUserButton.Location = new Point(3, 561);
            moderatorRegisterUserButton.Name = "moderatorRegisterUserButton";
            moderatorRegisterUserButton.Size = new Size(293, 25);
            moderatorRegisterUserButton.TabIndex = 35;
            moderatorRegisterUserButton.Text = "moderator/users/register";
            moderatorRegisterUserButton.UseVisualStyleBackColor = true;
            moderatorRegisterUserButton.Click += moderatorRegisterUserButton_Click;
            // 
            // moderatorResetAccessTokenButton
            // 
            moderatorResetAccessTokenButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            moderatorResetAccessTokenButton.AutoSize = true;
            moderatorResetAccessTokenButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            moderatorResetAccessTokenButton.ForeColor = Color.DarkViolet;
            moderatorResetAccessTokenButton.Location = new Point(3, 592);
            moderatorResetAccessTokenButton.Name = "moderatorResetAccessTokenButton";
            moderatorResetAccessTokenButton.Size = new Size(293, 25);
            moderatorResetAccessTokenButton.TabIndex = 37;
            moderatorResetAccessTokenButton.Text = "moderator/users/{discordUserId}/access-token/reset";
            moderatorResetAccessTokenButton.UseVisualStyleBackColor = true;
            moderatorResetAccessTokenButton.Click += moderatorResetAccessTokenButton_Click;
            // 
            // adminGetUserProfileButton
            // 
            adminGetUserProfileButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetUserProfileButton.AutoSize = true;
            adminGetUserProfileButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminGetUserProfileButton.ForeColor = Color.Red;
            adminGetUserProfileButton.Location = new Point(3, 623);
            adminGetUserProfileButton.Name = "adminGetUserProfileButton";
            adminGetUserProfileButton.Size = new Size(293, 25);
            adminGetUserProfileButton.TabIndex = 40;
            adminGetUserProfileButton.Text = "admin/users/{discordUserId}";
            adminGetUserProfileButton.UseVisualStyleBackColor = true;
            adminGetUserProfileButton.Click += adminGetUserProfileButton_Click;
            // 
            // adminSearchUserButton
            // 
            adminSearchUserButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminSearchUserButton.AutoSize = true;
            adminSearchUserButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminSearchUserButton.ForeColor = Color.Red;
            adminSearchUserButton.Location = new Point(3, 654);
            adminSearchUserButton.Name = "adminSearchUserButton";
            adminSearchUserButton.Size = new Size(293, 25);
            adminSearchUserButton.TabIndex = 44;
            adminSearchUserButton.Text = "admin/users/search";
            adminSearchUserButton.UseVisualStyleBackColor = true;
            adminSearchUserButton.Click += adminSearchUserButton_Click;
            // 
            // adminUserDepositButton
            // 
            adminUserDepositButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminUserDepositButton.AutoSize = true;
            adminUserDepositButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminUserDepositButton.ForeColor = Color.Red;
            adminUserDepositButton.Location = new Point(3, 685);
            adminUserDepositButton.Name = "adminUserDepositButton";
            adminUserDepositButton.Size = new Size(293, 25);
            adminUserDepositButton.TabIndex = 41;
            adminUserDepositButton.Text = "admin/users/{discordUserId}/deposit";
            adminUserDepositButton.UseVisualStyleBackColor = true;
            adminUserDepositButton.Click += adminUserDepositButton_Click;
            // 
            // adminUserWithdrawButton
            // 
            adminUserWithdrawButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminUserWithdrawButton.AutoSize = true;
            adminUserWithdrawButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminUserWithdrawButton.ForeColor = Color.Red;
            adminUserWithdrawButton.Location = new Point(3, 716);
            adminUserWithdrawButton.Name = "adminUserWithdrawButton";
            adminUserWithdrawButton.Size = new Size(293, 25);
            adminUserWithdrawButton.TabIndex = 42;
            adminUserWithdrawButton.Text = "admin/users/{discordUserId}/withdraw";
            adminUserWithdrawButton.UseVisualStyleBackColor = true;
            adminUserWithdrawButton.Click += adminUserWithdrawButton_Click;
            // 
            // adminTransactionsButton
            // 
            adminTransactionsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminTransactionsButton.AutoSize = true;
            adminTransactionsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminTransactionsButton.ForeColor = Color.Red;
            adminTransactionsButton.Location = new Point(3, 747);
            adminTransactionsButton.Name = "adminTransactionsButton";
            adminTransactionsButton.Size = new Size(293, 25);
            adminTransactionsButton.TabIndex = 43;
            adminTransactionsButton.Text = "admin/transactions";
            adminTransactionsButton.UseVisualStyleBackColor = true;
            adminTransactionsButton.Click += adminTransactionsButton_Click;
            // 
            // adminGetNoticeListButton
            // 
            adminGetNoticeListButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetNoticeListButton.AutoSize = true;
            adminGetNoticeListButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminGetNoticeListButton.ForeColor = Color.Red;
            adminGetNoticeListButton.Location = new Point(3, 778);
            adminGetNoticeListButton.Name = "adminGetNoticeListButton";
            adminGetNoticeListButton.Size = new Size(293, 25);
            adminGetNoticeListButton.TabIndex = 54;
            adminGetNoticeListButton.Text = "GET admin/notices";
            adminGetNoticeListButton.UseVisualStyleBackColor = true;
            adminGetNoticeListButton.Click += adminGetNoticeListButton_Click;
            // 
            // adminPostNoticeButton
            // 
            adminPostNoticeButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminPostNoticeButton.AutoSize = true;
            adminPostNoticeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminPostNoticeButton.ForeColor = Color.Red;
            adminPostNoticeButton.Location = new Point(3, 809);
            adminPostNoticeButton.Name = "adminPostNoticeButton";
            adminPostNoticeButton.Size = new Size(293, 25);
            adminPostNoticeButton.TabIndex = 55;
            adminPostNoticeButton.Text = "POST admin/notices";
            adminPostNoticeButton.UseVisualStyleBackColor = true;
            adminPostNoticeButton.Click += adminPostNoticeButton_Click;
            // 
            // adminGetNoticesCountButton
            // 
            adminGetNoticesCountButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetNoticesCountButton.AutoSize = true;
            adminGetNoticesCountButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminGetNoticesCountButton.ForeColor = Color.Red;
            adminGetNoticesCountButton.Location = new Point(3, 840);
            adminGetNoticesCountButton.Name = "adminGetNoticesCountButton";
            adminGetNoticesCountButton.Size = new Size(293, 25);
            adminGetNoticesCountButton.TabIndex = 56;
            adminGetNoticesCountButton.Text = "admin/notices/count";
            adminGetNoticesCountButton.UseVisualStyleBackColor = true;
            adminGetNoticesCountButton.Click += adminGetNoticesCountButton_Click;
            // 
            // adminGetNoticeDetailButton
            // 
            adminGetNoticeDetailButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetNoticeDetailButton.AutoSize = true;
            adminGetNoticeDetailButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminGetNoticeDetailButton.ForeColor = Color.Red;
            adminGetNoticeDetailButton.Location = new Point(3, 871);
            adminGetNoticeDetailButton.Name = "adminGetNoticeDetailButton";
            adminGetNoticeDetailButton.Size = new Size(293, 25);
            adminGetNoticeDetailButton.TabIndex = 57;
            adminGetNoticeDetailButton.Text = "GET admin/notices/{noticeId}";
            adminGetNoticeDetailButton.UseVisualStyleBackColor = true;
            adminGetNoticeDetailButton.Click += adminGetNoticeDetailButton_Click;
            // 
            // adminEditNoticeButton
            // 
            adminEditNoticeButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminEditNoticeButton.AutoSize = true;
            adminEditNoticeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminEditNoticeButton.ForeColor = Color.Red;
            adminEditNoticeButton.Location = new Point(3, 902);
            adminEditNoticeButton.Name = "adminEditNoticeButton";
            adminEditNoticeButton.Size = new Size(293, 25);
            adminEditNoticeButton.TabIndex = 58;
            adminEditNoticeButton.Text = "PUT admin/notices/{noticeId}";
            adminEditNoticeButton.UseVisualStyleBackColor = true;
            adminEditNoticeButton.Click += adminEditNoticeButton_Click;
            // 
            // adminDeleteNoticeButton
            // 
            adminDeleteNoticeButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminDeleteNoticeButton.AutoSize = true;
            adminDeleteNoticeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminDeleteNoticeButton.ForeColor = Color.Red;
            adminDeleteNoticeButton.Location = new Point(3, 933);
            adminDeleteNoticeButton.Name = "adminDeleteNoticeButton";
            adminDeleteNoticeButton.Size = new Size(293, 25);
            adminDeleteNoticeButton.TabIndex = 59;
            adminDeleteNoticeButton.Text = "DELETE admin/notices/{noticeId}";
            adminDeleteNoticeButton.UseVisualStyleBackColor = true;
            adminDeleteNoticeButton.Click += adminDeleteNoticeButton_Click;
            // 
            // adminGetIntegrationApplicationsButton
            // 
            adminGetIntegrationApplicationsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminGetIntegrationApplicationsButton.AutoSize = true;
            adminGetIntegrationApplicationsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminGetIntegrationApplicationsButton.ForeColor = Color.Red;
            adminGetIntegrationApplicationsButton.Location = new Point(3, 964);
            adminGetIntegrationApplicationsButton.Name = "adminGetIntegrationApplicationsButton";
            adminGetIntegrationApplicationsButton.Size = new Size(293, 25);
            adminGetIntegrationApplicationsButton.TabIndex = 60;
            adminGetIntegrationApplicationsButton.Text = "GET admin/integration-applications";
            adminGetIntegrationApplicationsButton.UseVisualStyleBackColor = true;
            adminGetIntegrationApplicationsButton.Click += adminGetIntegrationApplicationsButton_Click;
            // 
            // adminPostIntegrationApplicationButton
            // 
            adminPostIntegrationApplicationButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminPostIntegrationApplicationButton.AutoSize = true;
            adminPostIntegrationApplicationButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminPostIntegrationApplicationButton.ForeColor = Color.Red;
            adminPostIntegrationApplicationButton.Location = new Point(3, 995);
            adminPostIntegrationApplicationButton.Name = "adminPostIntegrationApplicationButton";
            adminPostIntegrationApplicationButton.Size = new Size(293, 25);
            adminPostIntegrationApplicationButton.TabIndex = 61;
            adminPostIntegrationApplicationButton.Text = "POST admin/integration-applications";
            adminPostIntegrationApplicationButton.UseVisualStyleBackColor = true;
            adminPostIntegrationApplicationButton.Click += adminPostIntegrationApplicationButton_Click;
            // 
            // adminEditIntegrationApplicationButton
            // 
            adminEditIntegrationApplicationButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            adminEditIntegrationApplicationButton.AutoSize = true;
            adminEditIntegrationApplicationButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            adminEditIntegrationApplicationButton.ForeColor = Color.Red;
            adminEditIntegrationApplicationButton.Location = new Point(3, 1026);
            adminEditIntegrationApplicationButton.Name = "adminEditIntegrationApplicationButton";
            adminEditIntegrationApplicationButton.Size = new Size(293, 25);
            adminEditIntegrationApplicationButton.TabIndex = 62;
            adminEditIntegrationApplicationButton.Text = "PUT admin/integration-applications/{applicationId}";
            adminEditIntegrationApplicationButton.UseVisualStyleBackColor = true;
            adminEditIntegrationApplicationButton.Click += adminEditIntegrationApplicationButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(352, 12);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.Size = new Size(913, 743);
            logTextBox.TabIndex = 2;
            // 
            // getBalanceHistoryButton
            // 
            getBalanceHistoryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            getBalanceHistoryButton.AutoSize = true;
            getBalanceHistoryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getBalanceHistoryButton.ForeColor = Color.DodgerBlue;
            getBalanceHistoryButton.Location = new Point(3, 220);
            getBalanceHistoryButton.Name = "getBalanceHistoryButton";
            getBalanceHistoryButton.Size = new Size(293, 25);
            getBalanceHistoryButton.TabIndex = 63;
            getBalanceHistoryButton.Text = "me/balance/history";
            getBalanceHistoryButton.UseVisualStyleBackColor = true;
            getBalanceHistoryButton.Click += getBalanceHistoryButton_Click;
            // 
            // Tester
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 767);
            Controls.Add(logTextBox);
            Controls.Add(flowLayoutPanel1);
            Name = "Tester";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Button adminGetUserProfileButton;
        private Button adminUserDepositButton;
        private Button adminUserWithdrawButton;
        private Button adminTransactionsButton;
        private Button adminSearchUserButton;
        private Button getMaintenanceStatusButton;
        private Button lotteryButton;
        private Button getLotteryBank;
        private Button pingButton;
        private Button getVersionButton;
        private TextBox logTextBox;
        private Button searchUserButton;
        private Button getNoticesCountButton;
        private Button getNoticeListButton;
        private Button getNoticeDetailButton;
        private Button adminGetNoticeListButton;
        private Button adminPostNoticeButton;
        private Button adminGetNoticesCountButton;
        private Button adminGetNoticeDetailButton;
        private Button adminEditNoticeButton;
        private Button adminDeleteNoticeButton;
        private Button adminGetIntegrationApplicationsButton;
        private Button adminPostIntegrationApplicationButton;
        private Button adminEditIntegrationApplicationButton;
        private Button getBalanceHistoryButton;
    }
}
