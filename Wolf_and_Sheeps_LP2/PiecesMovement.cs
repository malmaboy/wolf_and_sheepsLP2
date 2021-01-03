using System;
namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// Put the Initial pieces in the board
    /// Pieces Movement
    /// /// </summary>
    public class PiecesMovement
    {
        /// <summary>
        /// Userinterface instance
        /// </summary>
        UserInterface userInterface;
        private string position;

        /// <summary>
        /// PiecesMovement Constructor
        /// </summary>
        public PiecesMovement()
        {
            userInterface = new UserInterface();

        }

        /// <summary>
        /// Put the Initial positions of the pieces
        /// </summary>
        public void InitialPositions()
        {
            userInterface.WolfPositonPrint();

            position = Console.ReadLine();

            switch (position)
            {
                case "1":
                    userInterface.board[0, 1] = (char)Pieces.X; break;
                case "3":
                    userInterface.board[0, 3] = (char)Pieces.X; break;
                case "5":
                    userInterface.board[0, 5] = (char)Pieces.X; break;
                case "7":
                    userInterface.board[0, 7] = (char)Pieces.X; break;
                default:
                    userInterface.InvalidPositionPrint();
                    break;
            }
            /// <summary>
            /// sheep's Initial positions
            /// </summary>
            /// <returns></returns>
            userInterface.board[7, 0] = (char)Pieces.O;
            userInterface.board[7, 2] = (char)Pieces.O;
            userInterface.board[7, 4] = (char)Pieces.O;
            userInterface.board[7, 6] = (char)Pieces.O;


            userInterface.DisplayBoard();

        }


        /// <summary>
        /// Wolf Movement
        /// </summary>
        private void WolfMovement()
        {

        }

    }
}