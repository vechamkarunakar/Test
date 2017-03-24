namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int PKId { get; set; }

        [Required]
        [StringLength(500)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(15)]
        public string DepartmentID { get; set; }

        [StringLength(15)]
        public string LocationID { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string EmailAddress { get; set; }

        public int? MgrLevel1ID { get; set; }

        public int? MgrLevel2ID { get; set; }

        public int? MgrLevel3ID { get; set; }

        public int? MgrLevel4ID { get; set; }

        public bool Role_Reconciler { get; set; }

        public bool Role_Reviewer { get; set; }

        public bool Role_Approver { get; set; }

        public bool Role_MgrLevel1 { get; set; }

        public bool Role_MgrLevel2 { get; set; }

        public bool Role_MgrLevel3 { get; set; }

        public bool Role_MgrLevel4 { get; set; }

        public bool? Role_QA { get; set; }

        public bool Role_ProgramAdmin { get; set; }

        [StringLength(15)]
        public string ProgramAdminRoleID { get; set; }

        [StringLength(50)]
        public string AuthenticationType { get; set; }

        public bool? Active { get; set; }

        public bool? NewUser { get; set; }

        public int? QADataProfile { get; set; }

        public int? PADataProfile { get; set; }

        public int? UserRights { get; set; }

        [StringLength(500)]
        public string DomainName { get; set; }

        [StringLength(10)]
        public string Language { get; set; }

        public bool Role_Archive { get; set; }

        public int? ArchiveDataProfile { get; set; }

        public bool Role_JEPreparer { get; set; }

        public bool Role_JEApprover { get; set; }

        public bool? GroupUser { get; set; }

        public int? JESecurityGroup { get; set; }

        [StringLength(255)]
        public string LdapGuid { get; set; }

        public int? LoginAttempts { get; set; }

        public bool? ChangePasswordOnLogin { get; set; }
    }
}
