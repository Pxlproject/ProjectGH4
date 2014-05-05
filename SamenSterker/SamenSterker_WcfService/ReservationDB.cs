using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    public static class ReservationDB
    {
        public static List<Reservation> GetReservationList()
        {
            List<Reservation> reservationList = new List<Reservation>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT Id, Number, StartDate, EndDate, CompanyId, LocationId, CreateDate " +
                                     "FROM reservation ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reserv = new Reservation();
                    reserv.id = (int)reader["Id"];
                    reserv.number = (int)reader["Number"];
                    reserv.startDate = (DateTime)reader["StartDate"];
                    reserv.endDate = (DateTime)reader["EndDate"];
                    reserv.companyId = (int)reader["CompanyId"];
                    reserv.locationId = (int)reader["LocationId"];
                    reserv.createDate = (DateTime)reader["CreateDate"];

                    reservationList.Add(reserv);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ReservationDB", ex.Message);
                throw ex;
            }
            finally
            {
                /// connectie sluiten
                conn.Close();
            }
            return reservationList;
        }
    }
}