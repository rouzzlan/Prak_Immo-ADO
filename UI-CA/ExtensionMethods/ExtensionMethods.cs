using BL.Domain;

namespace UI_CA.ExtensionMethods
{
  internal static class ExtensionMethods
  {
    internal static string PrintImmo(this Immo immo)
    {
      string type = "";
      switch (immo.Type)
      {
        case ImmoType.House:
          type = "House";
          break;
        case ImmoType.Appartement:
          type = "Appartment";
          break;
        case ImmoType.Residential:
          type = "Residential";
          break;
      }
      string message = $"({immo.Id}) {type} @ {immo.Zip} BR:{immo.NumberOfBedrooms} G:{immo.Garage} > {immo.Price:0:00}";
      return message;
    }

    internal static string PrintPerson(this Person person)
    {
      string message = $"({person.PersonNumber}) {person.Name} ({person.BirthDate:MM/dd/yyyy})";

      return message;
    }
  }
}
