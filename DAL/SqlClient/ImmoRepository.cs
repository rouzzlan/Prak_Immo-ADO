using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using BL.Domain;

namespace DAL
{
  public delegate IEnumerable<Immo> _readImmos(bool sold); 
  public class ImmoRepository : IImmoRepository
  {
    public IEnumerable<Person> ReadPersons()
    {
      List<Person> persons = new List<Person>();
      string querry = "SELECT PersonNumber, Name, BirthDate, Email FROM Person";
      using (SqlConnection connection = GetConnection())
      {
        SqlCommand command = new SqlCommand(querry, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          Person person = new Person();
          int indexPersonNumber = reader.GetOrdinal("PersonNumber");
          int indexName = reader.GetOrdinal("Name");
          int indexBirthDate = reader.GetOrdinal("BirthDate");
          int indexEmail = reader.GetOrdinal("Email");

          person.PersonNumber = reader.GetInt32(indexPersonNumber);
          person.Name = reader.GetString(indexName);
          person.Email = reader.IsDBNull(indexEmail) ? null : reader.GetString(indexEmail);
          person.BirthDate = reader.IsDBNull(indexBirthDate) ? (DateTime?) null : reader.GetDateTime(indexBirthDate);
          persons.Add(person);
        }
        reader.Close();
        connection.Close();
      }
      return persons;
    }

    public IEnumerable<Immo> ReadImmosBySold(bool sold)
    {
      return ReadImmos(false);
    }


    
    public IEnumerable<Immo> ReadImmos(bool sold)
    {
      List<Immo> immos = new List<Immo>();
      string querry = "SELECT i.Id, i.Type, i.ZipCode, i.NumberOfBedrooms, i.Garage, i.Price, i.Sold, p.PersonNumber, p.Name, p.BirthDate, p.Email FROM Immo i INNER JOIN Person p ON i.OwnerId = PersonNumber";
      if (!sold)
      {
        querry += " WHERE Sold=0";
      }
      using (SqlConnection connection = GetConnection())
      {
        SqlCommand command = new SqlCommand(querry, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {

          int indexOfColumnId = reader.GetOrdinal("Id");
          int indexOfColumnType = reader.GetOrdinal("Type");
          int indexOfColumnZipCode = reader.GetOrdinal("ZipCode");
          int indexOfColumnNumberOfBedrooms = reader.GetOrdinal("NumberOfBedrooms");
          int indexOfColumnGarage = reader.GetOrdinal("Garage");
          int indexOfColumnPrice = reader.GetOrdinal("Price");
          int indexOfColumnSold = reader.GetOrdinal("Sold");
          int indexOfColumnPersonNumber = reader.GetOrdinal("PersonNumber");
          int indexOfColumnName = reader.GetOrdinal("Name");
          int indexOfColumnBirthDate = reader.GetOrdinal("BirthDate");
          int indexOfColumnEmail = reader.GetOrdinal("Email");

          Immo immo = new Immo();
          immo.Id = reader.GetInt32(indexOfColumnId);
          immo.Garage = reader.GetBoolean(indexOfColumnGarage);
          immo.NumberOfBedrooms = reader.IsDBNull(indexOfColumnNumberOfBedrooms) ? null : (byte?)reader.GetByte(indexOfColumnNumberOfBedrooms);
          immo.Price = reader.IsDBNull(indexOfColumnPrice) ? (decimal?) null : reader.GetDecimal(indexOfColumnPrice);
          immo.Sold = reader.GetBoolean(indexOfColumnSold);
          immo.Zip = reader.GetInt16(indexOfColumnZipCode);
          byte type = reader.GetByte(indexOfColumnType);
          immo.Type = (ImmoType)type;

          Person person = new Person();
          person.PersonNumber = reader.GetInt32(indexOfColumnPersonNumber);
          person.Name = reader.GetString(indexOfColumnName);
          person.Email = reader.IsDBNull(indexOfColumnEmail) ? null : reader.GetString(indexOfColumnEmail);
          person.BirthDate = reader.IsDBNull(indexOfColumnBirthDate) ? (DateTime?)null : reader.GetDateTime(indexOfColumnBirthDate);
          immo.Owner = person;
          immos.Add(immo);
        }
        reader.Close();
        connection.Close();
      }
      return immos;
    }


    private SqlConnection GetConnection()
    {
      var connStr = ConfigurationManager.ConnectionStrings["ImmoDB-ADO"].ConnectionString;
      //add reference niet vergeten
      return new SqlConnection(connStr);
    }

    public IEnumerable<Immo> ReadImmosByType(ImmoType _type)
    {
      List<Immo> immos = new List<Immo>();
      string querry = string.Format("SELECT i.Id, i.Type, i.ZipCode, i.NumberOfBedrooms, i.Garage, i.Price, i.Sold, p.PersonNumber, p.Name, p.BirthDate, p.Email FROM Immo i INNER JOIN Person p ON i.OwnerId = PersonNumber WHERE Type={0}", (byte)_type);
      using (SqlConnection connection = GetConnection())
      {
        SqlCommand command = new SqlCommand(querry, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {

          int indexOfColumnId = reader.GetOrdinal("Id");
          int indexOfColumnType = reader.GetOrdinal("Type");
          int indexOfColumnZipCode = reader.GetOrdinal("ZipCode");
          int indexOfColumnNumberOfBedrooms = reader.GetOrdinal("NumberOfBedrooms");
          int indexOfColumnGarage = reader.GetOrdinal("Garage");
          int indexOfColumnPrice = reader.GetOrdinal("Price");
          int indexOfColumnSold = reader.GetOrdinal("Sold");
          int indexOfColumnPersonNumber = reader.GetOrdinal("PersonNumber");
          int indexOfColumnName = reader.GetOrdinal("Name");
          int indexOfColumnBirthDate = reader.GetOrdinal("BirthDate");
          int indexOfColumnEmail = reader.GetOrdinal("Email");

          Immo immo = new Immo();
          immo.Id = reader.GetInt32(indexOfColumnId);
          immo.Garage = reader.GetBoolean(indexOfColumnGarage);
          immo.NumberOfBedrooms = reader.IsDBNull(indexOfColumnNumberOfBedrooms) ? null : (byte?)reader.GetByte(indexOfColumnNumberOfBedrooms);
          immo.Price = reader.IsDBNull(indexOfColumnPrice) ? (decimal?)null : reader.GetDecimal(indexOfColumnPrice);
          immo.Sold = reader.GetBoolean(indexOfColumnSold);
          immo.Zip = reader.GetInt16(indexOfColumnZipCode);
          byte type = reader.GetByte(indexOfColumnType);
          immo.Type = (ImmoType)type;

          Person person = new Person();
          person.PersonNumber = reader.GetInt32(indexOfColumnPersonNumber);
          person.Name = reader.GetString(indexOfColumnName);
          person.Email = reader.IsDBNull(indexOfColumnEmail) ? null : reader.GetString(indexOfColumnEmail);
          person.BirthDate = reader.IsDBNull(indexOfColumnBirthDate) ? (DateTime?)null : reader.GetDateTime(indexOfColumnBirthDate);
          immo.Owner = person;
          immos.Add(immo);
        }
        reader.Close();
        connection.Close();
      }
      return immos;

    }
  }
}
