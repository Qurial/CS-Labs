using System;

namespace ConsoleApp1
{

    class Program
    {

        public static int[] throwDice()
        {
            int[] playerDice = new int[6];
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                playerDice[i] = rnd.Next(6) + 1;
                Console.Write(playerDice[i] + ", ");
            }
            return playerDice;
        } 
        
        public static int[] rethrowDice(int[] playerDice, string rethrownDice)
        {
            Random rnd = new Random();
            string[] dice = rethrownDice.Split();          //creating an array of numbers of dice that will be rethrown
            int length = dice.Length;
            int[] diceNum = new int[length];

            for (int i = 0; i < length; i++)                    
            {
                diceNum[i] = int.Parse(dice[i]);
                playerDice[diceNum[i] - 1] = rnd.Next(6) + 1;
            }
            return playerDice;
        }
        public static int finalScore(int[] playerDice)
        {
            int pair = 0, threeOfKind = 0, score, finalScore = 0, one = 0, six = 0;
            for (int i = 1; i <= 6; i++)
            {
                score = 0;
                for (int a = 0; a < 5; a++)
                {
                    if (i == playerDice[a])
                    {
                        score++;
                    }
                    if (playerDice[a] == 1)
                    {
                        one = 1;
                    }
                    else if (playerDice[a] == 6)
                    {
                        six = 1;
                    }
                }
                if (score == 2)
                {
                    pair++;
                }
                else if (score == 3)
                {
                    threeOfKind++;
                }
                else if (score == 4)        //Four-of-a-Kind — four dice showing the same value. Score - 7
                {
                    finalScore = 7;
                }
                else if (score == 5)        //Five-of-a-Kind — all five dice showing the same value. Score - 8
                {
                    finalScore = 8;
                }
            }
            if (pair == 1 && threeOfKind == 0)      //Pair — two dice showing the same value. Score - 1
            {
                finalScore = 1;
            }
            else if (pair == 2)                     //Two Pairs — two pairs of dice, each showing the same value. Score - 2
            {
                finalScore = 2;
            }
            else if (pair == 0 && threeOfKind == 1) //Three-of-a-Kind — three dice showing the same value. Score - 3
            {
                finalScore = 3;
            }
            else if (pair == 1 && threeOfKind == 1) //Full House — Pair of one value and Three-of-a-Kind of another. Score - 6
            {
                finalScore = 6;
            }
            if (finalScore == 0 && one == 1 && six == 0)    //Five High Straight — dice showing values from 1 through 5, inclusive. Score - 4
            {
                finalScore = 4;
            }
            if (finalScore == 0 && one == 0 && six == 1)    //Six High Straight — dice showing values from 2 through 6, inclusive. Score - 5
            {
                finalScore = 5;
            }
            return finalScore;
        }

        static void whoWon(int[] fPlayerDice, int[] sPlayerDice)
        {
            int fPlayerScore = finalScore(fPlayerDice);
            int sPlayerScore = finalScore(sPlayerDice);

            if (fPlayerScore > sPlayerScore)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (fPlayerScore < sPlayerScore)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }

        static int[] whatToRethrow(int[] playerDice)
        {
            string answer = Console.ReadLine();

            if (answer == "yes")
            {
                Console.WriteLine("\nWhat dices do you wnat to rethrow?");
                string rethrownDice = Console.ReadLine();
                playerDice = rethrowDice(playerDice, rethrownDice);
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(playerDice[i] + ", ");
                }
            }
            return playerDice;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Press any key to throw dice, player one");
            Console.ReadKey();
            int[] fPlayerDice = throwDice();


            Console.WriteLine("\nPress any key to throw dice, player two");
            Console.ReadKey();
            int[] sPlayerDice = throwDice();

            Console.WriteLine("\nDo you want to rethrow part of your dices , player one?");
            fPlayerDice =  whatToRethrow(fPlayerDice);
            /*Console.WriteLine("\nDo you want to rethrow part of your dices , player one?");
            string answer = Console.ReadLine();

            if (answer == "yes")
            {
                Console.WriteLine("\nWhat dices do you wnat to rethrow?");
                string rethrownDice = Console.ReadLine();
                fPlayerDice = rethrowDice(fPlayerDice, rethrownDice);
                for (int i = 0 ;i < 5 ; i++)
                {
                    Console.Write(fPlayerDice[i] + ", ");
                }
            }*/

            Console.WriteLine("\nDo you want to rethrow part of your dices , player two?");
            sPlayerDice = whatToRethrow(sPlayerDice);
            /*string answer = Console.ReadLine();

            if (answer == "yes")
            {
                Console.WriteLine("\nWhat dices do you wnat to rethrow?");
                string rethrownDice = Console.ReadLine();
                sPlayerDice = rethrowDice(sPlayerDice, rethrownDice);
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(sPlayerDice[i] + ", ");
                }
            }*/
            whoWon(fPlayerDice, sPlayerDice);
        }
    }

    
}




