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
        public string CompanyNameEn { get; set; }

        [StringLength(100)]
        public string CompanyNameAr { get; set; }

        [StringLength(50)]
        public string PoCode { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string LastUpdateBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
