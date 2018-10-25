using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public class ConnectionString
{
    private string _baseDir; 
    private string _dir; 
    private string _stockInfoDB;
    public string StockInfoDB
    {
        get
        {
            setConnectionString();
            return _stockInfoDB;
        }
    }

    private void setConnectionString()
    {
        //_baseDir = Directory.GetCurrentDirectory(); 
        //_dir = System.IO.Path.Combine(_baseDir, @"App_Data\StockInfo.mdf");
        _stockInfoDB = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\KUSTLecture\\SoftwareEngineering\\assignment\\ConsoleApp1\\ConsoleApp1\\App_Data\\StockInfo.mdf;Integrated Security=True;";
    }
}
namespace DBFunction
{
    public class Function
    {
        public static SqlConnection Conn(string DB_Name)
        {
            SqlConnection oConn = new SqlConnection();
            oConn.ConnectionString = DB_Name;
            return oConn;
        }

        public static int IsDataExist(string sSQL, SqlConnection oConn)
        {
            SqlCommand cmd;
            try
            {
                oConn.Open();
                cmd = new SqlCommand(sSQL, oConn);
                if (cmd.ExecuteScalar() != null)
                {
                    return ReturnCode.DataExist;
                }
                else
                {
                    return ReturnCode.DataNotExist;
                }
            }
            catch (SqlException se)
            {
                return ReturnCode.SystemError;
            }
            finally
            {
                oConn.Close();
            }
        }

        public static int DBIDU(string sSQL, SqlConnection conn)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                int n = cmd.ExecuteNonQuery();
                return ReturnCode.Success;
            }
            catch (SqlException ex)
            {
                return ReturnCode.SystemError;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

     
  


 