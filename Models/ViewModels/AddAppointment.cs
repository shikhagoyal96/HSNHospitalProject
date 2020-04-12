﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSNHospitalProject.Models.ViewModels
{
    public class AddAppointment
    {
        public virtual Appointments Appointment { get; set; }

        public virtual List<Patients> Patients { get; set; }
        public virtual List<Doctors> Doctors { get; set; }
    }
}