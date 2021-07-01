using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTransaction.Database
{
    public class People
    {
        [Key]
        public string PersonId { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
