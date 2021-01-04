using System;
using System.Threading;
namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// User Interface
    /// Error Handling.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Vertical Symbol for board creation.
        /// </summary>
        private readonly string verticalSymbol;

        /// <summary>
        /// Horizontal Symbol for board creation.
        /// </summary>
        private readonly string horizontalSymbol;

        /// <summary>
        /// Variables.
        /// </summary>
        private string input;

        /// <summary>
        /// User Interface constructor.
        /// </summary>
        public UserInterface()
        {
            horizontalSymbol = "----";
            verticalSymbol = "|";
        }

        /// <summary>
        /// Display's the board on the console.
        /// </summary>
        /// <param name="board">the board.</param>
        /// <param name="color">A color that means a invalid position.</param>
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
                        if (k == 0)
                        {
                            System.Console.Write("   ");
                        }

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
                        {
                            Console.Write(" " + board.GetPos(i, j) + " ");
                        }
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(verticalSymbol);
                    Console.WriteLine(string.Empty);
                }

                Console.Write($"\nINPUT: {input}");
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// A Print that say to choose the wolf initial position.
        /// </summary>
        public void WolfPositonPrint()
        {
            System.Console.WriteLine("Choose the wolf initial position. [1] [3] [5] [7]\n");
        }

        /// <summary>
        /// A print that says invalid position if the player insert's a invalid
        /// /// /// position.
        /// </summary>
        public void InvalidPositionPrint()
        {
            Console.WriteLine("Invalid Position.");
            Console.WriteLine("Choose between 1, 3, 5, 7.\n");
        }

        /// <summary>
        /// Reads the input of the user.
        /// </summary>
        /// <returns>User Input.</returns>
        public string ReadInput()
        {
            ConsoleKeyInfo key;
            input = string.Empty;
            while (true)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(input);
                    return input;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Remove(input.Length - 1);
                    }
                }
                else
                {
                    input = string.Concat(input, key.KeyChar.ToString());
                }
            }
        }

        /// <summary>
        /// Print that says invalid position for the sheeps.
        /// </summary>
        public void InvalidPositionSheep()
        {
            Console.WriteLine("\nThe Sheep can't move there.");
        }

        /// <summary>
        /// Print that says the victory for the wolf.
        /// </summary>
        public void WolfVictory()
        {
            Console.WriteLine("\nWolf won the game!\n");
            Environment.Exit(0);
        }

        /// <summary>
        /// Print that says the victory for the sheeps.
        /// </summary>
        public void SheepVictory()
        {
            Console.WriteLine("\nSheep's won the game!\n");
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints the main menu.
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("Wolf and Sheep: The Game.");
            Console.WriteLine("Choose the first position for the wolf.");
            Console.WriteLine
            ("When 'x' is blinking, it means it's the wolf's turn");
            Console.WriteLine
            ("Type a position line and column to move the wolf.");
            Console.WriteLine("The Wolf can move diagonally forward and backwards");
            Console.WriteLine
            ("When the o is blinking it means that it's sheep's turn");
            Console.Write
            ("While choosing the sheep's  position write the initial");
            Console.Write("position followed by the desired position");
            Console.WriteLine("The sheep can only move diagonally forward.\n");
        }

        /// <summary>
        /// Print invalid input.
        /// </summary>
        public void InvalidInput()
        {
            System.Console.WriteLine("Invalid Input");
        }
    }
}