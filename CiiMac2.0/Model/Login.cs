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
    [Table("Login")]
    [DataContract]

    public class Login
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }

        [DataMember]
        public int Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int Level { get; set; }

        public byte[] CompletePassword { private get; set; }

        public byte[] PasswordSalt { private get; set; }
    }
}