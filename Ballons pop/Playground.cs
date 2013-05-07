using System;
using System.Collections.Generic;


namespace BalloonsPop
{
    class Playground
    {
        // const added
        public const int NumberOfColors = 4;

        // gen -> GeneratePlayground
        // temp -> playground
        // randNumber -> use class RandomGenerator.GetNext
        // tempByte -> balloonColor
       public static byte[,] GeneratePlayground(byte rows, byte columns)
        {
            byte[,] playground = new byte[rows, columns];
            //Random randomGenerator = new Random();

            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte balloonColor = (byte)RandomGenerator.GetNext(1, NumberOfColors);
                    playground[row, column] = balloonColor;
                }
            }
            return playground;
        }

        // checkLeft -> CheckLeft
        // matrix -> playground
        // row -> currentRow
        // column -> currentCol
        // searchedItem -> searchedColor 
        // try catch -> new Method IsOnPlayground( ... ) and bool isOnPlayground
        static void CheckLeft(byte[,] playground, int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn - 1;
            bool isOnPlayground = IsOnPlayground(playground, newRow, newColumn);
           
            if (isOnPlayground && playground[newRow, newColumn] == searchedColor)
            {
                playground[newRow, newColumn] = 0;
                CheckLeft(playground, newRow, newColumn, searchedColor);
            }
            else
            {
                return;
            }
           
        }

        // Aditionaly added method
        private static bool IsOnPlayground(byte[,] playground, int row, int column)
        {
            int rows = playground.GetLength(0);
            int columns = playground.GetLength(1);
            if ((row >= 0 && row < rows) && (column >= 0 && column < columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // checkRight -> CheckRight
        // matrix -> playground
        // row -> currentRow
        // column -> currentCol
        // searchedItem -> searchedColor 
        // try catch -> new Method IsOnPlayground( ... ) and bool isOnPlayground
        static void CheckRight(byte[,] playground, int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow;
            int newColumn = currentColumn + 1;
            bool isOnPlayground = IsOnPlayground(playground, newRow, newColumn);
           
                if (isOnPlayground && playground[newRow, newColumn] == searchedColor)
                {
                    playground[newRow, newColumn] = 0;
                    CheckRight(playground, newRow, newColumn, searchedColor);
                }
                else
                {
                    return;
                }
        }

        // checkUp -> CheckUp
        // matrix -> playground
        // row -> currentRow
        // column -> currentCol
        // searchedItem -> searchedColor 
        // try catch -> new Method IsOnPlayground( ... ) and bool isOnPlayground
        static void CheckUp(byte[,] playground, int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow + 1;
            int newColumn = currentColumn;
            bool isOnPlayground = IsOnPlayground(playground, newRow, newColumn);
           
                if (isOnPlayground && playground[newRow, newColumn] == searchedColor)
                {
                    playground[newRow, newColumn] = 0;
                    CheckUp(playground, newRow, newColumn, searchedColor);
                }
                else
                {
                    return;
                }
        }

        // checkDown -> CheckDown
        // matrix -> playground
        // row -> currentRow
        // column -> currentCol
        // searchedItem -> searchedColor 
        // try catch -> new Method IsOnPlayground( ... ) and bool isOnPlayground
        static void CheckDown(byte[,] playground, int currentRow, int currentColumn, int searchedColor)
        {
            int newRow = currentRow - 1;
            int newColumn = currentColumn;
            bool isOnPlayground = IsOnPlayground(playground, newRow, newColumn);
           
                if (isOnPlayground && playground[newRow, newColumn] == searchedColor)
                {
                    playground[newRow, newColumn] = 0;
                    CheckDown(playground, newRow, newColumn, searchedColor);
                }
                else
                {
                    return;
                }

        }

        // change -> IsEmptyCell
        internal static bool IsEmptyCell(byte[,] playground, int row, int column)
        {
            if (playground[row, column] == 0)
            {
                return true;
            }

            return false;
        }
  
        // method extracted
        // searchedTarget -> searchedColor
        internal static void PopAtPosition(byte[,] playground, int row, int column)
        {
            byte searchedColor = playground[row, column];
            playground[row, column] = 0;

            CheckLeft(playground, row, column, searchedColor);
            CheckRight(playground, row, column, searchedColor);
            CheckUp(playground, row, column, searchedColor);
            CheckDown(playground, row, column, searchedColor);
        }

        // added method
        internal static bool IsPlaygroundEmpty(byte[,] playground)
        {
            bool isPlaygroundEmpty = true;
            int rows = playground.GetLength(0);
            int columns = playground.GetLength(1);
            bool stop = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (playground[row, col] != 0)
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

        // doit ->  ReorderPlayground
        // i -> row
        // j -> col
        // columnLenght -> rows
        // added columns = playground.GetLength(1)
        // Stack<byte> stek -> byte[] reorderedColumn
        // try catch -> removed
        // bool Method -> void Method
        // new Method added IsPlaygroundEmpty
        internal static void ReorderPlayground(byte[,] playground)
        {
            
            int rows = playground.GetLength(0);
            int columns = playground.GetLength(1);

            for (int col = 0; col < columns; col++)
            {
                byte[] reorderedColumn = new byte[rows];
                int currentRow = rows-1;
                for (int row =rows-1; row >=0; row--)
                {
                    if (playground[row, col] != 0)
                    {
                        reorderedColumn[currentRow] = playground[row, col];
                        currentRow--;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    playground[row, col] = reorderedColumn[row];
                }
            }
        }
    }
}


