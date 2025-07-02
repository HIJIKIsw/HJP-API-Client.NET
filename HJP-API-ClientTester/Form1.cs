using Hjp.Api.Client;
using Hjp.Api.Client.Tester;
using System.Diagnostics;

namespace HJP_API_ClientTester
{
    public partial class Form1 : Form
    {
        private HjpApiClient hjpApiClient;

        public Form1()
        {
            this.InitializeComponent();

            this.hjpApiClient = new HjpApiClient(AppSettings.ApiBaseUrl, AppSettings.ApiKey);
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            this.loginButton.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.LoginWithUserAsync(AppSettings.AccessToken);
                if (result.IsSuccess == false)
                {
                    throw new Exception(result.Message);
                }
                Debug.WriteLine("Login Success: " + result.Result?.UserName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                this.loginButton.Enabled = true;
            }
        }

        private async void getProfileButton_Click(object sender, EventArgs e)
        {
            this.getProfileButton.Enabled = false;
            try
            {
                var result = await this.hjpApiClient.UsersClient.GetProfileAsync();
                if (result.IsSuccess == false)
                {
                    throw new Exception(result.Message);
                }
                Debug.WriteLine("GetProfile Success: " + result.Result?.Name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                this.getProfileButton.Enabled = true;
            }
        }
    }
}
