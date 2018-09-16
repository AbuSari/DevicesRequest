namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PoRceived")]
    public partial class PoRceived
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PoRceived()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int PoRceivedId { get; set; }

        [StringLength(100)]
        [Display(Name = "Company Name En")]
        public string CompanyNameEn { get; set; }

        [StringLength(100)]
        [Display(Name = "Company Name Ar")]
        public string CompanyNameAr { get; set; }

        [StringLength(50)]
        [Display(Name = "PoCode")]
        public string PoCode { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
