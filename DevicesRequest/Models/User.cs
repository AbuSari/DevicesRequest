namespace DevicesRequest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Departments = new HashSet<Department>();
            RequestItems = new HashSet<RequestItem>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }

        [StringLength(30)]
        [Display(Name = "First Name Ar")]
        public string FirstNameAr { get; set; }

        [StringLength(30)]
        [Display(Name = "Last Name Ar")]
        public string LastNameAr { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "First Name En")]
        public string FirstNameEn { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name En")]
        public string LastNameEn { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Job Number")]
        public string JobNumber { get; set; }

        [Display(Name = "Level")]
        public int? LevelId { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        //[Required]
        [Display(Name = "Position")]
        public int? PositionId { get; set; }

        [StringLength(15)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [StringLength(15)]
        [Display(Name = "Telephon")]
        public string Telephon { get; set; }

        [StringLength(15)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [StringLength(100)]
        [Display(Name = "Cereated By")]
        public string CereatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

        [Display(Name = "Image Job No")]
        public string ImageJobNo { get; set; }

        [StringLength(500)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }

        public virtual Department Department { get; set; }

        public virtual Level Level { get; set; }

        public virtual Position Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestItem> RequestItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentHistory> TreatmentHistories { get; set; }

    }
}
