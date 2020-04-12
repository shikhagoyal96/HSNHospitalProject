using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSNHospitalProject.Models
{
    public class Feedback
    {
        [Key]

        public int feedbackId { get; set; }

        public string feedbackEmail { get; set; }

        public string feedbackMsg { get; set; }
    }
}