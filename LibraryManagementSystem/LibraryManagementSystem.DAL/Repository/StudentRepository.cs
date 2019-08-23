using LibraryManagementSystem.DatabaseContext.DatabaseContext;
using LibraryManagementSystem.Model.Model;
using LibraryManagementSystem.Model.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManagementSystem.DAL.Repository
{
    public class StudentRepository
    {

        LibraryManagementDBContext db = new LibraryManagementDBContext();
        public bool Add(Student student, HttpPostedFileBase image)
        {

            using (BinaryReader br = new BinaryReader(image.InputStream))
            {

                student.Data = br.ReadBytes(image.ContentLength);
            }
            db.Students.Add(student);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetByUsername(string username)
        {
            Student student = db.Students.Where(c => c.Email == username).SingleOrDefault();
            if (student != null)
            {
                return student;
            }

            return null;
        }

        public List<OrderVM> History(int Id)
        {


            var history = (List<OrderVM>)(from orr in db.Orders
                                         join s in db.Students on orr.StudentID equals s.ID
                                        join b in db.Books on  orr.BookID equals b.ID
                                        where s.ID == Id

                                        select new OrderVM
                                        {
                                            oID = orr.ID,
                                            sID = s.ID,
                                            bID = b.ID,
                                            bcode = b.Code,
                                            scode = s.Code,
                                            bName = b.Name,
                                            bAuthonerName = b.AuthorName,
                                            oIsReturn = orr.IsReturn,
                                            oDate = orr.Date,
                                            oDayFor = orr.DayFor,
                                            OReturnDate = orr.ReturnDate
                                        }
                 ).ToList();

            return history;



        }

        public bool OrderBook(Order order)
        {
            db.Orders.Add(order);
            Book book = db.Books.Where(c => c.ID == order.BookID).SingleOrDefault();
            book.Quantity = book.Quantity - 1;
            int isAdded = db.SaveChanges();
            if (isAdded > 0)
            {
                return true;
            }

            return false;
        }


        public List<OrderVM> Current(int Id)
        {


            var history = (List<OrderVM>)(from orr in db.Orders
                                          join s in db.Students on orr.StudentID equals s.ID
                                          join b in db.Books on orr.BookID equals b.ID
                                          where s.ID == Id && orr.IsReturn == 0

                                          select new OrderVM
                                          {
                                              oID = orr.ID,
                                              sID = s.ID,
                                              bID = b.ID,
                                              bcode = b.Code,
                                              scode = s.Code,
                                              bName = b.Name,
                                              bAuthonerName = b.AuthorName,
                                              oIsReturn = orr.IsReturn,
                                              oDate = orr.Date,
                                              oDayFor = orr.DayFor,
                                              OReturnDate = orr.ReturnDate
                                          }
                 ).ToList();

            return history;



        }


        public bool IsSameBookBorrow(int studentID, int BookID)
        {
            Order order = db.Orders.Where(c => c.StudentID == studentID && c.BookID == BookID && c.IsReturn == 0).SingleOrDefault();

            if (order == null)
            {
                return true;
            }
            return false;
        }

        public Book GetByBookID(int id)
        {
            Book order = db.Books.Where(c => c.ID == id).SingleOrDefault();
            if (order != null)
            {
                return order;
            }

            return null;
        }


        public string IsExists(Student student)
        {
            
            Student dBstudent = db.Students.Where(c => c.Code == student.Code).SingleOrDefault();
            if (dBstudent != null)
            {
                return "Student ID";
            }
             dBstudent = db.Students.Where(c => c.Email == student.Email).SingleOrDefault();
            if (dBstudent != null)
            {
                return "Email";
            }
            

            return "";
        }
    }
}
