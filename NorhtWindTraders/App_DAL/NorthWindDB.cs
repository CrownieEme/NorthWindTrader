using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class NorthWindDB
    {
        private string s_SQLConnection;

        public NorthWindDB()
        {
            //Default Constructor
        }

        public NorthWindDB(string con)
        {
            s_SQLConnection = con; // ConfigurationManager.ConnectionStrings["NorthwindCon"].ConnectionString;
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
        public DataSet GetDataSetFromSQL(string SqlStr)
        {
            SqlDataAdapter sqlDataAdapter;
            SqlCommand sqlCommand = new SqlCommand();

            SqlParameter sqlParameter = new SqlParameter();

            DataSet ds = new DataSet();

            SqlConnection sqlConnection = new SqlConnection(s_SQLConnection);
            string sMessageOut = "OK";

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                sqlCommand.CommandText = SqlStr;


                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
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
            return ds;
        }

        /// <summary>
        /// Retrieves a specified dataset from a Stored Procedure using a parameter list
        /// </summary>
        /// <param name="p">Parameter List</param>
        /// <param name="sp">Stored Procedure name</param>
        /// <returns></returns>
        public DataSet GetDataSet(List<SqlParameter> p, String sp)
        {
            SqlDataAdapter d = default(SqlDataAdapter);
            SqlCommand com = new SqlCommand();
            SqlParameter para = default(SqlParameter);
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            int count = p.Count;
            int i = 0;
            string msgOut = "OK";
            string sqlConn = "";

            if (count > 0)
            {
                for (i = 0; i <= count - 1; i++)
                {
                    para = new SqlParameter();
                    para = p[i];
                    com.Parameters.Add(para);
                }
            }

            try
            {
                con.ConnectionString = sqlConn;

                // Check connection state
                if (con.State == ConnectionState.Closed)
                    con.Open();

                // set command attributes
                com.CommandText = sp;
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con;

                //prepare the query
                com.Prepare();

                // set data adapter and fill dataset
                d = new SqlDataAdapter(com);
                d.Fill(ds);
            }
            catch (Exception E) { msgOut = E.Message; }
            finally
            {
                // Check connection state
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return ds;
        }

        public DataTable GetDataSet(string sp)
        {
            SqlDataAdapter d = default(SqlDataAdapter);
            SqlCommand com = new SqlCommand();

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
          
            string msgOut = "OK";
            string sqlConn = ""; 

            try
            {
                con.ConnectionString = sqlConn;

                // Check connection state
                if (con.State == ConnectionState.Closed)
                    con.Open();

                // set command attributes
                com.CommandText = sp;
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con;

                //prepare the query
                com.Prepare();

                // set data adapter and fill dataset
                d = new SqlDataAdapter(com);
                d.Fill(dt);
            }
            catch (Exception E) { msgOut = E.Message; }
            finally
            {
                // Check connection state
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return dt;
        }
    }
}