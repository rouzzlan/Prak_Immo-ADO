using System;
using BL;
using UI_CA.ExtensionMethods;

namespace UI_CA
{
  class Program
  {
    private static readonly IImmoManager ImmoManager = new ImmoManager();
    private static bool _verdergaan = true;
    static void Main()
    {
      while (_verdergaan)
      {
        ShowMenu();
      }
    }
    public static void ShowMenu()
    {
      var message = "===========================================\n";
      message += "===== Contacten Administratie Systeem =====\n";
      message += "===========================================\n";
      message += "1) Toon alle personen\n";
      message += "2) Toon alle eigendommen\n";
      message += "3) Toon alle eigendommen die nog niet verkocht zijn\n";
      message += "4) Toon alle eigendommen van een bepaald type\n";
      message += "0) verlaat het systeem";
      Console.WriteLine(message);
      DetectUserAction();

    }

    private static void DetectUserAction()
    {
      string input = Console.ReadLine();
      int keuze;
      if (Int32.TryParse(input, out keuze))
      {
        switch (keuze)
        {
          case 1:
            PrintAllPersons();
            break;
          case 2:
            PrintAllImmos();
            break;
          case 3:
            PrintAllSoldImmos();
            break;
          case 4:
            PrintImmosByType();
            break;
          case 0:
            _verdergaan = false;
            break;
        }
      }
    }

    private static void PrintImmosByType()
    {
      BL.Domain.ImmoType type = immoKeuze();
      foreach(var immo in ImmoManager.GetImmosByType(type))
      {
        Console.WriteLine(immo.PrintImmo());
      }
    }
    private static BL.Domain.ImmoType immoKeuze()
    {
      string menu = "Maak keuze uit volgende immo types:\n1) House\n2) Appartement\n3) Residential";
      Console.WriteLine(menu);
      string input = Console.ReadLine();
      int keuze;
      if (Int32.TryParse(input, out keuze))
      {
        if (keuze == 1)
          return BL.Domain.ImmoType.House;
        else if (keuze == 2)
          return BL.Domain.ImmoType.Appartement;
        else if (keuze == 3)
          return BL.Domain.ImmoType.Residential;
        else
          throw new InvalidOperationException();
      }
      throw new InvalidOperationException();
    }

    private static void PrintAllPersons()
    {
      foreach (var person in ImmoManager.GetPersons())
      {
        Console.WriteLine(person.PrintPerson());
      }
    }

    private static void PrintAllImmos()
    {
      foreach (var immo in ImmoManager.GetImmos(true))
      {
        Console.WriteLine(immo.PrintImmo());
      }
      
    }

    private static void PrintAllSoldImmos()
    {
      foreach (var immo in ImmoManager.GetImmos(false))
      {
        Console.WriteLine(immo.PrintImmo());
      }
    }
  }
}
