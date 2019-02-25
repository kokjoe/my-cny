using System;
using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public class Identification
    {
        [Key]
        public int IdentificationId { get; set;}
        [StringLength(50)]
        public string IdentificationName { get; set; }
        public int Version { get; set; }
        public bool IsAudit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
    }
}