//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SmartElectricityMeter
    {
        public int id { get; set; }
        public Nullable<int> Voltage { get; set; }
        public Nullable<int> CurrentValue { get; set; }
        public Nullable<int> Units { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public string DeviceTime { get; set; }
        public Nullable<int> deviceid { get; set; }
    }
}
