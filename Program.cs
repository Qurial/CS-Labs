using System;

namespace ConsoleApp1
{
    class Program
    {
        static void printDice(int[] fPlayerDice, int[] sPlayerDice)
        {
            Console.Clear();
            Console.WriteLine("Player 1 Dices:              Player 2 Dices:");
            Console.Write("  ");
            for (int i = 0; i < 11; i++)
            {
                if (i <= 4)
                {
                    Console.Write(fPlayerDice[i]);
                    Console.Write(" ");
                }
                else if (i == 5)
                {
                    Console.Write("                   ");
                }
                else
                {
                    Console.Write(sPlayerDice[i - 6]);
                    Console.Write(" ");
                }
            }
            Console.WriteLine("");
        }
        static int[] throwDice()
        {
            int[] playerDice = new int[6];
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                playerDice[i] = rnd.Next(6) + 1;
            }
            return playerDice;
        }    
        static int[] rethrowDice(int[] playerDice, string rethrownDice)
        {
            Random rnd = new Random();
            string[] dice = rethrownDice.Split();          //creating an array of numbers of dice that will be rethrown
            int length = dice.Length;
            int[] diceNum = new int[length];

            for (int i = 0; i < length; i++)                    
            {
                if (dice[i] == "1" || dice[i] == "2" || dice[i] == "3" || dice[i] == "4" || dice[i] == "5" || dice[i] == "6")
                {
                    diceNum[i] = int.Parse(dice[i]);
                    playerDice[diceNum[i] - 1] = rnd.Next(6) + 1;
                }
            }
            return playerDice;
        }
        static int finalScore(int[] playerDice)
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
            
            Console.WriteLine();

            if (fPlayerScore > sPlayerScore)
            {
                Console.WriteLine("              Player 1 wins!");
            }
            else if (fPlayerScore < sPlayerScore)
            {
                Console.WriteLine("              Player 2 wins!");
            }
            else
            {
                Console.WriteLine("                   Draw");
            }
        }
        static int[] whatToRethrow(int[] playerDice)
        {
            Console.Write(" what dices do you wnat to re-roll?(Or press enter to continue without re-rolling):\n");
            string rethrownDice = Console.ReadLine();
            playerDice = rethrowDice(playerDice, rethrownDice);
            return playerDice;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Write 'rules' or press enter to start");
            string action = Console.ReadLine();
            while (action == "rules" || action == "ranking")
            {
                if (action == "rules")
                {
                    Console.WriteLine("Each player uses a set of five dice");
                    Console.WriteLine("The goal of the game is to roll the strongest hand in two out of three hands");
                    Console.WriteLine("After first roll you can select any dice you wish to re-roll");
                    Console.WriteLine("The player with the highest-ranking hand wins");
                    Console.WriteLine("To know the Ranking of Hands enter 'ranking' or press enter to start");
                }
                else if(action == "ranking")
                {
                    Console.WriteLine("Nothing — five mismatched dice forming no sequence longer than four.");
                    Console.WriteLine("Pair — two dice showing the same value.");
                    Console.WriteLine("Two Pairs — two pairs of dice, each showing the same value.");
                    Console.WriteLine("Three-of-a-Kind — three dice showing the same value.");
                    Console.WriteLine("Five High Straight — dice showing values from 1 through 5, inclusive.");
                    Console.WriteLine("Six High Straight — dice showing values from 2 through 6, inclusive.");
                    Console.WriteLine("Full House — Pair of one value and Three-of-a-Kind of another.");
                    Console.WriteLine("Four-of-a-Kind — four dice showing the same value.");
                    Console.WriteLine("Five-of-a-Kind — all five dice showing the same value.");
                    Console.WriteLine("Press enter to start");
                }
                action = Console.ReadLine();
            }
            
            int[] fPlayerDice = throwDice();
            int[] sPlayerDice = throwDice();
            printDice(fPlayerDice, sPlayerDice);

            Console.Write("player 1,");
            fPlayerDice =  whatToRethrow(fPlayerDice);
            printDice(fPlayerDice, sPlayerDice);

            Console.Write("player 2,");
            sPlayerDice = whatToRethrow(sPlayerDice);
            printDice(fPlayerDice, sPlayerDice);

            whoWon(fPlayerDice, sPlayerDice);
        }
    }  
}