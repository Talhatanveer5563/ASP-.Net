using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Institute_Of_Fine_Arts.Models;
using System.Data.Entity.Validation;
using System.IO;
using System.Data.Entity;
using System.Net;

namespace Institute_Of_Fine_Arts.Controllers
{
    public class HomeController : Controller
    {
        Register_Context reg = new Register_Context();
        //home
        public ActionResult homesection()
        {
            return View();
        }

        //gallery
        public ActionResult gallery()
        {
            return View();
        }

        //about
        public ActionResult about()
        {
            return View();
        }

        //contact
        public ActionResult contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult contact(Contactus objcon)
        {
            reg.contactus.Add(objcon);
            if (reg.SaveChanges() > 0)
            {
                reg.SaveChanges();
                ModelState.Clear();
                ViewBag.msg = "Your message has been sent.";
            }
       
            else
            {
                ViewBag.msg = "Something is wrong!";
            }
    
            return View();
        }

      
       
   
        //singup
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Registration objreg)
        {

            reg.registrations.Add(objreg);
          
                reg.SaveChanges();
            
       
           

            return RedirectToAction("login");
        }

        //login
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Registration model)
        {
            Registration r = reg.registrations.Where(a => a.s_email.Equals(model.s_email)
            && a.s_Password.Equals(model.s_Password)).SingleOrDefault();
            if (r != null)
            {
                Session["uname"] = r.s_name.ToString();
                return RedirectToAction("UserDasboard");
            }
            else
            {
                return RedirectToAction("login");
            }
           
        }

        //dashboard
        public ActionResult UserDasboard()
        {
            return View();
        }

        //logout
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        //list
        IFAEntities db = new IFAEntities();
        public ActionResult List(int? id,string searchby, string search)
        {
           


            if (searchby == "First Name")
            {
                return View(db.Staff_pro.Where(x => x.s_firstname == search || search == null).ToList());
            }
            else
            {
                return View(db.Staff_pro.Where(x => x.s_lastname == search || search == null).ToList());
            }
        }

      

        //create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase abc, Staff_pro emp)
        {
            string filename = Path.GetFileName(abc.FileName);
            string _filename = DateTime.Now.ToString("yymmdd ") + filename;
            string extension = Path.GetExtension(abc.FileName);
            string path = Path.Combine(Server.MapPath("~/Content/assets/img/Staff Profile Pics/"), _filename);
            emp.s_img = "~/Content/assets/img/Staff Profile Pics/" + _filename;
            if (abc.ContentLength <= 1000000)
            {
                db.Staff_pro.Add(emp);
                if (db.SaveChanges() > 0)
                {
                    abc.SaveAs(path);
                    ViewBag.msg = "Record Inserted...";
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.msg = "Failed to insert Record";
            }

            return View();
        }
//details
        ////Geting user data using id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbl_img = db.Staff_pro.Find(id);
            Session["imgPath"] = tbl_img.s_img;
            if (tbl_img == null)
            {
                return HttpNotFound();
            }

            return View(tbl_img);
        }

        //delete
        ////Deleting user data using id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbl_img = db.Staff_pro.Find(id);
            if (tbl_img == null)
            {
                return HttpNotFound();
            }
            string current_img = Request.MapPath(tbl_img.s_img);
            db.Entry(tbl_img).State = EntityState.Deleted;
            if (db.SaveChanges() > 0)
            {
                if (System.IO.File.Exists(current_img))
                {
                    System.IO.File.Delete(current_img);
                }
                ViewBag.msg = "Data has been Deleted...";
                return RedirectToAction("List");
            }

            return View();
        }
        //edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbl_img = db.Staff_pro.Find(id);
            Session["imgPath"] = tbl_img.s_img;
            if (tbl_img == null)
            {
                return HttpNotFound();
            }

            return View(tbl_img);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase abc, Staff_pro emp)
        {
            if (ModelState.IsValid)
            {
                if (abc != null)
                {
                    string filename = Path.GetFileName(abc.FileName);
                    string _filename = DateTime.Now.ToString("yymmdd ") + filename;
                    string extension = Path.GetExtension(abc.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img/Staff Profile Pics/"), _filename);
                    emp.s_img = "~/Content/assets/img/Staff Profile Pics/" + _filename;
                    if (abc.ContentLength <= 1000000)
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        string oldImgPath = Request.MapPath(Session["imgPath"].ToString());
                        if (db.SaveChanges() > 0)
                        {
                            abc.SaveAs(path);
                            if (System.IO.File.Exists(oldImgPath))
                            {
                                System.IO.File.Delete(oldImgPath);
                            }
                            TempData["msg"] = "Record has been Updated";
                        }

                    }
                    else
                    {
                        ViewBag.msg = "Something Wrong";
                    }
                }
                else
                {
                    emp.s_img = Session["imgPath"].ToString();
                    db.Entry(emp).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        ViewBag.msg = "Data has been Updated...";
                        return RedirectToAction("List");
                    }
                }

            }
            return View();






            }
        }

    }

    
