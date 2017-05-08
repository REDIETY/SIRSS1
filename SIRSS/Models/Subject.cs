using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace SIRSS.Models
{
    public class Subject
    {
        [HiddenInput]
        public virtual int Id { get; set; }

        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public virtual string Name { get; set; }

        [Range(0, 10)]
        [Display(Name = "Units")]
        public virtual int NumberOfUnits { get; set; }


        public virtual Level Level { get; set; }
        [Required]
        public virtual int LevelId { get; set; }
    }
}