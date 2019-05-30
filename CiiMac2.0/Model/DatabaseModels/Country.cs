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
    [Table("Country")]
    [DataContract]
    public class Country
    {
        [Key]
        [DataMember]
        public Guid CountryId { get; set; }
        [DataMember]
        public string CountryName { get; set; }

       
    }
}
