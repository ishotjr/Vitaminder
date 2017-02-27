using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http; // for HttpClient
using System.Threading.Tasks; // for TaskCanceledException
using Newtonsoft.Json; // for JSON deserializing 


namespace Vitaminder
{
    // for JSON parsing
    public class LwaResponse
    {
        public string access_token { get; set;  }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
    }

    public partial class HandleLogin : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            // TODO: handle empty/bad/etc.
            string code = Request.QueryString["code"];
            litCode.Text = code;

            await GetToken(code);
        }

        private async Task GetToken(string code)
        {

            HttpClient httpClient = new HttpClient();
            try
            {
                Uri hostUri = new Uri("https://api.amazon.com/auth/o2/token");
                httpClient.BaseAddress = hostUri;

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("client_id", "amzn1.application-oa2-client.d1c6352332154272b75adfa65a6031f5"),
                    new KeyValuePair<string, string>("client_secret", "f3c96d96832b5dadfcd13b0950fd2c4e528f0ddc2e106045593127ca357539c8"),
                    new KeyValuePair<string, string>("redirect_uri", "https://vitaminder.azurewebsites.net/AfterToken.aspx"),
                    new KeyValuePair<string, string>("token_type", "bearer")
                });
                /*
POST /auth/o2/token HTTP/1.1
Host: api.amazon.com
Content-Type: application/x-www-form-urlencoded
Cache-Control: no-cache

grant_type=authorization_code
code=ANiuYPfpaMvBrqCRfDJs
client_id=amzn1.application-oa2-client.d1c6352332154272b75adfa65a6031f5
client_secret=f3c96d96832b5dadfcd13b0950fd2c4e528f0ddc2e106045593127ca357539c8
redirect_uri=http%3A%2F%2Flocalhost%3A9000%2Fdrs-handle-login.html
token_type=bearer
                */

                var result = await httpClient.PostAsync("/auth/o2/token", formContent);
                string resultContent = await result.Content.ReadAsStringAsync();
                //litResult.Text = resultContent;

                // TODO: error handling!
                LwaResponse response = JsonConvert.DeserializeObject<LwaResponse>(resultContent);
                Session["AccessToken"] = response.access_token;
                Session["RefreshToken"] = response.refresh_token;

                litResult.Text = "<hr><em>" + resultContent + "</em><br><hr>";
                litResult.Text += "AccessToken: [";
                litResult.Text += Session["AccessToken"];
                litResult.Text += "] RefreshToken: [";
                litResult.Text += Session["RefreshToken"];
                litResult.Text += "]";
            }

            catch (HttpRequestException hre)
            {
                litResult.Text = "Error:" + hre.Message;
            }
            catch (TaskCanceledException)
            {
                litResult.Text = "Request canceled.";
            }
            catch (Exception ex)
            {
                litResult.Text = ex.Message;
            }
            finally
            {

                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }

        }
    }
}