using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// User Interface
    /// Error Handling
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Variables
        /// </summary>


        /// <summary>
        /// Horizontal Symbol for board creation
        /// </summary>
        private string horizontalSymbol;
        /// <summary>
        /// Vertical Symbol for board creation
        /// </summary>
        private string verticalSymbol;

        /// <summary>
        /// User Interface constructor 
        /// </summary>

        public UserInterface()
        {
            horizontalSymbol = "----";
            verticalSymbol = "|";
        }

        /// <summary>
        /// Displays the board 
        /// </summary>

        public void DisplayBoard(char[,] board)
        {
            System.Console.WriteLine("   0   1   2   3   4   5   6   7");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int k = 0; k < board.GetLength(0); k++)
                {
                    if (k == 0) System.Console.Write("   ");
                    System.Console.Write(horizontalSymbol);
                }
                System.Console.Write("\n" + i.ToString() + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    System.Console.Write(verticalSymbol + " " +
                        board[i, j] + " ");
                }
                Console.Write(verticalSymbol);
                Console.WriteLine("");
            }
        }
        /*
        public void ReadWolfPosition(string position){
            position = Console.ReadLine();
        }*/

        /// <summary>
        /// A Print that say to choose the wolf initial postion
        /// </summary>
        public void WolfPositonPrint()
        {
            System.Console.WriteLine("Choose the wolf initial position.\n");
        }
        /// <summary>
        /// A print that says invalid position if the player insert's a invalid
        /// position
        /// </summary>
        public void InvalidPositionPrint()
        {
            System.Console.WriteLine("Invalid Position.");
            System.Console.WriteLine("Choose between 1, 3, 5, 7.\n");
        }
    }
}