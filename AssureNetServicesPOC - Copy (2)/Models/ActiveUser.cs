using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.Models
{
    public partial class ActiveUser
    {
        [Key]
        [Column(Order = 0)]
        public int PKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string FullName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Role_Approver { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool Role_Reviewer { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool Role_Reconciler { get; set; }


        [Key]
        [Column(Order = 8)]
        public bool Role_ProgramAdmin { get; set; }
        
    }
}