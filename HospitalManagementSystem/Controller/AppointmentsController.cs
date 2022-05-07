using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagementSystem.Controller
{
    [Route("Api/HMSAppoitment")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
       HospitalManagementSystemContext  DB = new HospitalManagementSystemContext();
        public AppointmentController(HospitalManagementSystemContext db)
        {
            DB = db;
        }

        [Route("HMSAddappoitment")]
        [HttpPost]
        public object AddotrUpdateappointment(Appointment st)
        {
            try
            {
                if (st.Id == 0)
                {
                    Appointment sm = new Appointment();
                    sm.Confrimdate = st.Confrimdate;
                    sm.Doctortype = st.Doctortype;
                    sm.Problemdescription = st.Problemdescription;
                    sm.Counseledbefore = st.Counseledbefore;
                    sm.UserMail = st.UserMail;
                    DB.Appointment.Add(sm);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Appointment Details SuccessFully Saved." };
                }
                else
                {
                    var obj = DB.Appointment.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        /*obj.Confrimdate = st.Confrimdate;
                        obj.Doctortype = st.Doctortype;
                        obj.Problemdescription = st.Problemdescription;
                        obj.Counseledbefore = st.Counseledbefore;
                        obj.UserMail = st.UserMail;
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };*/

                        return Editappointment(st.Id, st);
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
        [Route("HMSAppointmentdetails")]
        [HttpGet]
        public object Appointmentdetails()
        {

            var a = DB.Appointment.ToList();
            return a;
        }
        [Route("HMSAppointmentById/{id}")]
        [HttpGet]
        public object AppointmentById(int id)
        {
            var obj = DB.Appointment.Where(x => x.Id == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("HMSDeleteappointment/{id}")]
        [HttpDelete]
        public object Deletestudent(int id)
        {
            var obj = DB.Appointment.Where(x => x.Id == id).ToList().FirstOrDefault();
            DB.Appointment.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Deleted Successfuly"
            };
        }

        [Route("HMSEditappointment/{id}")]
        [HttpPut]
        public object Editappointment(int id , Appointment appointment)
        {

            if (id != appointment.Id)
            {
                return new Response
                {
                    Status = "BadRequest",
                    Message = "Bad Request"
                };
            }

            if (!DB.Appointment.Any(x => x.Id == appointment.Id))
            {
                return new Response
                {
                    Message = "Not Found"
                };
            }

            DB.Entry(appointment).State = EntityState.Modified;
            DB.SaveChanges();
            return new Response
            {
                Status = "Update",
                Message = "Updated Successfuly"
            };
            /*var obj = DB.Appointment.Where(x => x.Id == id).ToList().FirstOrDefault();
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
            };*/


        }
    }
}
