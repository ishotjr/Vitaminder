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
    public partial class AfterToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // button handlers
            btnReplenish.Click += new EventHandler(btnReplenish_Click);

            // TODO: error handling
            litTokens.Text = "";
            litTokens.Text += "AccessToken: [";
            litTokens.Text += Session["AccessToken"];
            litTokens.Text += "] RefreshToken: [";
            litTokens.Text += Session["RefreshToken"];
            litTokens.Text += "]";
        }

        private async void btnReplenish_Click(object sender, EventArgs e)
        {
            await ReplenishSlot();
        }

        private async Task ReplenishSlot()
        {

            HttpClient httpClient = new HttpClient();
            try
            {
                Uri hostUri = new Uri("https://dash-replenishment-service-na.amazon.com");
                httpClient.BaseAddress = hostUri;
                 
                // add headers
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["AccessToken"]);
                httpClient.DefaultRequestHeaders.Add("x-amzn-accept-type", "com.amazon.dash.replenishment.DrsReplenishResult@1.0");
                httpClient.DefaultRequestHeaders.Add("x-amzn-type-version", "com.amazon.dash.replenishment.DrsReplenishInput@1.0");

                var noContent = new StringContent("");
                /*
POST /replenish/4c8746c0-91cf-40ac-a001-daca4ab0aa1c HTTP/1.1
Host: dash-replenishment-service-na.amazon.com
Authorization: Bearer Atza|IwEBIP-G_cMGDTwJw0S2ts_WLVRRsCN2rF8re4XjjychMuUdjj1UCoPcTah1fGGUpjiL2BeV3dGEyjjzNgvxywpxmls-ol3JPgA3uODbJzsPumeSNC6NNlZd8wyXxlpBgBWZjeYuqxTHEjaVzrvgu5-5FzeyLAYhiaB-6DM_PdqPRc5obFrxmN-iNk3uBaS093HsX6_eA-H1i-KDgcmL1ubUv56ZounaBTj7Phpma8MI2S_ezCKwg_ahAfOS8M0v2tEKPD8p_szm8PjvDQeTDypbr3vKYgur1gWjQAXBZpp2puKuoY5TWYRLSpSkXfZUaG_UCet6XdT4QQpaTa6kpo_z_0OMwyKxg-CZy0g2ugjFYy4X0dBnxVvDFOHy4-FOFPG-3FtNdRP4kRhDWms3W8L0tDIixj4YFZaXhHA_6pQUh8QjwIDZeTQhZsxuddOfsUllbsAwVrXtN8WqgovEhIlrI40Z
x-amzn-accept-type: com.amazon.dash.replenishment.DrsReplenishResult@1.0
x-amzn-type-version: com.amazon.dash.replenishment.DrsReplenishInput@1.0
Cache-Control: no-cache
Postman-Token: e4657a50-3a81-fa1d-b037-7672551dfa8c
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW
                */

                var result = await httpClient.PostAsync("/replenish/4c8746c0-91cf-40ac-a001-daca4ab0aa1c", noContent);
                string resultContent = await result.Content.ReadAsStringAsync();
                litResult.Text = "<div class=\"alert alert-success\" role=\"alert\">" + resultContent + "</div>";

                // TODO: error handling!
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