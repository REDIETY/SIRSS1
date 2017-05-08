using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SIRSS.Models
{
    public class ExamResult
    {

        [HiddenInput]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public virtual string Name { get; set; }


        public virtual Level Level { get; set; }
        [Required]
        public virtual int LevelId { get; set; }
    }
}