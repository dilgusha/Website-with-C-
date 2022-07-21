using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoffeSite.Models;
using System.Web.Mvc;
using System.IO;

namespace CoffeSite.Controllers
{
    public class AdminController : Controller
    {

        DataClasses1DataContext DataBase = new DataClasses1DataContext();

        // GET: Admin
        public ActionResult About()
        {
            try
            {
                if(Request.Cookies["Users"].Values["Login"] == "1")
                {
                    List<About> haqqinda = new List<About>();
                    haqqinda = DataBase.Abouts.ToList();
                    return View(haqqinda);

                }
                
                else
                {
                    return RedirectToAction("../User/Pass");
                }
            }

            catch(Exception)
            {
                return RedirectToAction("../User/Pass");

            }
        }
        [HttpPost]
        public ActionResult About(About a,HttpPostedFileBase AboutPhoto)
        {
            if (a.AboutID == 0)
            {
                DataBase.Abouts.InsertOnSubmit(a);
                DataBase.SubmitChanges();
            }
            else
            {
                About selectedAbout = DataBase.Abouts.SingleOrDefault(x => x.AboutID == a.AboutID);
                selectedAbout.AboutTitle = a.AboutTitle;
                selectedAbout.AboutContent = a.AboutContent;

                string PhotoName = "AboutPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
               DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(AboutPhoto.FileName);
                AboutPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
                a.AboutPhoto = PhotoName;
                DataBase.Abouts.InsertOnSubmit(a);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutList()
        {
            List<About> haqqinda = new List<About>();
            ViewBag.About = DataBase.Abouts.ToList();
            haqqinda = DataBase.Abouts.ToList();
            return View(haqqinda);
        }
        public ActionResult AboutDelete(int id)
        {
            DataBase.Abouts.DeleteOnSubmit(DataBase.Abouts.SingleOrDefault(x => x.AboutID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutEdit(int id)
        {
            List<About> haqqinda = new List<About>();
            ViewBag.About = DataBase.Abouts.ToList();
            haqqinda = DataBase.Abouts.ToList();
            About a = DataBase.Abouts.Where(x => x.AboutID == id).SingleOrDefault();
            return View(haqqinda);
        }
        [HttpPost]
        public ActionResult AboutEdit(int id, About a, HttpPostedFileBase AboutPhoto)
        {
            string PhotoName = "AboutPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
                 DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(AboutPhoto.FileName);
            AboutPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
            About update = DataBase.Abouts.SingleOrDefault(x => x.AboutID == id);
            update.AboutTitle = a.AboutTitle;
            update.AboutContent = a.AboutContent;
            update.AboutPhoto = PhotoName;
            DataBase.SubmitChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult BlogsAdmin()
        {
            List<Blog> bloq = new List<Blog>();
            bloq = DataBase.Blogs.ToList();
            return View(bloq);
        }

        [HttpPost]
        public ActionResult BlogsAdmin(Blog b, HttpPostedFileBase BlogsPhoto)
        {
            if (b.BlogsID == 0)
            {
                DataBase.Blogs.InsertOnSubmit(b);
                DataBase.SubmitChanges();
            }
            else
            {
                Blog selectedBlog = DataBase.Blogs.SingleOrDefault(x => x.BlogsID == b.BlogsID);
                selectedBlog.BlogsTitle = b.BlogsTitle;
                selectedBlog.BlogsMain = b.BlogsMain;
                selectedBlog.BlogsDate = b.BlogsDate;
                selectedBlog.BlogsContent = b.BlogsContent;

                string PhotoName = "BlogsPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
                DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(BlogsPhoto.FileName);
                BlogsPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
                b.BlogsPhoto = PhotoName;
                DataBase.Blogs.InsertOnSubmit(b);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("BlogsList");
        }
        public ActionResult BlogsList()
        {
            List<Blog> bloq = new List<Blog>();
            bloq = DataBase.Blogs.ToList();
            return View(bloq);
        }
        public ActionResult BlogDelete(int id)
        {
            DataBase.Blogs.DeleteOnSubmit(DataBase.Blogs.SingleOrDefault(x => x.BlogsID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("BlogsList");
        }


        public ActionResult BlogEdit(int id)
        {
            List<Blog> bloq = new List<Blog>();
            ViewBag.Blog = DataBase.Blogs.ToList();
            bloq = DataBase.Blogs.ToList();
            Blog b = DataBase.Blogs.Where(x => x.BlogsID == id).SingleOrDefault();
            return View(bloq);
        }
        [HttpPost]
        public ActionResult BlogEdit(int id, Blog b, HttpPostedFileBase BlogsPhoto)
        {
            string PhotoName = "BlogsPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
               DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(BlogsPhoto.FileName);
            BlogsPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
            Blog update = DataBase.Blogs.SingleOrDefault(x => x.BlogsID == id);
            update.BlogsTitle = b.BlogsTitle;
            update.BlogsMain = b.BlogsMain;
            update.BlogsDate = b.BlogsDate;
            update.BlogsContent = b.BlogsContent;
            update.BlogsPhoto = PhotoName;
            DataBase.SubmitChanges();
            return RedirectToAction("BlogsList");
        }
        public ActionResult StaffAdmin()
        {
            List<Staff> chef = new List<Staff>();
            chef = DataBase.Staffs.ToList();
            return View(chef);
        }
        [HttpPost]
        public ActionResult StaffAdmin(Staff s, HttpPostedFileBase StaffPhoto)
        {
            if (s.StaffID == 0)
            {
                DataBase.Staffs.InsertOnSubmit(s);
                DataBase.SubmitChanges();
            }
            else
            {
                Staff selectedStaff = DataBase.Staffs.SingleOrDefault(x => x.StaffID == s.StaffID);
                selectedStaff.StaffName = s.StaffName;
                selectedStaff.StaffJob = s.StaffJob;
                selectedStaff.StaffFacebook = s.StaffFacebook;
                selectedStaff.StaffInstagram = s.StaffInstagram;
                selectedStaff.StaffLinkedin = s.StaffLinkedin;


                string PhotoName = "StaffPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
               DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(StaffPhoto.FileName);
                StaffPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
                s.StaffPhoto = PhotoName;
                DataBase.Staffs.InsertOnSubmit(s);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("StaffList");
        }
        public ActionResult StaffList()
        {
            List<Staff> chef = new List<Staff>();
            chef = DataBase.Staffs.ToList();
            return View(chef);
        }
        public ActionResult StaffDelete(int id)
        {
            DataBase.Staffs.DeleteOnSubmit(DataBase.Staffs.SingleOrDefault(x => x.StaffID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("StaffList");
        }
          
        public ActionResult GalleryAdmin()
        {
            List<Gallery> photo = new List<Gallery>();
            photo = DataBase.Galleries.ToList();
            return View(photo);
        }
        [HttpPost]
        public ActionResult GalleryAdmin(Gallery g, HttpPostedFile GalleryPhoto)
        {
            if (g.GalleryID == 0)
            {
                DataBase.Galleries.InsertOnSubmit(g);
                DataBase.SubmitChanges();
            }
            else
            {
                Gallery selectedGallery = DataBase.Galleries.SingleOrDefault(x => x.GalleryID == g.GalleryID);
                string PhotoName = "GalleryPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
                DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(GalleryPhoto.FileName);
                GalleryPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
                g.GalleryPhoto = PhotoName;
                DataBase.Galleries.InsertOnSubmit(g);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("GalleryList");
        }

        public ActionResult GalleryDelete(int id)
        {
            DataBase.Galleries.DeleteOnSubmit(DataBase.Galleries.SingleOrDefault(x => x.GalleryID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("GalleryList");
        }
        public ActionResult GalleryList()
        {
            List<Gallery> photo = new List<Gallery>();
            photo = DataBase.Galleries.ToList();
            return View(photo);
        }
        public ActionResult ContactList()
        {
            List<Contact> elaqe = new List<Contact>();
            elaqe = DataBase.Contacts.ToList();
            return View(elaqe);
        }
        public ActionResult ContactDelete(int id)
        {
            DataBase.Contacts.DeleteOnSubmit(DataBase.Contacts.SingleOrDefault(x => x.ContactID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult ReservationList()
        {
            List<Reservation> reserv = new List<Reservation>();
            reserv = DataBase.Reservations.ToList();
            return View(reserv);
        }
        public ActionResult RezervDelete(int id)
        {
            DataBase.Reservations.DeleteOnSubmit(DataBase.Reservations.SingleOrDefault(x => x.RsrvtnID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ConnectionInfo()
        {
            return View();
        }
        public ActionResult CommentList()
        {
            List <Comment> rey = new List<Comment>();
            rey = DataBase.Comments.ToList();
            return View(rey);
        }
        public ActionResult Info()
        {
            List<Info> info = new List<Info>();
            info = DataBase.Infos.ToList();
            return View(info);
        }

        [HttpPost]
        public ActionResult Info(Info i)
        {
            if (i.InfoID == 0)
            {
                DataBase.Infos.InsertOnSubmit(i);
                DataBase.SubmitChanges();
            }
            else
            {
                Info selectedInfo = DataBase.Infos.SingleOrDefault(x => x.InfoID == i.InfoID);
                selectedInfo.InfoPlace = i.InfoPlace;
                selectedInfo.InfoPhone = i.InfoPhone;
                selectedInfo.InfoEmail = i.InfoEmail;
                selectedInfo.InfoFacebook = i.InfoFacebook;
                selectedInfo.InfoInstagram = i.InfoInstagram;
                selectedInfo.InfoWhatsapp = i.InfoWhatsapp;
                selectedInfo.InfoOpenHours1 = i.InfoOpenHours1;
                selectedInfo.InfoOpenHours2 = i.InfoOpenHours2;

                DataBase.Infos.InsertOnSubmit(i);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("InfoList");
        }
        public ActionResult InfoList()
        {
            List<Info> info = new List<Info>();
            info = DataBase.Infos.ToList();
            return View(info);
        }
        public ActionResult InfoDelete(int id)
        {
            DataBase.Infos.DeleteOnSubmit(DataBase.Infos.SingleOrDefault(x => x.InfoID == id));
            DataBase.SubmitChanges();
            return RedirectToAction("InfoList");
        }

        public ActionResult AdminMenu()
        {
            List<Sweet> sweets = new List<Sweet>();
            sweets = DataBase.Sweets.ToList();
            List<Categoria> categorias = new List<Categoria>();
            ViewBag.Categoria = DataBase.Categorias.ToList();
            categorias = DataBase.Categorias.ToList();
            return View(sweets);
        }

        [HttpPost]
        public ActionResult AdminMenu(Sweet sweet, HttpPostedFileBase SweetsPhoto)
        {
            string PhotoName = "SweetsPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
               DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(SweetsPhoto.FileName);
            SweetsPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
            sweet.SweetsPhoto = PhotoName;
            DataBase.Sweets.InsertOnSubmit(sweet);
            DataBase.SubmitChanges();
            return RedirectToAction("AdminMenuList");
        }

        public ActionResult Categori()
        {
            List<Categoria> categorias = new List<Categoria>();
            ViewBag.Categoria= DataBase.Categorias.ToList();
            categorias = DataBase.Categorias.ToList();
            return View(categorias);
        }
        [HttpPost]
        public ActionResult Categori(Categoria categoria)
        {
            DataBase.Categorias.InsertOnSubmit(categoria);
            DataBase.SubmitChanges();
            return RedirectToAction("Categori");
        }
        public ActionResult AdminMenuList()
        {
            List<Umumi> umumis = new List<Umumi>();
            ViewBag.Umumi = DataBase.Umumis.ToList();
            umumis = DataBase.Umumis.ToList();

            return View(umumis);
        }

        public ActionResult DeleteMenuList(int id)
        {
            DataBase.Sweets.DeleteOnSubmit(DataBase.Sweets.SingleOrDefault(x => x.SweetsId == id));
            DataBase.SubmitChanges();
            return RedirectToAction("AdminMenuList");
        }

        public ActionResult EditMenu1(int id)
        {
            ViewBag.Sweets = DataBase.Sweets.ToList();
            ViewBag.Categoria = DataBase.Categorias.ToList();
            Sweet sweet = DataBase.Sweets.Where(x => x.SweetsId == id).SingleOrDefault();
            return View(sweet);
        }
        [HttpPost]
        public ActionResult EditMenu1(int id, Sweet sweet, HttpPostedFileBase SweetsPhoto)
        {
            string PhotoName = "SweetsPhoto" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour +
                DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(SweetsPhoto.FileName);
            SweetsPhoto.SaveAs(Server.MapPath("~/Content/CoffeePhoto/" + PhotoName));
            Sweet update = DataBase.Sweets.SingleOrDefault(x => x.SweetsId == id);
            update.SweetsName = sweet.SweetsName;
            update.SweetsContent = sweet.SweetsContent;
            update.SweetsPrice = sweet.SweetsPrice;
            update.SweetsPhoto = PhotoName;
            update.SweetsCategoriaId = sweet.SweetsCategoriaId;
            DataBase.SubmitChanges();
            return RedirectToAction("AdminMenuList");
        }
    }
}