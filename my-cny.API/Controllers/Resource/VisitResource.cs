using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using my_cny.API.Model;

namespace my_cny.API.Controllers.Resource
{
    public class VisitResource
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
        public PatientNameResource Patient { get; set; }
    }
}