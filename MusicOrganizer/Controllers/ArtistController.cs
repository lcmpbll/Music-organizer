using Microsoft.AspNetCore.Mvc;
using MusicCollection.Models;
using System.Collections.Generic;

namespace MusicCollection.Controllers
{
  public class ArtistsController : Controller 
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist seclectedArtist = Artist.Find(id);
      List<Record> artistRecords = seclectedArtist.Records;
      model.Add("artist", seclectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create (int artistId, string recordTitle)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Record newRecord = new Record(recordTitle);
      foundArtist.AddRecord(newRecord);
      List<Record> artistRecord = foundArtist.Records;
      model.Add("records", artistRecord);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}