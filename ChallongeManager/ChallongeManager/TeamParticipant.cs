using System;
using System.Collections.Generic;
using System.Text;

namespace ChallongeManager
{
    class TeamParticipant:Participant
    {
        #region Fieds
        protected List<SingleParticipant> _teamMembers;

        public TeamParticipant(int id, string name) : base(id, name)
        {
        }
        #endregion
    }
}
