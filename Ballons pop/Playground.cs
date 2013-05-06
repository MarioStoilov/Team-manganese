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

        // change -> 
        public static bool change(byte[,] matrixToModify, int rowAtm, int columnAtm)
        {
            if (matrixToModify[rowAtm, columnAtm] == 0)
            {
                return true;
            }

            byte searchedTarget = matrixToModify[rowAtm, columnAtm];
            matrixToModify[rowAtm, columnAtm] = 0;
            CheckLeft(matrixToModify, rowAtm, columnAtm, searchedTarget);
            CheckRight(matrixToModify, rowAtm, columnAtm, searchedTarget);

            CheckUp(matrixToModify, rowAtm, columnAtm, searchedTarget);
            CheckDown(matrixToModify, rowAtm, columnAtm, searchedTarget);
            return false;
        }

      
    }
}


