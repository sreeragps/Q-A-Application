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
    public class QuestionsRepository : IQuestionsRepository
    {

        public void Add(Stack stackobj)
        {
            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True");
            string sqlins = @"insert into stack(StackQuestion,StackAnswer)values(@StackQuestion, @StackAnswer)";
            SqlCommand cmdnon = new SqlCommand(sqlins, connection);
            cmdnon.Parameters.Add("@StackQuestion", SqlDbType.NVarChar, 100);
            cmdnon.Parameters.Add("@StackAnswer", SqlDbType.NVarChar, 1000);
            connection.Open();
            cmdnon.Parameters["@StackQuestion"].Value = stackobj.StackQuestion;
            cmdnon.Parameters["@StackAnswer"].Value = stackobj.StackAnswer;
            cmdnon.ExecuteNonQuery();
            connection.Close();
        }
        public List<Stack> QuestionList = new List<Stack>();
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