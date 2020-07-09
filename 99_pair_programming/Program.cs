using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace _99_Console_Game
{
    class tictactoe
    {
        static int player = 1;
        static int choice;
        static char[] arr = { 'o', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int flag = 0;
        static void Main(string[] args)
        {
            List<int> chosenNums = new List<int>();
            do
            {
                Console.Clear();//loop SHOULD....SHOULD start again here
                Console.WriteLine("Player 1 will be O and Player 2 will be X");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Playa 2 Pick a number");
                }
                else
                {
                    Console.WriteLine("Playa 1 pick number");
                }
                Console.WriteLine("\n");
                Board();
                choice = Int32.Parse(Console.ReadLine());
                if (chosenNums.Contains(choice))
                {
                    Console.WriteLine("Sorry playa that spot is already taken-Choose again");
                    Console.WriteLine("\n");
                    Thread.Sleep(2000);
                }
                else
                {
                    chosenNums.Add(choice);
                    if (player % 2 == 0) //takes player divid by 2 player 1 should be odds if not they are even numbers
                    {
                        arr[choice] = 'x';
                        player++;//should just keep adding 1 to what ever number player is
                    }
                    else
                    {
                        arr[choice] = 'o';
                        player++;
                    } //i cant figure out why this is mad at me
                }
                flag = CheckWin();//should call on method checkwin 
            } while (flag != 1 && flag != -1);
            Console.Clear();// clearing the console  
            Board();// getting filled board again  
            if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else// if flag value is -1 no one is the winner  
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // Board method which creats board  
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not  
        private static int CheckWin()
        {
            //start Winning Condition For Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            //start Winning Condition For Columns      
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            //Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}