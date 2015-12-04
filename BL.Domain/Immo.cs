using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.Domain
{
  public class Immo : IValidatableObject
  {
    public int Id { get; set; }
    public ImmoType Type { get; set; }
    public short Zip { get; set; }
    public byte ? NumberOfBedrooms { get; set; }
    public bool Garage { get; set; }
    public decimal ? Price { get; set; }
    public bool Sold { get; set; }
    public int OwnerId { get; set; }
    public Person Owner { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      List<ValidationResult> resslts = new List<ValidationResult>();
      string message;
      if (Owner==null)
      {
        resslts.Add(new ValidationResult("De eigenaar moet ingevuld zijn"));
      }
      if (!(Zip >= 1000 && Zip <= 9999))
      {
        message = "De zipcode waarde moet tussen 1000 en 9999 liggen";
        resslts.Add(new ValidationResult(message));
      }
      if (Type == ImmoType.Residential && Garage && NumberOfBedrooms > 0)
      {
        message = "Dit type is Residential en kunnen er geen slaapkamers en een garage zijn";
        resslts.Add(new ValidationResult(message));
      }
      return resslts;
    }
  }
}
