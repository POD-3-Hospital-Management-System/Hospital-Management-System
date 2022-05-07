using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using MedicalAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controller
{
    [Route("Api/HMSVaccine")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private HospitalManagementSystemContext DB = new HospitalManagementSystemContext();
        [Route("HMSVaccinationRegistration")]
        [HttpPost]
        public object VaccinationRegistration(Vaccination st)
        {
            try
            {
                if (st.Id == 0)
                {
                    Vaccination sm = new Vaccination();

                    sm.ConfrimDateOfVaccination = st.ConfrimDateOfVaccination;
                    sm.VaccineName = st.VaccineName;
                    sm.ChooseSlot = st.ChooseSlot;
                    sm.IdProof = st.IdProof;
                    sm.UserMail = st.UserMail;
                    DB.Vaccination.Add(sm);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Vaccine request successfully done." };
                }
                else
                {
                    var obj = DB.Vaccination.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        obj.ConfrimDateOfVaccination = st.ConfrimDateOfVaccination;
                        obj.VaccineName = st.VaccineName;
                        obj.ChooseSlot = st.ChooseSlot;
                        obj.IdProof = st.IdProof;
                        obj.UserMail = st.UserMail;
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not inserted"
            };

        }
        [Route("HMSVaccinationDeatils")]
        [HttpGet]
        public object VaccinationDeatils()
        {

            var a = DB.Vaccination.ToList();
            return a;
        }
        [Route("HMSVaccinationById/{id}")]
        [HttpGet]
        public object VaccinationById(int id)
        {
            var obj = DB.Vaccination.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("HMSDeleteVaccination/{id}")]
        [HttpDelete]
        public object DeleteVaccination(int id)
        {
            var obj = DB.Vaccination.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.Vaccination.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Deleted Successfuly"
            };
        }

        [Route("HMSEditblood/{id}")]
        [HttpPut]
        public object Editappointment(int id)
        {

            var obj = DB.Vaccination.Where(x => x.Id == id).ToList().FirstOrDefault();
            if (obj == null)
            {
                return new Response
                {
                    Message = "Not Found"
                };
            }
            DB.Entry(obj).State = EntityState.Modified;
            DB.SaveChanges();
            return new Response
            {
                Status = "Update",
                Message = "Update Successfuly"
            };
        }

    }
}
