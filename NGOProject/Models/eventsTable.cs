//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NGOProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using NGOProject.SharedClass;

    public partial class eventsTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eventsTable()
        {
            this.tickets = new HashSet<ticket>();
        }
        [Required]
        [Display(Name = "Name of Event ")]
        public string eventDescription { get; set; }
        [Required]
        [Display(Name = "Category of Event ")]
        public string eventCategory { get; set; }
        [Required]
        [Display(Name = "Start Date of Event ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime eventStartDate { get; set; }
        [Required]
        [Display(Name = "End Date of Event ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [EndDate]
        public System.DateTime eventEndDate { get; set; }
        [Required]
        [Display(Name = "Start Time of Event ")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public System.TimeSpan eventStartTime { get; set; }
        [Required]
        [Display(Name = "End Time of Event ")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public System.TimeSpan eventEndTime { get; set; }
        public bool registration { get; set; }
        [Display(Name = "Price for Adult")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public Nullable<decimal> adultPrice { get; set; }
        [Display(Name = "Price for Children")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public Nullable<decimal> childPrice { get; set; }
        public int eventID { get; set; }
        public string image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
