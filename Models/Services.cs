using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HSNHospitalProject.Models
{
    public class Services
    {
        [Key]
        public int servicesId { get; set; }

        public string servicesName { get; set; }



    }
}