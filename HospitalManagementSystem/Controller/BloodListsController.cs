using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;



namespace HospitalManagementSystem.Controller
{
    [Route("Api/HMSBlood")]
    [ApiController]
    public class BloodListController : ControllerBase
    {
        HospitalManagementSystemContext DB;
        
        public BloodListController(HospitalManagementSystemContext db)
        {
            DB = db;
        }
  
        [Route("HMSAddBlood")]
        [HttpPost]
        public object AddBlood(BloodList vt)
        {
            try
            {
                if (vt.Id == 0)
                {
                    BloodList vm = new BloodList();
                    //vm.BloodGroup = vt.BloodGroup;
                    vm.BloodGroup = vt.BloodGroup;
                    vm.BloodAvilability = vt.BloodAvilability;
                    DB.BloodList.Add(vm);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Blood SuccessFully Saved." };
                }
                else
                {
                    var obj = DB.BloodList.Where(x => x.Id == vt.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        /*obj.BloodGroup = vt.BloodGroup;
                        obj.BloodGroup = vt.BloodGroup;
                        obj.BloodAvilability = vt.BloodAvilability;
                        DB.SaveChanges();
                        return new Response
                        { Status = "Success", Message = "Not Saved." };*/

                        return Editblood(vt.Id, vt);
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
                Message = "Data not Inserted"
            };

        }
        [Route("HMSBloodDetails")]
        [HttpGet]
        public object BloodDetails()
        {

            var a = DB.BloodList.ToList();
            return a;
        }
        [Route("HMSBloodListById/{id}")]
        [HttpGet]
        public object BloodListById(int id)
        {
            var obj = DB.BloodList.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("HMSDeleteBlood/{id}")]
        [HttpDelete]
        public object DeleteBlood(int id)
        {
            var obj = DB.BloodList.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.BloodList.Remove(obj);
            DB.SaveChanges();
            return new Response
            { Status = "Success", Message = "SuccessFully Deleted." };
        }

        [Route("HMSEditblood/{id}")]
        [HttpPut]
        public object Editblood(int id, BloodList bloodList)
        {

            if (id != bloodList.Id)
            {
                return new Response
                {
                    Status = "BadRequest",
                    Message = "Bad Request"
                };
            }

            if (!DB.BloodList.Any(x => x.Id == bloodList.Id))
            {
                return new Response
                {
                    Message = "Not Found"
                };
            }

            DB.Entry(bloodList).State = EntityState.Modified;
            DB.SaveChanges();
            return new Response
            {
                Status = "Update",
                Message = "Update Successfuly"
            };
        }
    }
}
