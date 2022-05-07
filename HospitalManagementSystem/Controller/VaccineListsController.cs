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
    [Route("Api/HMSVaccineList")]
    [ApiController]
    public class VaccineListController : ControllerBase
    {
        HospitalManagementSystemContext DB = new HospitalManagementSystemContext();
        [Route("HMSAddLimit")]
        [HttpPost]
        public object AddLimit(VaccineList st)
        {
            try
            {
                if (st.Id == 0)
                {
                    VaccineList sm = new VaccineList();
                    sm.AvailVaccineName = st.AvailVaccineName;
                    sm.Limit = st.Limit;
                    DB.VaccineList.Add(sm);
                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = DB.VaccineList.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        obj.AvailVaccineName = st.AvailVaccineName;
                        obj.Limit = st.Limit;
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
        [Route("HMSVaccineList")]
        [HttpGet]
        public object VaccineList()
        {

            var a = DB.VaccineList.ToList();
            return a;
        }

        //[Route("DoctorListById")]
        //[HttpGet]
        //public object DoctorListById(int id)
        //{
        //    var obj = DB.DoctorLists.Where(x => x.Id == id).ToList().FirstOrDefault();
        //    return obj;
        //}

        [Route("HMSDeleteVaccine/{id}")]
        [HttpDelete]
        public object DeleteVaccine(int id)
        {
            var obj = DB.VaccineList.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.VaccineList.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Deleted Successfuly"
            };
        }

    }
}
