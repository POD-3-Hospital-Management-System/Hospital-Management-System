using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controller
{
    public class DoctorLoginAndSignupController : ControllerBase
    {
        [Route("Api/HMSlogin")]
        [ApiController]
        public class DoctorLoginandSignupController : ControllerBase
        {
            private HospitalManagementSystemContext  DB = new HospitalManagementSystemContext();
            [Route("HMSInsertDoctor")]
            [HttpPost]
            public object InsertDoctor(DoctorRegistration Reg)
            {
                try
                {
                    DoctorRegistration PL = new DoctorRegistration();
                    if (PL.DoctorId == 0)
                    {
                        PL.Name = Reg.Name;
                        PL.UserName = Reg.UserName;
                        PL.HighestDegree = Reg.HighestDegree;
                        PL.Age = Reg.Age;
                        PL.Speciality = Reg.Speciality;
                        PL.Email = Reg.Email;
                        PL.Password = Reg.Password;
                        DB.DoctorRegistration.Add(PL);
                        DB.SaveChanges();
                        return new Response
                        { Status = "Success", Message = "Record SuccessFully Saved." };
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }
            //Login
            [Route("HMSDoctorLogin")]
            [HttpPost]
            public Response DoctorLogin(DoctorLogin login)
            {
                var log = DB.DoctorRegistration.Where(x => x.Email.Equals(login.Email) &&
                          x.Password.Equals(login.Password)).FirstOrDefault();

                if (log != null)
                {
                    return new Response { Status = "Success", Message = "Login Successfully." };
                }
                return null;
            }
        }
    }
}
