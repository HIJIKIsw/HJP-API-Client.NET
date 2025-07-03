using Hjp.Api.Client;
using Hjp.Api.Client.Tester;
using Hjp.Shared.Dto.Users.Deposit;
using Hjp.Shared.Dto.Users.Login;
using Hjp.Shared.Dto.Users.Transfer;
using Hjp.Shared.Dto.Users.Withdraw;
using Hjp.Shared.Entities;
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
    }
}
