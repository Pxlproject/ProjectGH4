using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    public static class ReservationDB
    {
        /// <summary>
        /// haalt een lijst met de reservaties op
        /// </summary>
        /// <returns> reservationList (lijst van reservaties) </returns>
        public static List<Reservation> GetReservationList()
        {
            List<Reservation> reservationList = new List<Reservation>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT reservation.Id, reservation.Number, reservation.StartDate, reservation.EndDate, reservation.CompanyId, reservation.LocationId, reservation.CreateDate, location.Name as Name " +
                                     "FROM reservation INNER JOIN location ON reservation.LocationId = location.Id ";
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
                    reserv.locationName = reader["Name"].ToString();

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

        /// <summary>
        /// voegt een nieuwe reservatie toe
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> True of False (naargelang het toevoegen gelukt is) </returns>
        public static Boolean AddReservation(Reservation reserv)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String insertStatement = "INSERT INTO reservation(Number, StartDate, EndDate, LocationId) " +
                                    "VALUES (@number, @startDate, @endDate, @locationId)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, conn);
            insertCommand.Parameters.AddWithValue("@number", reserv.number);
            insertCommand.Parameters.AddWithValue("@startDate", reserv.startDate);
            insertCommand.Parameters.AddWithValue("@endDate", reserv.endDate);
            insertCommand.Parameters.AddWithValue("@locationId", reserv.locationId);
            try
            {
                conn.Open();
                int success;
                success = insertCommand.ExecuteNonQuery();
                if (success == 1)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ReservationDB", ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// past een reservatie aan
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> True of False (naargelang de update gelukt is) </returns>
        public static Boolean UpdateReservation(Reservation old, Reservation updated)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String updateStatement =
                "UPDATE Reservation SET " +
                    "Number = @newNumber, " +
                    "StartDate = @newStartDate, " +
                    "EndDate = @newEndDate, " +
                    "CompanyId = @newCompanyId, " +
                    "LocationId = @newLocationId, " +
                "WHERE " +
                    "Id = @Id ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, conn);
            updateCommand.Parameters.AddWithValue("@newNumber", updated.number);
            updateCommand.Parameters.AddWithValue("@newStartDate", updated.startDate);
            updateCommand.Parameters.AddWithValue("@newEndDate", updated.endDate);
            updateCommand.Parameters.AddWithValue("@newCompanyId", updated.companyId);
            updateCommand.Parameters.AddWithValue("@newLocationId", updated.locationId);

            updateCommand.Parameters.AddWithValue("@Id", old.id);

            try
            {
                conn.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ReservationDB", ex.Message);
                throw ex;

            }
        }

        /// <summary>
        /// verwijdert een reservatie
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> True of False (naargelang het verwijderen gelukt is) </returns>
        public static Boolean DeleteReservation(Reservation reserv)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String deleteStatement =
                "DELETE FROM reservation " +
                "WHERE Id = @Id ";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@Id", reserv.id);

            try
            {
                conn.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ReservationDB", ex.Message);
                throw ex;

            }
        }
    }
}