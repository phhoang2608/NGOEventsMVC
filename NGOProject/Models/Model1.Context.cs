﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NGOEventsEntities : DbContext
    {
        public NGOEventsEntities()
            : base("name=NGOEventsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<eventsTable> eventsTables { get; set; }
    }
}
