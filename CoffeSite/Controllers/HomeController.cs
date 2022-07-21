using CoffeSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeSite.Controllers
{
    public class HomeController : Controller
    {

        DataClasses1DataContext DataBase = new DataClasses1DataContext();

        // GET: Home
        public ActionResult Home()
        {
            List<Umumi> umumis = new List<Umumi>();
            ViewBag.Umumi = DataBase.Umumis.ToList();
            umumis = DataBase.Umumis.ToList();
            return View(umumis);
        }
        public ActionResult Blogs()
        {
            List<Blog> bloq = new List<Blog>();
            bloq = DataBase.Blogs.ToList();
            return View(bloq);
        }
        public ActionResult Blog( int id)
        {
            List<Blog> bloq = new List<Blog>();
            ViewBag.Blog = DataBase.Blogs.ToList();
            bloq = DataBase.Blogs.ToList();
            List<DetailView> detail = new List<DetailView>();
            ViewBag.DetailView = DataBase.DetailViews.ToList();
            detail = DataBase.DetailViews.ToList();
            List<Comment> rey = new List<Comment>();
            ViewBag.Comment = DataBase.Comments.ToList();
            rey = DataBase.Comments.ToList();
            return View(detail);
        }
        [HttpPost]
        public ActionResult Blog(Comment com)
        {
            if (com.CommentID == 0)
            {
                DataBase.Comments.InsertOnSubmit(com);
                DataBase.SubmitChanges();
            }
            else
            {
                Comment selectedComment = DataBase.Comments.SingleOrDefault(x => x.CommentID == com.CommentID);
                selectedComment.CommentName = com.CommentName;
                selectedComment.CommentEmail = com.CommentEmail;
                selectedComment.CommentMessage = com.CommentMessage;

                DataBase.Comments.InsertOnSubmit(com);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("Blog");
        }

        public ActionResult Menu()
        {
            List<Categoria> categorias = new List<Categoria>();
            ViewBag.Categoria = DataBase.Categorias.ToList();
            categorias = DataBase.Categorias.ToList();
            List<Umumi> umumis = new List<Umumi>();
            ViewBag.Umumi = DataBase.Umumis.ToList();
            umumis = DataBase.Umumis.ToList();
            List<Sweet> sweets = new List<Sweet>();
            ViewBag.Sweet = DataBase.Sweets.ToList();
            sweets = DataBase.Sweets.ToList();
            return View(umumis);
        }

        public ActionResult Staff()
        {
            List<Staff> chef = new List<Staff>();
            chef = DataBase.Staffs.ToList();
            return View(chef);
        }
        
        public ActionResult About()
        {
            List<About> haqqinda = new List<About>();
            haqqinda = DataBase.Abouts.ToList();
            return View(haqqinda);
        }
        public ActionResult Contact()
        {
            List <Contact> elaqe = new List<Contact>();
            elaqe = DataBase.Contacts.ToList();
            return View(elaqe);
        }
        [HttpPost]
        public ActionResult Contact(Contact c)
        {
            if (c.ContactID == 0)
            {
                DataBase.Contacts.InsertOnSubmit(c);
                DataBase.SubmitChanges();
            }
            else
            {
                Contact selectedContact = DataBase.Contacts.SingleOrDefault(x => x.ContactID == c.ContactID);
                selectedContact.ContactName = c.ContactName;
                selectedContact.ContactEmail = c.ContactEmail;
                selectedContact.ContactMessage = c.ContactMessage;

                DataBase.Contacts.InsertOnSubmit(c);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("Contact");
        }
        public ActionResult Reservation()
        {
            List<Reservation> reserv = new List<Reservation>();
            reserv = DataBase.Reservations.ToList();
            return View(reserv);
        }
        [HttpPost]
        public ActionResult Reservation(Reservation r)
        {
            if (r.RsrvtnID == 0)
            {
                DataBase.Reservations.InsertOnSubmit(r);
                DataBase.SubmitChanges();
            }
            else
            {
                Reservation selectedReservation = DataBase.Reservations.SingleOrDefault(x => x.RsrvtnID == r.RsrvtnID);
                selectedReservation.RsrvtnName = r.RsrvtnName;
                selectedReservation.RsrvtnPhone = r.RsrvtnPhone;
                selectedReservation.RsrvtnDate = r.RsrvtnDate;
                selectedReservation.RsrvtnTime = r.RsrvtnTime;
                selectedReservation.RsrvtnMessage = r.RsrvtnMessage;

                DataBase.Reservations.InsertOnSubmit(r);
                DataBase.SubmitChanges();
            }
            return RedirectToAction("Reservation");
        }
        public ActionResult Gallery()
        {
            List<Gallery> photo = new List<Gallery>();
            photo = DataBase.Galleries.ToList();
            return View(photo);
        }

      
        
        public ActionResult Info()
        {
            List<Info> info = new List<Info>();
            info = DataBase.Infos.ToList();
            return View(info);
        }
    }
}