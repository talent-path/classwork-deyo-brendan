using System;
using RoomEscape.Concrete.Armors;
using RoomEscape.Concrete.Fighters;
using RoomEscape.Concrete.Weapons;
using RoomEscape.Interfaces;

namespace RoomEscape
{
    class Program
    {
        static Random random = new Random();

        static IFighter playerFighter;
        static IFighter firstEnemy;

        static IFighter[] enemies = new IFighter[223];

        static bool playerNotDead = true;
        static bool gameIsOver = false;

        static char empty = '-';
        static char exit = 'F';

        static void Main(string[] args)
        { 

            Console.Write("Enter you player name: ");
            string playerName = Console.ReadLine();

            Console.Write("Choose a fighter type (Knight/Mercenary/Viking): ");
            string fighter = Console.ReadLine().ToLower();

            Console.Write("Choose an armor set (Black Knight Shield/Purple Flame Shield/Spiked Shield): ");
            string armor = Console.ReadLine().ToLower().Replace(" ", "");

            Console.Write("Choose a weapon (Great Scythe/Hiltless/Morning Star): ");
            string weapon = Console.ReadLine().ToLower().Replace(" ", "");

            IWeapon playerWeapon = ChooseWeapon(weapon);
            IArmor playerArmor = ChooseArmor(armor);
            playerFighter = ChooseFighter(fighter, playerArmor, playerWeapon, 100, playerName, 'O', 0, 0);

            firstEnemy = ChooseFighter("knight", new BlackKnightShield(), new MorningStar(),
                15, "Java Warrior", 'X', random.Next(3, 13), random.Next(3, 13));

            if (enemies.Length == 0)
                enemies[0] = firstEnemy;

            Console.WriteLine();
            Console.WriteLine("========= RULES! =========");
            Console.WriteLine("Player: " + playerFighter.Name + " represented with O");
            Console.WriteLine("Enemies are represented with X");
            Console.WriteLine("Get to the exit marked F by moving left right up or down while battling enemies that get in your path.");
            Console.WriteLine("==========================");
            Console.WriteLine();

            char[,] grid = GenerateGrid();
            char[,] tempGrid = grid;
            PrintGrid(grid);
            Console.WriteLine();

            grid = PromptPlayerMove(grid);
            PrintGrid(grid);
        }

        static char[,] IterateEnemiesToPlayer(char[,] grid)
        {
            char[,] toReturn = grid;

            if (!gameIsOver)
            {
                int playerRow = playerFighter.Row;
                int playerCol = playerFighter.Col;

                int[] moveRows;
                int[] moveCols;

                for (int i = 0; i < enemies.Length; i++)
                {
                    if (playerRow > enemies[i].Row && playerCol > enemies[i].Col)
                    {
                        enemies[i].Row += 1;
                        enemies[i].Col += 1;
                    }
                    else if (playerRow < enemies[i].Row && playerCol < enemies[i].Col)
                    {
                        enemies[i].Row -= 1;
                        enemies[i].Col -= 1;
                    }
                    else if (playerRow > enemies[i].Row && playerCol < enemies[i].Col)
                    {
                        enemies[i].Row += 1;
                        enemies[i].Col -= 1;
                    }
                    else if (playerRow < enemies[i].Row && playerCol > enemies[i].Col)
                    {
                        enemies[i].Row -= 1;
                        enemies[i].Col += 1;
                    }
                    else if (playerRow == enemies[i].Row && playerCol > enemies[i].Col)
                    {
                        // TODO!!!
                    }

                }
            }

            return toReturn;
        }

