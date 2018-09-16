namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [StringLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Update Date")]
        public string LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
