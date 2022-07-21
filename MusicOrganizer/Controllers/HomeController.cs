using Microsoft.AspNetCore.Mvc;
using MusicCollection.Models;

namespace MusicCollection.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index()
    {
     
      return View();
    }

  }
}