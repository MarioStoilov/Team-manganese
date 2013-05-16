using System;

namespace BalloonsPop
{
    internal class Playground
    {

        private byte[,] playGround;

        public byte this[int i, int j]
        {
            get
            {
                return playGround[i, j];
            }
        }

        public int Height
        {
            get
            {
                return this.playGround.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return this.playGround.GetLength(1);
            }
        }

        /// <summary>
        /// Creates an instance of the playgorund class
        /// </summary>
        /// <param name="rows">The rows in the playgorund</param>
        /// <param name="columns">The columns in the playgorund</param>
        /// <param name="numberOfColors">The number of different colors of the ballons in the playground</param>
        internal Playground(byte rows, byte columns, byte numberOfColors)
        {
            this.playGround = new byte[rows, columns];
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte balloonColor = (byte)RandomGenerator.GetNext(1, numberOfColors);
                    this.playGround[row, column] = balloonColor;
                }
            }
        }

        // change -> IsPositionEmpty
        internal bool IsPositionEmpty(int row, int column)
        {
            if (this.playGround[row, column] == 0)
            {
                return true;
            }

            return false;
        }
  
        // method extracted
        // searchedTarget -> searchedColor

        /// <summary>
        /// Pops a ballon at the given position
        /// </summary>
        internal void PopAtPosition(int row, int column)
        {
            byte searchedColor = playGround[row, column];
            playGround[row, column] = 0;
            CheckLeft(row, column, searchedColor);
            CheckRight(row, column, searchedColor);
            CheckUp(row, column, searchedColor);
            CheckDown(row, column, searchedColor);
        }


        internal bool IsPlaygroundEmpty()
        {
            bool isPlaygroundEmpty = true;
            int rows = playGround.GetLength(0);
            int columns = playGround.GetLength(1);
            bool stop = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (playGround[row, col] != 0)
                    {
                        isPlaygroundEmpty = false;
                        stop = true;
                        break;
                    }
                }

                if (stop)
                {
                    break;
                }
            }

            return isPlaygroundEmpty;
        }

        /// <summary>
        /// Moves the ballons down if there is an empty spot
        /// </summary>
        internal void ReorderPlayground()
        {
            int rows = playGround.GetLength(0);
            int columns = playGround.GetLength(1);

            for (int col = 0; col < columns; col++)
            {
                byte[] reorderedColumn = new byte[rows];
                int currentRow = rows - 1;
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (playGround[row, col] != 0)
                    {
                        reorderedColumn[currentRow] = playGround[row, col];
                        currentRow--;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    playGround[row, col] = reorderedColumn[row];
                }
            }
        }

        /// <summary>
        /// Checks the left neighbour of a given baloon wether it's color is equal to the given one
        /// </summary>
        private void CheckLeft(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn - 1;
            bool isOnPlayground = IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && playGround[newRow, newColumn] == searchedColor)
            {
                playGround[newRow, newColumn] = 0;
                CheckLeft(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks if the given position is in the playground
        /// </summary>
        public bool IsOnPlayground(int row, int column)
        {
            int rows = playGround.GetLength(0);
            int columns = playGround.GetLength(1);
            if ((row >= 0 && row < rows) && (column >= 0 && column < columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the right neighbour of a given baloon wether it's color is equal to the given one
        /// </summary>
        private void CheckRight(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn + 1;
            bool isOnPlayground = IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && playGround[newRow, newColumn] == searchedColor)
            {
                playGround[newRow, newColumn] = 0;
                CheckRight(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks the top neighbour of a given baloon wether it's color is equal to the given one
        /// </summary>
        private void CheckUp(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow + 1;
            int newColumn = currentColumn;
            bool isOnPlayground = IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && playGround[newRow, newColumn] == searchedColor)
            {
                playGround[newRow, newColumn] = 0;
                CheckUp(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks the bottom neighbour of a given baloon wether it's color is equal to the given one
        /// </summary>
        private void CheckDown(int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow - 1;
            int newColumn = currentColumn;
            bool isOnPlayground = IsOnPlayground(newRow, newColumn);

            if (isOnPlayground && playGround[newRow, newColumn] == searchedColor)
            {
                playGround[newRow, newColumn] = 0;
                CheckDown(newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
        }
    }
}