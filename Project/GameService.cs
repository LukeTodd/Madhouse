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
    public Room Locked1 { get; set; }
    public Room Locked2 { get; set; }

    public bool Playing { get; set; }

    public void Setup()
    {
      Room startingRoom = new Room("The Great Hall", "This is the room you started in. You notice nothing special about this room.  There are Doors to the north, south, east, and west");
      Room den = new Room("The Den", "You are in the Den. The heads of many animals hang on the walls.  It smells of old cigar smoke. You do not see any other exits out of this room besides the one you came through.  There is a giant mahogany desk in the center of the room.  You sit behind the desk to feel important.  It instead makes you feel small as you will never have this feeling again.  While pondering your insecurities, you notice a trap door underneath the desk.");
      Room ballroom = new Room("The Ballroom", "This is the Ballroom. You are reminded that you can't dance.  There are no exits besides the one you came through. You see a lockpick");

      Room library = new Room("The Library", @"You are in the Library.  Giant shelves case each wall with many books. A magnificent glass chandelier hangs from the ceiling. You see two levers on the wall that are labeled:
      Lever 1: Do not touch!
      lever 2: Really do not touch!!
      ");
      Room bedroom = new Room("A Secret Room", "You walk up into a secret room.  It's dark and gloomy.  You are reminded of your childhood.  You see a bed, a wardrobe, and a closet on the east wall. The closet is Locked");
      Room closet = new Room("The Closet", "This is a closet. You only see a master sword here.");
      Room cellar = new Room("The Cellar", "You go down in to the Cellar. You see a giant rat.");
      Room foyer = new Room("The Grand Foyer", "This is the Grand Foyer. You see the exit of the Mansion to the south and really cool statue. The exit to the south is locked");
      Room outside = new Room("Outside", "You have escaped MadHouse Mansion! You have a new appreciation for life and dedicate yourself to being the best human possible. You spend decades crafting your skills and finally publish your masterpiece. Its the second most successful text based adventure game (behind this one of course) and makes you a ton of dough. You live a long life and die rich and happy.");

      Item key = new Item("Lockpick", "This is a lockpick");
      Item mKey = new Item("Key", "Very shiny, must open something important.");
      Item sword = new Item("Sword", "Good at killing things");
      Item note = new Item("Note", "Welcome to Madhouse Mansion!  My name is SawJig. I have kidnapped you.  I'm very bored with my life and like to watch people try to escape my house...or die trying. MuaHaHaHa");

      closet.Items.Add(sword);
      ballroom.Items.Add(key);
      cellar.Items.Add(mKey);
      startingRoom.Items.Add(note);

      startingRoom.Exits.Add("north", den);
      startingRoom.Exits.Add("south", foyer);
      startingRoom.Exits.Add("east", ballroom);
      startingRoom.Exits.Add("west", library);
      den.Exits.Add("south", startingRoom);
      den.Exits.Add("down", cellar);
      ballroom.Exits.Add("west", startingRoom);
      foyer.Exits.Add("north", startingRoom);
      // foyer.Exits.Add("south", outside);
      library.Exits.Add("east", startingRoom);
      library.Exits.Add("up", bedroom);
      cellar.Exits.Add("up", den);
      bedroom.Exits.Add("down", library);
      // bedroom.Exits.Add("east", closet);
      closet.Exits.Add("west", bedroom);
      closet.Items.Add(key);

      Locked1 = closet;
      Locked2 = outside;

      CurrentRoom = startingRoom;

      Console.Clear();
      System.Console.WriteLine("You wake up on the floor with no memory of how you got here.  You look about you and see that you are in a giant room. As you examine the room you realize that this looks like a great hall of a 16th century victorian mansion. You know this because you've spent the last 3 years majoring in history before you realized there is no career in this field and dropped out of school.  You start to think of the crippling debt you've accumulated over the years.  You start to feel a little depressed.  As you start to dwell on all the bad choices you've made in life, you notice a note on the ground");
      Run();

    }

    public void Run()
    {
      while (Playing)
      {
        IRoom currentRoom = CurrentRoom;
        Console.WriteLine(Environment.NewLine);
        if (CurrentRoom.Name == "The Cellar" && CurrentPlayer.Inventory.Count < 1)
        {
          Console.WriteLine("You are eaten by a Giant Rat");
          Playing = false;
          return;
        }
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
        case "inventory":
          Inventory();
          break;
        default:
          Console.WriteLine("Invalid Command");
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
      Inventory - See What is in Your Inventory
      ");
    }

    public void Go(string direction)
    {
      Console.Clear();
      if (CurrentRoom.Exits.ContainsKey(direction))
      {

        {
          CurrentRoom = (Room)CurrentRoom.Exits[direction];
          Look();
        }
      }
      else
      {
        Console.WriteLine("Can't Go In That Direction");
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(f =>
            {
              return f.Name.ToLower() == itemName;
            });

      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        Console.WriteLine($"You received {item.Name}. {item.Description}");
      }
      else
      {
        Console.WriteLine("You Cant Take That!");
      }
    }

    public void UseItem(string itemName)
    {
      // Console.WriteLine($"{CurrentRoom.Name}");
      // Console.WriteLine($"{CurrentPlayer.Inventory[0].Name}");
      Item i = CurrentRoom.Items.Find(items => items.Name.ToLower() == itemName.ToLower());
      Item item = CurrentPlayer.Inventory.Find(items => items.Name.ToLower() == itemName.ToLower());
      // if (item != null)
      // {
      if (CurrentRoom.Name == "A Secret Room" && CurrentPlayer.Inventory[0].Name == "Lockpick")
      {
        Console.WriteLine("You've unlocked the Door!");
        CurrentRoom.Exits.Add("east", Locked1);
        GetUserInput();
        CurrentPlayer.Inventory.Remove(item);
      }
      else if (CurrentRoom.Name == "The Cellar" && CurrentPlayer.Inventory[0].Name == "Sword")
      {
        Console.WriteLine("You Killed the Giant Rat! A shiny key appears");
        CurrentPlayer.Inventory.Remove(item);
        GetUserInput();
      }
      else if (CurrentRoom.Name == "The Grand Foyer" && CurrentPlayer.Inventory[0].Name == "Key")
      {
        Console.WriteLine("You've unlocked the Door!");
        CurrentRoom.Exits.Add("south", Locked2);
        CurrentPlayer.Inventory.Remove(item);
      }
      // else if (CurrentRoom.Name == "The Library" && i.Name == "Lever1")
    }

    public void Inventory()
    {
      if (CurrentPlayer.Inventory.Count > 0)
      {

        CurrentPlayer.Inventory.ForEach(i =>
       {
         Console.WriteLine(i.Name);
         Console.WriteLine(i.Description);
         Console.WriteLine(Environment.NewLine);
       });
      }
      else
      {
        System.Console.WriteLine("No items in Inventory");
      }
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