using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ChallongeManager
{
    public partial class TournamentMatchControl : UserControl
    {
        #region Properties
        public string MatchId
        {
            get
            {
                return labelMatchNumber.Text;
            }

            set
            {
                labelMatchNumber.Text = value;
            }
        }

        public string Opponent1
        {
            get
            {
                return textBoxOpponent1.Text;
            }

            set
            {
                textBoxOpponent1.Text = value;
            }
        }

        public string Opponent2
        {
            get
            {
                return textBoxOpponent2.Text;
            }

            set
            {
                textBoxOpponent2.Text = value;
            }
        }
        #endregion

        public TournamentMatchControl()
        {
            InitializeComponent();
        }

        public void SetTooltip(string text)
        {
            toolTip1.SetToolTip(labelMatchNumber, text);
        }
    }
}
