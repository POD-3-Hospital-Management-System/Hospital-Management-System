using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controller
{
    [Route("Api/HMSDoctor")]
    [ApiController]
    public class DoctorListController : ControllerBase
    {
        HospitalManagementSystemContext DB = new HospitalManagementSystemContext();
        [Route("HMSAddDoctor")]
        [HttpPost]
        public object AddDoctor(DoctorList st)
        {
            try
            {
                if (st.Id == 0)
                {
                    DoctorList sm = new DoctorList();
                    sm.DoctorName = st.DoctorName;
                    sm.DoctorSpecilaity = st.DoctorSpecilaity;
                    sm.DoctorAvilability = st.DoctorAvilability;
                    DB.DoctorList.Add(sm);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Admin Signup SuccessFully Saved." };
                }
                else
                {
                    var obj = DB.DoctorList.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        obj.DoctorName = st.DoctorName;
                        obj.DoctorSpecilaity = st.DoctorSpecilaity;
                        obj.DoctorAvilability = st.DoctorAvilability;
                        DB.SaveChanges();
                        return new Response
                        { Status = "Success", Message = "Admin Signup SuccessFully Saved." };
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
                Message = "Data not insert"
            };

        }
        [Route("HMSDoctorDetails")]
        [HttpGet]
        public object DoctorDetails()
        {

            var a = DB.DoctorList.ToList();
            return a;
        }
        [Route("HMSDoctorListById")]
        [HttpGet]
        public object DoctorListById(int id)
        {
            var obj = DB.DoctorList.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("HMSDeleteDoctor")]
        [HttpDelete]
        public object DeleteDoctor(int id)
        {
            var obj = DB.DoctorList.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.DoctorList.Remove(obj);
            DB.SaveChanges();
            return new Response
            { Status = "Success", Message = "Admin Signup SuccessFully Saved." };
        }

    }
}
