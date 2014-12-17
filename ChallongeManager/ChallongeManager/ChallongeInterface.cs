using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ChallongeManager.Properties;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ChallongeManager
{
    public class ChallongeInterface
    {
        #region Fields
        private List<wr_Tournament> _tournamentsList = new List<wr_Tournament>();
        private List<Game> _gameList = new List<Game>();
        #endregion

        #region Properties
        public List<wr_Tournament> TournamentsList
        {
            get { return _tournamentsList; }
        }

        public List<Game> GameList
        {
            get { return _gameList; }
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            // Build game list from settings (1 game per line, game aliases separated by '/')
            string[] gamesList = Settings.Default.Challonge_GameList.Split( new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < gamesList.Length; i++)
            {
                string[] namesList = gamesList[i].Split(new char[] {'/'},StringSplitOptions.RemoveEmptyEntries);
                if (namesList.Length > 0)
                {
                    Game newGame = new Game(namesList[0]);
                    for (int j = 1; j < namesList.Length; j++)
                    {
                        newGame.AddAlias(namesList[j]);
                    }
                    _gameList.Add(newGame);
                }                
            }
        }

        public bool GetTournaments(DateTime afterDate, DateTime beforeDate)
        {
            bool ret = false;
            if (beforeDate > afterDate)
            {
                _tournamentsList = new List<wr_Tournament>();
                // date consistency ok, retrieve data

                // First retrieve tournaments list
                string tournamentListRequest = string.Format("https://{0}:{1}@api.challonge.com/v1/tournaments.xml?created_after={2}&created_before={3}", 
                                                                Settings.Default.Challonge_ID, 
                                                                Settings.Default.Challonge_APIkey,
                                                                afterDate.ToString("yyyy-MM-dd"),
                                                                beforeDate.ToString("yyyy-MM-dd"));
                WebRequest request = WebRequest.Create(tournamentListRequest);
                System.Net.NetworkCredential netCredential = new System.Net.NetworkCredential(Settings.Default.Challonge_ID, Settings.Default.Challonge_APIkey, "");
                request.Credentials = netCredential;
                
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();

                XmlSerializer ser = new XmlSerializer(typeof(tournaments));
                tournaments reqTournamentList;
                using (XmlReader xmlreader = XmlReader.Create(dataStream))
                {
                    reqTournamentList = (tournaments)ser.Deserialize(xmlreader);
                }
                response.Close();

                // Then fill in each tournaments complying with search tag
                for (int i = 0; i < reqTournamentList.tournament.Length; i++)
                {
                    if (reqTournamentList.tournament[i].name.Contains(Settings.Default.Challonge_SearchTag) &&
                        (reqTournamentList.tournament[i].state == "complete")  &&
                        ((reqTournamentList.tournament[i].tournamenttype == "single elimination") || (reqTournamentList.tournament[i].tournamenttype == "double elimination")))
                    {
                        string currentTournamentID = reqTournamentList.tournament[i].id[0].Value;
                        string tournamentRequest = string.Format("https://{0}:{1}@api.challonge.com/v1/tournaments/{2}.xml?include_participants=1&include_matches=1",
                                                                    Settings.Default.Challonge_ID,
                                                                    Settings.Default.Challonge_APIkey,
                                                                    currentTournamentID);
                        WebRequest requestTournament = WebRequest.Create(tournamentRequest);
                        requestTournament.Credentials = netCredential;

                        WebResponse responseTournament = requestTournament.GetResponse();
                        dataStream = responseTournament.GetResponseStream();

                        XmlSerializer serTournament = new XmlSerializer(typeof(tournament));
                        tournament currentTournament;
                        using (XmlReader xmlreader = XmlReader.Create(dataStream))
                        {
                            currentTournament = (tournament)serTournament.Deserialize(xmlreader);
                        }
                        responseTournament.Close();

                        wr_Tournament newTournament = new wr_Tournament();
                        newTournament.FillFromChallongeTournament(currentTournament);
                        _tournamentsList.Add(newTournament);
                    }
                }

                ret = _tournamentsList.Count > 0;
            }
            return ret;
        }

        public bool GetResults(List<string> consideredTournaments,
                                out List<Player> resultsByPlayers)
        {
            bool ret = false;
            resultsByPlayers = new List<Player>();
            for (int i = 0; i < _tournamentsList.Count; i++)
            {
                if (consideredTournaments.Contains(_tournamentsList[i].Name))
                {
                    // Search associated game
                    Game currentGame = null;
                    for (int j = 0; (j < _gameList.Count) && (currentGame == null); j++)
                    {
                        if (_gameList[j].StringContainThisgame(_tournamentsList[i].Name))
                        {
                            currentGame = _gameList[j];
                        }
                    }
                    if (currentGame != null)
                    {
                        // Browse list of participants and for each, check if a line already exists. If it exists, update it. Else, create a new line
                        for (int j = 0; j < _tournamentsList[i].Participants.Count; j++)
                        {
                            int playerIndex = resultsByPlayers.FindIndex(delegate(Player p) { return p.Name == _tournamentsList[i].Participants[j].Name; });
                            if (playerIndex != -1)
                            {
                                resultsByPlayers[playerIndex].AddPoints(currentGame, _tournamentsList[i].Participants[j].EarnedPoints);                                
                            }
                            else
                            {
                                resultsByPlayers.Add(new Player(_tournamentsList[i].Participants[j].Name));
                                resultsByPlayers[resultsByPlayers.Count - 1].AddPoints(currentGame, _tournamentsList[i].Participants[j].EarnedPoints);                                                                
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public bool GetResults(List<wr_Tournament> consideredTournaments,
                               out List<Player> resultsByPlayers)
        {
            bool ret = false;
            resultsByPlayers = new List<Player>();
            for (int i = 0; i < consideredTournaments.Count; i++)
            {
                // Search associated game
                Game currentGame = null;
                for (int j = 0; (j < _gameList.Count) && (currentGame == null); j++)
                {
                    if (_gameList[j].StringContainThisgame(consideredTournaments[i].Name))
                    {
                        currentGame = _gameList[j];
                    }
                }
                if (currentGame != null)
                {
                    // Browse list of participants and for each, check if a line already exists. If it exists, update it. Else, create a new line
                    for (int j = 0; j < consideredTournaments[i].Participants.Count; j++)
                    {
                        int playerIndex = resultsByPlayers.FindIndex(delegate(Player p) { return p.Name == consideredTournaments[i].Participants[j].Name; });
                        if (playerIndex != -1)
                        {
                            resultsByPlayers[playerIndex].AddPoints(currentGame, consideredTournaments[i].Participants[j].EarnedPoints);
                        }
                        else
                        {
                            resultsByPlayers.Add(new Player(consideredTournaments[i].Participants[j].Name));
                            resultsByPlayers[resultsByPlayers.Count - 1].AddPoints(currentGame, consideredTournaments[i].Participants[j].EarnedPoints);
                        }
                    }
                }
            }
            return ret;
        }

        public string GetTournamentDetails(string tournamentId)
        {
            string tournamentDetails = "";
            int tournamentIndex = _tournamentsList.FindIndex(delegate(wr_Tournament tr) { return tr.Id == tournamentId; });
            if (tournamentIndex != -1)
            {
                tournamentDetails = _tournamentsList[tournamentIndex].GetTournamentDetails();
            }
            return tournamentDetails;
        }

        public static int CalculateParticipantPoints(int tournamentParticipantsNumber, int finalRank, bool forfeiting)
        {
            int ret = 0;
            if (forfeiting)
            {
                // todo: Define specific rules for forfeiting (negative points depending on size of tournament?)
                //  For now, consider 0
                ret = 0;
            }
            else
            {
                if (tournamentParticipantsNumber <= 8)
                {
                    if (finalRank == 1)
                    {
                        ret = 5;
                    }
                    else if (finalRank == 2)
                    {
                        ret = 3;
                    }
                    else if ((finalRank == 3) || (finalRank == 4))
                    {
                        ret = 2;
                    }
                    else
                    {
                        ret = 1;
                    }
                }
                else if (tournamentParticipantsNumber <= 16)
                {
                    if (finalRank == 1)
                    {
                        ret = 8;
                    }
                    else if (finalRank == 2)
                    {
                        ret = 5;
                    }
                    else if ((finalRank == 3) || (finalRank == 4))
                    {
                        ret = 3;
                    }
                    else if (finalRank <= 8)
                    {
                        ret = 2;
                    }
                    else
                    {
                        ret = 1;
                    }
                }
                else if (tournamentParticipantsNumber <= 32)
                {
                    if (finalRank == 1)
                    {
                        ret = 12;
                    }
                    else if (finalRank == 2)
                    {
                        ret = 8;
                    }
                    else if ((finalRank == 3) || (finalRank == 4))
                    {
                        ret = 5;
                    }
                    else if (finalRank <= 8)
                    {
                        ret = 3;
                    }
                    else if (finalRank <= 16)
                    {
                        ret = 2;
                    }
                    else
                    {
                        ret = 1;
                    }
                }
                else
                {
                    if (finalRank == 1)
                    {
                        ret = 18;
                    }
                    else if (finalRank == 2)
                    {
                        ret = 12;
                    }
                    else if ((finalRank == 3) || (finalRank == 4))
                    {
                        ret = 8;
                    }
                    else if (finalRank <= 8)
                    {
                        ret = 5;
                    }
                    else if (finalRank <= 16)
                    {
                        ret = 3;
                    }
                    else
                    {
                        ret = 1;
                    }
                }
            }
            return ret;
        }        
        #endregion
    }

    public class Game
    {
        #region Fields
        private string _name;
        private List<string> _aliasList = new List<string>();
        #endregion

        #region Properties
        public string Name
        {
            get { return _name;}
        }

        public List<string> AliasList
        {
            get { return _aliasList; }
        }
        #endregion

        #region CTOR
        public Game(string name)
        {
            _name = name;
        }
        #endregion

        #region Method
        public bool AddAlias(string aliasName)
        {
            bool ret = false;
            if (!_aliasList.Contains(aliasName))
            {
                _aliasList.Add(aliasName);
                ret = true;
            }
            return ret;
        }

        public bool IsAlias(string nameToCheck, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return _aliasList.Contains(nameToCheck);
            }
            else
            {
                for (int i = 0; i < _aliasList.Count; i++)
                {
                    if (nameToCheck.ToLower() == _aliasList[i].ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool StringContainThisgame(string inputString)
        {
            bool ret = false;
            if (inputString.Contains(_name))
            {
                ret = true;
            }
            else
            {
                for (int i = 0; (i < _aliasList.Count) && !ret; i++)
                {
                    ret = inputString.Contains(_aliasList[i]);
                }
            }

            return ret;
        }
        #endregion
    }

    public class Player:IComparable<Player>
    {
         #region Fields
        private string _name;
        private List<string> _aliasList = new List<string>();
        private Dictionary<Game, int> _earnedPoints = new Dictionary<Game, int>();
        #endregion

        #region Properties
        public string Name
        {
            get { return _name;}
        }

        public List<string> AliasList
        {
            get { return _aliasList; }
        }
        #endregion

        #region CTOR
        public Player(string name)
        {
            _name = name;
        }
        #endregion

        #region Method
        public bool AddAlias(string aliasName)
        {
            bool ret = false;
            if (!_aliasList.Contains(aliasName))
            {
                _aliasList.Add(aliasName);
                ret = true;
            }
            return ret;
        }

        public bool IsAlias(string nameToCheck, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return _aliasList.Contains(nameToCheck);
            }
            else
            {
                for (int i = 0; i < _aliasList.Count; i++)
                {
                    if (nameToCheck.ToLower() == _aliasList[i].ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool StringContainThisPlayer(string inputString)
        {
            bool ret = false;
            if (inputString.Contains(_name))
            {
                ret = true;
            }
            else
            {
                for (int i = 0; (i < _aliasList.Count) && !ret; i++)
                {
                    ret = inputString.Contains(_aliasList[i]);
                }
            }

            return ret;
        }

        public int GetTotalPoints()
        {
            int totalPoints = 0;
            foreach (KeyValuePair<Game, int> var in _earnedPoints)
            {
                totalPoints += var.Value;
            }
            return totalPoints;
        }

        /// <summary>
        /// Set points for a given game. The data overrides the existing data. If necessary, creates the new record in the
        /// player game results list.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="points"></param>
        public void SetPoints(Game game, int points)
        {            
            if (_earnedPoints.ContainsKey(game))
            {
                _earnedPoints[game] = points;
            }
            else
            {
                _earnedPoints.Add(game, points);
            }            
        }

        /// <summary>
        /// Add points for a given game. If necessary, creates the new record in the
        /// player game results list.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="points"></param>
        public void AddPoints(Game game, int additionalPoints)
        {
            if (_earnedPoints.ContainsKey(game))
            {
                _earnedPoints[game] += additionalPoints;
            }
            else
            {
                _earnedPoints.Add(game, additionalPoints);
            }
        }

        public bool GetPoints(string game, out int points)
        {
            bool ret = false;
            points = 0;
            foreach (KeyValuePair<Game, int> var in _earnedPoints)
            {
                if (var.Key.StringContainThisgame(game))
                {
                    ret = true;
                    points = var.Value;
                }
            }
            return ret;
        }
        #endregion
        #region IComparable<Player> Membres

        public int CompareTo(Player other)
        {
            return GetTotalPoints().CompareTo(other.GetTotalPoints());
        }

        #endregion
    }

    public class wr_Tournament
    {
        #region Fields
        private string descriptionField;

        private string nameField;

        private string rankedbyField;

        private string stateField;

        private string tournamenttypeField;

        private string urlField;

        private string descriptionsourceField;

        private string fullchallongeurlField;

        private string liveimageurlField;

        private string categoryField;

        private DateTime completeDateField;

        private DateTime createDateField;

        private string gameidField;

        private string idField;

        private int participantscountField;

        private int _adjustedParticipantCount;

        private int _forfeitCount;

        private int progressmeterField;

        private List<wr_Participant> participantsField;

        private List<wr_Match> matchesField;
        #endregion

        #region Properties        
        public string Description
        {
            get { return descriptionField; }            
        }

        public string Name
        {
            get { return nameField; }            
        }

        public string Rankedby
        {
            get { return rankedbyField; }
        }

        public string State
        {
            get { return stateField; }
        }

        public string Tournamenttype
        {
            get { return tournamenttypeField; }
        }

        public string Url
        {
            get { return urlField; }
        }

        public string Descriptionsource
        {
            get { return descriptionsourceField; }
        }

        public string Fullchallongeurl
        {
            get { return fullchallongeurlField; }
        }

        public string Liveimageurl
        {
            get { return liveimageurlField; }
        }

        public string Category
        {
            get { return categoryField; }
        }

        public DateTime CompleteDate
        {
            get { return completeDateField; }
        }

        public DateTime CreateDate
        {
            get { return createDateField; }
        }

        public string Gameid
        {
            get { return gameidField; }
        }

        public string Id
        {
            get { return idField; }
        }

        public int Participantscount
        {
            get { return participantscountField; }
        }

        public int Progressmeter
        {
            get { return progressmeterField; }
        }

        public List<wr_Participant> Participants
        {
            get { return participantsField; }
        }

        public List<wr_Match> Matches
        {
            get { return matchesField; }
        }
        #endregion

        #region Methods
        public void FillFromChallongeTournament(tournament inputData)
        {
            descriptionField = inputData.description;
            nameField = inputData.name;
            rankedbyField = inputData.rankedby;
            stateField = inputData.state;
            tournamenttypeField = inputData.tournamenttype;
            urlField = inputData.url;
            descriptionsourceField = inputData.descriptionsource;
            fullchallongeurlField = inputData.fullchallongeurl;
            liveimageurlField = inputData.liveimageurl;
            categoryField = inputData.category[0].nil;
            completeDateField = DateTime.Parse(inputData.completedat[0].Value);
            createDateField = DateTime.Parse(inputData.createdat[0].Value);
            gameidField = inputData.gameid[0].nil;
            idField = inputData.id[0].Value;
            participantscountField = int.Parse(inputData.participantscount[0].Value);
            progressmeterField = int.Parse(inputData.progressmeter[0].Value);
            
            participantsField = new List<wr_Participant>();

            // Adjust participants number with forfeits
            for (int i = 0; i < inputData.participants[0].participant.Length; i++)
            {
                wr_Participant newParticipant = new wr_Participant();
                newParticipant.FillFromChallongeParticipant(inputData.participants[0].participant[i]);
                if (newParticipant.Name.Contains(Settings.Default.ForfeitTag))
                {
                    _forfeitCount++;
                }
            }

            _adjustedParticipantCount = participantscountField;

            // Calculate points for each participant 
            for (int i = 0; i < inputData.participants[0].participant.Length; i++)
            {
                wr_Participant newParticipant = new wr_Participant();
                newParticipant.FillFromChallongeParticipant(inputData.participants[0].participant[i]);
                
                // Check if forfeit
                bool isForfeit = false;
                if (newParticipant.Name.Contains(Settings.Default.ForfeitTag))
                {
                    // Tag found --> forfeiting
                    isForfeit = true;
                }
                else
                {
                    // No tag found --> early quit
                }

                // Calculate points
                newParticipant.EarnedPoints = ChallongeInterface.CalculateParticipantPoints(_adjustedParticipantCount, newParticipant.Finalrank, isForfeit);

                participantsField.Add(newParticipant);
            }
            // Sort participant by final rank
            participantsField.Sort();

            matchesField = new List<wr_Match>();
            for (int i = 0; i < inputData.matches[0].match.Length; i++)
            {
                wr_Match newMatch = new wr_Match();
                newMatch.FillFromChallongeMatch(inputData.matches[0].match[i]);
                matchesField.Add(newMatch);
            }
            // Sort matches by date
            matchesField.Sort(new wr_MatchList_DateSorter());
        }

        public string GetTournamentDetails()
        {
            string tournamentDetails = string.Format(@"Nom: {0}
Date: {1}
Participants (forfaits): {2}({3})
Resultats:", nameField, completeDateField, participantscountField, _forfeitCount);
            string resultsRanking = "";
            for (int i = 0; i < participantsField.Count; i++)
            {
                resultsRanking += string.Format("    #{0} {1} ({2} pts)", participantsField[i].Finalrank, participantsField[i].Name, participantsField[i].EarnedPoints);
                if (participantsField[i].Name.Contains(Settings.Default.ForfeitTag))
                {
                    resultsRanking += " [Forfait]";
                }
                resultsRanking += Environment.NewLine;
            }

            tournamentDetails += Environment.NewLine + resultsRanking;
            return tournamentDetails;
        }
        #endregion

        #region override
        public override string ToString()
        {
            return nameField;
        }
        #endregion
    }

    public class wr_Participant:IComparable<wr_Participant>
    {
        #region Fields
        private string nameField;

        private bool activeField;

        private int finalrankField;

        private string idField;

        private int seedField;

        private string tournamentIdField;

        private int earnedPoints = 0;
        #endregion

        #region Properties
        public string Name
        {
            get { return nameField; }
        }

        public bool Active
        {
            get { return activeField; }
        }

        public int Finalrank
        {
            get { return finalrankField; }
        }

        public string Id
        {
            get { return idField; }
        }

        public int Seed
        {
            get { return seedField; }
        }

        public string TournamentId
        {
            get { return tournamentIdField; }
        }

        public int EarnedPoints
        {
            get { return earnedPoints; }
            set { earnedPoints = value;}
        }
        #endregion

        #region Methods
        public void FillFromChallongeParticipant(tournamentParticipantsParticipant inputData)
        {
            nameField = inputData.name;

            activeField = bool.Parse(inputData.active[0].Value);

            finalrankField = int.Parse(inputData.finalrank[0].Value);

            idField = inputData.id[0].Value;

            seedField = int.Parse(inputData.seed[0].Value);

            tournamentIdField = inputData.tournamentid[0].Value;
        }
        #endregion

        #region IComparable<wr_Participant> Membres

        int IComparable<wr_Participant>.CompareTo(wr_Participant other)
        {
            return finalrankField.CompareTo(other.finalrankField);
        }

        #endregion
    }

    public class wr_ParticipantList_SeedSorter : IComparer<wr_Participant>
    {
        public int Compare(wr_Participant obj1, wr_Participant obj2)
        {
            return obj1.Seed.CompareTo(obj1.Seed);
        }
    }

    public class wr_Match
    {
        #region Fields
        private string identifierField;

        private string stateField;

        private string scorescsvField;

        private string idField;

        private string loserIdField;

        private string winnerIdField;

        private string player1IdField;

        private int player1PointsField;

        private string player2IdField;

        private int player2PointsField;

        private string tournamentidField;

        private DateTime updatedateField;
        #endregion

        #region Properties
        public string Identifier
        {
            get { return identifierField; }
        }

        public string State
        {
            get { return stateField; }
        }

        public string Scorescsv
        {
            get { return scorescsvField; }
        }

        public string Id
        {
            get { return idField; }
        }

        public string LoserId
        {
            get { return loserIdField; }
        }

        public string WinnerId
        {
            get { return winnerIdField; }
        }

        public string Player1Id
        {
            get { return player1IdField; }
        }

        public string Player2Id
        {
            get { return player2IdField; }
        }

        public string Tournamentid
        {
            get { return tournamentidField; }
        }

        public int Player1Points
        {
            get { return player1PointsField; }
        }

        public int Player2Points
        {
            get { return player2PointsField; }
        }

        public DateTime Updatedate
        {
            get { return updatedateField; }
        }
        #endregion

        #region Methods
        public void FillFromChallongeMatch(tournamentMatchesMatch inputData)
        {
            identifierField = inputData.identifier;
            stateField = inputData.state;
            scorescsvField = inputData.scorescsv;
            string[] scoreSplit = scorescsvField.Split('-');
            if (scoreSplit.Length == 2)
            {
                player1PointsField = int.Parse(scoreSplit[0]);
                player2PointsField = int.Parse(scoreSplit[1]);
            }

            idField = inputData.id[0].Value;

            loserIdField = inputData.loserid[0].Value;

            winnerIdField = inputData.winnerid[0].Value;;

            player1IdField = inputData.player1id[0].Value;

            player2IdField = inputData.player2id[0].Value;

            tournamentidField = inputData.tournamentid[0].Value;

            updatedateField = DateTime.Parse(inputData.updatedat[0].Value);
        }
        #endregion
    }
    public class wr_MatchList_DateSorter : IComparer<wr_Match>
    {
        public int Compare(wr_Match obj1, wr_Match obj2)
        {
            return obj1.Updatedate.CompareTo(obj1.Updatedate);
        }
    }

}
