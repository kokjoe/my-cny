using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public class CurrentMRN
    {
        [Key]
        public int RunningId { get; set; }
        public int RunningNum { get; set; }
        [StringLength(20)]
        public string Prefix { get; set; }
        
    }
}