﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiharITI.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kernels1_itiEntities : DbContext
    {
        public kernels1_itiEntities()
            : base("name=kernels1_itiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public virtual DbSet<GP> GPS { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<SmartElectricityMeter> SmartElectricityMeters { get; set; }
        public virtual DbSet<SmartEnergy> SmartEnergies { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }
        public virtual DbSet<Temperature_ITI> Temperature_ITI { get; set; }
        public virtual DbSet<VehicleTracking> VehicleTrackings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}