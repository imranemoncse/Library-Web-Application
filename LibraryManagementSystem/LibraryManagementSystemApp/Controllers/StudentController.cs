using LibraryManagementSystem.BLL.Manager;
using LibraryManagementSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Model.Model.ViewModel;

namespace LibraryManagementSystemApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager = new StudentManager();
        UserManager _userManager = new UserManager();
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
        public ActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
              string error =   _studentManager.IsExists(student);

                if (error != "")
                {
                    ViewBag.FMsg = "Save failed!! " + error + " Already exists" ;
                    return View(student);
                }
                HttpPostedFileBase image = Request.Files["ImageData"];

                bool IsExecute = _studentManager.Add(student, image);

                if (IsExecute)
                {
                    User user = new User();
                    user.UserName = student.Email;
                    user.Password = student.Password;

                    bool execute = _userManager.AddUser(user);

                    return RedirectToAction("Show");

                }
                else
                {
                    return View(student);
                }

            }

            return View(student);
        }

        public ActionResult Show()
        {
            if (Session["admin"] != null)
            {
                return View(_studentManager.GetAll());
            }

            return RedirectToAction("Login", "Home");
        }


        public ActionResult History()
        {

            if (Session["Student"] != null)
            {
                dynamic student = Session["Student"];
                List<OrderVM> Historys = _studentManager.History(student.ID);
                ViewBag.History = Historys;
                return View(Historys);
            }

            return RedirectToAction("Login", "Home");
        }



       
        public ActionResult OrderBook(int id)
        {

            if (Session["Student"] != null)
            {
                dynamic student = Session["Student"];

                bool isSameBook = _studentManager.IsSameBookBorrow(student.ID,id);

                
                Book book = _studentManager.GetByBookID(id);
                OrderVM order = new OrderVM();
                order.bcode = book.Code;
                order.bName = book.Name;
                order.bAuthonerName = book.AuthorName;
                order.oDayFor = 7;
                order.sID = student.ID;
                order.bID = id;
                if (!isSameBook)
                {
                    ViewBag.FMsg = "You have already borrow "+ order.bName + "(" + order.bcode + ")book before";
                    return View(order);
                }
                return View(order);
            }

            return RedirectToAction("Login", "Home");
        }

        /*  public ActionResult OrderBook(int id)
        {

            if (Session["Student"] != null)
            {
                dynamic student = Session["Student"];

                bool isSameBook = _studentManager.IsSameBookBorrow(student.ID,id);

                if (!isSameBook)
                {
                    ViewBag.FMsg = "You have already borrow this book before. please return first.";
                    return RedirectToAction("Borrow","Book", ViewBag.FMsg);
                }

                Order order = new Order();
                order.StudentID = student.ID;
                order.BookID = id;
                order.Date = DateTime.Now;
                order.DayFor = 7;
                order.IsReturn = 0;
                order.ReturnDate = DateTime.Now.AddDays(7);


                bool isAdded =  _studentManager.OrderBook(order);
                if (isAdded)
                {
                    return RedirectToAction("History", "Student");
                }
                else
                {
                    return View();
                }
            }

            return RedirectToAction("Login", "Home");
        }
 */
        public ActionResult BorrowNow(int StudentID,int BookID)
        {

            if (Session["Student"] != null)
            {
                dynamic student = Session["Student"];

                bool isSameBook = _studentManager.IsSameBookBorrow(StudentID, BookID);


                Order order = new Order();
                order.StudentID = StudentID;
                order.BookID = BookID;
                order.Date = DateTime.Now;
                order.DayFor = 7;
                order.IsReturn = 0;
                order.ReturnDate = DateTime.Now.AddDays(7);


                bool isAdded = _studentManager.OrderBook(order);
                if (isAdded)
                {
                    return RedirectToAction("Current", "Student");
                }
                else {
                    return RedirectToAction("Borrow", "Book");
                }
            }

            return RedirectToAction("Login", "Home");
        }
        
        public ActionResult Current()
        {

            if (Session["Student"] != null)
            {
                dynamic student = Session["Student"];
                List<OrderVM> Historys = _studentManager.Current(student.ID);
                ViewBag.History = Historys;
                return View(Historys);
            }

            return RedirectToAction("Login", "Home");
        }
        
    }
}