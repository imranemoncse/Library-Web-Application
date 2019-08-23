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
    public class BookRepository
    {
        LibraryManagementDBContext db = new LibraryManagementDBContext();
        public bool Add(Book book, HttpPostedFileBase image)
        {

            using (BinaryReader br = new BinaryReader(image.InputStream))
            {

                book.Data = br.ReadBytes(image.ContentLength);
            }
            db.Books.Add(book);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                return true;
            }
            return false;
        }

        public List<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public bool ReturnBook(int id)
        {
            Order order = db.Orders.Where(c => c.ID == id).SingleOrDefault();
          
            if (order != null)
            {
                order.IsReturn = 1;
                order.ReturnDate = DateTime.Now;
                Book book = db.Books.Where(c => c.ID == order.BookID).SingleOrDefault();
                book.Quantity = book.Quantity + 1;
               int isMod =  db.SaveChanges();
                if (isMod > 0)
                {


                    return true;
                }
               
            }
            return false;
        }

        public List<Book> GetByName(Book book)
        {

            return db.Books.Where(c => c.Name.Contains(book.Name)).ToList();
        }
        public string IsExists(Book book)
        {

            Book dBBook = db.Books.Where(c => c.Code == book.Code).SingleOrDefault();
            if (dBBook != null)
            {
                return "Book ID";
            }
            dBBook = db.Books.Where(c => c.Name == book.Name && c.AuthorName == book.AuthorName).SingleOrDefault();
            if (dBBook != null)
            {
                return "Book Name and Author Name";
            }


            return "";
        }


        public List<OrderVM> AllCurrentHistory()
        {


            var history = (List<OrderVM>)(from orr in db.Orders
                                          join s in db.Students on orr.StudentID equals s.ID
                                          join b in db.Books on orr.BookID equals b.ID
                                          where orr.IsReturn ==  0
                                          orderby s.Name ascending
                                          select new OrderVM
                                          {
                                              oID = orr.ID,
                                              sID = s.ID,
                                              bID = b.ID,
                                              bcode = b.Code,
                                              scode = s.Code,
                                              bName = b.Name,
                                              sName = s.Name,
                                              bAuthonerName = b.AuthorName,
                                              oIsReturn = orr.IsReturn,
                                              oDate = orr.Date,
                                              oDayFor = orr.DayFor,
                                              OReturnDate = orr.ReturnDate
                                          }
                 ).ToList();

            return history;



        }

        public List<OrderVM> AllHistory()
        {


            var history = (List<OrderVM>)(from orr in db.Orders
                                          join s in db.Students on orr.StudentID equals s.ID
                                          join b in db.Books on orr.BookID equals b.ID
                                          orderby s.Name ascending
                                          select new OrderVM
                                          {
                                              oID = orr.ID,
                                              sID = s.ID,
                                              bID = b.ID,
                                              bcode = b.Code,
                                              scode = s.Code,
                                              bName = b.Name,
                                              sName = s.Name,
                                              bAuthonerName = b.AuthorName,
                                              oIsReturn = orr.IsReturn,
                                              oDate = orr.Date,
                                              oDayFor = orr.DayFor,
                                              OReturnDate = orr.ReturnDate
                                          }
                 ).ToList();

            return history;



        }

    }
}
