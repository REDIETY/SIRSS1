//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIRSS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conduct
    {
        public int Id { get; set; }
        public int ConductStatusId { get; set; }
        public System.DateTime Year { get; set; }
        public short Semister { get; set; }
        public int StudentId { get; set; }
    
        public virtual ConductStatus ConductStatus { get; set; }
        public virtual Student Student { get; set; }
    }
}
