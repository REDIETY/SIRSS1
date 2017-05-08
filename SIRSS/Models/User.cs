using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.Web.Mvc;
namespace SIRSS.Models
{

    public class  User
    {
      
        public virtual int Id { get; set; }

        public virtual Student Student { get; set; }
     
    }
}