using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// GameLoop Class
    /// </summary>
    public class GameLoop
    {

        private UserInterface userInterface;
        private Board gameBoard;


        /// <summary>
        /// 
        /// </summary>
        public GameLoop()
        {
            userInterface = new UserInterface();
            gameBoard = new Board();
        }

        /// <summary>
        /// 
        ///  </summary>
        public void Start()
        {
            userInterface.WolfPositonPrint();
            gameBoard.InitialWolfPosition();
            userInterface.DisplayBoard(gameBoard.GetBoard());
        }
    }
}