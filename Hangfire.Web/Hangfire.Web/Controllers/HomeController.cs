using Hangfire.Web.BackgroundJobs;
using Hangfire.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Hangfire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            /*
            |
            |   Fire and forget job is called here
            |
            */

            FireAndForget.Job_SendEmail("1", "Welcome to my application!");

            return View();
        }
    
        public IActionResult ImageSave()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile image)
        {
            if (image != null)
            {
                // init filename & path to save
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);

                // copy image to path
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                /*
                |
                |   Delayed job is called here
                |
                */

                string jobId = Jobs.Delayed.Job_AddWatermark(filename, "your message");
            }

            return View();
        }
    }
}
