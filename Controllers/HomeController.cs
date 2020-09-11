using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using test_mvc.Models;
using test_mvc.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace test_mvc.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IOptions<AppSetting> _options;

    public HomeController(ILogger<HomeController> logger, IOptions<AppSetting> options)
    {
      _logger = logger;
      _options = options;
    }

    public string Index()
    {
      _logger.LogInformation("Lorem ipsum dolor sit amet, consectetur adipisicing elit. Explicabo eos cumque sint maxime voluptate perspiciatis libero provident harum quia at ipsum commodi, nesciunt reiciendis quisquam unde eum. \nNihil eveniet voluptatum iste quibusdam at itaque, laborum natus, beatae perferendis debitis illo, ipsum nisi. \nRerum eveniet magnam harum! Voluptatibus quos fugiat blanditiis voluptates, totam reprehenderit delectus recusandae, a ipsam ad cumque temporibus veritatis non, dolorem accusantium mollitia beatae ipsum placeat expedita modi rem inventore officia!\nEius libero culpa nulla ea esse accusantium dicta, error possimus illo earum ipsum quisquam inventore sit ipsam repellendus.Enim, quos hic commodi officiis ipsa quisquam consectetur earum.");
      return "Version is " + GetType().Assembly.GetName().Version.ToString();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
