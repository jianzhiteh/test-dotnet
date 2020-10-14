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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace test_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSetting> _options;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSetting> options, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _options = options;
            _hostingEnvironment = hostingEnvironment;

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index2(string hello)
        {
            string projectRootPath = _hostingEnvironment.ContentRootPath;

            var path = Path.Join(projectRootPath, "logs", "log20201014.txt");

            using (TextWriter tw = new StreamWriter(path,true))
            {
                tw.WriteLine(hello);
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