        static char[,] PromptPlayerMove(char[,] grid)
        {
            char[,] toReturn = grid;

            if (!gameIsOver)
            {
                Console.Write("Move " + playerFighter.Name + " up (U), left (L), right (R), or down (D)? ");
                string input = Console.ReadLine().ToLower();

                int playerRow = playerFighter.Row;
                int playerCol = playerFighter.Col;
                int moveRow = 0;
                int moveCol = 0;

                if (playerRow == 0 && playerCol == 0)
                {
                    if (input == "r")
                        moveCol = playerCol + 1;
                    else if (input == "d")
                        moveRow = playerRow + 1;
                }
                else if (playerRow == 0 && playerCol != 0)
                {
                    if (input == "l")
                        moveCol = playerCol - 1;
                    else if (input == "r")
                        moveCol = playerCol + 1;
                    else if (input == "d")
                        moveRow = playerRow + 1;
                }
                else if (playerRow != 0 && playerCol == 0)
                {
                    if (input == "u")
                        moveRow = playerRow - 1;
                    else if (input == "d")
                        moveRow = playerRow + 1;
                    else if (input == "r")
                        moveCol = playerCol + 1;
                }
                else
                {
                    if (input == "u")
                        moveRow = playerRow - 1;
                    else if (input == "d")
                        moveRow = playerRow + 1;
                    else if (input == "r")
                        moveCol = playerCol + 1;
                    else if (input == "l")
                        moveCol = playerCol - 1;
                }

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[moveRow, moveCol] == empty)
                        {
                            toReturn[playerRow, playerCol] = empty;
                            toReturn[moveRow, moveCol] = playerFighter.Symbol;
                        }
                    }
                }
            }

            return toReturn;
        }

        static int GetEmptyGridRow(char[,] grid)
        {
            int toReturn = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i,j] == empty)
                    {
                        toReturn = i;
                    }
                }
            }
            return toReturn;
        }

        static int GetEmptyGridCol(char[,] grid)
        {
            int toReturn = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == empty)
                    {
                        toReturn = j;
                    }
                }
            }
            return toReturn;
        }

        static void PrintGrid(char[,] grid)
        {
            Console.WriteLine();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                    if (j == 14)
                        Console.WriteLine();
                }
            }
        }

        static char[,] GenerateGrid()
        {
            char[,] grid = new char[15,15];

            int x = random.Next(3, 13);
            int y = random.Next(3, 13);

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == playerFighter.Row && j == playerFighter.Col)
                        grid[i, j] = playerFighter.Symbol;
                    else if (i == firstEnemy.Row && j == firstEnemy.Col)
                        grid[i, j] = firstEnemy.Symbol;
                    else if (i == 14 && j == 14)
                        grid[i, j] = exit;
                    else
                        grid[i, j] = empty;
                }

            return grid;

        }

        static IFighter ChooseFighter(string fighter, IArmor armor, IWeapon weapon,
            int health, string name, char symbol, int row, int col)
        {
            if (fighter == "knight")
                return new Knight(health, name, armor, weapon, symbol, row, col);
            else if (fighter == "mercenary")
                return new Mercenary(health, name, armor, weapon, symbol, row, col);
            else
                return new Viking(health, name, armor, weapon, symbol, row, col);
        }

        static IArmor ChooseArmor(string armor)
        {
            if (armor == "blackknightshield")
                return new BlackKnightShield();
            else if (armor == "purpleflameshield")
                return new PurpleFlameShield();
            else
                return new SpikedShield();
        }

        static IWeapon ChooseWeapon(string weapon)
        {
            if (weapon == "greatscythe")
                return new GreatScythe();
            else if (weapon == "hiltless")
                return new Hiltless();
            else
                return new MorningStar();
        }

        static IFighter GenerateRandomEnemy(char[,] grid)
        {
            string[] enemies = {"David Smelser", "Little Finger", "The Hound", "Walter White",
                "Wicked Witch of the West", "Roberto", "Mr. X", "Teemo", "Beebo" };
            string[] fighters = { "knight", "viking", "mercenary" };
            string[] weapons = { "greatscythe", "hiltless", "morningstar" };
            string[] armor = { "purpleflameshield", "spikedshield", "blackknightshield" };

            IWeapon enemyWeapon = ChooseWeapon(weapons[random.Next(0, 3)]);

            IArmor enemyArmor = ChooseArmor(armor[random.Next(0, 3)]);

            IFighter enemy = ChooseFighter(fighters[random.Next(0, 3)], enemyArmor,
                enemyWeapon, 25, enemies[random.Next(0, 8)], 'X', GetEmptyGridRow(grid), GetEmptyGridCol(grid));

            return enemy;
        }
    }
}
