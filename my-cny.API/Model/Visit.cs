using System;
using System.ComponentModel.DataAnnotations;
using my_cny.API.Controllers.Resource;

namespace my_cny.API.Model
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        [StringLength(20)]
        [Required]
        public string VisitType { get; set; }
        [StringLength(20)]
        [Required]
        public string VisitNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int Version { get; set; }
        public bool IsAudit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }

    }
}