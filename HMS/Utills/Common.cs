using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Data;

namespace HMS.Utills
{
    public class Common
    {
        static string constring = ConfigurationManager.ConnectionStrings["dbHostiptalERPEntities"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
