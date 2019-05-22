using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   
    [Table("Company")]
    [DataContract]
    public class Company
    {

        [Key]
        [DataMember]
        [JsonProperty(PropertyName = "customerNumber")] 
        public string Id { get; set; }
        
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "corporateIdentificationNumber")]
        public string Cvr { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        public Guid LoginId { get; set; }
        [ForeignKey("LoginId")]

        public Login Login { get; set; }


    }
}
