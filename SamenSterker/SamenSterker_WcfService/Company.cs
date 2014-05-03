using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse Company
    /// hierin staan de properties van een Company
    /// </summary>
    [DataContract]
    public class Company
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String street { get; set; }
        [DataMember]
        public int zipcode { get; set; }
        [DataMember]
        public String city { get; set; }
        [DataMember]
        public String country { get; set; }
        [DataMember]
        public String email { get; set; }
        [DataMember]
        public String phone { get; set; }
    }
}