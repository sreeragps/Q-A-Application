using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;


namespace StackOverFlowProject.Pages
{
    public class AddModel : PageModel
    {
        public void OnPost(string question, string details)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True");
            string sqlins = @"insert into stack(StackQuestion,StackAnswer)values(@question, @details)";
            SqlCommand cmdnon = new SqlCommand(sqlins, connection);

            cmdnon.Parameters.Add("@question", SqlDbType.NVarChar, 100);
            cmdnon.Parameters.Add("@details", SqlDbType.NVarChar, 200);
            connection.Open();
            cmdnon.Parameters["@question"].Value = question;
            cmdnon.Parameters["@details"].Value = details;
            cmdnon.ExecuteNonQuery();
            connection.Close();

        }
    }
}