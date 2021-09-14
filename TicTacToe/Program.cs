using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] board = new string[3, 3]
            {
                {" "," "," "},
                {" "," "," "},
                {" "," "," "},
            };//array used to draw and store the variables of the board

            Console.WriteLine("TIC TAC TOE \n"); //Title and game rules bellow
            Console.WriteLine("To play the game you must input two numbers. \nThe first one choses the line and second choses the column. \nPlayer 1 will have \'X\' and player 2 will have \'O\'.");
            Console.WriteLine("To win the game you must have a line, column or diagonal filled by your symbol.");
            Console.WriteLine("This is the board you will play in!\n");
            DrawBoard(board);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            int turns = 1; // player counter used to count the number of plays
            int playerN = ConvertTurnToPlayer(turns); //introduce the variable and initialize it. Can be player 1 or 2. check the fuction


            do
            {
                DrawBoard(board);

                bool lineCheck = true; //variable used in the line conversion cycle
                bool columnCheck = true; //variable used in the column conversion cycle
                int i = 0; //variable used for lines
                int j = 0; //variable used fo columns
                bool sqrFilled = true;

                do
                {
                    do
                    {
                        playerN = ConvertTurnToPlayer(turns);
                        string line = AskInputLine(playerN);

                        if (VerifyLineInput(line) == true)
                        {
                            i = ConvertLine(line);
                            lineCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Input not valid!");
                        }
                    } while (lineCheck == true);

                    do
                    {
                        string column = AskInputCol(playerN);

                        if (VerifyColumnInput(column) == true)
                        {
                            j = ConvertLine(column);
                            columnCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Input not valid!");
                        }
                    } while (columnCheck == true);

                    sqrFilled = IsSquareFilled(board, i, j);

                } while (sqrFilled == true);

                FillSquare(playerN, board, i, j);

                DrawBoard(board);

                if (WinConLine(board, playerN) == true)
                {
                    WinConLine(board, playerN);

                }
                else if (WinConCol(board, playerN) == true)
                {
                    WinConCol(board, playerN);

                }
                else if (WinConDiag(board, playerN) == true)
                {
                    WinConDiag(board, playerN);

                }

                Console.Clear();

                turns++;

            }
            while (turns <= 9); //game cycle limited to 9 turns (number of squares in Tic Tac Toe)

            Console.WriteLine("the game ended up in a DRAW!"); //if the game gets to 9 turns without triggering any of the win codditions means it is a draw

        }

        public static int ConvertTurnToPlayer(int turns)
        {

            if (turns % 2 == 0) //if the number of the play is an even number the player is number 2
            {
                return 2;
            }
            else
            {
                return 1;
            }
        } //function used to convert the number of plays into player number

        public static void DrawBoard(string[,] board)
        {
            Console.WriteLine("    C o l u m n s");
            Console.WriteLine("    | 1 | 2 | 3 ");
            Console.WriteLine("  ---------------");
            Console.WriteLine("L 1 | {0} | {1} | {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("i ---------------");
            Console.WriteLine("n 2 | {0} | {1} | {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("e ---------------");
            Console.WriteLine("s 3 | {0} | {1} | {2}", board[2, 0], board[2, 1], board[2, 2]);
        } //function used to draw the board

        public static string AskInputLine(int playerN)
        {
            string line;
            Console.WriteLine("PLAYER {0}", playerN);
            Console.Write("Please input a line:");
            return line = Console.ReadLine();
        } //function to ask for input line from the users

        public static string AskInputCol(int playerN)
        {
            string column;
            Console.WriteLine("PLAYER {0}", playerN);
            Console.Write("Please input a column:");
            return column = Console.ReadLine();
        } //function to ask for input column from the users

        public static bool VerifyLineInput(string line)
        {
            if (line == "1" || line == "2" || line == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        } //function to verify if the line input matches one of the possibilities

        public static bool VerifyColumnInput(string column)
        {
            if (column == "1" || column == "2" || column == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        } //function to verify if the column input matches one of the possibilities

        public static int ConvertLine(string lineInp)
        {
            int i;
            return i = Convert.ToInt32(lineInp) - 1;
        } //function used to convert the input for a line into an integer and use it as an array index

        public static int ConvertCol(string colInp)
        {
            int j;
            return j = Convert.ToInt32(colInp) - 1;
        } //function used to convert the input for a column into an integer and use it as an array index

        public static bool WinConLine(string[,] board, int playerN)
        {
            if ((board[0, 0] == "X" && board[0, 1] == "X" && board[0, 2] == "X") || (board[0, 0] == "O" && board[0, 1] == "O" && board[0, 2] == "O"))
            {

                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else if ((board[1, 0] == "X" && board[1, 1] == "X" && board[1, 2] == "X") || (board[1, 0] == "O" && board[1, 1] == "O" && board[1, 2] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else if ((board[2, 0] == "X" && board[2, 1] == "X" && board[2, 2] == "X") || (board[2, 0] == "O" && board[2, 1] == "O" && board[2, 2] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else
            {
                return false;
            }

        }//function used to verify if a win condition is met in any of the lines

        public static bool WinConCol(string[,] board, int playerN)
        {
            if ((board[0, 0] == "X" && board[1, 0] == "X" && board[2, 0] == "X") || (board[0, 0] == "O" && board[1, 0] == "O" && board[2, 0] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else if ((board[0, 1] == "X" && board[1, 1] == "X" && board[2, 1] == "X") || (board[0, 1] == "O" && board[1, 1] == "O" && board[2, 1] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else if ((board[0, 2] == "X" && board[1, 2] == "X" && board[2, 2] == "X") || (board[0, 2] == "O" && board[1, 2] == "O" && board[2, 2] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else
            {
                return false;
            }

        }//function used to verify if a win condition is met in any of the columns

        public static bool WinConDiag(string[,] board, int playerN)
        {
            if ((board[0, 0] == "X" && board[1, 1] == "X" && board[2, 2] == "X") || (board[0, 0] == "O" && board[1, 1] == "O" && board[2, 2] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else if ((board[2, 0] == "X" && board[1, 1] == "X" && board[0, 2] == "X") || (board[2, 0] == "O" && board[1, 1] == "O" && board[0, 2] == "O"))
            {
                Console.WriteLine("PLAYER {0} WON!", playerN);
                Console.WriteLine("Press any key to exit...");
                System.Environment.Exit(0);
                return true;
            }
            else
            {
                return false;
            }

        }//function used to verify if a win condition is met in any of the diagonals

        public static bool IsSquareFilled(string[,] board, int i, int j)
        {
            if (board[i, j] == "X" || board[i, j] == "O")
            {
                Console.WriteLine("This square is already filled! Please provide different inputs!");
                return true;
            }
            else
            {
                return false;
            }
        } //fuction used to verify if the square is already filled

        public static void FillSquare(int playerN, string[,] board, int i, int j) //fuction used to fill the square 
        {
            if (playerN % 2 != 0) //the player turn will be a counter, player 1 will have odd numbers and player 2 will have even numbers
            {
                board[i, j] = "X";
            }
            else
            {
                board[i, j] = "O";
            }
        }

    }
}
