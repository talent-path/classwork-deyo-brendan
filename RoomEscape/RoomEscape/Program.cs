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
        static int _hpPotion = 25;
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

            _playerFighter = ChooseFighter(fighter, playerArmor, playerWeapon, 100, playerName, 'O', 0, 0);

            //_enemies.Add(ChooseFighter("knight", new BlackKnightShield(), new MorningStar(),
            //    25, "Java Warrior", 'X', _random.Next(3, 13), _random.Next(3, 13)));

            Console.WriteLine();
            Console.WriteLine("========= RULES! =========");
            Console.WriteLine("Player: " + _playerFighter.Name + " represented with O");
            Console.WriteLine("Enemies are represented with X");
            Console.WriteLine("Get to the exit marked F by moving left right up or down while battling enemies that get in your path.");
            Console.WriteLine("==========================");
            Console.WriteLine();

            PrintGrid();
            Console.WriteLine();

            while (!_gameIsOver)
            {
                for (int i = 0; i < _roomCount; i++)
                {
                    _enemies.Add(GenerateRandomEnemy());
                }

                PrintGrid();

                while (_playerNotDead && !_reachedExit)
                {
                    PromptPlayerMove();
                    IterateEnemiesToPlayer();

                    foreach (IFighter enemy in _enemies)
                        if (enemy.Row == _playerFighter.Row && enemy.Col == _playerFighter.Col)
                            Battle(enemy, _playerFighter);

                    PrintGrid();

                    if (_playerFighter.Row == 14 && _playerFighter.Col == 14)
                        _reachedExit = true;

                    Console.WriteLine();
                }

                _roomCount++;

                if (_roomCount == 224)
                    _gameIsOver = true;
            }
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

                    if (Math.Abs(rowDiff) == 1 && Math.Abs(colDiff) == 1)
                    {
                        Battle(_enemies[i], _playerFighter);
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

        static void Battle(IFighter enemy, IFighter player)
        {

            if (player.Health < 25 && _usedPotion == false)
            {
                player.Health += _hpPotion;
                _usedPotion = true;
                Console.WriteLine(player.Name + " used potion: + 25 HP");
                Console.WriteLine();
            }

            IFighter attacker, defender;
            attacker = player;
            defender = enemy;

            while (defender.Health > 0 && attacker.Health > 0)
            {
                IFighter temp;

                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine(attacker.Name + " health: " + attacker.Health);
                Console.WriteLine(defender.Name + " health: " + defender.Health);
                Console.WriteLine(attacker.Name + " is attacking " + defender.Name);
                Console.WriteLine("---------------------");

                defender.Defend(attacker.Attack(defender));

                if (attacker.Health <= 0)
                    _playerNotDead = false;

                temp = attacker;
                attacker = defender;
                defender = temp;
            }
        }

        static void PromptPlayerMove()
        {
            if (!_gameIsOver)
            {
                Console.Write("Move " + _playerFighter.Name + " up (U), left (L), right (R), or down (D)? ");
                string input = Console.ReadLine().ToLower();

                if (_playerFighter.Row == 0 && _playerFighter.Col == 0)
                {
                    if (input == "r")
                        _playerFighter.Col++;
                    else if (input == "d")
                        _playerFighter.Row++;
                    else
                        _playerFighter.Row++;
                }
                else if (_playerFighter.Row == 0 && _playerFighter.Col != 0)
                {
                    if (input == "l")
                        _playerFighter.Col--;
                    else if (input == "r")
                        _playerFighter.Col++;
                    else if (input == "d")
                        _playerFighter.Row++;
                }
                else if (_playerFighter.Row != 0 && _playerFighter.Col == 0)
                {
                    if (input == "u")
                        _playerFighter.Row--;
                    else if (input == "d")
                        _playerFighter.Row++;
                    else if (input == "r")
                        _playerFighter.Col++;
                }
                else
                {
                    if (input == "u")
                        _playerFighter.Row--;
                    else if (input == "d")
                        _playerFighter.Row++;
                    else if (input == "r")
                        _playerFighter.Col++;
                    else if (input == "l")
                        _playerFighter.Col--;
                }

                for (int i = 0; i < _enemies.Count; i++)
                {
                    int rowDiff = _playerFighter.Row - _enemies[i].Row;
                    int colDiff = _playerFighter.Col - _enemies[i].Row;

                    if (Math.Max(Math.Abs(rowDiff), Math.Abs(colDiff)) == 1)
                    {
                        Battle(_enemies[i], _playerFighter);
                    }

                }

                //if (_playerFighter.Row == 14 && _playerFighter.Col == 14)
                //    _reachedExit = true;

            }

        }

        //static int GetEmptyGridRow(char[,] grid)
        //{
        //    List<int> rowList = new List<int>();

        //    int toReturn = 0;

        //    for (int i = 0; i < grid.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < grid.GetLength(1); j++)
        //        {
        //            if (grid[i, j] == _empty)
        //            {
        //                rowList.Add(i);
        //            }
        //        }
        //    }

        //    int index = _random.Next(rowList.Count);

        //    toReturn = rowList[index];

        //    return toReturn;
        //}

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

        //static int GetEmptyGridCol(char[,] grid)
        //{
        //    List<int> colList = new List<int>();

        //    int toReturn = 0;

        //    for (int i = 0; i < grid.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < grid.GetLength(1); j++)
        //        {
        //            if (grid[i, j] == _empty)
        //            {
        //                colList.Add(j);
        //            }
        //        }
        //    }

        //    int index = _random.Next(colList.Count);

        //    toReturn = colList[index];

        //    return toReturn;
        //}

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

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] =_empty;
                }

            foreach (IFighter enemy in _enemies)
            {
                grid[enemy.Row, enemy.Col] = enemy.Symbol;
            }

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

            Tuple<int, int> cell = emptyCell[_random.Next(randomIndex)];

            int enemyRow = cell.Item1;
            int enemyCol = cell.Item2;

            IFighter enemy = ChooseFighter(fighters[_random.Next(0, 3)], enemyArmor,
                enemyWeapon, 25, enemies[_random.Next(0, 8)], 'X', enemyRow, enemyCol);

            return enemy;
        }
    }
}
