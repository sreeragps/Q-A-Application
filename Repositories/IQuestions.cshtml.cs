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
    public interface IQuestionsRepository  
    {         
      void Add(Stack stack);  
      List<Stack> List();  
    } 

    public class QuestionsRepository :IQuestionsRepository 
    {
      
        public void Add(Stack stackobj)
        {
            string question=stackobj.StackQuestion;
            string details=stackobj.StackAnswer;
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True");
            string sqlins = @"insert into stack(StackQuestion,StackAnswer)values(@question, @details)";
            SqlCommand cmdnon = new SqlCommand(sqlins, connection);

            cmdnon.Parameters.Add("@question", SqlDbType.NVarChar, 100);
            cmdnon.Parameters.Add("@details", SqlDbType.NVarChar, 500);
            connection.Open();
            cmdnon.Parameters["@question"].Value =question;
            cmdnon.Parameters["@details"].Value = details;
            cmdnon.ExecuteNonQuery();
            connection.Close();

        }
          
        public  List<Stack> QuestionList = new List<Stack>();
        public List<Stack> List()
         {
            
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM stack", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               QuestionList.Add(new Stack(reader.GetString(1), reader.GetString(2)));
            }
            connection.Close();
            return QuestionList;


         }
    }
   
}