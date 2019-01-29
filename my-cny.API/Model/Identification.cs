using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public class Identification
    {
        [Key]
        public int IdentificationId { get; set;}
        [StringLength(50)]
        public string IdentificationName { get; set; }
    }
}