using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphCocoApp
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string SoldToId { get; set; }
        public string TerritoryId { get; set; }
    }
}
