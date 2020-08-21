using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;
using System.Linq;
using System.Threading.Tasks;

namespace GraphCocoApp
{
    public class ConnectUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DefaultApp { get; set; }
        public virtual  ICollection<Access> Accesses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }

}
