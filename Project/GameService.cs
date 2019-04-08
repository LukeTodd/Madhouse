using System;
using System.Collections.Generic;
using MadHouse.Project.Interfaces;
using MadHouse.Project.Models;

namespace MadHouse.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public bool Playing { get; set; }

    public void Setup()
    {
      Room startingRoom = new Room("The Great Hall", "This is the room you started in. You notice nothing special about this room.  There are Doors to the north, south, east, and west");
      Room den = new Room("The Den", "You are in the Den of the mansion. The heads of many animals hang on the walls.  It smells of old cigar smoke. You do not see any other exits out of this room besides the one you came through.  There is a giant mahogany desk in the center of the room.  You sit behind the desk to feel important.  It instead makes you feel small as you will never have this feeling again.  While pondering your insecurities, you notice a trap door underneath the desk.");
      Room ballroom = new Room("The Ballroom", "This is the Ballroom");
      Room library = new Room("The Library", "This is the Library, many books");
      Room bedroom = new Room("A Secret Room", "This looks like an ordinary room, whith a closet");
      Room closet = new Room("The Closet", "This is a closet");
      Room cellar = new Room("The Cellar", "This is a cellar");
      Room foyer = new Room("The Grand Foyer", "This is the grand foyer");
      Room outside = new Room("Outside", "You have escaped MadHouse Mansion! You have a new appreciation for life and dedicate yourself to being the best human possible. You spend decades crafting your skills and finally published your masterpiece. Its the second best texted based adventure game (behind this one of course) and makes you a ton of doe. You live a long life and die rich and happy.");

      Item key = new Item("Brass Key", "This is a brass key");
      Item sword = new Item("Master Sword", "This is a master sword");
      Item note = new Item("Note", "Welcome to Madhouse Mansion!  My name is SawJig. I have kidnapped you.  I'm very bored and like to watch people try to escape my house...or die trying. MuaHaHaHa");

      startingRoom.Exits.Add("north", den);
      startingRoom.Exits.Add("south", foyer);
      startingRoom.Exits.Add("east", ballroom);
      startingRoom.Exits.Add("west", library);
      den.Exits.Add("south", startingRoom);
      den.Exits.Add("down", cellar);
      ballroom.Exits.Add("west", startingRoom);
      foyer.Exits.Add("north", startingRoom);
      foyer.Exits.Add("south", outside);
      library.Exits.Add("east", startingRoom);
      library.Exits.Add("up", bedroom);
      cellar.Exits.Add("up", den);
      bedroom.Exits.Add("down", library);
      bedroom.Exits.Add("east", closet);
      closet.Exits.Add("west", bedroom);
      closet.Items.Add(key);

      CurrentRoom = startingRoom;

      Console.Clear();
      System.Console.WriteLine("You Wake Up On The Floor With No Memory Of How You Got There. You Look About You And See That You Are In A Giant Room. As You Examine The Room You Realize That This Looks Like a Great Hall Of A 16th Century Victorian Mansion.  You Know This Because You Spent The Last 3 Years Of Your Life Majoring In History Before You Decided There Is No Career In This Field And You Dropped Out Of School.  YOU START TO THINK OF THE CRIPPLING DEBT YOU'VE PILED UP AND MAKES YOU FEEL A LITTLE DEPRESSED.  As You Start To Dwell On All The Bad Choices You've Made In Life, You Notice A Note On The Ground.");
      Run();

    }

    public void Run()
    {
      while (Playing)
      {
        IRoom currentRoom = CurrentRoom;
        Console.WriteLine(Environment.NewLine);
        System.Console.WriteLine($"What would you like to do, {CurrentPlayer.PlayerName}?");
        Console.WriteLine(Environment.NewLine);
        GetUserInput();
      }
    }

    public void GetUserInput()
    {
      string[] playerChoice = Console.ReadLine().ToLower().Split(" ");
      string command = playerChoice[0];
      string choice = "";
      if (playerChoice.Length > 1)
      {
        choice = playerChoice[1];
      }

      switch (command)
      {
        case "go":
          Go(choice);

          break;
        case "look":
          Look();
          break;
        case "quit":
          Quit();
          break;
        case "reset":
          Reset();
          break;
        case "help":
          Help();
          break;
        case "take":
          TakeItem(choice);
          break;
        case "use":
          UseItem(choice);
          break;

      }
    }











    public void Reset()
    {
      Console.WriteLine("DO YOU REALLY WANT TO START THE GAME OVER? (Y/N)");
      if (Console.ReadLine() == "y".ToLower())
      {
        Setup();
      }
      else Look();
    }

    public void StartGame()
    {

    }



    public void Quit()
    {
      Console.WriteLine("Do you really want to quit the game? (Y/N)");
      if (Console.ReadLine() == "y".ToLower())
      {
        Playing = false;
      }
      else Look();
    }

    public void Help()
    {
      Console.WriteLine(@"
      Go - Choose a Direction to go (North, South, East, West, Up, Down)
      Look - Look Around the Room
      Quit - Quit the Game
      Reset - Restart the Game
      Take - Take an Item to Use
      Use - Use Item
      ");
    }

    public void Go(string direction)
    {
      Console.Clear();
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
        Look();
      }
      else
      {
        Console.WriteLine("Can't Go In That Direction");
      }
    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {
      Console.WriteLine($"{CurrentRoom.Description}");
    }

    public GameService(Player newPlayer)
    {
      CurrentPlayer = newPlayer;
      Playing = true;

    }
  }
}