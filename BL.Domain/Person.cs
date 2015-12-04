using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.Domain
{
  public class Person
  {
    [Required]
    public int PersonNumber { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public DateTime ? BirthDate { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public ICollection<Immo> Immos { get; set; }
  }
}
