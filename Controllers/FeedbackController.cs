using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HSNHospitalProject.Models;
using HSNHospitalProject.Models.ViewModels;
using System.Diagnostics;

namespace HSNHospitalProject.Controllers
{
    public class FeedbackController : Controller
    {
        //establishing database connection
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }
        //disaplaying details
        public ActionResult Details(string userfeedbackkey, int pagenum=0)
        {
            //List<Feedback> feedbacks = db.Feedbacks.ToList();
            //return View(feedbacks);
            string query = "select * from Feedbacks";
            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (userfeedbackkey != "")
            {
                query = query + " where feedbackEmail like @userfeedbackkey";
                sqlparams.Add(new SqlParameter("@userfeedbackkey", "%" + userfeedbackkey + "%"));
            }

            List<Feedback> feedbacks = db.Feedbacks.SqlQuery(query, sqlparams.ToArray()).ToList();

            int perpage = 3;
            int faqcount = feedbacks.Count();
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
                string pagedquery = " select * from Feedbacks order by feedbackID offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                feedbacks = db.Feedbacks.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            return View(feedbacks);
        }
        public ActionResult Show(int? id)
        {
            Debug.WriteLine(id);//id of the selected feedback

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string feedbackEmail, string feedbackMsg)
        {
            Debug.WriteLine("FeedbackEmail" + feedbackEmail);
            Debug.WriteLine("FeedbackMsg" + feedbackMsg);

            Feedback feedback = new Feedback();
            feedback.feedbackEmail = feedbackEmail;
            feedback.feedbackMsg = feedbackMsg;
            db.Feedbacks.Add(feedback);
            db.SaveChanges();

            /*string query = "insert into Feedbacks(feedbackEmail, feedbackMsg) values (@feedbackEmail, @feedbackMsg)";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@feedbackEmail", feedbackEmail);
            sqlparams[1] = new SqlParameter("@feedbackMsg", feedbackMsg);

            db.Database.ExecuteSqlCommand(query, sqlparams);*/

            return RedirectToAction("Details");
        }
        public ActionResult Edit(int id)
        {
            Debug.WriteLine(id);//id of the selected feedback

            Feedback feedback = db.Feedbacks.Find(id);
            return View(feedback);
        }
        [HttpPost]
        public ActionResult Edit(int id,string feedbackMsg)
        {
            Debug.WriteLine("FeedbackId" + id);
            Debug.WriteLine("FeedbackMsg" + feedbackMsg);

            Feedback feedback = db.Feedbacks.Find(id);//updating feedback message of the selected feedback
            feedback.feedbackMsg = feedbackMsg;
            db.SaveChanges();

            return RedirectToAction("Details");
        }
        public ActionResult Delete(int id)
        {
            Debug.WriteLine("FeedbackId" + id);//id of the selected feedback

            Feedback feedback = db.Feedbacks.Find(id);//delete data of the selected id
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        public ActionResult postMsg(int id)
        {
            Debug.WriteLine("FeedbackId" + id);

            return RedirectToAction("Details");
        }
    }
}