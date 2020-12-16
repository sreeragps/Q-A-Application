using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StackOverFlowProject.Models;
using Microsoft.Extensions.Configuration;

namespace StackOverFlowProject.Pages
{
    public class EditDeleteModel : PageModel
    {
        public List<Stack> questionListNew = new List<Stack>();
        public void OnGet()
        {
            QuestionsRepository questionRepositoryNew = new QuestionsRepository();
            questionListNew = questionRepositoryNew.List();
        }
    }
}