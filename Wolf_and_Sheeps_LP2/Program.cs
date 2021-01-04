using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// Program class. Run the game.
    /// </summary>
    public sealed class Program 
    {
        /// <summary>
        /// Gameloop instance to run the game.
        /// </summary>
        private readonly GameLoop gameLoop;
        private static void Main()
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
