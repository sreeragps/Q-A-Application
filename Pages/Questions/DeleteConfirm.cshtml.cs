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
    public class DeleteConfirmModel : PageModel
    {
        IQuestionsRepository questionRepository = new QuestionsRepository();

        public List<Stack> stackList = new List<Stack>();
        public void OnGet(int stackId)
        {

            stackList = questionRepository.Read(stackId);
        }

        public IActionResult OnPost(Stack stackObject)
        {
            questionRepository.Remove(stackObject);
            return Redirect("~/Questions/EditDelete");
        }
    }
}