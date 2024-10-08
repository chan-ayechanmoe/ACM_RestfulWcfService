using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ACM_RestfulWcfService
{
    public class CommonFunction
    {
        public string strConn = ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString.ToString();

        #region "Execute Query"
        private SqlConnection GetConnectionString()
        {

            SqlConnection sqlconn;

            sqlconn = new SqlConnection(strConn);

            if (sqlconn.State == ConnectionState.Open)
                sqlconn.Close();
            try
            {
                sqlconn.Open();
            }
            catch (Exception ex)
            {
                //WriteServiceLog(ex.Message.ToString(), "Y", "DB Connection Error");
            }
            return sqlconn;
        }

        public DataTable RunQuery(string strQuery)
        {
            try
            {
                using (var myConn = GetConnectionString())
                {
                    SqlCommand MyCommand = new SqlCommand(strQuery, myConn);
                    MyCommand.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable mytable = new DataTable();
                    da.SelectCommand = MyCommand;
                    da.SelectCommand.CommandTimeout = 0;//0
                    da.Fill(mytable);
                    myConn.Close();
                    return mytable;

                }
            }
            catch (Exception ex)
            {
                //WriteServiceLog(ex.Message.ToString(), "Y", "DB Connection Error");
                return new DataTable();
            }


        }

        public String RunQuery_NoResult(string strQuery)
        {
            int result = 0;

            try
            {
                using (var myConn = GetConnectionString())
                {
                    SqlCommand MyCommand = new SqlCommand(strQuery, myConn);
                    MyCommand.CommandType = CommandType.Text;
                    MyCommand.CommandTimeout = 0;//0
                    result = Convert.ToInt32(MyCommand.ExecuteNonQuery());
                    myConn.Close();
                    return "";

                }
            }
            catch (Exception ex)
            {
                //WriteServiceLog(ex.Message.ToString(), "Y", "DB Connection Error");
                return ex.Message;
            }

        }
        #endregion

    }
}