using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace StackOverFlowProject.Pages
{
    public class EditDeleteModel:PageModel
    {
        private readonly ILogger<EditDeleteModel> _logger;

        public EditDeleteModel(ILogger<EditDeleteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}