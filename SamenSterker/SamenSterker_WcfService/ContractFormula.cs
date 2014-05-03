using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse ContractFormula
    /// hierin staan de properties van een ContractFormule
    /// </summary>
    [DataContract]
    public class ContractFormula
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public String description { get; set; }
        [DataMember]
        public int maxUsageHoursPerPeriod { get; set; }
        [DataMember]
        public int periodInMonths { get; set; }
        [DataMember]
        public int noticePeriodInMonths { get; set; }
        [DataMember]
        public double price { get; set; }
    }
}