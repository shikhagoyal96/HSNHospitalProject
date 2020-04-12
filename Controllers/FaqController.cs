using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
//to run LINQ commands
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
//to run SQL commands
using System.Data.SqlClient;
//to connect to the model
using HSNHospitalProject.Models;
//to connect to the Viewmodel
using HSNHospitalProject.Models.ViewModels;

namespace HSNHospitalProject.Controllers
{
    public class FaqController : Controller
    {
        //establishing a connection to the database
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Faq
        public ActionResult Details(string faqsearchkey, int pagenum = 0)
        {
            Debug.WriteLine("Searchkey of faq = " + faqsearchkey);
            Debug.WriteLine("pagenum = " + pagenum);

            //List<Faq> faqs = db.Faqs.SqlQuery("select * from Faqs").ToList();
            //return View(faqs);

            /*Displaying a list of faqs with the search and pagination techniques*/

            string query = "select * from Faqs";

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (faqsearchkey != "")
            {
                query = query + " where faqQuestion like @faqsearchkey";
                sqlparams.Add(new SqlParameter("@faqsearchkey", "%" + faqsearchkey + "%"));
            }
            Debug.WriteLine("Details page query = " + query);

            List<Faq> faqs = db.Faqs.SqlQuery(query, sqlparams.ToArray()).ToList();

            int perpage = 3;//setting 3 data perpage
            int faqcount = faqs.Count();//counting the number of data in the faq table
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
                string pagedquery = " select * from Faqs order by faqID offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                faqs = db.Faqs.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            return View(faqs);
        }
        public ActionResult DetailsUser(string faqsearchkey, int pagenum = 0)
        {
            Debug.WriteLine("Searchkey of faq = " + faqsearchkey);
            Debug.WriteLine("pagenum = " + pagenum);

            //List<Faq> faqs = db.Faqs.SqlQuery("select * from Faqs").ToList();
            //return View(faqs);

            /*Displaying a list of faqs with the search and pagination techniques*/

            string query = "select * from Faqs";

            List<SqlParameter> sqlparams = new List<SqlParameter>();

            if (faqsearchkey != "")
            {
                query = query + " where faqQuestion like @faqsearchkey";
                sqlparams.Add(new SqlParameter("@faqsearchkey", "%" + faqsearchkey + "%"));
            }
            Debug.WriteLine("Details page query = " + query);

            List<Faq> faqs = db.Faqs.SqlQuery(query, sqlparams.ToArray()).ToList();

            int perpage = 3;//setting 3 data perpage
            int faqcount = faqs.Count();//counting the number of data in the faq table
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
                string pagedquery = " select * from Faqs order by faqID offset @start rows fetch first @perpage rows only ";
                Debug.WriteLine(pagedquery);
                Debug.WriteLine("offset " + start);
                Debug.WriteLine("fetch first " + perpage);
                faqs = db.Faqs.SqlQuery(pagedquery, newparams.ToArray()).ToList();
            }
            return View(faqs);
        }
        public ActionResult Show(int? id)
        {
            Debug.WriteLine(id);//displaying the id of the seleted faq

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faq faqs = db.Faqs.SqlQuery("Select * from Faqs where faqId = @faqId", new SqlParameter("@faqId", id)).FirstOrDefault();
            Debug.WriteLine(faqs);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            return View(faqs);
        }

        public ActionResult Create()
        {
            //displaying the department details via "GET" method
            List<Department> departments = db.Departments.SqlQuery("select * from Departments").ToList();

            return View(departments);
        }

        [HttpPost]
        public ActionResult Create(int departmentId, string faqQuestion, string faqAnswer)
        {
            //add a new faq for the selected department via "POST" method
            string query = "insert into Faqs(departmentId, faqQuestion, faqAnswer) values (@departmentId, @faqQuestion, @faqAnswer)";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@departmentId", departmentId);
            sqlparams[1] = new SqlParameter("@faqQuestion", faqQuestion);
            sqlparams[2] = new SqlParameter("@faqAnswer", faqAnswer);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //after creation redirect to the Details page
            return RedirectToAction("Details");

        }
        public ActionResult Edit(int id)
        {
            Debug.WriteLine(id);//id of the selected data

            //displaying the data of the selected faq in the update page via "GET" method which can be updated
            Faq faqs = db.Faqs.SqlQuery("Select * from Faqs where faqId = @faqId", new SqlParameter("@faqId", id)).FirstOrDefault();
            return View(faqs);
        }
        [HttpPost]
        public ActionResult Edit(int faqId, string faqQuestion, string faqAnswer)//updation via "POST" method
        {
            Debug.WriteLine(faqId);//id of the selected data

            //update the data of the selected faq where the id matches in the faq table
            string query = "update Faqs set faqQuestion=@faqQuestion,  faqAnswer=@faqAnswer where faqId=@faqId";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@faqQuestion", faqQuestion);
            sqlparams[1] = new SqlParameter("@faqAnswer", faqAnswer);
            sqlparams[2] = new SqlParameter("@faqId", faqId);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //after updation redirect to the Details page
            return RedirectToAction("Details");
        }

        public ActionResult Delete(int? id)
        {
            //delete the data of the selected faq
            Debug.WriteLine(id);//id of the selected data

            string query = "delete from Faqs where faqId = @faqId";//delete the faq data where the id matches in the faq table
            SqlParameter paramater = new SqlParameter("@faqId", id);

            db.Database.ExecuteSqlCommand(query, paramater);
            
            //after updation redirect to the Details page
            return RedirectToAction("Details");
        }

    }
}