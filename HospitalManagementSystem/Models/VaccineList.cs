using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class VaccineList
    {
        public int Id { get; set; }

        public string AvailVaccineName { get; set; }

        public int Limit { get; set; }
    }
}
