using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HospitalManagementSystem.Models;

namespace MedicalAppointment.Models
{
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        public string ConfrimDateOfVaccination { get; set; }

        public string VaccineName { get; set; }

        public string ChooseSlot { get; set; }

        public string IdProof { get; set; }

        public string UserMail { get; set; }

    }
}
