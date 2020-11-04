using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NorhtWindTraders.App_DAL
{
    public class NorthwindDB
    {
        private string s_SQLConnection;

        public NorthwindDB(string con)
        {
            s_SQLConnection = con; // ConfigurationManager.ConnectionStrings["NorthwindCon"].ConnectionString;
        }

        public DataSet getDataSet(List<SqlParameter> ListSqlParams, string NameSP)
        {

            SqlDataAdapter sqlDataAdapter = default(SqlDataAdapter);
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter sqlParameter =  default(SqlParameter);
            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection();
            int iListCount = ListSqlParams.Count;
            int iCount = 0;
            string sMessageOut = "OK";
            if(iListCount > 0)
            {
                for(iCount = 0; iCount <= iListCount -1 ; iCount++)
                {
                    sqlParameter = new  SqlParameter();
                    sqlParameter = ListSqlParams[iCount];
                    sqlCommand.Parameters.Add(sqlParameter);

                }
            }
            try
            {
                sqlConnection.ConnectionString = s_SQLConnection;
                if(sqlConnection.State == ConnectionState.Closed)
                {
                    
                   sqlConnection.Open();
                }
                    sqlCommand.CommandText = NameSP;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(ds);
            }
            catch(Exception E)

            {
                sMessageOut = E.Message;
            }
            finally
            {
                if(sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
            return ds;
        }

        public int execNonQuery(String sqlStr)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameter sqlParameter = new SqlParameter();
            DataSet ds = new DataSet();
            
            SqlConnection sqlConnection = new SqlConnection(s_SQLConnection);
            string sMessageOut = "OK";

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.CommandText = sqlStr;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                sMessageOut = E.Message;
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return 1;
            
        }

        public DataSet GetDataSet(string SqlStr)
        {
            SqlDataAdapter sqlDataAdapter;
            SqlCommand sqlCommand = new SqlCommand();

            SqlParameter sqlParameter = new SqlParameter();

            DataSet ds = new DataSet();

            SqlConnection sqlConnection = new SqlConnection(s_SQLConnection);
            string sMessageOut = "OK";

            try
            {
                if(sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                
                sqlCommand.CommandText = SqlStr;
                

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
            }
            catch(Exception E)
            {
                sMessageOut = E.Message;
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return ds;
        }
    }
}