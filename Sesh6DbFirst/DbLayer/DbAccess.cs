using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesh6DbFirst.DbLayer
{
    internal class DbAccess
    {

        private SqlConnection sqlCon;

        public List<ConnectionState> TryConnection(string connectionString)
        {
            List<ConnectionState> stateResults = null;
            sqlCon = new(connectionString);
            if(sqlCon != null )
            {
                sqlCon.Open();
                ConnectionState stateFirst = sqlCon.State;
                sqlCon.Close();
                ConnectionState stateSecond = sqlCon.State;
                stateResults = new List<ConnectionState> 
                {
                    stateFirst, stateSecond 
                };

            }
            return stateResults;
        }

    }
}
