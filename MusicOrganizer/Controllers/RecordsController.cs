using Microsoft.AspNetCore.Mvc;
using MusicCollection.Models;

namespace MusicCollection.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/artists/{artistId}/records/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Record.ClearAll();
      return View();
    }

    [HttpGet("/artists/{artistId}/records/{itemId}")]
    public ActionResult Show(int artistId, int recordId)
    {
      Record record = Record.Find(recordId);
      Artist artist = Artist.Find(artistId);
      Dictionary <string, object> model = new Dictionary <string, object>();
      model.Add("record", record);
      model.Add("artist", artist);
      return View(model);
    }
  }
}