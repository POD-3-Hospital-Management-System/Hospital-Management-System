using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controller
{
    [Route("Api/HMSlogin")]
    [ApiController]
    public class PatientLoginandSignupController : ControllerBase
    {
        
        private HospitalManagementSystemContext DB;
        public PatientLoginandSignupController(HospitalManagementSystemContext db)
        {
            DB = db;
        }

        [Route("HMSInsertPatient")]
        [HttpPost]
        public object InsertPatient(PatientRegistration Reg)
        {
            try
            {
                PatientRegistration PL = new PatientRegistration();
                if (PL.PatientId == 0)
                {
                    PL.FirstName = Reg.FirstName;
                    PL.LastName = Reg.LastName;
                    PL.Email = Reg.Email;
                    PL.Mobile = Reg.Mobile;
                    PL.Gender = Reg.Gender;
                    PL.Age = Reg.Age;
                    PL.Password = Reg.Password;
                    DB.PatientRegistration.Add(PL);
                    DB.SaveChanges();
                    var name = PL.FirstName + " " + PL.LastName;
                    return new Response
                    { Status = "Success", Message = PL.Email, Name = name };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        //Login
        [Route("HMSPatientLogin")]
        [HttpPost]
        public Response PatientLogin(PatientLogin login)
        {

            var log = DB.PatientRegistration.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();
            if(log == null)
            {
                return new Response { Status="NotFound", Message="Enter valid user id and password." };
            }

            var getName = log.FirstName + " " + log.LastName;

            return new Response { Status = "Success", Message = login.Email, Name = getName };
         
        }
    }
}
