using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SIRSS.Models
{
    public class GradeLevel
    {

        [HiddenInput]
        public virtual int Id { get; set; }


        /// <sue>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public virtual string Title { get; set; }

        [Required]
        [StringLength(20)]
        public virtual string Acronym { get; set; }


        public virtual Level Level { get; set; }
        [Required]
        public virtual int LevelId { get; set; }

        public string LevelAndTitle
        {
            get
            {
                return Level + " - " + Title;
            }
        }
    }
}