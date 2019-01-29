using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Resource
{
    public class IdentificationResource
    {
        [Key]
        public int IdentificationId { get; set;}
        [StringLength(50)]
        public string IdentificationName { get; set; }
    }
}