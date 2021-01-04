using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        GameLoop gameLoop;
        static void Main(string[] args)
        {
            Program p;
            p = new Program();
            p.Run();
        }

        /// <summary>
        /// Program Constructor
        /// </summary>
        private Program()
        {
            gameLoop = new GameLoop();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Run()
        {
            gameLoop.Start();
        }
    }
}
