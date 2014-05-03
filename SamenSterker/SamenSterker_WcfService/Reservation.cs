using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse Reservation
    /// hierin staan de properties van een Reservation
    /// </summary>
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }
        [DataMember]
        public int companyId { get; set; }
        [DataMember]
        public int locationId { get; set; }
        [DataMember]
        public DateTime createDate { get; set; }
    }
}