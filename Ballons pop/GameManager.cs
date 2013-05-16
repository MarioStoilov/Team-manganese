using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop
{
    /// <summary>
    /// A class the serves to manage all game logic related operations
    /// </summary>
    class GameManager
    {
        public int UserMoves
        {
            get;
            private set;
        }

        public Playground PlayGround
        {
            get;
            private set;
        }

        public GameManager()
        {
            this.UserMoves = 0;
            this.PlayGround = new Playground(5, 10, 4);
        }

        public void PopAtPosition(int row, int column)
        {
            UserMoves++;
            this.PlayGround.PopAtPosition(row, column);
        }
        
    }
}
