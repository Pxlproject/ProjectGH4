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
    }
}