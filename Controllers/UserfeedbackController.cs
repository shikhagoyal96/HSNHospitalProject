using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
//for Linq commands
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
//for sql commands
using System.Data.SqlClient;
//to access appropraite model
using HSNHospitalProject.Models;
//to access viewModel UpdateUserfeedback
using HSNHospitalProject.Models.ViewModels;

namespace HSNHospitalProject.Controllers
{
    public class UserfeedbackController : Controller
    {
        //create database connection
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Userfeedback
        public ActionResult Details(string userfeedbackkey, int pagenum = 0)
        {
            // List<Userfeedback> userfeedbacks = db.Userfeedbacks.ToList();
            //return View(userfeedbacks);

            string query = "select * from Userfeedbacks";
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (userfeedbackkey != "")
            {
                query = query + " where userfeedbackEmail like @userfeedbackkey";
                sqlparams.Add(new SqlParameter("@userfeedbackkey", "%" + userfeedbackkey + "%"));
                //sqlparams.Add(new SqlParameter("@userfeedbackkey", userfeedbackkey));
            }

            List<Userfeedback> userfeedbacks = db.Userfeedbacks.SqlQuery(query, sqlparams.ToArray()).ToList();

            int perpage = 3;
            int faqcount = userfeedbacks.Count();
            int maxpage = (int)Math.Ceiling((decimal)faqcount / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = (int)(perpage * pagenum);
            ViewData["pagenum"] = pagenum;
            ViewData["pagesummary"] = "";
            if (maxpage > 0)
            {
                ViewData["pagesummary"] = (pagenum + 1) + "of" + (maxpage + 1);
                List<SqlParameter> newparams = new List<SqlParameter>();

                newparams.Add(new SqlParameter("@start", start));
                newparams.Add(new SqlParameter("@perpage", perpage));
                string pagedquery = " select * from Userfeedbacks order by userfeedbackID offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                userfeedbacks = db.Userfeedbacks.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            return View(userfeedbacks);
        }
        public ActionResult Show(int? id)
        {
            Debug.WriteLine(id);//displaying id of particular feedback

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userfeedback userfeedback = db.Userfeedbacks.Find(id);
            if (userfeedback == null)
            {
                return HttpNotFound();
            }
            return View(userfeedback);
        }

        public ActionResult Create()
        {
            //displaying a dropdown menu of services name via "GET" method
            List<Services> services = db.Services.ToList();

            return View(services);
        }

        [HttpPost]
        public ActionResult Create(int servicesId, string userfeedbackEmail, string userfeedbackMsg)
        {
            //creating a feedback for the selected  service via "POST" method
            Debug.WriteLine("userFeedbackEmail" + userfeedbackEmail);
            Debug.WriteLine("userFeedbackMsg" + userfeedbackMsg);

            Userfeedback userfeedback = new Userfeedback();
            userfeedback.servicesId = servicesId;
            userfeedback.userfeedbackEmail = userfeedbackEmail;
            userfeedback.userfeedbackMsg = userfeedbackMsg;
            db.Userfeedbacks.Add(userfeedback);
            db.SaveChanges();

            /*string query = "insert into Faqs(departmentId, faqQuestion, faqAnswer) values (@departmentId, @faqQuestion, @faqAnswer)";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@departmentId", departmentId);
            sqlparams[1] = new SqlParameter("@faqQuestion", faqQuestion);
            sqlparams[2] = new SqlParameter("@faqAnswer", faqAnswer);

            db.Database.ExecuteSqlCommand(query, sqlparams);*/
            
            //after creating the feedback remain on the create page
            return RedirectToAction("Create");

        }
        public ActionResult Edit(int id)
        {
            //displaying the details of the selected feedback to make changes in the feedback message via "GET" method
            Debug.WriteLine(id);

            UpdateUserfeedback update = new UpdateUserfeedback();//object created of viewmodel updateuserfeedback
            update.Userfeedbacks = db.Userfeedbacks.Find(id);//calling the database of Userfeedback model
            update.Services = db.Services.ToList();//calling the database of Services model

            return View(update);
        }
        [HttpPost]
        public ActionResult Edit(int id, string userfeedbackMsg)
        {
            //updating the field via "POST" method
            Debug.WriteLine("userFeedbackId" + id);
            Debug.WriteLine("userFeedbackMsg" + userfeedbackMsg);

            Userfeedback userfeedback = db.Userfeedbacks.Find(id);
            userfeedback.userfeedbackMsg = userfeedbackMsg;
            db.SaveChanges();

            return RedirectToAction("Details");
        }
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("userFeedbackId" + id);
            //delete the details of the selected feedback where the id matches in the database table
            Userfeedback userfeedback = db.Userfeedbacks.Find(id);
            db.Userfeedbacks.Remove(userfeedback);
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        public ActionResult postMsg(int id)
        {
            Debug.WriteLine("UserfeedbackId" + id);

            return RedirectToAction("Details");
        }
    }
}