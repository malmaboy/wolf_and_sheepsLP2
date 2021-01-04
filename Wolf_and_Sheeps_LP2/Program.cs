using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// Program class. Run the game.
    /// </summary>
    sealed class Program 
    {
        GameLoop gameLoop;
        static void Main(string[] args)
        {
            Program p;
            p = new Program();
            p.Run();
        }

        /// <summary>
        /// Program Constructor.
        /// </summary>
        private Program()
        {
            gameLoop = new GameLoop();
        }

        /// <summary>
        /// Start's the Game.
        /// </summary>
        private void Run()
        {
            gameLoop.Start();
        }
    }
}
