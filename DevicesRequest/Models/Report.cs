namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int ReportId { get; set; }

        public string Details { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string LastUpdateBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        public int? ItemId { get; set; }

        public int? UserId { get; set; }

        public virtual RequestItem RequestItem { get; set; }
    }
}
