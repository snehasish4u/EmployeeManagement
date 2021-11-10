using EmployeeManagement.BusinessObjects;
using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult dashboard()
        {
            return View();
        }
        public ActionResult esigroup()
        {
            return View();
        }
        public ActionResult ptgroup()
        {
            return View();
        }
        public ActionResult pfgroup()
        {
            return View();
        }
        public ActionResult bankdetails()
        {
            return View();
        }
        public ActionResult pfsetting()
        {
            return View();
        }
        public ActionResult retirementesetting()
        {
            return View();
        }
        public ActionResult salarystructure()
        {
            return View();
        }
        public ActionResult grademaster()
        {
            return View();
        }
        public ActionResult holidaymaster()
        {
            return View();
        }
        public ActionResult leavemaster()
        {
            return View();
        }
        public ActionResult sitemaster()
        {
            return View();
        }
        public ActionResult workordermaster()
        {
            return View();
        }
        public ActionResult pfrateeditor()
        {
            return View();
        }
        public ActionResult payheadmaster()
        {
            return View();
        }
        public ActionResult qualification()
        {
            return View();
        }
        public ActionResult lumpsumdefiner()
        {
            return View();
        }
        public ActionResult department()
        {
            return View();
        }
        public ActionResult designation()
        {
            List<Designation> listresults = new List<Designation>()
            { new Designation()
            {
                DesignationName ="Software Engg",
                Shortname="SE",
                Id=1

            },
            new Designation()
            {
                DesignationName ="Senior Software Engg",
                Shortname="SSE",
                Id=2

            },
            new Designation()
            {
                DesignationName ="Team Lead",
                Shortname="TL",
                Id=3

            }
            };
            DataSet ds = new DataSet();
            //var obj = new DesignationDataAccess();
            //ds = obj.Getdesignation();
            return View(listresults);
            
                //var obj = new DesignationDataAccess();
                //var list = obj.Getdesignation();
                //return View(list);
            
        }
        public ActionResult occupation()
        {
            return View();
        }
        public ActionResult division()
        {
            return View();
        }
        public ActionResult attendence()
        {
            return View();
        }
        public ActionResult Payheadmapping()
        {
            return View();
        }
        public ActionResult view_employeee()
        {
            return View();
        }
        public ActionResult attendenceprocess()
        {
            return View();
        }
        public ActionResult leave()
        {
            return View();
        }
        public ActionResult createdesignation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adddesignation(Designation designation)
        {
            DesignationDataAccess dataAccess = new DesignationDataAccess();
            dataAccess.Insertdesignation(designation);
            return View();
        }
        public ActionResult deletedesignation(string ids)
        {
            DesignationDataAccess dataAccess = new DesignationDataAccess();
            int id = 0;
            dataAccess.Deletedesignation(ids);
             
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("designation");
        }
        public ActionResult editdesignation(int id)
        {
            List<Designation> listresults = new List<Designation>()
            { new Designation()
            {
                DesignationName ="Software Engg",
                Shortname="SE",
                Id=1

            },
            new Designation()
            {
                DesignationName ="Senior Software Engg",
                Shortname="SSE",
                Id=2

            },
            new Designation()
            {
                DesignationName ="Team Lead",
                Shortname="TL",
                Id=3

            }
            };
            DesignationDataAccess dataAccess = new DesignationDataAccess();

            //dataAccess.editdesignation(id);
            Designation result = listresults.Where(x => x.Id == id).FirstOrDefault();
            return View(result);
        }
        public ActionResult updatedesignation(Designation designation,int id)
        {
            DesignationDataAccess dataAccess = new DesignationDataAccess();
            dataAccess.Updatedesignation(designation, id);
            return View();
        }

    }
}