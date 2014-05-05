using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    public static class LocationDB
    {
        public static List<Location> GetLocationList()
        {
            List<Location> LocationList = new List<Location>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT Id, Name " +
                                     "FROM location ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Location loc = new Location();
                    loc.id = (int)reader["Id"];
                    loc.name = reader["Name"].ToString();

                    LocationList.Add(loc);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("LocationDB", ex.Message);
                throw ex;
            }
            finally
            {
                /// connectie sluiten
                conn.Close();
            }
            return LocationList;
        }
    }
}