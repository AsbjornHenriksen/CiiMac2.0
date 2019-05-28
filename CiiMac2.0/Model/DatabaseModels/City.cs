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
    [Table("City")]
    [DataContract]
    public class City
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string CityName { get; set; }

        [DataMember]
        public int PostalCode { get; set; }

    }
}
