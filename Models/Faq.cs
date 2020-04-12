using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HSNHospitalProject.Models
{
    public class Faq
    {
        [Key]
        public int faqId { get; set; }
        //calling the departmentID(primary key) of Department table as a foreign key on Faq Table
        public int departmentId { get; set; }
        [ForeignKey("departmentId")]
        public virtual Department Departments { get; set; }

        public string faqQuestion { get; set; }
        public string faqAnswer { get; set; }
    }
}