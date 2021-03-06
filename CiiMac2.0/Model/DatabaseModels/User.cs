﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.DatabaseModels
{

    [Table("User")]
    public class User
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set;  }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int Level { get; set; }

        public long CustomerNumber { get; set; }
        [ForeignKey("CustomerNumber")]
        public Company Company { get; set; }

        public byte[] CompletePassword { private get; set; }

        public byte[] PasswordSalt { private get; set; }

    }
}
