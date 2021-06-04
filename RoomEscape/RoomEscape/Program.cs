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
        static int _hpPotion = 100;
        static int _roomCount = 1;

        static List<IFighter> _enemies = new List<IFighter>();

        static bool _playerNotDead = true;
        static bool _reachedExit = false;
        static bool _gameIsOver = false;
        static bool _usedPotion = false;

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

            _playerFighter = ChooseFighter(fighter, playerArmor, playerWeapon, 500, playerName, 'O', 0, 0);

            //_enemies.Add(ChooseFighter("knight", new BlackKnightShield(), new MorningStar(),
            //    25, "Java Warrior", 'X', _random.Next(3, 13), _random.Next(3, 13)));

            Console.WriteLine();
            Console.WriteLine("========= RULES! =========");
            Console.WriteLine("Player: " + _playerFighter.Name + " represented with O");
            Console.WriteLine("Enemies are represented with X");
            Console.WriteLine("Get to the exit marked F by moving left right up or down while battling enemies that get in your path.");
            Console.WriteLine("==========================");
            Console.WriteLine();

            while (!_gameIsOver)
            {
                _enemies.RemoveRange(0, _enemies.Count);

                for (int i = 1; i <= _roomCount; i++)
                {
                    _enemies.Add(GenerateRandomEnemy());
                }

                _reachedExit = false;

                PrintGrid();
                Console.WriteLine();

                while (_playerNotDead && !_reachedExit)
                {
                    Console.WriteLine("Room Count: " + _roomCount);
                    Console.WriteLine();

                    if (_playerFighter.Health <= 0)
                    {
                        _gameIsOver = true;
                        Console.WriteLine();
                        Console.WriteLine("You have died!");
                        break;
                    }

                    PromptPlayerMove();
                    IterateEnemiesToPlayer();

                    PrintGrid();

                    if (_playerFighter.Row == 14 && _playerFighter.Col == 14)
                    {
                        _reachedExit = true;
                        Console.WriteLine();
                        Console.WriteLine("=========NEW ROOM=========");
                    }

                    Console.WriteLine();
                }

                _roomCount++;

                if (_roomCount == 224)
                {
                    Console.WriteLine("====YOU WON====");
                    Console.WriteLine("yay :)");
                    _gameIsOver = true;
                }
            }
        }

        static void IterateEnemiesToPlayer()
        {
            if (!_gameIsOver && _enemies.Count > 0)
            {
                int playerRow = _playerFighter.Row;
                int playerCol = _playerFighter.Col;

                for (int i = 0; i < _enemies.Count; i++)
                {
                    int desiredRow = _enemies[i].Row;
                    int desiredCol = _enemies[i].Col;

                    int currentRow = _enemies[i].Row;
                    int currentCol = _enemies[i].Col;

                    int rowDiff = playerRow - _enemies[i].Row;
                    int colDiff = playerCol - _enemies[i].Col;

                    if (Math.Abs(rowDiff) > Math.Abs(colDiff))
                    {
                        desiredRow += rowDiff > 0 ? 1 : -1;
                    }
                    else
                    {
                        desiredCol += colDiff > 0 ? 1 : -1;
                    }

                    bool canMoveEnemy = true;

                    if (desiredRow == _playerFighter.Row && desiredCol == _playerFighter.Col)
                        Battle(_enemies[i], _playerFighter);
                    else
                    {
                        foreach(IFighter enemy in _enemies)
                        {
                            if (enemy.Row == desiredRow && enemy.Col == desiredCol)
                            {
                                _enemies[i].Row = currentRow;
                                _enemies[i].Col = currentCol;
                                canMoveEnemy = false;
                            }
                        }

                        if (canMoveEnemy)
                        {
                            _enemies[i].Row = desiredRow;
                            _enemies[i].Col = desiredCol;
                        }
                    }
                }
            }
        }

        static void Battle(IFighter attacker, IFighter defender)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------");
            if (attacker.Health > 0)
                Console.WriteLine(attacker.Name + " health: " + attacker.Health);
            else
                Console.WriteLine(attacker.Name + " health: 0");
            if (defender.Health > 0)
                Console.WriteLine(defender.Name + " health: " + defender.Health);
            else
                Console.WriteLine(defender.Name + " health: 0");
            Console.WriteLine(attacker.Name + " is attacking " + defender.Name);
            Console.WriteLine("---------------------");

            defender.Defend(attacker.Attack(defender));

        }

        static void PromptPlayerMove()
        {
            if (!_gameIsOver)
            {
                int desiredRow = _playerFighter.Row;
                int desiredCol = _playerFighter.Col;

                Console.Write("Move " + _playerFighter.Name + " up (U), left (L), right (R), or down (D)? ");
                string input = Console.ReadLine().ToLower();

                Console.WriteLine();

                if (_playerFighter.Row == 0 && _playerFighter.Col == 0)
                {
                    if (input == "r")
                        desiredCol++;
                    else if (input == "d")
                        desiredRow++;
                    else if (!input.GetType().Equals(typeof(char)))
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                    }
                    else
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Can't move there!");
                        Console.WriteLine();
                    }
                }
                else if (_playerFighter.Row == 0 && _playerFighter.Col != 0 && _playerFighter.Col != 14)
                {
                    if (input == "l")
                        desiredCol--;
                    else if (input == "r")
                        desiredCol++;
                    else if (input == "d")
                        desiredRow++;
                    else if (!input.GetType().Equals(typeof(char)))
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                    }
                    else
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Can't move there!");
                        Console.WriteLine();
                    }
                }
                else if (_playerFighter.Row != 0 && _playerFighter.Col == 0 && _playerFighter.Row != 14)
                {
                    if (input == "u")
                        desiredRow--;
                    else if (input == "d")
                        desiredRow++;
                    else if (input == "r")
                        desiredCol++;
                    else if (!input.GetType().Equals(typeof(char)))
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();
                    }
                    else
                    {
                        desiredRow = _playerFighter.Row;
                        desiredCol = _playerFighter.Col;
                        Console.WriteLine("Can't move there!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (_playerFighter.Row == 14 && _playerFighter.Col == 0)
                    {
                        if (input == "u")
                            desiredRow--;
                        else if (input == "r")
                            desiredCol++;
                        else if (!input.GetType().Equals(typeof(char)))
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                        else
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Can't move there!");
                            Console.WriteLine();
                        }
                    }
                    else if (_playerFighter.Row == 0 && _playerFighter.Col == 14)
                    {
                        if (input == "d")
                            desiredRow++;
                        else if (input == "l")
                            desiredCol--;
                        else if (input == "r")
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                        else if (!input.GetType().Equals(typeof(char)))
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                        else
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Can't move there!");
                            Console.WriteLine();
                        }
                    }
                    else if (_playerFighter.Row == 14 && _playerFighter.Col != 0)
                    {
                        if (input == "u")
                            desiredRow--;
                        else if (input == "r")
                            desiredCol++;
                        else if (input == "l")
                            desiredCol--;
                        else if (!input.GetType().Equals(typeof(char)))
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                        else
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Can't move there!");
                            Console.WriteLine();
                        }
                    }
                    else if (_playerFighter.Row != 0 && _playerFighter.Col == 14)
                    {
                        if (input == "u")
                            desiredRow--;
                        else if (input == "d")
                            desiredRow++;
                        else if (input == "l")
                            desiredCol--;
                        else if (!input.GetType().Equals(typeof(char)))
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                        else
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Can't move there!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if (input == "u")
                            desiredRow--;
                        else if (input == "d")
                            desiredRow++;
                        else if (input == "r")
                            desiredCol++;
                        else if (input == "l")
                            desiredCol--;
                        else if (!input.GetType().Equals(typeof(char)))
                        {
                            desiredRow = _playerFighter.Row;
                            desiredCol = _playerFighter.Col;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine();
                        }
                    }
                }

                bool fought = false;

                for (int i = 0; i < _enemies.Count; i++)
                {
                    int rowDiff = desiredRow - _enemies[i].Row;
                    int colDiff = desiredCol - _enemies[i].Col;

                    if (rowDiff == 0 && colDiff == 0)
                    {

                        if (_playerFighter.Health <= 25 && !_usedPotion)
                        {
                            Console.WriteLine(_playerFighter.Name + " used potion: + 25 HP");
                            _playerFighter.Health += _hpPotion;
                            _usedPotion = true;
                        }

                        Battle(_playerFighter, _enemies[i]);

                        fought = true;

                        if (_playerFighter.Health <= 0)
                            _playerNotDead = false;
                    }
                }

                if (!fought)
                {
                    _playerFighter.Row = desiredRow;
                    _playerFighter.Col = desiredCol;
                }
            }

        }

        static List<Tuple<int, int>> GetEmptyCell()
        {
            List<Tuple<int, int>> toReturn = new List<Tuple<int, int>>();

            char[,] grid = GenerateGrid();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == _empty)
                    {
                        toReturn.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return toReturn;
        }

        static void PrintGrid()
        {
            char[,] grid = GenerateGrid();

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

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] =_empty;
                }

            if (_enemies.Count != 0)
            {
                foreach (IFighter enemy in _enemies)
                {
                    if (enemy.Health <= 0)
                    {
                        grid[enemy.Row, enemy.Col] = _empty;
                        _enemies.RemoveAt(_enemies.IndexOf(enemy));
                        break;
                    }
                    else
                        grid[enemy.Row, enemy.Col] = enemy.Symbol;

                }
            }

            if (_reachedExit)
            {
                _playerFighter.Row = 0;
                _playerFighter.Col = 0;
                grid[_playerFighter.Row, _playerFighter.Col] = _playerFighter.Symbol;
            }
            else
                grid[_playerFighter.Row, _playerFighter.Col] = _playerFighter.Symbol;

            grid[14, 14] = _exit;

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

        static IFighter GenerateRandomEnemy()
        {
            string[] enemies = {"David Smelser", "Little Finger", "The Hound", "Walter White",
                "Wicked Witch of the West", "Roberto", "Mr. X", "Teemo", "Beebo" };
            string[] fighters = { "knight", "viking", "mercenary" };
            string[] weapons = { "greatscythe", "hiltless", "morningstar" };
            string[] armor = { "purpleflameshield", "spikedshield", "blackknightshield" };

            IWeapon enemyWeapon = ChooseWeapon(weapons[_random.Next(0, 3)]);

            IArmor enemyArmor = ChooseArmor(armor[_random.Next(0, 3)]);

            List<Tuple<int, int>> emptyCell = GetEmptyCell();

            int randomIndex = _random.Next(emptyCell.Count);

            Tuple<int, int> cell = emptyCell[randomIndex];

            int enemyRow = cell.Item1;
            int enemyCol = cell.Item2;

            IFighter enemy = ChooseFighter(fighters[_random.Next(0, 3)], enemyArmor,
                enemyWeapon, 25, enemies[_random.Next(0, 8)], 'X', enemyRow, enemyCol);

            return enemy;
        }
    }
}
