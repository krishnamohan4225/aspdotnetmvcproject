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
    
    public partial class Temperature_ITI
    {
        public int id { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public string DeviceTime { get; set; }
        public Nullable<int> deviceid { get; set; }
        public string devicename { get; set; }
        public Nullable<decimal> temp { get; set; }
        public Nullable<decimal> faht { get; set; }
    }
}
