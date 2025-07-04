using Hjp.Api.Client;
using Hjp.Api.Client.Tester;
using Hjp.Shared.Dto.Admin.Login;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Withdraw;
using Hjp.Shared.Dto.Moderator.Login;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;
using Hjp.Shared.Dto.Users.Me.Deposit;
using Hjp.Shared.Dto.Users.Login;
using Hjp.Shared.Dto.Users.Me.Transfer;
using Hjp.Shared.Dto.Users.Me.Withdraw;
using System.Diagnostics;
using System.Text.Json;

namespace HJP_API_ClientTester
{
    public partial class Tester : Form
    {
        private HjpApiClient hjpApiClient;

        public Tester()
        {
            this.InitializeComponent();

            this.hjpApiClient = new HjpApiClient(AppSettings.ApiBaseUrl, AppSettings.ApiKey);
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new UserLoginRequest() { AccessToken = AppSettings.AccessToken };
                var result = await this.hjpApiClient.LoginWithUserAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                    Amount = 10,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.DepositAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                    Amount = 15,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.WithdrawAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                    ToDiscordUserId = 555,
                    Amount = 5,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                };
                var result = await this.hjpApiClient.UsersClient.TransferAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorLoginButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new ModeratorLoginRequest()
                {
                    AccessToken = AppSettings.AccessToken
                };
                var result = await this.hjpApiClient.LoginWithModeratorAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void moderatorGetAccessTokenButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.ModeratorClient.GetUserAccessTokenAsync(this.lastCreatedDiscordUserId);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private async void adminLoginButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            try
            {
                var request = new AdminLoginRequest() { AccessToken = AppSettings.AccessToken };
                var result = await this.hjpApiClient.LoginWithAdminAsync(request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                    Amount = 5,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
                };
                var result = await this.hjpApiClient.AdminClient.UserDepositAsync(this.lastCreatedDiscordUserId, request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                    Amount = 10,
                    Description = "TestByTester: " + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
                };
                var result = await this.hjpApiClient.AdminClient.UserWithdrawAsync(this.lastCreatedDiscordUserId, request);
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                var result = await this.hjpApiClient.AdminClient.SearchUserAsync();
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
                var result = await this.hjpApiClient.UsersClient.Lottery();
                Debug.WriteLine($"{button.Name}: " + JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                button.Enabled = true;
            }
        }
    }
}
