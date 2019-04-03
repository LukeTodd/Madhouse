using System.Collections.Generic;
using MadHouse.Project.Models;

namespace MadHouse.Project.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
