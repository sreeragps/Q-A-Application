using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using StackOverFlowProject.Models;
using Microsoft.Extensions.Configuration;

namespace StackOverFlowProject.Pages
{
    public class ListModel : PageModel
    {
        public List<Stack> QuestionList1 = new List<Stack>();
        public void OnGet()
        {
            QuestionsRepository questionrepository = new QuestionsRepository();
            QuestionList1 = questionrepository.List();
        }
    }
}