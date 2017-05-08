using System;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SIRSS.Models
{
    public class Parent : User
    {

           public int ParentID { get; set; }
   
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
       ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
       
        
    }
}