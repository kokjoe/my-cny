using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public class EmergencyContact
    {
        [Key]
        public int EmergencyContactId { get; set; }
        [StringLength(20)]
        public string ContactNo { get; set; }
        public Relationship Relationship { get; set; }
        public int RelationshipId { get; set; }
        [StringLength(20)]
        public string IdentificationNo { get; set; }
        public Identification Identification { get; set; }
        public int IdentificationId { get; set; }
    }
}