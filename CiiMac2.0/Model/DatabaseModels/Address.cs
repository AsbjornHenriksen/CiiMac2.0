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
    [Table("Address")]
    [DataContract]
    public class Address
    {
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string StreetName { get; set; }

        [DataMember]
        public int HouseNo { get; set; }

        [DataMember]
        public int Floor { get; set; }

        [DataMember]
        public string Direction { get; set; }

        [DataMember]
        public bool CompanyAddressOrDeliveryAddress { get; set; }

        public Guid CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

    }
}
