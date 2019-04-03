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
      Room startingRoom = new Room("Great Hall", "This is the Starting Room");
      Room den = new Room("Den", "This is the Den");
      Room ballroom = new Room("Ballroom", "This is the Ballroom");
      Room library = new Room("Library", "This is the Library, many books");
      Room bedroom = new Room("Secret Room", "This looks like an ordinary room, whith a closet");
      Room closet = new Room("Closet", "This is a closet");
      Room cellar = new Room("Cellar", "This is a cellar");
      Room foyer = new Room("Grand Foyer", "This is the grand foyer");
      Room outside = new Room("Outside", "You escape MadHouse Mansion and life a happy fullfilling life");

      Item key = new Item("Brass Key", "This is a brass key");

      startingRoom.Exits.Add("north", den);
      startingRoom.Exits.Add("south", foyer);
      startingRoom.Exits.Add("east", ballroom);
      startingRoom.Exits.Add("west", library);
      den.Exits.Add("south", startingRoom);
      den.Exits.Add("down", cellar);
      ballroom.Exits.Add("west", startingRoom);
      foyer.Exits.Add("north", startingRoom);
      foyer.Exits.Add("south", outside);
      library.Exits.Add("west", startingRoom);
      library.Exits.Add("up", bedroom);
      cellar.Exits.Add("up", den);
      bedroom.Exits.Add("down", library);
      bedroom.Exits.Add("east", closet);
      closet.Exits.Add("west", bedroom);

      closet.Items.Add(key);


    }

    public void Run()
    {

    }


    public GameService(Player newPlayer)
    {
      CurrentPlayer = newPlayer;
      Playing = true;

    }
  }
}