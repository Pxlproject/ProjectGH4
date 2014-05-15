using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse CompanyDB
    /// hierin worden de methoden met betrekking tot Company gemaakt
    /// </summary>
    public static class CompanyDB
    {
        /// <summary>
        /// haalt een lijst op met de gegevens van bedrijven
        /// </summary>
        /// <returns> companyList (lijst van bedrijven) </returns>
        public static List<Company> GetCompanyList()
        {
            List<Company> companyList = new List<Company>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT Id, Name, Street, Zipcode, City, Country, Email, Phone " +
                                     "FROM company ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Company comp = new Company();
                    comp.id = (int)reader["Id"];
                    comp.name = reader["Name"].ToString();
                    comp.street = reader["Street"].ToString();
                    comp.zipcode = (int)reader["Zipcode"];
                    comp.city = reader["City"].ToString();
                    comp.country = reader["Country"].ToString();
                    comp.email = reader["Email"].ToString();
                    comp.phone = reader["Phone"].ToString();

                    companyList.Add(comp);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("CompanyDB", ex.Message);
                throw ex;
            }
            finally
            {
                /// connectie sluiten
                conn.Close();
            }
            return companyList;
        }

        /// <summary>
        /// voegt een nieuw bedrijf toe
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> True of False (of het toevoegen al dan niet gelukt is) </returns>
        public static Boolean AddCompany(Company comp)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String insertStatement = "INSERT INTO company(Name, Street, Zipcode, City, Country, Email, Phone) " +
                                    "VALUES (@name, @street, @zipcode, @city, @country, @email, @phone)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, conn);
            insertCommand.Parameters.AddWithValue("@name", comp.name);
            insertCommand.Parameters.AddWithValue("@street", comp.street);
            insertCommand.Parameters.AddWithValue("@zipcode", comp.zipcode);
            insertCommand.Parameters.AddWithValue("@city", comp.city);
            insertCommand.Parameters.AddWithValue("@country", comp.country);
            insertCommand.Parameters.AddWithValue("@email", comp.email);
            insertCommand.Parameters.AddWithValue("@phone", comp.phone);

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
                logger.WriteLine("CompanyDB", ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// past de gegevens van een bedrijf aan 
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> True of False (naargelang de update geslaagd is) </returns>
        public static Boolean UpdateCompany(Company old, Company updated)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String updateStatement =
                "UPDATE Company SET " +
                    "Name = @newName, " +
                    "Street = @newStreet, " +
                    "Zipcode = @newZipcode, " +
                    "City = @newCity, " +
                    "Country = @newCountry, " +
                    "Email = @newEmail, " +
                    "Phone = @newPhone, " +
                "WHERE " +
                    "Id = @Id ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, conn);
            updateCommand.Parameters.AddWithValue("@newName", updated.name);
            updateCommand.Parameters.AddWithValue("@newStreet", updated.street);
            updateCommand.Parameters.AddWithValue("@newZipcode", updated.zipcode);
            updateCommand.Parameters.AddWithValue("@newCity", updated.city);
            updateCommand.Parameters.AddWithValue("@newCountry", updated.country);
            updateCommand.Parameters.AddWithValue("@newEmail", updated.email);
            updateCommand.Parameters.AddWithValue("@newPhone", updated.phone);

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
                logger.WriteLine("CompanyDB", ex.Message);
                throw ex;

            }
        }

        /// <summary>
        /// verwijdert een bedrijf met zijn gegevens
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> True of False (naargelang de update geslaagd is) </returns>
        public static Boolean DeleteCompany(Company comp)
        {
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            String deleteStatement =
                "DELETE FROM company " +
                "WHERE Id = @Id ";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@Id", comp.id);

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
                logger.WriteLine("CompanyDB", ex.Message);
                throw ex;

            }
        }
    }
}