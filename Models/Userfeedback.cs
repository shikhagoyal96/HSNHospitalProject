using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSNHospitalProject.Models
{
    public class Userfeedback
    {
        [Key]

        public int userfeedbackId { get; set; }
        //calling the primary key of Services table as the foreign key in Userfeedback table
        public int servicesId { get; set; }
        [ForeignKey("servicesId")]
        public virtual Services Services { get; set; }

       public string userfeedbackEmail { get; set; }
       public string userfeedbackMsg { get; set; }

    }
}