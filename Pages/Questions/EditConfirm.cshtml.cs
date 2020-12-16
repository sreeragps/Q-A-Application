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
using Microsoft.Extensions.Configuration;

namespace StackOverFlowProject.Pages
{
    public class EditConfirmModel : PageModel
    {
        public List<Stack> StackList = new List<Stack>();
        public void OnGet(int stackId)
        {
            QuestionsRepository questionRepository = new QuestionsRepository();
            StackList = questionRepository.Read(stackId);
        }
        public IActionResult OnPost(Stack stackObject)
        {
            QuestionsRepository questionRepository = new QuestionsRepository();
            questionRepository.Edit(stackObject);
            return Redirect("~/Questions/EditDelete");
        }
    }
}