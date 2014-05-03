using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse SamenSterkerDB
    /// hierin wordt de methode GetConnection() gemaakt
    /// </summary>
    public static class SamenSterkerDB
    {
        /// <summary>
        /// GetConnection
        /// zorgt voor de connectie met de database
        /// </summary>
        /// <returns> ConnectionString </returns>
        public static string GetConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["SamenSterker_Conn"].ConnectionString;
        }
    }
}