using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    public static class ContractFormulaDB
    {
        public static List<ContractFormula> GetContractFormulaList()
        {
            List<ContractFormula> contractFormulaList = new List<ContractFormula>();
            SqlConnection conn = new SqlConnection(SamenSterkerDB.GetConnection());
            string selectStatement = "SELECT Id, Description, MaxUsageHoursPerPeriod, PeriodInMonths, NoticePeriodInMonths, Price " +
                                     "FROM contractFormula ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    ContractFormula contrForm = new ContractFormula();
                    contrForm.id = (int)reader["Id"];
                    contrForm.description = reader["Description"].ToString();
                    contrForm.maxUsageHoursPerPeriod = (int)reader["MaxUsageHoursPerPeriod"];
                    contrForm.periodInMonths = (int)reader["PeriodInMonths"];
                    contrForm.noticePeriodInMonths = (int)reader["NoticePeriodInMonths"];
                    contrForm.price = (double)reader["Price"];

                    contractFormulaList.Add(contrForm);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Logging logger = new Logging("log.txt");
                logger.WriteLine("ContractFormulaDB", ex.Message);
                throw ex;
            }
            finally
            {
                /// connectie sluiten
                conn.Close();
            }
            return contractFormulaList;
        }
    }
}