namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipment")]
    public partial class Shipment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "PoRceived")]
        public int PoRceivedId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        [StringLength(100)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        public virtual Item Item { get; set; }

        public virtual PoRceived PoRceived { get; set; }
    }
}
