namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechnicianReport")]
    public partial class TechnicianReport
    {
        [Key]
        public int ReportId { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [StringLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        [Display(Name = "Report")]
        public int? ReportItem { get; set; }

        [Display(Name = "User")]
        public int? UserId { get; set; }

        public virtual RequestItem RequestItem { get; set; }
    }
}
