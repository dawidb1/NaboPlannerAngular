using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NaboPlannerAngular.Controllers
{
    [Route("api/[controller]")]
    public partial class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //[HttpGet("[action]")]
        //public IEnumerable<Song> SongList()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new Song
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}
    }
}
