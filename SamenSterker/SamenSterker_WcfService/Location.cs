using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SamenSterker_WcfService
{
    /// <summary>
    /// klasse Location
    /// hierin staan de properties van een Location
    /// </summary>
    [DataContract]
    public class Location
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public String name { get; set; }
    }
}