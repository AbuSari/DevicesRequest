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
            Reports = new HashSet<Report>();
        }

        [Key]
        public int RequestItemId { get; set; }

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
        public virtual RequestStatu RequestStatu { get; set; }


        [Display(Name = "Type Of Reques")]
        public int? TypeOfRequestId { get; set; }
        public virtual TypeOfRequest TypeOfRequest { get; set; }


        [StringLength(100)]
        [Display(Name = "Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Director Recommondation")]
        public string DirectorRecommondation { get; set; }

        [Display(Name = "Item")]
        public virtual Item Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }



        public virtual User User { get; set; }
    }
}
