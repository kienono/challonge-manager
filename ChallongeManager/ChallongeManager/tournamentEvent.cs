using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChallongeManager
{
    internal class tournamentEvent
    {
        #region Fields
        protected int _participantIdCounter = 0;
        protected int _matchIdCounter = 0;

        protected string _gameName;
        protected List<Participant> _participants = new List<Participant>();
        protected DateTime _tournamentStartDate;
        protected DateTime _tournamentEndDate;
        protected string _place;
        protected tournamentVenue _venue;
        protected Color _mainColor;

        protected Dictionary<int, tournamentMatch> _matches = new Dictionary<int, tournamentMatch>();
        
        protected List<tournamentEvent> _subTournaments = new List<tournamentEvent>();

        #endregion

        #region Method
        public bool AddParticipant(Participant newParticipant)
        {
            _participants.Add(newParticipant);

            return true;
        }

        public Participant GetParticipantFromName(string name)
        {
            for (int i = 0; i < _participants.Count; i++)
            {
                if (_participants[i].Name == name)
                {
                    return _participants[i];
                }
            }
            return null;
        }

        public Participant GetParticipantFromId(int id)
        {
            for (int i = 0; i < _participants.Count; i++)
            {
                if (_participants[i].Id == id)
                {
                    return _participants[i];
                }
            }
            return null;
        }
        #endregion
    }

    internal class tournamentEventSingleElimBracket : tournamentEvent
    {

    }

    internal class tournamentEventDoubleElimBracket : tournamentEvent
    {
        private List<int> winnersBracketMatchesIds = new List<int>();
        private List<int> loosersBracketMatchesIds = new List<int>();
        
        private tournamentMatchBracket _finalMatch;
        private tournamentMatchBracket _loosersFinalMatch;
        private int _tournamentWinnersDepth = 0;
        private int _tournamentLoosersDepth = 0;

        #region Properties
        protected List<int> WinnersBracketMatchesIds
        {
            get
            {
                return winnersBracketMatchesIds;
            }

            set
            {
                winnersBracketMatchesIds = value;
            }
        }

        protected List<int> LoosersBracketMatchesIds
        {
            get
            {
                return loosersBracketMatchesIds;
            }

            set
            {
                loosersBracketMatchesIds = value;
            }
        }

        internal tournamentMatchBracket FinalMatch
        {
            get
            {
                return _finalMatch;
            }

            set
            {
                _finalMatch = value;
            }
        }

        public int TournamentWinnersDepth
        {
            get
            {
                return _tournamentWinnersDepth;
            }

            set
            {
                _tournamentWinnersDepth = value;
            }
        }

        internal tournamentMatchBracket LoosersFinalMatch
        {
            get
            {
                return _loosersFinalMatch;
            }

            set
            {
                _loosersFinalMatch = value;
            }
        }

        public int TournamentLoosersDepth
        {
            get
            {
                return _tournamentLoosersDepth;
            }

            set
            {
                _tournamentLoosersDepth = value;
            }
        }

        internal tournamentMatchBracket LoosersFinalMatch1
        {
            get
            {
                return _loosersFinalMatch;
            }

            set
            {
                _loosersFinalMatch = value;
            }
        }
        #endregion

        #region Methods
        #region Public
        public void InitializeTournament(Dictionary<int, wr_Match> matchPool, int lastMatchId)
        {
            winnersBracketMatchesIds = new List<int>();
            loosersBracketMatchesIds = new List<int>();
            _matches = new Dictionary<int, tournamentMatch>();

            AddMatchToTournament(matchPool, lastMatchId, 0, false);
            FillWinnersAndLoosersMatches();
        }

        public bool GetWinnerBracketRoundMatches(uint roundNb, out List<tournamentMatchBracket> matches)
        {
            bool ret = false;
            matches = new List<tournamentMatchBracket>();
            if (roundNb <= _tournamentWinnersDepth)
            {
                foreach (int item in winnersBracketMatchesIds)
                {
                    if (roundNb == _tournamentWinnersDepth - ((tournamentMatchBracket)_matches[item]).Depth + 1)
                    {
                        matches.Add(((tournamentMatchBracket)_matches[item]));
                    }
                }
                ret = matches.Count > 0;
            }
            return ret;
        }
        #endregion

        #region Private
        private tournamentMatchBracket AddMatchToTournament(Dictionary<int, wr_Match> matchPool, int baseMatchId, int matchDepth, bool isInLoosersBracket)
        {
            int opponent1Id;
            int opponent2Id;

            int.TryParse(matchPool[baseMatchId].Player1Id, out opponent1Id);
            int.TryParse(matchPool[baseMatchId].Player2Id, out opponent2Id);

            tournamentMatchBracket currentMatch = new tournamentMatchBracket(baseMatchId,
                                                                                matchPool[baseMatchId].Identifier,
                                                                                GetParticipantFromId(opponent1Id),
                                                                                GetParticipantFromId(opponent2Id),
                                                                                new matchStation(),
                                                                                matchPool[baseMatchId].Player1Points,
                                                                                matchPool[baseMatchId].Player2Points,
                                                                                matchPool[baseMatchId].Player1IsPrereqMatchLooserField == "true",
                                                                                matchPool[baseMatchId].Player2IsPrereqMatchLooserField == "true",
                                                                                tournamentMatch.MatchStatus.NotRunYet);
            currentMatch.Depth = matchDepth;

            bool player1PrevMatchLoose = false;
            bool player2PrevMatchLoose = false;

            int player1PreviousMatchId = -1;
            int player2PreviousMatchId = -1;

            // In looser's bracket, consider previous match only if winning
            if (matchPool[baseMatchId].Player1PrereqMatchIdField != null)
            {
                player1PreviousMatchId = int.Parse(matchPool[baseMatchId].Player1PrereqMatchIdField);
                if (matchPool[baseMatchId].Player1IsPrereqMatchLooserField == "true")
                {
                    player1PrevMatchLoose = true;
                }

                //    if (matchPool[baseMatchId].Player1PrereqMatchIdField == matchPool[baseMatchId].Player2PrereqMatchIdField)                    
                //{
                //    tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, matchId, matchDepth + 1, false);
                //    currentMatch.Opponent1PreviousMatch = player1PrereqMatch;
                //    ((tournamentMatchBracket)_matches[matchId]).WinnerNextMatch = currentMatch;
                //}
                //else if (matchPool[baseMatchId].Player1IsPrereqMatchLooserField == "false")
                //{
                //    tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, matchId, matchDepth + 1, isInLoosersBracket);
                //    currentMatch.Opponent1PreviousMatch = player1PrereqMatch;
                //    ((tournamentMatchBracket)_matches[matchId]).LooserNextMatch = currentMatch;
                //}
                //else if(matchPool[baseMatchId].Player1IsPrereqMatchLooserField == "true")
                //{
                //    tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, matchId, matchDepth + 1, false);
                //    currentMatch.Opponent1PreviousMatch = player1PrereqMatch;
                //    ((tournamentMatchBracket)_matches[matchId]).LooserNextMatch = currentMatch;
                //    player1PrevMatchLoose = true;
                //}
            }

            if (matchPool[baseMatchId].Player2PrereqMatchIdField != null)
            {
                player2PreviousMatchId = int.Parse(matchPool[baseMatchId].Player2PrereqMatchIdField);
                if (matchPool[baseMatchId].Player2IsPrereqMatchLooserField == "true")
                {
                    player2PrevMatchLoose = true;
                }

                //if ((matchPool[baseMatchId].Player2PrereqMatchIdField == matchPool[baseMatchId].Player2PrereqMatchIdField) ||
                //    (matchPool[baseMatchId].Player2IsPrereqMatchLooserField == "false"))
                //{
                //    tournamentMatchBracket player2PrereqMatch = AddMatchToTournament(matchPool, matchId, matchDepth + 1, false);
                //    currentMatch.Opponent1PreviousMatch = player2PrereqMatch;
                //    ((tournamentMatchBracket)_matches[matchId]).WinnerNextMatch = currentMatch;
                //}
                //else if (matchPool[baseMatchId].Player2IsPrereqMatchLooserField == "true")
                //{
                //    if (!isInLoosersBracket)
                //    {
                //        tournamentMatchBracket player2PrereqMatch = AddMatchToTournament(matchPool, matchId, matchDepth + 1, true);
                //        currentMatch.Opponent1PreviousMatch = player2PrereqMatch;
                //        ((tournamentMatchBracket)_matches[matchId]).LooserNextMatch = currentMatch;
                //    }
                //    player2PrevMatchLoose = true;
                //}
            }

            isInLoosersBracket = isInLoosersBracket || (player1PrevMatchLoose && player2PrevMatchLoose);

            if (isInLoosersBracket)
            {
                if (player1PreviousMatchId!=-1)                    
                {
                    if (!player1PrevMatchLoose)
                    {
                        tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, player1PreviousMatchId, matchDepth + 1, true);
                        currentMatch.Opponent1PreviousMatch = player1PrereqMatch;
                    }
                    else
                    {
                        //tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, player1PreviousMatchId, matchDepth + 1, false);
                        currentMatch.Opponent1PreviousMatch = (tournamentMatchBracket)_matches[player1PreviousMatchId];                        
                    }
                    ((tournamentMatchBracket)_matches[player1PreviousMatchId]).WinnerNextMatch = currentMatch;
                }

                if (player2PreviousMatchId != -1)
                {
                    if (!player2PrevMatchLoose)
                    {
                        tournamentMatchBracket player2PrereqMatch = AddMatchToTournament(matchPool, player2PreviousMatchId, matchDepth + 1, true);
                        currentMatch.Opponent2PreviousMatch = player2PrereqMatch;
                    }
                    else
                    {
                        //tournamentMatchBracket player2PrereqMatch = AddMatchToTournament(matchPool, player2PreviousMatchId, matchDepth + 1, false);
                        currentMatch.Opponent2PreviousMatch = (tournamentMatchBracket)_matches[player2PreviousMatchId];
                    }
                    ((tournamentMatchBracket)_matches[player2PreviousMatchId]).WinnerNextMatch = currentMatch;
                }
            }
            else
            {
                if (player1PreviousMatchId != -1)
                {
                    bool previousMatchInLoosers = false;
                    if (!player1PrevMatchLoose)
                    {
                        // if 2 matches before, player1 loosed, its previous match is in looser's
                        if (matchPool[player1PreviousMatchId].Player1IsPrereqMatchLooserField == "true")
                        {
                            previousMatchInLoosers = true;
                        }
                    }
                    tournamentMatchBracket player1PrereqMatch = AddMatchToTournament(matchPool, player1PreviousMatchId, matchDepth + 1, previousMatchInLoosers);
                    currentMatch.Opponent1PreviousMatch = player1PrereqMatch;
                    ((tournamentMatchBracket)_matches[player1PreviousMatchId]).WinnerNextMatch = currentMatch;
                }

                if (player2PreviousMatchId != -1)
                {
                    bool previousMatchInLoosers = false;
                    if (!player2PrevMatchLoose)
                    {
                        // if 2 matches before, player1 loosed, its previous match is in looser's
                        if (matchPool[player2PreviousMatchId].Player1IsPrereqMatchLooserField == "true")
                        {
                            previousMatchInLoosers = true;
                        }
                    }
                    tournamentMatchBracket player2PrereqMatch = AddMatchToTournament(matchPool, player2PreviousMatchId, matchDepth + 1, previousMatchInLoosers);
                    currentMatch.Opponent2PreviousMatch = player2PrereqMatch;
                    ((tournamentMatchBracket)_matches[player2PreviousMatchId]).WinnerNextMatch = currentMatch;
                }
            }

            AddMatch(currentMatch);
            if (isInLoosersBracket)
            {
                if (!LoosersBracketMatchesIds.Contains(currentMatch.MatchId))
                {
                    LoosersBracketMatchesIds.Add(currentMatch.MatchId);
                    ((tournamentMatchBracket)_matches[currentMatch.MatchId]).InWinnersBracket = false;
                    _tournamentLoosersDepth = Math.Max(matchDepth, _tournamentLoosersDepth);
                }
            }
            else
            {
                if (!WinnersBracketMatchesIds.Contains(currentMatch.MatchId))
                {
                    WinnersBracketMatchesIds.Add(currentMatch.MatchId);
                    ((tournamentMatchBracket)_matches[currentMatch.MatchId]).InWinnersBracket = true;
                    _tournamentWinnersDepth = Math.Max(matchDepth, _tournamentWinnersDepth);
                }
            }

            _finalMatch = currentMatch;
            return currentMatch;
        }
        private void FillWinnersAndLoosersMatches()
        {
            // Fill main structure
            foreach (KeyValuePair<int, tournamentMatch> item in _matches)
            {
                if (((tournamentMatchBracket)item.Value).Opponent1PreviousMatch != null)
                {
                    if (((tournamentMatchBracket)item.Value).Opponent1LoosePreviousMatch)
                    {
                        ((tournamentMatchBracket)item.Value).Opponent1PreviousMatch.LooserNextMatch = (tournamentMatchBracket)item.Value;
                    }
                    else
                    {
                        ((tournamentMatchBracket)item.Value).Opponent1PreviousMatch.WinnerNextMatch = (tournamentMatchBracket)item.Value;
                    }
                }

                if (((tournamentMatchBracket)item.Value).Opponent2PreviousMatch != null)
                {
                    if (((tournamentMatchBracket)item.Value).Opponent2LoosePreviousMatch)
                    {
                        ((tournamentMatchBracket)item.Value).Opponent2PreviousMatch.LooserNextMatch = (tournamentMatchBracket)item.Value;
                    }
                    else
                    {
                        ((tournamentMatchBracket)item.Value).Opponent2PreviousMatch.WinnerNextMatch = (tournamentMatchBracket)item.Value;
                    }
                }
            }
            foreach (KeyValuePair<int, tournamentMatch> item in _matches)
            {
                if (((tournamentMatchBracket)item.Value).WinnerNextMatch != null)
                {
                    ((tournamentMatchBracket)item.Value).WinnerNextMatch = _matches[((tournamentMatchBracket)item.Value).WinnerNextMatch.MatchId] as tournamentMatchBracket;
                }
                if (((tournamentMatchBracket)item.Value).LooserNextMatch != null)
                {
                    ((tournamentMatchBracket)item.Value).LooserNextMatch = _matches[((tournamentMatchBracket)item.Value).LooserNextMatch.MatchId] as tournamentMatchBracket;
                }
            }

            // Update winner's bracket structure
            foreach (int item in WinnersBracketMatchesIds)
            {
                ((tournamentMatchBracket)_matches[item]).MatchRoundAlias = String.Format("Winner's bracket, round {0}", _tournamentWinnersDepth - ((tournamentMatchBracket)_matches[item]).Depth);
            }

            // Update looser's bracket structure
            // First remove final matches (grand final and bracket reset) from looser's bracket
            LoosersBracketMatchesIds.Remove(FinalMatch.MatchId);            
            foreach (int item in LoosersBracketMatchesIds)
            {

                if (((tournamentMatchBracket)_matches[item]).WinnerNextMatch.MatchId == FinalMatch.Opponent1PreviousMatch.MatchId)
                {
                    _loosersFinalMatch = ((tournamentMatchBracket)_matches[item]);
                    _loosersFinalMatch.Depth = 0;
                    _tournamentLoosersDepth = 1;
                    SetNextDepthInLoosers(_loosersFinalMatch, true);
                }
            }
            if (_loosersFinalMatch == null)
            {
                if (!FinalMatch.Opponent1PreviousMatch.InWinnersBracket && FinalMatch.Opponent2PreviousMatch.InWinnersBracket)
                {
                    _loosersFinalMatch = (FinalMatch.Opponent1PreviousMatch);
                    _loosersFinalMatch.Depth = 0;
                    _tournamentLoosersDepth = 1;
                    SetNextDepthInLoosers(_loosersFinalMatch, true);
                }
                if (FinalMatch.Opponent1PreviousMatch.InWinnersBracket && !FinalMatch.Opponent2PreviousMatch.InWinnersBracket)
                {
                    _loosersFinalMatch = (FinalMatch.Opponent2PreviousMatch);
                    _loosersFinalMatch.Depth = 0;
                    _tournamentLoosersDepth = 1;
                    SetNextDepthInLoosers(_loosersFinalMatch, true);
                }
            }
            foreach (int item in LoosersBracketMatchesIds)
            {
                ((tournamentMatchBracket)_matches[item]).MatchRoundAlias = String.Format("Looser's bracket, round {0}", _tournamentLoosersDepth - ((tournamentMatchBracket)_matches[item]).Depth);
            }

        }
        private bool AddMatch(tournamentMatchBracket newMatch)
        {
            if (!_matches.ContainsKey(newMatch.MatchId))
            {
                _matches.Add(newMatch.MatchId, newMatch);
            }

            return true;
        }

        private bool SetNextDepthInLoosers(tournamentMatchBracket baseMatch, bool recursive)
        {
            bool ret = false;
            if ((baseMatch.Opponent1PreviousMatch != null) && 
                (loosersBracketMatchesIds.Contains(baseMatch.Opponent1PreviousMatch.MatchId)))
            {
                ((tournamentMatchBracket)_matches[baseMatch.Opponent1PreviousMatch.MatchId]).Depth = baseMatch.Depth + 1;
                if (recursive)
                {
                    SetNextDepthInLoosers(((tournamentMatchBracket)_matches[baseMatch.Opponent1PreviousMatch.MatchId]), recursive);
                }
                ret = true;
            }
            if ((baseMatch.Opponent2PreviousMatch != null) &&
                (loosersBracketMatchesIds.Contains(baseMatch.Opponent2PreviousMatch.MatchId)))
            {
                ((tournamentMatchBracket)_matches[baseMatch.Opponent2PreviousMatch.MatchId]).Depth = baseMatch.Depth + 1;
                if (recursive)
                {
                    SetNextDepthInLoosers(((tournamentMatchBracket)_matches[baseMatch.Opponent2PreviousMatch.MatchId]), recursive);
                }
                ret = true;
            }
            _tournamentLoosersDepth = Math.Max(baseMatch.Depth, _tournamentLoosersDepth);
            
            return ret;
        }
        #endregion
        #endregion       

        public tournamentMatchBracket GetParticipantFirstMatch(Participant participant)
        {
            foreach (int item in WinnersBracketMatchesIds)
            {
                if (((_matches[item].Opponent1 != null) && (_matches[item].Opponent1.Id == participant.Id) && (((tournamentMatchBracket)_matches[item]).Opponent1PreviousMatch == null)) || 
                    ((_matches[item].Opponent2 != null) && (_matches[item].Opponent2.Id == participant.Id) && (((tournamentMatchBracket)_matches[item]).Opponent2PreviousMatch == null)))
                {
                    return _matches[item] as tournamentMatchBracket;
                }
            }
            return null;
        }

        public bool GetWinnerBracketFirstRoundMatches(out List<tournamentMatchBracket> matches)
        {
            bool ret = false;
            matches = new List<tournamentMatchBracket>();

            foreach (int item in WinnersBracketMatchesIds)
            {
                if ((((tournamentMatchBracket)_matches[item]).Opponent1PreviousMatch == null) &&
                    (((tournamentMatchBracket)_matches[item]).Opponent2PreviousMatch == null) &&
                    (((tournamentMatchBracket)_matches[item]).Depth == _tournamentWinnersDepth))
                {
                    matches.Add((tournamentMatchBracket)_matches[item]);
                }
            }
            ret = matches.Count > 0;
            return ret;
        }

    }
}
