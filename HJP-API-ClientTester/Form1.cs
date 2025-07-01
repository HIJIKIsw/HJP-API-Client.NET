using Hjp.Api.Client;
using Hjp.Api.Client.Tester;
using System.Diagnostics;

namespace HJP_API_ClientTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            this.loginButton.Enabled = false;
            try
            {
                var hjpApiClient = new HjpApiClient(AppSettings.ApiBaseUrl, AppSettings.ApiKey);
                var result = await hjpApiClient.LoginWithUserAsync(AppSettings.AccessToken);
                Debug.WriteLine("Success: " + result.Result?.UserName);
            }
            finally
            {
                this.loginButton.Enabled = true;
            }
        }
    }
}
