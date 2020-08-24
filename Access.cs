using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphCocoApp
{
    public class Access
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AppId { get; set; }
        public string BuId { get; set; }
        public string CustomerID { get; set; }
        public string RoleId { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
