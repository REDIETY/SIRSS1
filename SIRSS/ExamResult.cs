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
    
    public partial class ExamResult
    {
        public int Id { get; set; }
        public System.DateTime Year { get; set; }
        public short Semister { get; set; }
        public int SubjectId { get; set; }
        public int ResultTypeId { get; set; }
        public int Value { get; set; }
        public int Result { get; set; }
    
        public virtual ResultType ResultType { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
