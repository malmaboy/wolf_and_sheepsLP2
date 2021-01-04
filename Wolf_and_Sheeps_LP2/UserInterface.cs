using System;
using System.Threading;
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
        string input;


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
        /// /// </summary>

        public UserInterface()
        {
            horizontalSymbol = "----";
            verticalSymbol = "|";
        }

        /// <summary>
        /// Displays the board 
        /// </summary>

        public void DisplayBoard(Board board, ConsoleColor color)
        {
            bool lower = false;

            while (true)
            {
                lower = !lower;

                Console.Clear();

                Console.WriteLine($"Turn: {(char)board.Turn}\n");

                System.Console.WriteLine("   0   1   2   3   4   5   6   7");

                for (int i = 0; i < board.GetBoard().GetLength(0); i++)
                {
                    for (int k = 0; k < board.GetBoard().GetLength(0); k++)
                    {
                        if (k == 0) System.Console.Write("   ");
                        System.Console.Write(horizontalSymbol);
                    }
                    System.Console.Write("\n" + i.ToString() + " ");
                    for (int j = 0; j < board.GetBoard().GetLength(1); j++)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        System.Console.Write(verticalSymbol);
                        if ((i + j) % 2 == 0)
                            Console.BackgroundColor = color;
                        else
                            Console.BackgroundColor = ConsoleColor.Black;
                        if ((Pieces)board.GetPos(i, j) == board.Turn && lower)
                        {
                            Console.Write(" " + board.GetPos(i, j).ToString().ToLower() + " ");
                        }
                        else
                            Console.Write(" " + board.GetPos(i, j) + " ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(verticalSymbol);
                    Console.WriteLine(string.Empty);
                }
                Console.WriteLine($"\nINPUT: {input}");
                Thread.Sleep(1000);
            }
        }


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

        public string ReadInput()
        {
            ConsoleKeyInfo key;
            input = "";
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    System.Console.WriteLine(input);
                    return input;
                }
                else if (key.Key == ConsoleKey.Backspace)
                    input = input.Remove(input.Length - 1);
                else
                    input += key.KeyChar.ToString();

            }
        }

        public void InvalidPositionSheep()
        {
            System.Console.WriteLine("\nThe Sheep can't move there.");
        }

        public void WolfVictory()
        {
            System.Console.WriteLine("\nWolf won the game!\n");
            Environment.Exit(0);
        }

        public void SheepVictory()
        {
            System.Console.WriteLine("\nSheep's won the game!\n");
            Environment.Exit(0);
        }

        public void MainMenu()
        {
            Console.WriteLine("Wolf and sheep's : The Game.");
            Console.WriteLine
            ("When the squares are white means that is wolf turn");
            Console.WriteLine
            ("type a position line and column to move the wolf.");
            Console.WriteLine("Wolf can move forward and backwards");
            Console.WriteLine
            ("When the square are blue means that is sheep's turn");
            Console.Write
            ("Choose the position of the sheep that you want to");
            Console.Write("move then write another position for movement");
            Console.WriteLine("The sheep can only move forward");

        }
    }
}