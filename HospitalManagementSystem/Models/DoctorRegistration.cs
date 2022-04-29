using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class DoctorRegistration
    {
        [Key]
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string HighestDegree { get; set; }

        public string Age { get; set; }

        public string Speciality { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
