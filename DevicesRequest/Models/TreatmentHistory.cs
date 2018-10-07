using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevicesRequest.Models
{
    public class TreatmentHistory
    {

        [Key]
        public int TreatmentHistoryId { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }


        [Display(Name = "Stutus")]
        public int StutusId { get; set; }
        public virtual RequestStatu RequestStatu { get; set; }


        [Display(Name = "Request")]
        public int RequestId { get; set; }
        public virtual RequestItem RequestItem { get; set; }


        [StringLength(100)]
        [Display(Name = "Last Update By")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime? LastUpdateDate { get; set; }

    }
}