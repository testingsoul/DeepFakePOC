using System;
using System.Windows.Forms;
using PluginsAPI;

using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DeepFake
{
    public partial class frmDeepFake : Form
    {
        public frmDeepFake()
        {
            InitializeComponent();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            labelSelectNone.Visible = false;
            labelInvalidURL.Visible = false;
            groupBox1.Visible = false;
            var uri = "";
            try
            {
                var url = new Uri(txtURL.Text);
                uri = url.AbsoluteUri;
            }
            catch
            {
                labelInvalidURL.Visible = true;
            }
            if (checkBox1.Checked | checkBox2.Checked | checkBox3.Checked)
            {
                if (!labelInvalidURL.Visible) {
                    _ = SendUriToScanAsync((object)uri);
                }
            }
            else {
                labelSelectNone.Visible = true;
            }  
        }


        /// <summary>
        /// Send value to FakeAPI and analize the results.
        /// Generic code to extract data from API
        /// var client = new HttpClient();
        /// string baseURL = "https://fake1.api";
        /// string videoURL = o.ToString();
        /// string urlReport = "/fake/request?video-url=";
        /// string accessToken = "fakeAccessToken1";
        /// client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        /// var response = await client.GetStringAsync(baseURL + urlReport + videoURL);
        /// JObject json = JObject.Parse(response);
        /// var dfDetected = json["results"]["detected"];
        /// var dfScore = json["results"]["score"];
        /// </summary>
        /// <param name="value"></param>
        private async Task SendUriToScanAsync(object o)
        {
            int dfScore = 0;
            int nScore = 0;
            label4.Text = "Not Analyzed";
            label5.Text = "Not Analyzed";
            label6.Text = "Not Analyzed";

            if (checkBox1.Checked)
            {
                // DeefFakeAPI1 Analysis
                // Include code to extract data from API1
                bool dfDetected = true;
                dfScore += int.Parse("90");
                nScore += 1;
                if (dfDetected)
                {
                    label4.Text = "The video analyzed is classified as DEEPFAKE ";
                }
                else
                {
                    label4.Text = "The video analyzed is NOT classified as DEEPFAKE";
                }
            }
            if (checkBox2.Checked)
            {
                // DeefFakeAPI2 Analysis
                // Include code to extract data from API2
                bool dfDetected = false;
                dfScore += int.Parse("5");
                nScore += 1;
                if (dfDetected)
                {
                    label5.Text = "The video analyzed is classified as DEEPFAKE";
                }
                else
                {
                    label5.Text = "The video analyzed is NOT classified as DEEPFAKE";
                }
            }
            if (checkBox3.Checked)
            {
                // DeefFakeAPI3 Analysis
                // Include code to extract data from API3
                bool dfDetected = true;
                dfScore += int.Parse("55");
                nScore += 1;
                if (dfDetected)
                {
                    label6.Text = "The video analyzed is classified as DEEPFAKE ";
                }
                else
                {
                    label6.Text = "The video analyzed is NOT classified as DEEPFAKE";
                }
            }
            dfScore /= nScore;
            groupBox1.Visible = true;
            labelScore.Text = dfScore.ToString() + "/100";
            if (dfScore < 33)
            {
                pictureBoxGreen.Visible = true;
                pictureBoxOrange.Visible = false;
                pictureBoxRed.Visible = false;
            }
            if (33 <= dfScore && 66 > dfScore)
            {
                pictureBoxGreen.Visible = false;
                pictureBoxOrange.Visible = true;
                pictureBoxRed.Visible = false;
            }
            if (dfScore >= 66)
            {
                pictureBoxGreen.Visible = false;
                pictureBoxOrange.Visible = false;
                pictureBoxRed.Visible = true;
            }
        }
    }
}
