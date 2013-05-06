using System;
using System.Collections.Generic;


namespace BalloonsPop
{
    //gen -> GeneratePlayground
    class Playground
    {
        // const added
        
        public const int numberOfColors = 4;

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
                    byte balloonColor = (byte)RandomGenerator.GetNext(1, numberOfColors);
                    playground[row, column] = balloonColor;
                }
            }
            return playground;
        }

        // checkLeft -> CheckLeft
        // matrix -> playground
        // row -> currentRow
        // column -> currentCol
        // searchedItem -> ................ Playground
        // try catch -> new Method IsOnPlayground( ... ...) and bool isOnPlayground
        static void CheckLeft(byte[,] playground, int currentRow, int currentColumn, int searchedItem)
        {
            int newRow = currentRow;
            int newColumn = currentColumn - 1;
            bool isOnPlayground = IsOnPlayground(playground, newRow, newColumn);
            //try
            //{
            if (isOnPlayground && playground[newRow, newColumn] == searchedItem)
            {
                playground[newRow, newColumn] = 0;
                CheckLeft(playground, newRow, newColumn, searchedItem);
            }
            else
            {
                return;
            }
            //}catch(IndexOutOfRangeException)
            //    {return;} 
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

        // checkRight -> 
        // matrix -> playground
        static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkRight(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        // 
        static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkUp(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }
        }

        // 
        static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkDown(matrix, newRow, newColumn, searchedItem);
                }
                else return;
            }
            catch (IndexOutOfRangeException)
            { return; }

        }

        // 
        public static bool change(byte[,] matrixToModify, int rowAtm, int columnAtm)
        {
            if (matrixToModify[rowAtm, columnAtm] == 0)
            {
                return true;
            }
            byte searchedTarget = matrixToModify[rowAtm, columnAtm];
            matrixToModify[rowAtm, columnAtm] = 0;
            CheckLeft(matrixToModify, rowAtm, columnAtm, searchedTarget);
            checkRight(matrixToModify, rowAtm, columnAtm, searchedTarget);


            checkUp(matrixToModify, rowAtm, columnAtm, searchedTarget);
            checkDown(matrixToModify, rowAtm, columnAtm, searchedTarget);
            return false;
        }

        // 
       

        

       
    }
}


