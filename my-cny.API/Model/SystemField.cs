using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Model
{
    public abstract class SystemField
    {
        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}