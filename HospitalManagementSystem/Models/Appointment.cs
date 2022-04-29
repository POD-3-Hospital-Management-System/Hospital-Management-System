using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string Confrimdate { get; set; }

        public string Doctortype { get; set; }

        public string Problemdescription { get; set; }

        public string Counseledbefore { get; set; }

        public string UserMail { get; set; }

    }
}