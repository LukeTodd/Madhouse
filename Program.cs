﻿using System;
using MadHouse.Project;
using MadHouse.Project.Models;

namespace MadHouse
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      System.Console.WriteLine(Environment.NewLine);
      System.Console.WriteLine(@"
 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.   
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |  
| | ____    ____ | || |      __      | || |  ________    | || |  ____  ____  | || |     ____     | || | _____  _____ | || |    _______   | || |  _________   | |  
| ||_   \  /   _|| || |     /  \     | || | |_   ___ `.  | || | |_   ||   _| | || |   .'    `.   | || ||_   _||_   _|| || |   /  ___  |  | || | |_   ___  |  | |  
| |  |   \/   |  | || |    / /\ \    | || |   | |   `. \ | || |   | |__| |   | || |  /  .--.  \  | || |  | |    | |  | || |  |  (__ \_|  | || |   | |_  \_|  | |  
| |  | |\  /| |  | || |   / ____ \   | || |   | |    | | | || |   |  __  |   | || |  | |    | |  | || |  | '    ' |  | || |   '.___`-.   | || |   |  _|  _   | |  
| | _| |_\/_| |_ | || | _/ /    \ \_ | || |  _| |___.' / | || |  _| |  | |_  | || |  \  `--'  /  | || |   \ `--' /   | || |  |`\____) |  | || |  _| |___/ |  | |  
| ||_____||_____|| || ||____|  |____|| || | |________.'  | || | |____||____| | || |   `.____.'   | || |    `.__.'    | || |  |_______.'  | || | |_________|  | |  
| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |  
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |  
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'   
         .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.  .-----------------.              
        | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |              
        | | ____    ____ | || |      __      | || | ____  _____  | || |    _______   | || |     _____    | || |     ____     | || | ____  _____  | |              
        | ||_   \  /   _|| || |     /  \     | || ||_   \|_   _| | || |   /  ___  |  | || |    |_   _|   | || |   .'    `.   | || ||_   \|_   _| | |              
        | |  |   \/   |  | || |    / /\ \    | || |  |   \ | |   | || |  |  (__ \_|  | || |      | |     | || |  /  .--.  \  | || |  |   \ | |   | |              
        | |  | |\  /| |  | || |   / ____ \   | || |  | |\ \| |   | || |   '.___`-.   | || |      | |     | || |  | |    | |  | || |  | |\ \| |   | |              
        | | _| |_\/_| |_ | || | _/ /    \ \_ | || | _| |_\   |_  | || |  |`\____) |  | || |     _| |_    | || |  \  `--'  /  | || | _| |_\   |_  | |              
        | ||_____||_____|| || ||____|  |____|| || ||_____|\____| | || |  |_______.'  | || |    |_____|   | || |   `.____.'   | || ||_____|\____| | |              
        | |              | || |              | || |              | || |              | || |              | || |              | || |              | |              
        | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |              
         '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'               
");
      System.Console.WriteLine(Environment.NewLine);
      System.Console.WriteLine("WHAT IS YOUR NAME?");
      string playerName = Console.ReadLine();
      Player player = new Player(playerName);
      System.Console.WriteLine($"Hello {playerName}, WOULD YOU LIKE TO PLAY (Y/N)");
      string playerChoice = Console.ReadLine().ToLower();
      GameService gameService = new GameService(player);
      if (playerChoice == "y")
      {
        gameService.Setup();

      }
      else return;
    }
  }
}
