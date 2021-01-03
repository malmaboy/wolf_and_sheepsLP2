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
        /// Board Dimension
        /// </summary>
        private const int Dimension = 8;

        /// Board array
        public char[,] board{get; set;}


        /// <summary>
        /// Horizontal Symbol for board creation
        /// </summary>
        private string horizontalSymbol;
        /// <summary>
        /// Vertical Symbol for board creation
        /// </summary>
        private string verticalSymbol;

        /// <summary>
        /// User Interface Constructor
        /// </summary>
        public UserInterface(){
            board = new char[Dimension, Dimension];
            horizontalSymbol = "+---";
            verticalSymbol = "| ";
        }

        /// <summary>
        /// Displays the board 
        /// </summary>
        public void DisplayBoard(){
            System.Console.WriteLine("   0   1    2    3   4   5   6   7");

            for(int lines = 0; lines < Dimension; lines++){
                System.Console.Write("  ");
                for(int columns = 0; columns < Dimension; columns++)
                    System.Console.Write(horizontalSymbol);

                System.Console.Write("+\n");

                for(int columns = 0; columns < Dimension; columns++){
                    if(columns == 0){
                        System.Console.Write("  ");
                         
                    }
                    System.Console.Write(verticalSymbol + board[lines,columns] 
                                + (char) Pieces.Empty);
                    

                }
                System.Console.Write("|\n");
                                            
            }
            System.Console.Write("  ");

            for(int columns = 0; columns < Dimension; columns++)
                System.Console.Write(horizontalSymbol);

            System.Console.Write("+\n\n");
        }
        /*
        public void ReadWolfPosition(string position){
            position = Console.ReadLine();
        }*/

        /// <summary>
        /// A Print that say to choose the wolf initial postion
        /// </summary>
        public void WolfPositonPrint(){
            System.Console.WriteLine("Choose the wolf initial position.\n");
        }
        /// <summary>
        /// A print that says invalid position if the player insert's a invalid
        /// position
        /// </summary>
        public void InvalidPositionPrint(){
            System.Console.WriteLine("Invalid Position.");
            System.Console.WriteLine("Choose between 1, 3, 5, 7.\n");
        }        
    }
}