using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIRSS.Models
{
    public class Teacher
    {


        public int ID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("FirstName")]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
       ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Full Name")]

        public virtual string GradeLevel { get; set; }
        public virtual int GradeLevelId { get; set; }
        public string FullName
        {
            get { return FirstName + ", " + LastName; }
        }
       
        public virtual Student Student { get; set; }
       
        public virtual ICollection<SubjectGradesRecord> SubjectGradesRecords { get; set; }
       
        public virtual ICollection<School> Schools { get; set; }
    }
}