﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SIRSS.Models
{
    public class School
    {
        public virtual int Id { get; set; }

        public virtual string schoolname { get; set; }

        [Required]
        [Display(Name = "From School Year")]
        [Range(1800, 9999)]
        public virtual int SchoolYearFrom { get; set; }

        [Required]
        [Display(Name = "To School Year")]
        [Range(1800, 9999)]
        public virtual int SchoolYearTo { get; set; }

        public virtual Semester Semester { get; set; }
        [Required]
        public virtual int SemesterId { get; set; }

        

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Registration")]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:MMMM dd,yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime DateOfRegistration { get; set; }

        public virtual ICollection<SubjectGradesRecord> SubjectGradesRecords { get; set; }

        //for navigation
        public virtual Student Student { get; set; }
        //public virtual int StudentId { get; set; } //for easy access to Student's Id

        [ScaffoldColumn((false))]
        public virtual bool IsDeleted { get; set; }

        [Display(Name = "School Year", Order = 500)]
        public string SchoolYear
        {
            get
            {
                return SchoolYearFrom + "-" + SchoolYearTo;
            }
        }

    }
}