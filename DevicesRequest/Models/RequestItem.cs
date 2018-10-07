namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestItem()
        {
            TechnicianReports = new HashSet<TechnicianReport>();
        }
        [Key]
        public int RequestItemsId { get; set; }


        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        [Display(Name = "Request Date")]
        public DateTime? RequestDate { get; set; }

        [Display(Name = "Stutus")]
        public int? StutusId { get; set; }

        [Display(Name = "Type Of Request")]
        public int? TypeOfRequestId { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Director Recommondation")]
        [StringLength(500)]
        public string DirectorRecommondation { get; set; }

        public virtual Item Item { get; set; }

        public virtual RequestStatu RequestStatu { get; set; }

        public virtual TypeOfRequest TypeOfRequest { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnicianReport> TechnicianReports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentHistory> TreatmentHistories { get; set; }

    }
}
