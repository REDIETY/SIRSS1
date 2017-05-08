using System;

using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

using System.ComponentModel;



using System.Text;
namespace SIRSS.Models
{


    public enum StudentStatus
    {

        [Description("NEW")]
        NEW = 1,

        [Description("OLD")]
        OLD,
        [Description("Not A Student Anymore")]
        NotAStudentAnymore
    }
    public enum Gende
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female
    }
    public class Student
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name", Order = 1000)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Middle Name", Order = 2000)]
        public virtual string MiddleName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name", Order = 2000)]
        public virtual string LastName { get; set; }
        public virtual GradeLevel GradeLevel { get; set; }
        public virtual int GradeLevelId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Emergency Contact", Order = 2000)]
        public virtual string EmergencyContact { get; set; }

        public virtual string Woreda { get; set; }
        public virtual string kebele { get; set; }

        public virtual string SubCity { get; set; }
       
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public virtual string Address
        {

            get
            {
                return Woreda + ", " + kebele + "," + SubCity;
            }


        }


        [Required]
        public virtual Gende Gender { get; set; }

        [DataType(DataType.EmailAddress)]
      


        [Display(Name = "Name", Order = 100)]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public virtual StudentStatus StudentStatus { get; set; }

        public virtual ICollection<School> schools { get; set; }

        [ScaffoldColumn(false)]
        public virtual bool IsDeleted { get; set; }

    }
}