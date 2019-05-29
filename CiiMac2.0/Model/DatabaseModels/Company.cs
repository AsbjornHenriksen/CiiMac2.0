using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.DatabaseModels
{
   
    
    [DataContract(Name = "Collection")]
    [Table("Company")]
    public class Company
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        [JsonProperty(PropertyName = "customerNumber")]
        public long CustomerNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "corporateIdentificationNumber")]
        public string CorporateIdentificationNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int Level { get; set; }

        public byte[] CompletePassword { get; set; }

        public byte[] PasswordSalt { get; set; }


    }
}
