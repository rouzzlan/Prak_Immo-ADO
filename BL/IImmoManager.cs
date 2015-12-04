using System.Collections.Generic;
using BL.Domain;

namespace BL
{
  public interface IImmoManager
  {
    IEnumerable<Person> GetPersons();
    IEnumerable<Immo> GetImmos(bool sold);
    IEnumerable<Immo> GetImmosByType(ImmoType type);
  }
}
