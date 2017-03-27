using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChallongeManager
{
    public partial class FormEventManager : Form
    {
        private ChallongeInterface _challongeInterface = new ChallongeInterface();

        public FormEventManager()
        {
            InitializeComponent();
            _challongeInterface.Initialize();
        }

        private void buttonGetTournamentData_Click(object sender, EventArgs e)
        {
            tournamentEventDoubleElimBracket extractedTournament;
            if (_challongeInterface.GetTournamentData(textBoxSingleChallongeTournID.Text, out extractedTournament))
            {
                int maxMatchesPerRound = 0;
                for (int i = 0; i < extractedTournament.TournamentWinnersDepth; i++)
                {
                    List<tournamentMatchBracket> matches = new List<tournamentMatchBracket>();
                    if (extractedTournament.GetWinnerBracketRoundMatches((uint)i + 1, out matches))
                    {
                        maxMatchesPerRound = Math.Max(maxMatchesPerRound, matches.Count);
                    }
                }

                // Draw winner's bracket
                tabPageWinnersBracket.SuspendLayout();
                // Clear bracket panel
                tabPageWinnersBracket.Controls.Clear();

                TournamentMatchControl currentMatchControl = new TournamentMatchControl();
                currentMatchControl.MatchId = extractedTournament.FinalMatch.MatchIdentifierInt;
                currentMatchControl.Opponent1 = extractedTournament.FinalMatch.Opponent1 != null ? extractedTournament.FinalMatch.Opponent1.Name : "";
                currentMatchControl.Opponent2 = extractedTournament.FinalMatch.Opponent2 != null ? extractedTournament.FinalMatch.Opponent2.Name : "";
                currentMatchControl.SetTooltip(extractedTournament.FinalMatch.MatchRoundAlias);               

                currentMatchControl.Location = new Point(0, 0);
                tabPageWinnersBracket.Controls.Add(currentMatchControl);

                int tournamentHeight = maxMatchesPerRound * (currentMatchControl.Height + 5);
                AddParentMatchesControls(tabPageWinnersBracket, currentMatchControl, extractedTournament.FinalMatch, tournamentHeight, true);

                // Relocate all controls
                int minX = 0;
                int minY = 0;
                foreach (Control item in tabPageWinnersBracket.Controls)
                {
                    minX = Math.Min(item.Location.X, minX);
                    minY = Math.Min(item.Location.Y, minY);
                }

                foreach (Control item in tabPageWinnersBracket.Controls)
                {
                    item.Location = new Point(item.Location.X - minX, item.Location.Y - minY);
                }

                tabPageWinnersBracket.ResumeLayout();

                // Draw looser's bracket
                tabPageLoosersBracket.SuspendLayout();
                // Clear bracket panel
                tabPageLoosersBracket.Controls.Clear();

                TournamentMatchControl currentLooserMatchControl = new TournamentMatchControl();
                currentLooserMatchControl.MatchId = extractedTournament.LoosersFinalMatch.MatchIdentifierInt;
                currentLooserMatchControl.Opponent1 = extractedTournament.LoosersFinalMatch.Opponent1 != null ? extractedTournament.LoosersFinalMatch.Opponent1.Name : "";
                currentLooserMatchControl.Opponent2 = extractedTournament.LoosersFinalMatch.Opponent2 != null ? extractedTournament.LoosersFinalMatch.Opponent2.Name : "";
                currentLooserMatchControl.SetTooltip(extractedTournament.LoosersFinalMatch.MatchRoundAlias);

                currentLooserMatchControl.Location = new Point(0, 0);
                tabPageLoosersBracket.Controls.Add(currentLooserMatchControl);

                tournamentHeight = maxMatchesPerRound * (currentLooserMatchControl.Height + 5);
                AddParentMatchesControls(tabPageLoosersBracket, currentLooserMatchControl, extractedTournament.LoosersFinalMatch, tournamentHeight, false);

                // Relocate all controls
                minX = 0;
                minY = 0;
                foreach (Control item in tabPageLoosersBracket.Controls)
                {
                    minX = Math.Min(item.Location.X, minX);
                    minY = Math.Min(item.Location.Y, minY);
                }

                foreach (Control item in tabPageLoosersBracket.Controls)
                {
                    item.Location = new Point(item.Location.X - minX, item.Location.Y - minY);
                }

                tabPageLoosersBracket.ResumeLayout();
            }
        }

        private void AddParentMatchesControls(Panel panelBracket, TournamentMatchControl currentMatchControl, tournamentMatchBracket match, int tournamentHeight, bool winnersBracket)
        {
            int verticalMargin = 5;
            int horizontalMargin = 10;

            bool addOpponent1PreviousMatch = (match.Opponent1PreviousMatch != null) &&
                                                (((match.Opponent1PreviousMatch.InWinnersBracket) && winnersBracket) ||
                                                ((!match.Opponent1PreviousMatch.InWinnersBracket) && !winnersBracket));
            bool addOpponent2PreviousMatch = (match.Opponent2PreviousMatch != null) &&
                                                (((match.Opponent2PreviousMatch.InWinnersBracket) && winnersBracket) ||
                                                ((!match.Opponent2PreviousMatch.InWinnersBracket) && !winnersBracket));
            Point opp1PreviousMatchLocation = new Point(currentMatchControl.Location.X - currentMatchControl.Width - horizontalMargin,
                                                                    currentMatchControl.Location.Y);
            Point opp2PreviousMatchLocation = new Point(currentMatchControl.Location.X - currentMatchControl.Width - horizontalMargin,
                                                                    currentMatchControl.Location.Y);
            bool samePreviousMatch = (match.Opponent1PreviousMatch != null) && (match.Opponent2PreviousMatch != null) &&
                (match.Opponent1PreviousMatch.MatchId == match.Opponent2PreviousMatch.MatchId);
            
            if (addOpponent1PreviousMatch && addOpponent2PreviousMatch &&
                !samePreviousMatch)
            {
                opp1PreviousMatchLocation = new Point(currentMatchControl.Location.X - currentMatchControl.Width - horizontalMargin,
                                                                    currentMatchControl.Location.Y - Math.Max((currentMatchControl.Height + verticalMargin)/ 2, tournamentHeight / (int)Math.Pow(2, (match.Opponent1PreviousMatch.Depth - 1))));
                opp2PreviousMatchLocation = new Point(currentMatchControl.Location.X - currentMatchControl.Width - horizontalMargin,
                                                                    currentMatchControl.Location.Y + Math.Max((currentMatchControl.Height + verticalMargin) / 2, tournamentHeight / (int)Math.Pow(2, (match.Opponent2PreviousMatch.Depth - 1))));
            }

            if (addOpponent1PreviousMatch)
            {
                TournamentMatchControl opp1PreviousMatchControl = new TournamentMatchControl();
                opp1PreviousMatchControl.MatchId = match.Opponent1PreviousMatch.MatchIdentifierInt;
                opp1PreviousMatchControl.Opponent1 = match.Opponent1PreviousMatch.Opponent1 != null ? match.Opponent1PreviousMatch.Opponent1.Name : "";
                opp1PreviousMatchControl.Opponent2 = match.Opponent1PreviousMatch.Opponent2 != null ? match.Opponent1PreviousMatch.Opponent2.Name : "";
                opp1PreviousMatchControl.SetTooltip(match.Opponent1PreviousMatch.MatchRoundAlias);
                opp1PreviousMatchControl.Location = opp1PreviousMatchLocation;

                panelBracket.Controls.Add(opp1PreviousMatchControl);
                AddParentMatchesControls(panelBracket, opp1PreviousMatchControl, match.Opponent1PreviousMatch, tournamentHeight, winnersBracket);
            }

            if (addOpponent2PreviousMatch && !samePreviousMatch)
            {
                TournamentMatchControl opp2PreviousMatchControl = new TournamentMatchControl();
                opp2PreviousMatchControl.MatchId = match.Opponent2PreviousMatch.MatchIdentifierInt;
                opp2PreviousMatchControl.Opponent1 = match.Opponent2PreviousMatch.Opponent1 != null ? match.Opponent2PreviousMatch.Opponent1.Name : "";
                opp2PreviousMatchControl.Opponent2 = match.Opponent2PreviousMatch.Opponent2 != null ? match.Opponent2PreviousMatch.Opponent2.Name : "";
                opp2PreviousMatchControl.SetTooltip(match.Opponent2PreviousMatch.MatchRoundAlias);
                opp2PreviousMatchControl.Location = opp2PreviousMatchLocation;

                panelBracket.Controls.Add(opp2PreviousMatchControl);
                AddParentMatchesControls(panelBracket, opp2PreviousMatchControl, match.Opponent2PreviousMatch, tournamentHeight, winnersBracket);
            }
        }

        private void FormEventManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
