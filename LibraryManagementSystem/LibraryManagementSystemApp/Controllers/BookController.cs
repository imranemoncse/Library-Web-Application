using LibraryManagementSystem.BLL.Manager;
using LibraryManagementSystem.Model.Model;
using LibraryManagementSystem.Model.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystemApp.Controllers
{
    public class BookController : Controller
    {
        BookManager _bookManager = new BookManager();

        // GET: Student
        public ActionResult Add()
        {
            if (Session["admin"] != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }
        [HttpPost, ActionName("Add")]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
               string error =  _bookManager.IsExists(book);
                if (error != "")
                {
                    ViewBag.FMsg = "Entry failed!! Same " + error + " Already exists";
                    return View(book);
                }

                HttpPostedFileBase image = Request.Files["ImageData"];

                bool IsExecute = _bookManager.Add(book, image);

                if (IsExecute)
                {

                    return RedirectToAction("Show");

                }
                else
                {
                    return View(book);
                }

            }

            return View(book);
        }

        public ActionResult Show()
        {
            if (Session["admin"] != null)
            {

                return View(_bookManager.GetAll());
            }

            return RedirectToAction("Login", "Home");
        }
       
        public ActionResult Borrow()
        {
            if (Session["Student"] != null)
            {
                ViewBag.FMsg = ViewBag.FMsg;
                return View(_bookManager.GetAll());
            }
            return RedirectToAction("Login", "Home");
        }
        
        [HttpPost,ActionName("Borrow")]
        public ActionResult Search(Book book)
        {
            if (Session["Student"] != null)
            {
                if (book.Name!=null)
            {
                ViewBag.Search = book.Name;
                return View(_bookManager.GetByName(book));
               
            }
   
            return View(_bookManager.GetAll());
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ReturnBook(int id)
        {
            if (Session["Student"] != null)
            {
                bool isreturn = _bookManager.ReturnBook(id);
                if (isreturn)
                {
                    return RedirectToAction("Current", "Student");
                }

                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AllBorrowHistory()
        {

            if (Session["admin"] != null)
            {
                
                List<OrderVM> Historys = _bookManager.AllHistory();
                ViewBag.History = Historys;
                return View(Historys);
            }

            return RedirectToAction("Login", "Home");
        }
        public ActionResult CurrentBorrowHistory()
        {

            if (Session["admin"] != null)
            {
                List<OrderVM> Historys = _bookManager.AllCurrentHistory();
                ViewBag.History = Historys;
                return View(Historys);
            }

            return RedirectToAction("Login", "Home");
        }
    }
}