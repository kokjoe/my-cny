using System;
using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }
        [StringLength(20)]
        public string RelationshipName { get; set; }
        public int Version { get; set; }
        public bool IsAudit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
    }
}