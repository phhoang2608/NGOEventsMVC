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

    public partial class ticket
    {
        [Display(Name = "Buyer Phone Number ")]
        public string buyerPhone { get; set; }
        [Display(Name = "Address Phone Number ")]
        public string buyerAddress { get; set; }
        [Display(Name = "Total Number of Adult ")]
        public int totalAdult { get; set; }
        [Display(Name = "Total Number of Children ")]
        public int totalChildren { get; set; }
        public int ticketID { get; set; }
        public int userID { get; set; }
        public int eventID { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
    
        public virtual user user { get; set; }
        public virtual eventsTable eventsTable { get; set; }
    }
}