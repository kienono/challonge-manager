using System.Collections.Generic;

namespace ChallongeManager
{
    internal class tournamentMatch
    {
        public enum MatchStatus
        {
            Opponent1Win,
            Opponent2Win,
            Draw,
            NotRunYet
        }
        #region Fields
        private int _matchId = -1;
        private string _matchIdentifier = "";
        private string _matchIdentifierInt = "";
        private string _matchRoundAlias = "";
        private static int _IdCounter = 0;

        private Participant _opponent1;
        private Participant _opponent2;
        private matchStation _matchLocation;
        private double _opponent1Score;
        private double _opponent2Score;
        private MatchStatus _result = MatchStatus.NotRunYet;
        #endregion

        #region Properties
        internal MatchStatus Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }    

        public int MatchId
        {
            get
            {
                return _matchId;
            }

            set
            {
                _matchId = value;
            }
        }

        public string MatchIdentifier
        {
            get
            {
                return _matchIdentifier;
            }

            set
            {
                _matchIdentifier = value;
            }
        }

        internal Participant Opponent1
        {
            get
            {
                return _opponent1;
            }

            set
            {
                _opponent1 = value;
            }
        }

        internal Participant Opponent2
        {
            get
            {
                return _opponent2;
            }

            set
            {
                _opponent2 = value;
            }
        }

        internal matchStation MatchLocation
        {
            get
            {
                return _matchLocation;
            }

            set
            {
                _matchLocation = value;
            }
        }

        public string MatchRoundAlias
        {
            get
            {
                return _matchRoundAlias;
            }

            set
            {
                _matchRoundAlias = value;
            }
        }

        public string MatchIdentifierInt
        {
            get
            {
                return _matchIdentifierInt;
            }

            set
            {
                _matchIdentifierInt = value;
            }
        }
        #endregion

        public tournamentMatch(int matchId, string matchIdentifier, Participant opponent1,
                                Participant opponent2,
                                matchStation matchLocation,
                                double opponent1Score,
                                double opponent2Score,
                                MatchStatus result)
        {
            _matchId = matchId;
            _matchIdentifier = matchIdentifier;
            _matchIdentifierInt = Tools.ConvertFromBase26(matchIdentifier).ToString();
            _matchLocation = matchLocation;
            _opponent1 = opponent1;
            _opponent2 = opponent2;
            _opponent1Score = opponent1Score;
            _opponent2Score = opponent2Score;
            _result = result;
        }

        public static int GetNextId()
        {
            return tournamentMatch._IdCounter++;
        }

        public void SetMatchResult(MatchStatus stat, double opponent1Score, double opponent2Score)
        {
            _result = stat;
            _opponent1Score = opponent1Score;
            _opponent2Score = opponent2Score;
        }
    }

    internal class tournamentMatchBracket: tournamentMatch
    {
        #region Fields
        private tournamentMatchBracket _opponent1PreviousMatch = null;
        private tournamentMatchBracket _winnerNextMatch = null;
        private tournamentMatchBracket _opponent2PreviousMatch = null;
        private tournamentMatchBracket _looserNextMatch = null;
        private bool _opponent1LoosePreviousMatch = false;
        private bool _opponent2LoosePreviousMatch = false;
        private int _depth = 0;
        private bool _inWinnersBracket = false;
        #endregion

        #region Properties
        internal tournamentMatchBracket Opponent1PreviousMatch
        {
            get
            {
                return _opponent1PreviousMatch;
            }

            set
            {
                _opponent1PreviousMatch = value;
            }
        }

        internal tournamentMatchBracket WinnerNextMatch
        {
            get
            {
                return _winnerNextMatch;
            }

            set
            {
                _winnerNextMatch = value;
            }
        }

        internal tournamentMatchBracket Opponent2PreviousMatch
        {
            get
            {
                return _opponent2PreviousMatch;
            }

            set
            {
                _opponent2PreviousMatch = value;
            }
        }

        internal tournamentMatchBracket LooserNextMatch
        {
            get
            {
                return _looserNextMatch;
            }

            set
            {
                _looserNextMatch = value;
            }
        }

        public bool Opponent1LoosePreviousMatch
        {
            get
            {
                return _opponent1LoosePreviousMatch;
            }

            set
            {
                _opponent1LoosePreviousMatch = value;
            }
        }

        public bool Opponent2LoosePreviousMatch
        {
            get
            {
                return _opponent2LoosePreviousMatch;
            }

            set
            {
                _opponent2LoosePreviousMatch = value;
            }
        }

        public int Depth
        {
            get
            {
                return _depth;
            }

            set
            {
                _depth = value;
            }
        }

        public bool InWinnersBracket
        {
            get
            {
                return _inWinnersBracket;
            }

            set
            {
                _inWinnersBracket = value;
            }
        }
        #endregion

        public tournamentMatchBracket(int matchId,
                                        string matchIdentifier,
                                        Participant opponent1, 
                                        Participant opponent2,
                                        matchStation matchLocation, 
                                        double opponent1Score, 
                                        double opponent2Score,
                                        bool opponent1LoosePreviousMatch,
                                        bool opponent2LoosePreviousMatch,
                                        MatchStatus result) : base(matchId, matchIdentifier, opponent1, opponent2, matchLocation, opponent1Score, opponent2Score, result)
        {
            _opponent1LoosePreviousMatch = opponent1LoosePreviousMatch;
            _opponent2LoosePreviousMatch = opponent2LoosePreviousMatch;
        }

        #region Methods
        public bool AddWinnersMatchesToStruc(ref List<tournamentMatchBracket> structure)
        {
            bool ret = false;
            if (_winnerNextMatch != null)
            {
                structure.Add(_winnerNextMatch);
                bool subret = _winnerNextMatch.AddWinnersMatchesToStruc(ref structure);

                ret = true;
            }            
            return ret;
        }
        #endregion
    }
}