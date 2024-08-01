using System;

public class Game
{
    private Room[,] _world;
    private Player _player;
    private IMonster _currentMonster;
    private bool _isFountainEnabled;

    public Game()
    {
        _world = new Room[3, 3];
        InitializeWorld();
        _player = new Player(0, 0);
        _isFountainEnabled = false;
    }

    private void InitializeWorld()
    {
        for (int row = 0; row < _world.GetLength(0); row++)
        {
            for (int col = 0; col < _world.GetLength(1); col++)
            {
                _world[row, col] = new Room(row, col);
            }
        }

        _world[0, 0].Description = "You see light coming from the cavern entrance.";
        _world[0, 2].Description = "You hear water dripping in this room. The Fountain of Objects is here!";
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Fountain of Objects!");

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You are in the room at (Row={_player.Row}, Column={_player.Column}).");
            Console.WriteLine(_world[_player.Row, _player.Column].Description);

            if (_currentMonster != null)
            {
                Console.WriteLine($"You encounter a {_currentMonster.Name}!");
            }

            Console.Write("What do you want to do? ");
            string command = Console.ReadLine().ToLower();

            if (command.StartsWith("move"))
            {
                string direction = command.Substring(5).Trim();
                MovePlayer(direction);
            }
            else if (command == "enable fountain")
            {
                EnableFountain();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }

            if (IsGameWon())
            {
                Console.WriteLine("Congratulations! You've won the game!");
                break;
            }
            else if (IsGameOver())
            {
                Console.WriteLine("Game Over!");
                break;
            }
        }
    }

    private void MovePlayer(string direction)
    {
        int newRow = _player.Row;
        int newCol = _player.Column;

        switch (direction)
        {
            case "north":
                newRow--;
                break;
            case "south":
                newRow++;
                break;
            case "east":
                newCol++;
                break;
            case "west":
                newCol--;
                break;
            default:
                Console.WriteLine("Error during movement: Invalid direction. Use 'move north', 'move south', 'move east', or 'move west'.");
                return;
        }

        if (IsValidPosition(newRow, newCol))
        {
            _player.Row = newRow;
            _player.Column = newCol;
            EncounterMonster();
        }
        else
        {
            Console.WriteLine("Error during movement: You cannot move outside the bounds of the cavern.");
        }
    }

    private void EncounterMonster()
    {
        if (new Random().Next(0, 4) == 0) 
        {
            _currentMonster = new Goblin(); 
            Console.WriteLine($"A {_currentMonster.Name} appears!");
        }
        else
        {
            _currentMonster = null;
        }
    }

    private void EnableFountain()
    {
        if (_player.Row == 0 && _player.Column == 2)
        {
            _isFountainEnabled = true;
            _world[0, 2].Description = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
        }
        else
        {
            Console.WriteLine("Error: You are not in the room with the Fountain of Objects.");
        }
    }

    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < _world.GetLength(0) && col >= 0 && col < _world.GetLength(1);
    }

    private bool IsGameWon()
    {
        return _isFountainEnabled && _player.Row == 0 && _player.Column == 2;
    }

    private bool IsGameOver()
    {
        return _player.Health <= 0;
    }
}
