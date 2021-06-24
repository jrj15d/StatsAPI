using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public static List<PlayerDTO> Players { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var handler = new WebRequestHandler();
            var str = handler.Get("http://localhost:51647/api/players/active").Result;
            Players = JsonConvert.DeserializeObject<List<PlayerDTO>>(str);
        }

        public void OnGet()
        {
        }
    }
}
