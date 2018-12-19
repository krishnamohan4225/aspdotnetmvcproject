using BiharITI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiharITI.DATA;
namespace AngularCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee  
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult Get_AllEmployee()
        {
            using (kernels1_itiEntities Obj = new kernels1_itiEntities())
            {
                List<User> Emp = Obj.Users.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (kernels1_itiEntities Obj = new kernels1_itiEntities())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Users.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Insert_Employee(User Employe)
        {
            if (Employe != null)
            {
                using (kernels1_itiEntities Obj = new kernels1_itiEntities())
                {
                    Obj.Users.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete_Employee(User Emp)
        {
            if (Emp != null)
            {
                using (kernels1_itiEntities Obj = new kernels1_itiEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Users.Attach(Emp);
                        Obj.Users.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update_Employee(User Emp)
        {
            if (Emp != null)
            {
                using (kernels1_itiEntities Obj = new kernels1_itiEntities())
                {
                    var Emp_ = Obj.Entry(Emp);
                    User EmpObj = Obj.Users.Where(x => x.UserID == Emp.UserID).FirstOrDefault();
                    EmpObj.Username = Emp.Username;
                    EmpObj.Password = Emp.Password;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}