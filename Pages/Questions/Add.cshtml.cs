using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;
using StackOverFlowProject.Models;

namespace StackOverFlowProject.Pages
{
    public class AddModel : PageModel
    {
        public void OnPost(Stack stack)
        {
            QuestionsRepository questionrepository = new QuestionsRepository();
            questionrepository.Add(stack);
        }
    }
}