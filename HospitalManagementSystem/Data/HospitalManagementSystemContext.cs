using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Models;
using MedicalAppointment.Models;

namespace HospitalManagementSystem.Data
{
    public class HospitalManagementSystemContext : DbContext
    {
        public HospitalManagementSystemContext (DbContextOptions<HospitalManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<HospitalManagementSystem.Models.AdminLoginAndSignup> AdminLoginAndSignup { get; set; }

        public DbSet<HospitalManagementSystem.Models.Appointment> Appointment { get; set; }

        public DbSet<HospitalManagementSystem.Models.BloodList> BloodList { get; set; }

        public DbSet<HospitalManagementSystem.Models.DoctorList> DoctorList { get; set; }

        public DbSet<HospitalManagementSystem.Models.DoctorRegistration> DoctorRegistration { get; set; }

        public DbSet<HospitalManagementSystem.Models.PatientRegistration> PatientRegistration { get; set; }

        public DbSet<MedicalAppointment.Models.Vaccination> Vaccination { get; set; }

        public DbSet<HospitalManagementSystem.Models.VaccineList> VaccineList { get; set; }
    }
}
