using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphCocoApp
{
    public class Role
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string BuId { get; set; }
            public string CustomerID { get; set; }
            public int RoleId { get; set; }

    }
}
