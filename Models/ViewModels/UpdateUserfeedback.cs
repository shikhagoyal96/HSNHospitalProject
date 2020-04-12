using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSNHospitalProject.Models.ViewModels
{
    public class UpdateUserfeedback
    {
        //a viewModel to combine two models Userfeedback and Services
        public virtual Userfeedback Userfeedbacks {get; set;}

        public virtual List<Services> Services { get; set; }
    }
}