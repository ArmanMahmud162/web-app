using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementApp.Gateway
{
    public class BaseGateWay
    {
         public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniConString"].ConnectionString;

         public BaseGateWay()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}