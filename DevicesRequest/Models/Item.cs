namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            RequestItems = new HashSet<RequestItem>();
            Shipments = new HashSet<Shipment>();
        }

        public int ItemId { get; set; }

        [StringLength(100)]
        [Display(Name = "NameEn")]
        public string NameEn { get; set; }

        [StringLength(100)]
        [Display(Name ="Name Ar")]
        public string NameAr { get; set; }

        [StringLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name ="Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name ="Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        public bool? Active { get; set; }

        [Display(Name = "Units In Stock")]
        public int? UnitsInStock { get; set; }

        [Display(Name = "Units On Order")]
        public int? UnitsOnOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestItem> RequestItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}