using Hjp.Api.Client;
using Hjp.Api.Client.Tester;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Withdraw;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;
using Hjp.Shared.Dto.Me.Deposit;
using Hjp.Shared.Dto.Me.Transfer;
using Hjp.Shared.Dto.Me.Withdraw;
using System.Text.Json;
using Hjp.Shared.Dto.Admin.Notices;
using Hjp.Shared.Dto.Me.Lottery;
using Hjp.Shared.Dto.Admin.IntegrationApplications;
using Hjp.Shared.Dto.Me.Balance.History;
using Hjp.Shared.Dto.Moderator.Users.Lottery;
using Hjp.Shared.Dto.Moderator.Users.Transfer;
using Hjp.Shared.Dto.Moderator.Users.ServerActivityReward;
using Hjp.Shared.Dto.Admin.Users.Purchase;

namespace HJP_API_ClientTester
{
    public partial class Tester : Form
    {
        private HjpApiClient hjpApiClient;

        public Tester()
        {
            this.InitializeComponent();

            this.hjpApiClient = new HjpApiClient(AppSettings.ApiBaseUrl);
        }

        private void AppendLog(string message)
        {
            this.logTextBox.AppendText($"{message}\r\n");
            this.logTextBox.SelectionStart = this.logTextBox.Text.Length;
            this.logTextBox.ScrollToCaret();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.LoginAsync(AppSettings.AccessToken);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getProfileButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetProfileAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getBalanceButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetBalanceAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getTransactionsButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetTransactionsAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getStatsButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetStatsAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void depositButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserDepositRequest()
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 10,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.DepositAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void withdrawButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserWithdrawRequest()
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 15,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.WithdrawAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void transferButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserTransferRequest()
                {
                    ApplicationId = AppSettings.ApplicationId,
                    ToDiscordUserId = 555,
                    Amount = 5,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.TransferAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }


        // HACK: ここにメンバを書くべきではないが便宜上こうする
        private ulong lastCreatedDiscordUserId = 555;

        private async void moderatorRegisterUserButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var discordUserId = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new ModeratorUserRegisterRequest()
                {
                    DiscordUserId = discordUserId,
                    UserName = $"TestByTester: {discordUserId}",
                    AvatarUrl = $"https://test.bytester/{discordUserId}",
                };
                var result = await this.hjpApiClient.ModeratorClient.RegisterUserAsync(request);
                if (result.IsSuccess == true && result.Result != null)
                {
                    this.lastCreatedDiscordUserId = discordUserId;
                }
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorResetAccessTokenButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new ModeratorUserAccessTokenResetRequest()
                {
                    UserName = $"TestByTester: {now}",
                    AvatarUrl = $"https://test.by.tester/{now}",
                };
                var result = await this.hjpApiClient.ModeratorClient.ResetUserAccessTokenAsync(this.lastCreatedDiscordUserId, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminGetUserProfileButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetUserProfileAsync(this.lastCreatedDiscordUserId);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminUserDepositButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new AdminUserDepositRequest()
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 5,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
                };
                var result = await this.hjpApiClient.AdminClient.UserDepositAsync(this.lastCreatedDiscordUserId, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminUserWithdrawButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new AdminUserWithdrawRequest()
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 10,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
                };
                var result = await this.hjpApiClient.AdminClient.UserWithdrawAsync(this.lastCreatedDiscordUserId, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminTransactionsButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetTransactionsAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminSearchUserButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.SearchUserAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getMaintenanceStatusButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.GetMaintenanceStatusAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void lotteryButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserLotteryRequest
                {
                    ApplicationId = AppSettings.ApplicationId,
                };
                var result = await this.hjpApiClient.UsersClient.DrawLotteryAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getLotteryBank_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetLotteryBankAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getVersionButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.GetVersionAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void pingButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.PingAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void searchUserButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.SearchUserAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getNoticeListButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetNoticeListAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getNoticesCountButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetNoticesCountAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getNoticeDetailButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetNoticeDetailAsync(this.lastCreatedNoticeId);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminGetNoticeListButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetNoticeListAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        // HACK: ここにメンバを書くべきではないが便宜上こうする
        private int lastCreatedNoticeId = 8;

        private async void adminPostNoticeButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new AdminNoticePostRequest() { Title = $"TestByTester: {now}", Body = $"TestByTester: {now}" };
                var result = await this.hjpApiClient.AdminClient.PostNoticeAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
                this.lastCreatedNoticeId = result.Result!.Id;
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminGetNoticesCountButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetNoticesCountAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminGetNoticeDetailButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetNoticeDetailAsync(this.lastCreatedNoticeId);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminEditNoticeButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new AdminNoticeEditRequest() { Title = $"TestByTester: {now}", Body = $"TestByTester: {now}", IsRemoved = false };
                var result = await this.hjpApiClient.AdminClient.EditNoticeAsync(this.lastCreatedNoticeId, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminDeleteNoticeButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.RemoveNoticeAsync(this.lastCreatedNoticeId);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminGetIntegrationApplicationsButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.AdminClient.GetIntegrationApplicationListAsync();
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        // HACK: ここにメンバを書くべきではないが便宜上こうする
        private int lastCreatedApplicationId = 2000;

        private async void adminPostIntegrationApplicationButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new AdminIntegrationApplicationRegisterRequest
                {
                    ApplicationId = new Random().Next(),
                    Name = $"TestByTester: {now}",
                    IconUrl = "https://placehold.jp/150x150.png",
                    IsVisible = true,
                };
                var result = await this.hjpApiClient.AdminClient.RegisterIntegrationApplicationAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
                if (result.IsSuccess == true && result.Result != null)
                {
                    this.lastCreatedApplicationId = result.Result.ApplicationId;
                }
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminEditIntegrationApplicationButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var request = new AdminIntegrationApplicationEditRequest
                {
                    Name = $"TestByTester: {now}",
                    IconUrl = "https://placehold.jp/150x150.png",
                    IsVisible = true,
                };
                var result = await this.hjpApiClient.AdminClient.EditIntegrationApplicationAsync(this.lastCreatedApplicationId, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
                if (result.IsSuccess == true && result.Result != null)
                {
                    this.lastCreatedApplicationId = result.Result.ApplicationId;
                }
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void getBalanceHistoryButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserBalanceHistoryRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Now.AddDays(-14)),
                    To = DateOnly.FromDateTime(DateTime.Now),
                    Sort = Hjp.Shared.Enums.SortOrder.Ascending,
                    TimeZoneId = TimeZoneInfo.Local.Id,
                };
                var result = await this.hjpApiClient.UsersClient.GetBalanceHistoryAsync(request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorGetUserBalanceAsync_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.ModeratorClient.GetUserBalanceAsync(8888);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorDrawUserLotteryAsync_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new ModeratorUserLotteryRequest
                {
                    ApplicationId = AppSettings.ApplicationId
                };
                var result = await this.hjpApiClient.ModeratorClient.DrawUserLotteryAsync(8888, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorDepositServerActivityReward_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new ModeratorServerActivityRewardRequest
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 100,
                    Description = "報酬テスト",
                };
                var result = await this.hjpApiClient.ModeratorClient.DepositServerActivityRewardAsync(8888, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorUserTransfer_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new ModeratorUserTransferRequest
                {
                    ApplicationId = AppSettings.ApplicationId,
                    ToDiscordUserId = 5555,
                    Amount = 100,
                    Description = "送ポテスト",
                };
                var result = await this.hjpApiClient.ModeratorClient.UserTransferAsync(8888, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminUserPurchase_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new AdminUserPurchaseRequest
                {
                    ApplicationId = AppSettings.ApplicationId,
                    Amount = 100,
                    Description = "購入テスト",
                };
                var result = await this.hjpApiClient.AdminClient.UserPurchaseAsync(8888, request);
                this.AppendLog($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                this.AppendLog("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }
    }
}
