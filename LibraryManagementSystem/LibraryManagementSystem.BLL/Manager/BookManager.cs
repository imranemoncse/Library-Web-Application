using LibraryManagementSystem.DAL.Repository;
using LibraryManagementSystem.Model.Model;
using LibraryManagementSystem.Model.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManagementSystem.BLL.Manager
{
    public class BookManager
    {
        BookRepository _bookRepository = new BookRepository();
        public bool Add(Book book, HttpPostedFileBase image)
        {
            
            return _bookRepository.Add(book,image);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
        public bool ReturnBook(int id)
        {
            return _bookRepository.ReturnBook(id);
        }
        public List<Book> GetByName(Book book)
        {
            return _bookRepository.GetByName(book);
        }
        public string IsExists(Book book)
        {



            return _bookRepository.IsExists(book);
        }


        public List<OrderVM> AllCurrentHistory()
        {
            return _bookRepository.AllCurrentHistory();

        }

        public List<OrderVM> AllHistory()
        {

            return _bookRepository.AllHistory(); ;
        }
    }
}
