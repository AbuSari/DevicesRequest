namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdminRole
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdminId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string CreatedDate { get; set; }

        [StringLength(100)]
        public string LastUpdateBy { get; set; }

        [StringLength(100)]
        public string LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Role Role { get; set; }
    }
}
