using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Web.Http;

namespace HospitalManagementSystem.Controller
{
    [RoutePrefix("Api/HMSAdmin")]
    public class AdminLoginandSignupController : ApiController
    {
        private HospitalManagementSystemContext  DB = new HospitalManagementSystemContext();

        [Route("HMSAdminSignup")]
        [HttpPost]
        public object InsertAdmin(AdminLoginAndSignup Reg)
        {
            try
            {
                AdminLoginAndSignup PL = new AdminLoginAndSignup();
                if (PL.Id == 0)
                {

                    PL.Email = Reg.Email;
                    PL.Password = Reg.Password;
                    DB.AdminLoginAndSignup.Add(PL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Admin Signup SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        //Login
        [Route("HMSAdminLogin")]
        [HttpPost]
        public Response AdminLogin(PatientLogin login)
        {
            var log = DB.AdminLoginAndSignup.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();

            if (log != null)
            {
                return new Response { Status = "Success", Message = "Admin Login Successfully." };
            }
            return null;
        }
    }
}
