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
        void Add(Stack obj);
        List<Stack> List();
        List<Stack> Read(int StackId);
        void Edit(Stack obj);
        void Remove(Stack obj);

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
        public List<Stack> StackList = new List<Stack>();
        public List<Stack> List()
        {

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM stack", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StackList.Add(new Stack(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            connection.Close();
            return StackList;
        }
        public List<Stack> Read(int StackId)
        {
            string sqlConnectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(sqlConnectString);
            connection.Open();
            string sqlSelect = "SELECT * FROM Stack WHERE StackId=@StackId";
            SqlCommand command = new SqlCommand(sqlSelect, connection);
            command.Parameters.Add("@StackId", SqlDbType.Int);
            command.Parameters["@StackId"].Value = StackId;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StackList.Add(new Stack(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            connection.Close();
            return StackList;
        }
        public void Edit(Stack stackObj)
        {
            string sqlConnectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(sqlConnectString);
            string sqlUpd = @"UPDATE Stack SET StackQuestion=@StackQuestion,StackAnswer=@StackAnswer WHERE StackId=@StackId";
            SqlCommand command = new SqlCommand(sqlUpd, connection);
            command.Parameters.Add("@StackId", SqlDbType.Int);
            command.Parameters.Add("@StackQuestion", SqlDbType.VarChar, 200);
            command.Parameters.Add("@StackAnswer", SqlDbType.VarChar, 1000);
            connection.Open();
            command.Parameters["@StackId"].Value = stackObj.StackId;
            command.Parameters["@StackQuestion"].Value = stackObj.StackQuestion;
            command.Parameters["@StackAnswer"].Value = stackObj.StackAnswer;
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void Remove(Stack stackObj)
        {
            string sqlConnectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StackOverflow;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(sqlConnectString);
            string sqlDel = @"DELETE FROM Stack WHERE StackId=@StackId";
            SqlCommand command = new SqlCommand(sqlDel, connection);
            command.Parameters.Add("@StackId", SqlDbType.Int);
            connection.Open();
            command.Parameters["@StackId"].Value = stackObj.StackId;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}