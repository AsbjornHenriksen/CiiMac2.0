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
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string CVR { get; set; }

        [DataMember]
        public string ContactPerson { get; set; }

        [DataMember]
        public List<Address> Addresses { get; set; }




        public Guid LoginId { get; set; }
        [ForeignKey("LoginId")]

        public Login Login { get; set; }


    }
}
