using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;



namespace SIRSS.Models
{
    public class SubjectGradesRecord
    {
        [HiddenInput]
        public virtual int Id { get; set; }


        public virtual Subject Subject { get; set; }
        [Required]
        public virtual int SubjectId { get; set; }

        public virtual decimal ClassExam { get; set; }
        public virtual decimal MidExam { get; set; }
        public virtual decimal FinalExam { get; set; }

        public virtual decimal TotalResult
        {

            get
            {
                decimal Total = (ClassExam + MidExam + FinalExam);
                return Total;
            }


        }
        //for navigation only
        public virtual School School { get; set; }
        //public virtual int RegistrationId { get; set; } //for easy access to Registration's Id

        [ScaffoldColumn(false)]
        public virtual bool IsDeleted { get; set; }



    }
}