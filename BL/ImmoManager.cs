using System;
using System.Collections.Generic;
using BL.Domain;
using DAL;

namespace BL
{
  public class ImmoManager : IImmoManager
  {
    private ImmoRepository _repsitory = new ImmoRepository();

    public IEnumerable<Person> GetPersons()
    {
      return _repsitory.ReadPersons();
    }

    public IEnumerable<Immo> GetImmos(bool sold)
    {
      return _repsitory.ReadImmos(sold);
    }

    public IEnumerable<Immo> GetImmosBySold()
    {
      return _repsitory.ReadImmosBySold(true);
    }
    public IEnumerable<Immo> GetImmosByType(ImmoType type)
    {
      return _repsitory.ReadImmosByType(type);
    }
  }
}
