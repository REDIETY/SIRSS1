using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace SIRSS.Models
{
    public class Grade
    {
        [HiddenInput]
        public virtual int Id { get; set; }

        public virtual ExamResult ExamResult { get; set; }
        [Required]
        public virtual int ExamResultId { get; set; }

        [DisplayFormat(DataFormatString = "{0:f}", NullDisplayText = "No Grade")]
        [Range(0, 100)]
        [Display(Name = "Grade")]
        public virtual decimal? GradeValue { get; set; }

        //for navigation only
        public virtual SubjectGradesRecord SubjectGradesRecord { get; set; }
        //public virtual int SubjectGradesRecordId { get; set; } //for easy access to SubjectGradesRecord's Id

        [ScaffoldColumn(false)]
        public virtual bool IsDeleted { get; set; }

    }
}