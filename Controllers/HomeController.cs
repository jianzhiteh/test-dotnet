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
      _logger.LogInformation("Test Information");
      _logger.LogWarning("Test Warning");
      _logger.LogError("Test Error");
      _logger.LogCritical("Test Critical");
      return "Version is " + GetType().Assembly.GetName().Version.ToString();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
