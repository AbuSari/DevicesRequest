namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int DepartmentId { get; set; }

        [StringLength(100)]
        [Display(Name = "Name En")]
        public string NameEn { get; set; }

        [StringLength(100)]
        [Display(Name = "Name Ar")]
        public string NameAr { get; set; }

        [Display(Name = "Parent")]
        public int? ParentId { get; set; }

        [StringLength(100)]
        [Display(Name = "Director Email")]
        public string DirectorEmail { get; set; }

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

        public bool? Active { get; set; }

        [StringLength(100)]
        [Display(Name = "Director Name")]
        public string DirectorName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
