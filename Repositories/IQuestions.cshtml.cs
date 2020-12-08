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
    public interface IQuestionsRepository  
    {         
      void Add(Questions qns);  
      //void List();  
    } 

    public class QuestionsRepository :IQuestionsRepository 
    {
        public void Add(Questions qns)
        {
            string question=qns.question;
            string details=qns.details;
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
    }
    public class Questions
    {  
        public Questions(){}
        public Questions(string question1,string details1) {

         this.question=question1;
         this.details=details1;
         }
         
        public string question
           {
            get;set;
            }
        
        public string details
           {
            get;set;
            }
        
    }
}