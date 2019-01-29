using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace my_cny.API.Resource
{
    public class PatientResource
    {
        [Key]
        public int PatientId { get; set; }
        [StringLength(20)]
        public string MRN { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int? ZipCode { get; set; }
        [StringLength(20)]
        public string IdentificationNo { get; set; }
        public IdentificationResource IdentificationResource { get; set; }
        public int IdentificationId { get; set; }
        public ICollection<EmergencyContactResource> EmergencyContactsResource { get; set; }
        

        public PatientResource()
        {
            EmergencyContactsResource = new Collection<EmergencyContactResource>();
        }
    }
}