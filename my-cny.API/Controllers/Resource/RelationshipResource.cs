using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Resource
{
    public class RelationshipResource
    {
        [Key]
        public int RelationshipId { get; set; }
        [StringLength(20)]
        public string RelationshipName { get; set; }
    }
}