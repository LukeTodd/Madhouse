using System.Collections.Generic;
using MadHouse.Project.Interfaces;

namespace MadHouse.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Desription { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }


    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();

    }

  }
}