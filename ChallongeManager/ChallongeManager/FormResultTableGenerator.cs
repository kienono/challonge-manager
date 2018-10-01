using ChallongeManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChallongeManager
{
    public partial class FormResultTableGenerator : Form
    {
        private ChallongeInterface _interface;
        private List<wr_Tournament> resultList = new List<wr_Tournament>();

        internal ChallongeInterface Interface
        {
            get
            {
                return _interface;
            }

            set
            {
                _interface = value;
            }
        }

        public FormResultTableGenerator()
        {
            InitializeComponent();
        }

        private void FormResultTableGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            progressBarRequest.Value = 0;
            progressBarRequest.Style = ProgressBarStyle.Marquee;
            backgroundWorkerChallongeRequest.RunWorkerAsync();            
        }

        private void backgroundWorkerChallongeRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            resultList = new List<wr_Tournament>();
            bool ret = _interface.GetEventTournaments(dateTimePickerEvent.Value, textBoxTag.Text, out resultList);
        }

        private void backgroundWorkerChallongeRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarRequest.Style = ProgressBarStyle.Continuous;
            progressBarRequest.Value = 100;

            // TODO: Request completed, generate code
            string ssf2x_Code = "";
            string sf3_Code = "";
            string karnov_Code = "";
            string dbfz_Code = "";
            string sf5_Code = "";
            string ggx_Code = "";
            string garou_Code = "";
            string vampire_Code = "";            
            string t7_Code = "";
            string season_Code = "";

            for (int i = 0; i < resultList.Count; i++)
            {               
                if (resultList[i].Name.Contains("2X"))
                {
                    ssf2x_Code = resultList[i].GetTournamentResultsHTML("2X",1,50);
                }
                else if (resultList[i].Name.Contains("3.3"))
                {
                    sf3_Code = resultList[i].GetTournamentResultsHTML("3.3", 1, 50);
                }
                else if (resultList[i].Name.Contains("DBFZ"))
                {
                    dbfz_Code = resultList[i].GetTournamentResultsHTML("DBFZ", 1, 50);
                }
                else if (resultList[i].Name.Contains("SFV"))
                {
                    sf5_Code = resultList[i].GetTournamentResultsHTML("SFV", 1, 50);
                }
                else if (resultList[i].Name.Contains("Garou"))
                {
                    garou_Code = resultList[i].GetTournamentResultsHTML("Garou", 1, 50);
                }
                else if (resultList[i].Name.Contains("XRD"))
                {
                    ggx_Code = resultList[i].GetTournamentResultsHTML("XRD", 1, 50);
                }
                else if (resultList[i].Name.Contains("Vampire"))
                {
                    vampire_Code = resultList[i].GetTournamentResultsHTML("Vampire", 1, 50);
                }
                else if (resultList[i].Name.Contains("Karnov"))
                {
                    karnov_Code = resultList[i].GetTournamentResultsHTML("Karnov", 1, 50);
                }
                else if (resultList[i].Name.Contains("Tekken 7"))
                {
                    t7_Code = resultList[i].GetTournamentResultsHTML("Tekken 7", 1, 50);
                }
                else if (resultList[i].Name.Contains("T7"))
                {
                    t7_Code = resultList[i].GetTournamentResultsHTML("T7", 1, 50);
                }
                else
                {
                    season_Code = resultList[i].GetTournamentResultsHTML("Season Game : " + Settings.Default.SeasonGame, 2, 50);
                }
            }

            List<string> finalResults = new List<string>();
            if (ssf2x_Code != "")
            {
                finalResults.Add(ssf2x_Code);
            }
            if (sf3_Code != "")
            {
                finalResults.Add(sf3_Code);
            }
            if (sf5_Code != "")
            {
                finalResults.Add(sf5_Code);
            }            
            if (vampire_Code != "")
            {
                finalResults.Add(vampire_Code);
            }
            if (garou_Code != "")
            {
                finalResults.Add(garou_Code);
            }
            if (karnov_Code != "")
            {
                finalResults.Add(karnov_Code);
            }
            if (ggx_Code != "")
            {
                finalResults.Add(ggx_Code);
            }            
            if (dbfz_Code != "")
            {
                finalResults.Add(dbfz_Code);
            }
            if (t7_Code != "")
            {
                finalResults.Add(t7_Code);
            }
            if (season_Code != "")
            {
                finalResults.Add(season_Code);
            }

            textBoxCode.Text = string.Format("<table style = \"text-align: center; margin-top: 15px;\" align = \"center\">" +
                "<tbody>" + Environment.NewLine);

            int columnCounter = 0;
            for (int i = 0; i < finalResults.Count; i++)
            {
                if (columnCounter == 0)
                {
                    textBoxCode.Text += "<tr> " + Environment.NewLine + finalResults[i];
                    columnCounter++;
                }
                else if (columnCounter == 1)
                {
                    textBoxCode.Text += finalResults[i] + "</tr> " + Environment.NewLine;
                    columnCounter = 0;
                }
            }

            if (columnCounter == 1)
            {
                textBoxCode.Text += "</tr> " + Environment.NewLine;
                columnCounter = 0;
            }
            textBoxCode.Text += "</tbody> " + Environment.NewLine + "</table> ";
    //"<tr> " + Environment.NewLine +
    //    ssf2x_Code +
    //    sf3_Code+
    //"</tr> " + Environment.NewLine +
    //"<tr> " + Environment.NewLine +       
    //    sf5_Code+
    //    t7_Code +
    //"</tr> " +Environment.NewLine +
    //"<tr> " + Environment.NewLine +
    //    vampire_Code+
    //    garou_Code+
    //"</tr>" + Environment.NewLine +
    //"<tr>" + Environment.NewLine +
    //    karnov_Code+
    //    ggx_Code+
    //"</tr>" + Environment.NewLine +
    //"<tr>" + Environment.NewLine +
    //    dbfz_Code +
    //"</tr>" + Environment.NewLine +
    //"<tr>" + Environment.NewLine +
    //    season_Code+
    //"</tr>" + Environment.NewLine +
    //"</tbody> " + Environment.NewLine +
    //"</table> ");

            string html = "<html><body>" + textBoxCode.Text + "</body></html>";
            webBrowserPreview.Navigate("about:blank");

            if (webBrowserPreview.Document != null)

            {

                webBrowserPreview.Document.Write(string.Empty);

            }

            webBrowserPreview.DocumentText = html;
        }
    }
}
