using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace StackOverFlowProject.Pages
{
    public class IndexModel1 : PageModel
    {
        private readonly ILogger<IndexModel1> _logger;

        public IndexModel1(ILogger<IndexModel1> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}