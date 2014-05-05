using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    public static class ContractDB
    {
        public static List<Contract> GetContractList()
        {
            List<Contract> contractList = new List<Contract>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT Id, Number, StartDate, EndDate, CompanyId, ContractFormulaId " +
                                     "FROM contract ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Contract cont = new Contract();
                    cont.id = (int)reader["Id"];
                    cont.number = (int)reader["Number"];
                    cont.startDate = (DateTime)reader["StartDate"];
                    cont.endDate = (DateTime)reader["EndDate"];
                    cont.companyId = (int)reader["CompanyId"];
                    cont.contractFormulaId = (int)reader["ContractFormulaId"];

                    contractList.Add(cont);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ContractDB", ex.Message);
                throw ex;
            }
            finally
            {
                /// connectie sluiten
                conn.Close();
            }
            return contractList;
        }
    }
}