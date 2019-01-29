using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Resource
{
    public class EmergencyContactResource
    {
        [Key]
        public int EmergencyContactId { get; set; }
        [StringLength(20)]
        public string ContactNo { get; set; }
        public RelationshipResource RelationshipResource { get; set; }
        public int RelationshipId { get; set; }
        [StringLength(20)]
        public string IdentificationNo { get; set; }
        public IdentificationResource IdentificationResource { get; set; }
        public int IdentificationId { get; set; }
    }
}