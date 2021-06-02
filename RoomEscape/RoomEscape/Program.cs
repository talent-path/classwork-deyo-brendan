using System;
using System.Collections.Generic;
using RoomEscape.Concrete.Armors;
using RoomEscape.Concrete.Fighters;
using RoomEscape.Concrete.Weapons;
using RoomEscape.Interfaces;

namespace RoomEscape
{
    class Program
    {
        static Random _random = new Random();

        static IFighter _playerFighter;
        //static IFighter _firstEnemy;

        static List<IFighter> _enemies = new List<IFighter>();

        static bool _playerNotDead = true;
        static bool _reachedExit = false;
        static bool _gameIsOver = false;

        static char _empty = '-';
        static char _exit = 'F';

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
            _playerFighter = ChooseFighter(fighter, playerArmor, playerWeapon, 100, playerName, 'O', 0, 0);

            //_firstEnemy = ChooseFighter("knight", new BlackKnightShield(), new MorningStar(),
            //    25, "Java Warrior", 'X', _random.Next(3, 13), _random.Next(3, 13));

            _enemies.Add(ChooseFighter("knight", new BlackKnightShield(), new MorningStar(),
                25, "Java Warrior", 'X', _random.Next(3, 13), _random.Next(3, 13)));

            Console.WriteLine();
            Console.WriteLine("========= RULES! =========");
            Console.WriteLine("Player: " + _playerFighter.Name + " represented with O");
            Console.WriteLine("Enemies are represented with X");
            Console.WriteLine("Get to the exit marked F by moving left right up or down while battling enemies that get in your path.");
            Console.WriteLine("==========================");
            Console.WriteLine();

            PrintGrid();
            Console.WriteLine();

            PromptPlayerMove();
            //Console.WriteLine(_firstEnemy.Row + ", " + _firstEnemy.Col);
            IterateEnemiesToPlayer();
            //Console.WriteLine(_firstEnemy.Row + ", " + _firstEnemy.Col);
            PrintGrid();

            //TODO: enemy row and columns are transitioning but are not being displayed correctly with the grid printing

        }

        static void IterateEnemiesToPlayer()
        {
            if (!_gameIsOver)
            {
                int playerRow = _playerFighter.Row;
                int playerCol = _playerFighter.Col;

                for (int i = 0; i < _enemies.Count; i++)
                {
                    int rowDiff = playerRow - _enemies[i].Row;
                    int colDiff = playerCol - _enemies[i].Row;

                    if (Math.Max(Math.Abs(rowDiff), Math.Abs(colDiff)) == 1)
                    {
                        throw new NotImplementedException();
                        //TODO: battle()
                    }

                    else
                    {
                        if (playerRow > _enemies[i].Row && playerCol > _enemies[i].Col)
                        {
                            _enemies[i].Row += 1;
                            _enemies[i].Col += 1;
                        }
                        else if (playerRow < _enemies[i].Row && playerCol < _enemies[i].Col)
                        {
                            _enemies[i].Row -= 1;
                            _enemies[i].Col -= 1;
                        }
                        else if (playerRow > _enemies[i].Row && playerCol < _enemies[i].Col)
                        {
                            _enemies[i].Row += 1;
                            _enemies[i].Col -= 1;
                        }
                        else if (playerRow < _enemies[i].Row && playerCol > _enemies[i].Col)
                        {
                            _enemies[i].Row -= 1;
                            _enemies[i].Col += 1;
                        }
                        else if (playerRow == _enemies[i].Row && playerCol > _enemies[i].Col)
                            _enemies[i].Col += 1;
                        else if (playerRow == _enemies[i].Row && playerCol < _enemies[i].Col)
                            _enemies[i].Col -= 1;
                        else if (playerRow > _enemies[i].Row && playerCol == _enemies[i].Col)
                            _enemies[i].Row += 1;
                        else if (playerRow < _enemies[i].Row && playerCol == _enemies[i].Col)
                            _enemies[i].Row -= 1;
                    }
                }
            }
        }

        static void Battle()
        {
            //TODO: logic stuff
        }

        static void PromptPlayerMove()
        { 

            if (!_gameIsOver)
            {
                Console.Write("Move " + _playerFighter.Name + " up (U), left (L), right (R), or down (D)? ");
                string input = Console.ReadLine().ToLower();

                int playerRow = _playerFighter.Row;
                int playerCol = _playerFighter.Col;
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

                _playerFighter.Row = moveRow;
                _playerFighter.Col = moveCol;
            }

        }

        static int GetEmptyGridRow(char[,] grid)
        {
            List<int> rowList = new List<int>();

            int toReturn = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == _empty)
                    {
                        rowList.Add(i);
                    }
                }
            }

            for (int i = 0; i < rowList.Count; i++)
            {
                int x = _random.Next(rowList[0], rowList[rowList.Count]);
                toReturn = x;
            }

            return toReturn;
        }

        static int GetEmptyGridCol(char[,] grid)
        {
            List<int> colList = new List<int>();

            int toReturn = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == _empty)
                    {
                        colList.Add(j);
                    }
                }
            }

            for(int i = 0; i < colList.Count; i++)
            {
                int x = _random.Next(colList[0], colList[colList.Count]);
                toReturn = x;
            }

            return toReturn;
        }

        static void PrintGrid()
        {
            char[,] grid = GenerateGrid();

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

            int x = _random.Next(3, 13);
            int y = _random.Next(3, 13);

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] =_empty;
                }

            foreach(IFighter enemy in _enemies)
            {
                grid[enemy.Row, enemy.Col] = enemy.Symbol;
            }

            grid[_playerFighter.Row, _playerFighter.Col] = _playerFighter.Symbol;

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

            IWeapon enemyWeapon = ChooseWeapon(weapons[_random.Next(0, 3)]);

            IArmor enemyArmor = ChooseArmor(armor[_random.Next(0, 3)]);

            IFighter enemy = ChooseFighter(fighters[_random.Next(0, 3)], enemyArmor,
                enemyWeapon, 25, enemies[_random.Next(0, 8)], 'X', GetEmptyGridRow(grid), GetEmptyGridCol(grid));

            return enemy;
        }
    }
}
