using System.Collection.Generic;

namespace MusicCollection.Models
{
  public class Artist
  {
    private static List<Category> _instances = new List<Category> {};
    public string ArtistName { get; set; }
    public int Id {get; }
    public List<Record> Records { get; set; }

    public Artist(string artistName)
    {
      ArtistName = artistName;
      _instances.Add(this);
      Id = _instances.Count;
      Records = new List<Record>{};
    }

    public static void ClearAll()
    {
      return _instances;
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find (int searchId)
    {
      return _instances[searchId-1];
    }

    public AddRecord(Record record)
    {
      Records.Add(record);
    }

  }
}