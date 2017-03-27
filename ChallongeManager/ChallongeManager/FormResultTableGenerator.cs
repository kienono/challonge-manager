﻿using System;
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
            string usf4_Code = "";
            string sf5_Code = "";
            string ggx_Code = "";
            string garou_Code = "";
            string vampire_Code = "";
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
                else if (resultList[i].Name.Contains("USF4"))
                {
                    usf4_Code = resultList[i].GetTournamentResultsHTML("USF4", 1, 50);
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
                else
                {
                    season_Code = resultList[i].GetTournamentResultsHTML("Season Game : Fighting Layer", 2, 100);
                }
            }

            textBoxCode.Text = string.Format("<table style = \"text-align: center; margin-top: 15px;\" align = \"center\">"+
                "<tbody>" + Environment.NewLine +
    "<tr> " + Environment.NewLine +
        ssf2x_Code +
        sf3_Code+
    "</tr> " + Environment.NewLine +
    "<tr> " + Environment.NewLine +
        usf4_Code+
        sf5_Code+
    "</tr> " +Environment.NewLine +
    "<tr> " + Environment.NewLine +
        vampire_Code+
        garou_Code+
    "</tr>" + Environment.NewLine +
    "<tr>" + Environment.NewLine +
        karnov_Code+
        ggx_Code+
    "</tr>" + Environment.NewLine +
    "<tr>" + Environment.NewLine +
        season_Code+
    "</tr>" + Environment.NewLine +
    "</tbody> " + Environment.NewLine +
    "</table> ");

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
