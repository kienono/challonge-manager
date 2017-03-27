using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChallongeManager
{
    class matchStation
    {
        #region Fields
        private int _id = -1;
        private string _name = "Undefined";
        private string _description;        
        private Point _location = new Point(0,0);
        private Color _color;
        private matchStationState _currentState = matchStationState.unavailable;
        #endregion
    }

    enum matchStationState
    {
        unavailable,
        free,
        used
    }
}
